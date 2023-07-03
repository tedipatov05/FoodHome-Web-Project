using FoodHome.Core.Models.User;
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
    }
}
