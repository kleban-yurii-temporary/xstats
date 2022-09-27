using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using XStats.Core;
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
            return View();
        }

        public async Task<string> Date()
        {
            return (await lossesRepository.GetMaxDateAsync()).Value.ToString("dd MMMM yyyy", new CultureInfo("uk-UA"));
        }

        public async Task<IEnumerable<DailyLosses>> Losses()
        {
            return await lossesRepository.GetDailyAsync();
        }

        public async Task<KeyValuePair<List<string>, List<int>>> GetEqData(int id)
        {
            return await lossesRepository.GetLossesDataByTypeAsync(id);
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