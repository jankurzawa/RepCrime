namespace RepCrime.MVC.Services
{
    public class StatsService : IStatsService
    {
        private HttpClient _httpClient;
        private IConfiguration _configuration;
        public StatsService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }
        public async Task<StatsViewModel> GetStatsViemModelAsync()
        {
            try
            {
                int TotalReportedCrimes = int.Parse(await _httpClient.GetStringAsync(_configuration["Paths:GetNumberOfAllCrimes"]));
                int DailyAverageOfReportedCrimes = TotalReportedCrimes / (int)(DateTime.Now - (DateTime.Parse(_configuration["DayOfStartedThisApp"]))).TotalDays;
                return new StatsViewModel(DailyAverageOfReportedCrimes, TotalReportedCrimes);
            }
            catch (Exception)
            {
                throw new StatisticCalculatingException("Cannot calculate statistics");
            }
        }
    }
}
