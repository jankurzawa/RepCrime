namespace RepCrime.MVC.Controllers
{
    public class StatsController : Controller
    {
        private IStatsService _statsService;
        public StatsController(IStatsService statsService)
            => _statsService = statsService;

        public async Task<IActionResult> Stats()
            => View(await _statsService.GetStatsViemModelAsync());
    }
}
