using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Services;
using Microsoft.AspNetCore.Mvc;

using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Areas.Admin.Controllers
{
    public class DishController : BaseController
    {
        private readonly IDishService dishService;
        private readonly ICategoryService categoryService;
        private readonly IRestaurantService restaurantService;

        public DishController(IDishService _dishService, ICategoryService _categoryService, IRestaurantService _restaurantService)
        {
            this.dishService = _dishService;
            this.categoryService = _categoryService;
            this.restaurantService = _restaurantService;
        }
        public async Task<IActionResult> All([FromQuery] DishesQueryModel model)
        {
            try
            {
                
                AllDishesFilteredAndPages serviceModel = await dishService.AllDishesFiltered(model);

                model.Dishes = serviceModel.Dishes;
                model.TotalDishes = serviceModel.TotalDishes;
                model.Categories = await categoryService.AllCategoryNames();


                return View("All", model);

            }
            catch (Exception ex)
            {
                TempData[ErrorMessage] = ex.Message;

                return RedirectToAction("All", "Restaurant");
            }

        }

    }
}
