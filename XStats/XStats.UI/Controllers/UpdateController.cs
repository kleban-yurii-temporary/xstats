using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XStats.Repos;

namespace XStats.UI.Controllers
{
    [Authorize]
    public class UpdateController : Controller
    {
        private readonly UpdateRepository updateRepository;

        public UpdateController(UpdateRepository updateRepository)
        {
            this.updateRepository = updateRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<List<string>> Run()
        {
            return await updateRepository.UpdateAsync();
        }
    }
}
