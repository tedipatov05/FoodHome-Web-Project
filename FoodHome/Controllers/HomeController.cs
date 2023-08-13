using FoodHome.Core.Contracts;
using FoodHome.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using FoodHome.Common;
using FoodHome.Infrastructure.Migrations;

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
            if (User.IsInRole(RoleConstants.Administrator))
            {
                return RedirectToAction("Index", "Home", new { Area = "Admin" });
            }
            return View();
            
        }

        public async Task<IActionResult> Contact()
        {
            var admin = await userService.GetAdmin();
            return View(admin);
        }

        
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}