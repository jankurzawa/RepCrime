namespace RepCrime.Crime.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrimeController : ControllerBase
    {
        private IMapper _mapper;
        private IConfiguration _configuration;
        private IPublisher _publisher;
        private HttpClient _httpClient;
        private readonly CrimeRepository _crimeRepository;
        public CrimeController(IMapper mapper, IConfiguration configuration, IPublisher publisher, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _configuration = configuration;
            _publisher = publisher;
            _crimeRepository = new CrimeRepository(_configuration["Mongo:ConnectionString"], _configuration["Mongo:DataBaseName"], _configuration["Mongo:ColletionName"]);
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet("GetNumberOfAllCrimes")]
        public async Task<IActionResult> GetNumberOfAllCrimes()
            => Ok(await _crimeRepository.GetNumberOfAllEventsAsync());
        
        [HttpPost]
        public async Task<IActionResult> AddNew(CreateCrimeDTO crimeDTO)
        {
            var newCrimeEvent = _mapper.Map<CrimeEvent>(crimeDTO);
            await _crimeRepository.Create(newCrimeEvent);
            var addedCrimeEvent = await _crimeRepository.GetByIdToFindAsync(newCrimeEvent.IdToFind);
            var response = await _httpClient.PutAsync(_configuration["Paths:AssignCrimeEventToLawEnforcement"], new StringContent(
                JsonConvert.SerializeObject(_mapper.Map<AssignToLawEnforcementCrimeDTO>(addedCrimeEvent)), Encoding.UTF8, "application/json"));
            if (!response.IsSuccessStatusCode)
            {
                throw new NoLawEnforcementAssignedException("Cannot assign Law Enforcement");
            }
            else
            {
                addedCrimeEvent.IdOfAssignedLawEnforcement = JsonConvert.DeserializeObject<Guid>(await response.Content.ReadAsStringAsync());
                await _crimeRepository.UpdateAsync(addedCrimeEvent);
                _publisher.SendMessage(crimeDTO);
                return CreatedAtAction(nameof(AddNew), newCrimeEvent);
            }
        }
    }
}
