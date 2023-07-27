using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Payment;
using FoodHome.Core.Services;
using FoodHome.Extensions;
using Microsoft.AspNetCore.Mvc;
using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        private readonly IDishService dishService;

        public PaymentController(IRestaurantService _restaurantService, IDishService _dishService)
        {
            this.restaurantService = _restaurantService;
            this.dishService = _dishService;
        }

        [HttpGet]
        public async Task<IActionResult> Payment()
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (isRestaurant)
            {
                string rId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to pay for order!";

                return RedirectToAction("Menu", "Dish", new { id = rId });
            }

            var dishes = dishService.GetCartDishes(User.GetUsername());


            PaymentFormModel model = new PaymentFormModel()
            {
                Amount = (decimal)dishes.Sum(d => d.Price * d.Quantity)
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                var dishes = dishService.GetCartDishes(User.GetUsername());
                model.Amount = (decimal)dishes.Sum(d => d.Price * d.Quantity);
                return View(model);
            }

            return Ok();
        }
    }
}
