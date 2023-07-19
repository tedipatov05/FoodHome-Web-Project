using FoodHome.Common;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Models.Order;
using FoodHome.Core.Services;
using FoodHome.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    [Authorize(Roles = RoleConstants.Customer)]
    public class OrderController : Controller
    {
        private readonly IRestaurantService restaurantService;
        private readonly IDishService dishService;

        public OrderController(IRestaurantService _restaurantService, IDishService _dishService)
        {
            restaurantService = _restaurantService;
            dishService = _dishService;
        }

        [HttpGet]
        public async Task<IActionResult> Order(string restaurantId)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (isRestaurant)
            {
                string rId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to order a dish";

                return RedirectToAction("Menu", "Dish",new { id = rId });
            }
            string username = User.GetUsername();


            var dishes = dishService.GetCartDishes(username);

            OrderFormModel model = new OrderFormModel()
            {
                DishesForOrder = dishes,
                RestaurantId = restaurantId

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Order(string restaurantId, OrderFormModel model)
        {
            return Ok();
        }
    }
}
