using FoodHome.Common;
using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    [Authorize(Roles = RoleConstants.Customer)]
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        private readonly IDishService dishService;

        public RestaurantController(IRestaurantService _restaurantService, IDishService _dishService)
        {
            this.restaurantService = _restaurantService;
            this.dishService = _dishService;

        }

        public async Task<IActionResult> All()
        {
            var restaurants = await restaurantService.GetRestaurantsAsync();
            return View(restaurants);
        }
        public async Task<IActionResult> Details(string id)
        {
            var restaurant = await restaurantService.GetRestaurantById(id);

            return View(restaurant);
        }

       

    }
}
