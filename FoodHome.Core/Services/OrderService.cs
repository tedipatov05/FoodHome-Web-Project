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
        public async Task<List<string>> GetOrdersIdByUserId(string userId)
        {
            var restaurantId = await restaurantService.GetRestaurantId(userId);

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
                Price = model.DishesForOrder.Select(d => d.Price).Sum(),
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
                };

                orderDishes.Add(orderDish);
            }

            order.Dishes = orderDishes;

            await repo.AddAsync<Order>(order);

            await repo.SaveChangesAsync();
        }
    }
}
