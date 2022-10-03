using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XStats.Repos;

namespace XStats.UI.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsersController : Controller
    {
        private readonly UsersRepository usersRepository;
        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View(await usersRepository.GetUsersAsync());
        }
    }
}
