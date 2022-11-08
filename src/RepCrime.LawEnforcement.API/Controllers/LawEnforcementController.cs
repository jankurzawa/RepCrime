namespace RepCrime.LawEnforcement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LawEnforcementController : ControllerBase
    {
        private ILawEnforecementRepository _lawEnforecementRepository;
        private IAssignCrimeRepository _assignCrimeRepository;

        public LawEnforcementController(ILawEnforecementRepository lawEnforecementRepository, IAssignCrimeRepository assignCrimeRepository)
        {
            _lawEnforecementRepository = lawEnforecementRepository;
            _assignCrimeRepository = assignCrimeRepository;
        }

        [HttpPut]
        public async Task<IActionResult> Assign(AssignToLawEnforcementCrimeDTO crimeDTO)
        {
            try
            {
                var lawEnforcement = await _lawEnforecementRepository.GetTheLeastLoadedLawEnforecementAsync(await GetCorrectRank(crimeDTO.Type));
                await _assignCrimeRepository.AddNewCrimeRepositoryAsync(new AssignCrime(crimeDTO.Id, lawEnforcement.Id));
                return Ok(lawEnforcement.Id);
            }
            catch (Exception)
            {
                throw new CannotAssignCrimeToLawEnforcementException($"Cannot assign crime with id { crimeDTO.Id} to any lawEnforcement");
            }
        }

        private async Task<RankOfLawEnforcement> GetCorrectRank(CrimeType crimeType)
        {
            if (crimeType == CrimeType.Attack || crimeType == CrimeType.Beating || crimeType == CrimeType.Murder) return RankOfLawEnforcement.Criminal;
            if (crimeType == CrimeType.Burglary || crimeType == CrimeType.Theft) return RankOfLawEnforcement.Asset_Recovery;
            return RankOfLawEnforcement.Investigation;
        }
    }
}