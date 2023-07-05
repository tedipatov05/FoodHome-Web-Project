using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Account;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IRepository repo;
        private readonly IOrderService orderService;
        private readonly IRestaurantService restaurantService;
       

        public ProfileService(IRepository _repo, IOrderService _orderService, IRestaurantService _restaurantService)
        {
            this.repo = _repo;
            this.orderService = _orderService;
            this.restaurantService = _restaurantService;
           
        }

        public async Task<ProfileViewModel> MyProfile(string userId, bool IsRestaurant)
        {
            var user = await repo.GetByIdAsync<User>(userId);
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            

            var profile = new ProfileViewModel()
            {
                Id = userId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Country = user.Country,
                Address = user.Address,
                ProfilePictureUrl = user.ProfilePictureUrl,
            };

            if (IsRestaurant)
            {
                var orders = await orderService.GetOrdersIdByUserId(userId);
                var restaurantId = await restaurantService.GetRestaurantId(userId);
                var restaurant = await restaurantService.GetRestaurantById(restaurantId);

                profile.OrdersCount = orders.Count();
                profile.Description = restaurant.Description;

            }

            return profile;

        }
    }
}
