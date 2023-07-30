using CloudinaryDotNet.Actions;
using FoodHome.Common;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Models.Order;
using FoodHome.Core.Services;
using FoodHome.Extensions;
using FoodHome.Infrastructure.Data.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
   

    public class OrderController : BaseController
    {
        private readonly IRestaurantService restaurantService;
        private readonly IDishService dishService;
        private readonly IOrderService orderService;
        private readonly ICustomerService customerService;
        private readonly IPaymentService paymentsService;

        public OrderController(IRestaurantService _restaurantService, IDishService _dishService, IOrderService _orderService, ICustomerService _customerService, IPaymentService _paymentService)
        {
            this.restaurantService = _restaurantService;
            this.dishService = _dishService;
            this.orderService = _orderService;
            this.customerService = _customerService;
            this.paymentsService = _paymentService;
        }

        [HttpGet]
        
        public async Task<IActionResult> Order(string restaurantId, string paymentId)
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
                RestaurantId = restaurantId, 
                PaymentId = paymentId,

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

            if (!ModelState.IsValid)
            {
                model.DishesForOrder = dishService.GetCartDishes(username);
                return View(model);
            }

            try
            {
               
                model.DishesForOrder = dishService.GetCartDishes(username);

                string customerId = await customerService.GetCustomerId(User.GetId());

                var orderId = await orderService.CreateOrder(model, customerId);

                await paymentsService.AddPaymentOrderId(model.PaymentId, orderId);
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

        
        
        public async Task<IActionResult> SendOrder(string orderId)
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

            await orderService.ChangeStatusOrder(orderId, OrderStatusEnum.Send.ToString());
            
            return RedirectToAction("RestaurantOrders");

        }

        [Authorize(Roles = RoleConstants.Restaurant)]
        public async Task<IActionResult> DeliverOrder(string orderId)
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

            await orderService.ChangeStatusOrder(orderId, OrderStatusEnum.Delivered.ToString());

            return RedirectToAction("RestaurantOrders");
        }

        
        public async Task<IActionResult> Accept(string orderId)
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

            var order = await orderService.GetOrderById(orderId);

            return View(order);


        }

        
        [HttpPost]
        public async Task<IActionResult> Accept(AcceptOrderFormModel model)
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
                ModelState.AddModelError(nameof(model.DeliveryTime), "Delivery time should be after order time");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await orderService.AddOrderDeliveryTime(model);
            await orderService.ChangeStatusOrder(model.Id, OrderStatusEnum.Confirmed.ToString());

            return RedirectToAction("RestaurantOrders");
        }
    }
}
