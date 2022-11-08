namespace RepCrime.MVC.Controllers
{
    public class ReportController : Controller
    {
        public ICrimeService _crimeService { get; set; }
        public ReportController(ICrimeService crimeService)
            => _crimeService = crimeService;

        public IActionResult ReportCrime()
            => View();

        [HttpPost]
        public async Task<IActionResult> AddNew(CreateCrimeDTO crimeDTO)
        {
            if (!ModelState.IsValid)
                return View(nameof(ReportCrime), crimeDTO);
            await _crimeService.AddNew(crimeDTO);
            return RedirectToAction(nameof(ReportCrime));
        }
    }
}
