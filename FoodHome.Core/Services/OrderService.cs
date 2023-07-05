using FoodHome.Core.Contracts;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository repo;
        private readonly IRestaurantService restaurantService;
        public OrderService(IRepository _repo, IRestaurantService _restaurantService)
        {
            this.repo = _repo;
            this.restaurantService = _restaurantService;

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
    }
}
