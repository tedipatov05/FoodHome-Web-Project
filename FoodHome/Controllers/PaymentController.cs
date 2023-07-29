using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Payment;
using FoodHome.Core.Services;
using FoodHome.Extensions;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        private readonly IDishService dishService;
        private readonly IPaymentService paymentService;
        private readonly ICustomerService customerService;

        public PaymentController(IRestaurantService _restaurantService, IDishService _dishService, IPaymentService _paymentService, ICustomerService _customerService)
        {
            this.restaurantService = _restaurantService;
            this.dishService = _dishService;
            this.paymentService = _paymentService;
            this.customerService = _customerService;
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
                Amount = (decimal)dishes.Sum(d => d.Price * d.Quantity),
                RestaurantId = dishes.FirstOrDefault().RestaurantId
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Payment(PaymentFormModel model)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (isRestaurant)
            {
                string rId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to pay for order!";

                return RedirectToAction("Menu", "Dish", new { id = rId });

            }

            string[] expDate = model.ExpiryDate.Split('/', StringSplitOptions.RemoveEmptyEntries);

            if (int.Parse(expDate[0]) < DateTime.Now.Month)
            {
                ModelState.AddModelError(nameof(model.ExpiryDate), "Expiry date should be before now.");
            }
            if (!ModelState.IsValid)
            {
                var dishes = dishService.GetCartDishes(User.GetUsername());
                model.Amount = (decimal)dishes.Sum(d => d.Price * d.Quantity);
                return View(model);
            }


           

           

            try
            {
                string customerId = await customerService.GetCustomerId(User.GetId());
                string paymentId = await paymentService.CreatePayment(customerId, model);

                return RedirectToAction("Order", "Order",
                    new { restaurantId = model.RestaurantId, paymentId });
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Unexpected Error occurred";
                return RedirectToAction("Index", "Home");
            }

        }
    }
}
