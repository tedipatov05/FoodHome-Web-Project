using FoodHome.Core.Contracts;
using FoodHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FoodHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService userService;

        public HomeController(ILogger<HomeController> logger, IUserService _userService)
        {
            _logger = logger;
            this.userService = _userService;
        }

        public IActionResult Index()
        {

            return View();
            
        }

        public async Task<IActionResult> Contact()
        {
            var admin = await userService.GetAdmin();
            return View(admin);
        }
    }
}