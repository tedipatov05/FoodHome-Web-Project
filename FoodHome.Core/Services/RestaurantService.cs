using FoodHome.Core.Contracts;
using FoodHome.Core.Models.User;
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
        public async Task<List<RestaurantViewModel>> GetRestaurantsAsync()
        {
            var restaurants = await repo.All<Restaurant>()
                .Select(r => new RestaurantViewModel()
                {
                    Id = r.Id,
                    Name = r.User.Name, 
                    PictureUrl = r.User.ProfilePictureUrl
                })
                .ToListAsync();

            return restaurants;
        }
    }
}
