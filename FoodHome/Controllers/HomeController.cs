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
        private readonly IRestaurantService restaurantService;

        public HomeController(ILogger<HomeController> logger, IRestaurantService _restaurrantService)
        {
            _logger = logger;
            restaurantService = _restaurrantService;
        }

        public IActionResult Index()
        {

            return View();
            
        }
    }
}