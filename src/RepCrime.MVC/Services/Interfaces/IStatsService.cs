namespace RepCrime.MVC.Services.Interfaces
{
    public interface IStatsService
    {
        Task<StatsViewModel> GetStatsViemModelAsync();
    }
}