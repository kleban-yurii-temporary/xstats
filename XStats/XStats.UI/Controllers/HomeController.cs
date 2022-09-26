using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XStats.Repos;
using XStats.UI.Models;

namespace XStats.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LossesRepository lossesRepository;

        public HomeController(ILogger<HomeController> logger, LossesRepository lossesRepository)
        {
            _logger = logger;
            this.lossesRepository = lossesRepository;
        }

        public async Task<IActionResult> Index(string date = null)
        {
            return View(await lossesRepository.GetDailyAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}