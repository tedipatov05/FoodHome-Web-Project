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
        private readonly IImageService imageService;
        private readonly IDishService dishService;
       

        public ProfileService(IRepository _repo, IOrderService _orderService, IRestaurantService _restaurantService, IImageService _imageService, IDishService _dishService)
        {
            this.repo = _repo;
            this.orderService = _orderService;
            this.restaurantService = _restaurantService;
            this.imageService = _imageService;
            this.dishService = _dishService;
        }



        public async Task Edit(string userId, EditProfileModel model)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            if(user == null)
            {
                throw new NullReferenceException("This user doea not exists");
            }

            user.Name = model.Name;
            user.Address = model.Address;
            user.Email = model.Email;
            user.City = model.City;
            user.Country = model.Country;
            user.PhoneNumber = model.PhoneNumber;

            if(model.ProfilePicture != null)
                user.ProfilePictureUrl = await imageService.UploadImage(model.ProfilePicture, "images", user);

            await repo.SaveChangesAsync();
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
                
                var restaurantId = await restaurantService.GetRestaurantId(userId);
                var orders = await orderService.GetOrdersIdByRestaurantId(restaurantId);
                var restaurant = await restaurantService.GetRestaurantById(restaurantId);

                profile.OrdersCount = orders.Count();
                profile.Description = restaurant.Description;
                profile.MenuPhotos = await dishService.AllDishesImagesByRestaurantId(restaurantId);

            }
            else
            {
                profile.OrdersCount = await orderService.GetOrdersCountByUserId(userId);
            }

            return profile;

        }
    }
}
