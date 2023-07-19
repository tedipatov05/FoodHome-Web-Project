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
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;

        public OrderController(IRestaurantService _restaurantService, IDishService _dishService, IOrderService _orderService, ICustomerService _customerService)
        {
            this.restaurantService = _restaurantService;
            this.dishService = _dishService;
            this.orderService = _orderService;
            this.customerService = _customerService;
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
        public async Task<IActionResult> Order(OrderFormModel model)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (isRestaurant)
            {
                string rId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to order a dish";

                return RedirectToAction("Menu", "Dish", new { id = rId });
            }

            string username = User.GetUsername();
            try
            {
                model.DishesForOrder = dishService.GetCartDishes(username);

                string customerId = await customerService.GetCustomerId(User.GetId());

                await orderService.CreateOrder(model, customerId);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;
                return View(model);
            }

            TempData[SuccessMessage] = "Successfully placed order!";
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> UserOrders()
        {
            return Ok();
        }
    }
}
