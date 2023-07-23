using CloudinaryDotNet.Actions;
using FoodHome.Common;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Models.Order;
using FoodHome.Core.Services;
using FoodHome.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
   
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
        [Authorize(Roles = RoleConstants.Customer)]
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
            dishes.ForEach(d => d.IsEnabled = false);

            OrderFormModel model = new OrderFormModel()
            {

                DishesForOrder = dishes,
                RestaurantId = restaurantId

            };

            return View(model);
        }
        [Authorize(Roles = RoleConstants.Customer)]
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

            if (!ModelState.IsValid)
            {
                model.DishesForOrder = dishService.GetCartDishes(username);
                return View(model);
            }

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

            HttpContext.Session.Clear();

            TempData[SuccessMessage] = "Successfully placed order!";
            return RedirectToAction("UserOrders");
        }

        [Authorize(Roles = RoleConstants.Customer)]
        public async Task<IActionResult> UserOrders()
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (isRestaurant)
            {
                string rId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a customer to order a dish";

                return RedirectToAction("Menu", "Dish", new { id = rId });
            }

            string customerId = await customerService.GetCustomerId(User.GetId());
            

            try
            {
                var orders = await orderService.GetOrdersByCustomerId(customerId);
                return View("All", orders);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("Index", "Home");
            }
            
        }

        [Authorize(Roles = RoleConstants.Restaurant)]
        public async Task<IActionResult> RestaurantOrders()
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be a restaurant to accept order";
                return RedirectToAction("UserOrders");
            }

            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());

            try
            {
                var orders = await orderService.GetOrdersByRestaurantId(restaurantId);
                return View("All", orders);
            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("Index", "Home");
            }


        }

        [Authorize(Roles = RoleConstants.Restaurant)]
        public async Task<IActionResult> AcceptOrder(string orderId)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be a restaurant to accept order";
                return RedirectToAction("UserOrders");
            }

            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());

            bool isOrderExists = await orderService.IsOrderExists(orderId);
            if (!isOrderExists)
            {
                TempData[ErrorMessage] = "This order does not exists";

                return RedirectToAction("UserOrders");
            }

            bool isInRestaurant = await orderService.IsOrderInRestaurant(orderId, restaurantId);
            if (!isInRestaurant)
            {
                TempData[ErrorMessage] = "The order should be in your restaurant to accept it";

                return RedirectToAction("UserOrders");
            }

            await orderService.AcceptOrder(orderId);
            var order = await orderService.GetOrderById(orderId);

            return View("Accept", order);

            
        }

        [Authorize(Roles = RoleConstants.Restaurant)]
        [HttpPost]
        public async Task<IActionResult> AcceptOrder(AcceptOrderFormModel model)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be a restaurant to accept order";
                return RedirectToAction("UserOrders");
            }

            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());

            bool isOrderExists = await orderService.IsOrderExists(model.Id);
            if (!isOrderExists)
            {
                TempData[ErrorMessage] = "This order does not exists";

                return RedirectToAction("UserOrders");
            }

            bool isInRestaurant = await orderService.IsOrderInRestaurant(model.Id, restaurantId);
            if (!isInRestaurant)
            {
                TempData[ErrorMessage] = "The order should be in your restaurant to accept it";

                return RedirectToAction("UserOrders");
            }

            if (model.DeliveryTime < DateTime.Parse(model.OrderTime))
            {
                ModelState.AddModelError(model.DeliveryTime.ToString(), "Delivery time should be after order time");
            }

            if (!ModelState.IsValid)
            {
                return View("Accept", model);
            }

            await orderService.AddOrderDeliveryTime(model);

            return RedirectToAction("RestaurantOrders");
        }
    }
}
