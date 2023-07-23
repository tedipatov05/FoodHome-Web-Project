using FoodHome.Core.Contracts;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Order;
using FoodHome.Infrastructure.Data.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

namespace FoodHome.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repo;
        private readonly IRestaurantService restaurantService;
        private readonly ICategoryService categoryService;
        
        public OrderService(IRepository _repo, IRestaurantService _restaurantService, ICategoryService _categoryService)
        {
            this.repo = _repo;
            this.restaurantService = _restaurantService;
            this.categoryService = _categoryService;
           
        }
        public async Task<List<string>> GetOrdersIdByUserId(string restaurantId)
        {
          
            var orders = await repo.All<Order>()
                .Where(o => o.RestaurantId == restaurantId)
                .Select(o => o.Id)
                .ToListAsync();

            return orders;
        }

        public async Task CreateOrder(OrderFormModel model, string userId)
        {
            Order order = new Order()
            {
                CustomerId = userId,
                DeliveryAddress = model.Address,
                OrderTime = DateTime.Now,
                Price = (decimal)model.DishesForOrder.Select(d => d.Price * d.Quantity).Sum(),
                RestaurantId = model.RestaurantId,
                Status = OrderStatusEnum.Waiting.ToString(),
                
            };

            List<OrderDish> orderDishes = new List<OrderDish>();

            foreach (var dish in model.DishesForOrder)
            {

                OrderDish orderDish = new OrderDish()
                {
                    OrderId = order.Id,
                    DishId = dish.Id,
                    Quantity = dish.Quantity,
                };

                orderDishes.Add(orderDish);
            }

            order.Dishes = orderDishes;

            await repo.AddAsync<Order>(order);

            await repo.SaveChangesAsync();
        }

        public async Task<List<OrderViewModel>> GetOrdersByCustomerId(string clientId)
        {
            var orders = await repo.All<Order>()
                .Where(o => o.CustomerId == clientId)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    RestaurantName = o.Restaurant.User.Name,
                    DeliveryAddress = o.DeliveryAddress,
                    DeliveryTime = o.DeliveryTime.Value.ToShortTimeString(),
                    OrderTime = o.OrderTime.ToShortTimeString(),
                    Status = o.Status,
                    Dishes = o.Dishes.Select(d => new OrderedDishInfo()
                    {
                        Name = d.Dish.Name, 
                        Quantity = d.Quantity
                    }).ToList(),
                    Price = o.Price,
                })
                .ToListAsync();

            return orders;
        }

        public async Task AcceptOrder(string orderId)
        {
            var order = await repo.All<Order>()
                .FirstOrDefaultAsync(o => o.Id == orderId);

            order.Status = OrderStatusEnum.Confirmed.ToString();

            await repo.SaveChangesAsync();
        }

        public async Task<bool> IsOrderExists(string orderId)
        {
            return await repo.All<Order>().AnyAsync(o => o.Id == orderId);
        }

        public async Task<bool> IsOrderInRestaurant(string orderId, string restaurantId)
        {
            var order = await repo.All<Order>()
                .FirstOrDefaultAsync(o => o.Id == orderId && o.RestaurantId == restaurantId);

            return order != null;
        }

        public async Task<List<OrderViewModel>> GetOrdersByRestaurantId(string restaurantId)
        {
            var orders = await repo.All<Order>()
                .Where(o => o.RestaurantId == restaurantId)
                .Select(o => new OrderViewModel()
                {
                    Id = o.Id,
                    RestaurantName = o.Restaurant.User.Name,
                    DeliveryAddress = o.DeliveryAddress,
                    DeliveryTime = o.DeliveryTime.Value.ToShortTimeString(),
                    OrderTime = o.OrderTime.ToShortTimeString(),
                    Status = o.Status,
                    Dishes = o.Dishes.Select(d => new OrderedDishInfo()
                    {
                        Name = d.Dish.Name,
                        Quantity = d.Quantity
                    }).ToList(),
                    Price = o.Price,
                })
                .ToListAsync();

            return orders;
        }

        public async Task<AcceptOrderFormModel> GetOrderById(string orderId)
        {
            var order = await repo.All<Order>()
                .Where(o => o.Id == orderId)
                .Select(o => new AcceptOrderFormModel()
                {
                    Id = o.Id,
                    CustomerName = o.Customer.User.Name,
                    DeliveryAddress = o.DeliveryAddress,
                    OrderTime = o.OrderTime.ToShortTimeString(),
                    Status = o.Status,
                    Dishes = o.Dishes.Select(d => new OrderedDishInfo()
                    {
                        Name = d.Dish.Name,
                        Quantity = d.Quantity
                    }).ToList(),
                    Price = o.Price,

                })
                .FirstOrDefaultAsync();

            return order;
        }

        public async Task AddOrderDeliveryTime(AcceptOrderFormModel model)
        {
            var order = await repo.All<Order>()
                .Where(o => o.Id == model.Id)
                .FirstOrDefaultAsync();

            order.DeliveryTime = model.DeliveryTime;

            await repo.SaveChangesAsync();
        }
    }
}
