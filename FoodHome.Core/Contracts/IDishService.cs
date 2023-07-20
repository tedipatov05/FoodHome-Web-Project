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

        Task AddDish(string restaurantId, DishFormModel model);

        Task<List<DishViewModel>> GetDishesByRestaurantId(string restaurantId);

        Task<DishFormModel> GetDishById(int id);

        Task<bool> ExistsById(int dishId);

        Task<bool> IsRestaurantOwnerToDish(int dishId, string restaurantId);

        Task EditDish(int dishId, DishFormModel model);

        Task Delete(int dishId);

        Task<PreDeleteDishViewModel> DishForDeleteById(int dishId);

        Task<AllDishesFilteredAndPages> DishesFiltered(DishesQueryModel model, string id);

        Task<List<OrderDishView>> GetDishesByIds(List<int> dishesIds);

        Task<OrderDishView> GetDishForOrderById(int id);

        Task AddDishToCart(string username, int dishId, int quantity);

        List<OrderDishView> GetCartDishes(string username);


    }
}
