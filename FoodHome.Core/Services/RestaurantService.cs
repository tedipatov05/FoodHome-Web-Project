using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Restaurant;
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
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository repo;
        public RestaurantService(IRepository _repo)
        {
            repo = _repo;
        }

        public async Task<bool> ExistsById(string id)
        {
            var restaurant = await repo.All<Restaurant>(r => (r.UserId == id || r.Id==id) && r.IsActive == true)
                .FirstOrDefaultAsync();

            return restaurant != null;
        }

        public async Task Create(string userId)
        {
            var restaurant = new Restaurant()
            {
                UserId = userId,
            };

            await repo.AddAsync(restaurant);
            await repo.SaveChangesAsync();
        }


        public async Task<RestaurantDetailsViewModel?> GetRestaurantById(string id)
        {
            var restaurant = await repo.All<Restaurant>()
                .Where(r => r.Id == id && r.IsActive == true)
                .Select(r => new RestaurantDetailsViewModel()
                {
                    Id = r.Id,
                    PictureUrl = r.User.ProfilePictureUrl,
                    Name = r.User.Name, 
                    Country = r.User.Country,
                    Description = r.Description, 
                    City = r.User.City, 
                    Address = r.User.Address
                })
                .FirstOrDefaultAsync();
                

            return restaurant;
        }

        public async Task<string> GetRestaurantId(string id)
        {
            var restaurantId = await repo.AllReadonly<Restaurant>()
                .Where(r => (r.UserId == id || r.Id == id) && r.User.IsActive == true)
                .Select(r => r.Id)
                .FirstOrDefaultAsync();

            if(restaurantId == null)
            {
                throw new NullReferenceException( "This restaurant doesn't exists");
            }

            return restaurantId;
        }

        public async Task<List<RestaurantViewModel>> GetRestaurantsAsync()
        {
            var restaurants = await repo.All<Restaurant>()
                .Where(r => r.IsActive == true)
                .Select(r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.User.Name, 
                    PictureUrl = r.User.ProfilePictureUrl!
                })
                .ToListAsync();

            return restaurants;
        }
    }
}
