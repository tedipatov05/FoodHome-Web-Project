using FoodHome.Common;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    [Authorize(Roles = RoleConstants.Restaurant)]
    public class DishController : BaseController
    {
        private readonly IDishService dishService;
        private readonly ICategoryService categoryService;
        private readonly IRestaurantService restaurantService;

        public DishController(IDishService _dishService, ICategoryService _categoryService, IRestaurantService _restaurantService)
        {
            dishService = _dishService;
            categoryService = _categoryService;
            this.restaurantService = _restaurantService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            var model = new DishAddModel()
            {
                Categories = await categoryService.AllCategories()
            };
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DishAddModel model)
        {
            bool isRestaurant = await restaurantService.ExistsById(GetUserId());
            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be a restaurant to add a dish";

                return RedirectToAction("Contact", "Home");
            }
            string restaurantId = await restaurantService.GetRestaurantId(GetUserId());

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await dishService.AddDish(restaurantId, model);

            this.TempData[SuccessMessage] = $"Successfully added dish {model.Name}";

            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Menu(string id)
        {
            bool isRestaurant = await restaurantService.ExistsById(id);

            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "Incorect restaurant";

                return RedirectToAction("All", "Rstaurant");
            }
            var restaurantId = await restaurantService.GetRestaurantId(id);

            var dishes = await dishService.GetDishesByRestaurantId(restaurantId);

            return View("All", dishes);


        }
    }
}
