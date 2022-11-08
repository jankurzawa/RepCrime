namespace RepCrime.MVC.Models
{
    public class StatsViewModel
    {
        public int DailyAverageOfReportedCrimes { get; set; }
        public int TotalReportedCrimes { get; set; }
        public StatsViewModel(int dailyAverageOfReportedCrimes, int totalReportedCrimes)
        {
            DailyAverageOfReportedCrimes = dailyAverageOfReportedCrimes;
            TotalReportedCrimes = totalReportedCrimes;
        }
    }
}
