using FoodHome.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FoodHome.Controllers
{
    public class RestaurantController : BaseController
    {
        private readonly IRestaurantService restaurantService;

        public RestaurantController(IRestaurantService _restaurantService)
        {
            this.restaurantService = _restaurantService;
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
