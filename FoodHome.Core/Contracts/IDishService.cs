using FoodHome.Core.Models.Dish;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface IDishService
    {
        Task<List<string>> AllDishesImagesByRestaurantId(string restaurantId);

        Task AddDish(string restaurantId, DishAddModel model);

        Task<List<DishViewModel>> GetDishesByRestaurantId(string restaurantId);

        Task<DishAddModel> GetDishById(int id, string restaurantId);

        Task<bool> ExistsById(int dishId);

        public Task<bool> IsRestaurantOwnerToDish(int dishId, string restaurantId);

    }
}
