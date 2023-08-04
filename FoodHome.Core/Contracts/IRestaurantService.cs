using FoodHome.Core.Models.Restaurant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface IRestaurantService
    {
        Task<List<RestaurantViewModel>> GetRestaurantsAsync();

        Task<RestaurantDetailsViewModel?> GetRestaurantById(string id);

        Task<string> GetRestaurantId(string userId);

        Task<bool> ExistsById(string userId);

        Task Create(string userId);

    }
}
