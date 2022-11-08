namespace RepCrime.MVC.Services
{
    public class CrimeService : ICrimeService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;
        public CrimeService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        public async Task AddNew(CreateCrimeDTO crimeDTO)
            => await _httpClient.PostAsync(_configuration["Paths:CreateNewCrimeEvent"], 
                new StringContent(JsonConvert.SerializeObject(crimeDTO), Encoding.UTF8, "application/json"));
    }
}
