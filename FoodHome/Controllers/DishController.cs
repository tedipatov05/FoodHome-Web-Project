using System.Diagnostics;
using System.Security.Claims;
using FoodHome.Common;
using FoodHome.Common.Extensions;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Services;
using FoodHome.Extensions;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static FoodHome.Common.NotificationConstants;

namespace FoodHome.Controllers
{
    [Authorize(Roles = RoleConstants.Restaurant)]
    public class DishController : BaseController
    {
        private readonly IDishService dishService;
        private readonly ICategoryService categoryService;
        private readonly IRestaurantService restaurantService;
        private readonly ICustomerService customerService;

        public DishController(IDishService _dishService, ICategoryService _categoryService, IRestaurantService _restaurantService, 
            ICustomerService _customerService)
        {
            this.dishService = _dishService;
            this.categoryService = _categoryService;
            this.restaurantService = _restaurantService;
            this.customerService = _customerService;

        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            
            var model = new DishFormModel()
            {
                Categories = await categoryService.AllCategories()
            };

            
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(DishFormModel model)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be a restaurant to add a dish";

                return RedirectToAction("Contact", "Home");
            }
            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await dishService.AddDish(restaurantId, model);

            this.TempData[SuccessMessage] = $"Successfully added dish {model.Name}";

            return RedirectToAction("Menu", new {id = restaurantId});
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Menu(string id, [FromQuery]DishesQueryModel model)
        {
            bool isRestaurant = await restaurantService.ExistsById(id);

            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "Incorrect restaurant";

                return RedirectToAction("Index", "Home");
            }

            try
            {
               
                var restaurantId = await restaurantService.GetRestaurantId(id);

                AllDishesFilteredAndPages serviceModel = await dishService.DishesFiltered(model, restaurantId);

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
        [HttpGet]
        public async Task<IActionResult> Edit(int dishId)
        {
            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
            bool isDishExists = await dishService.ExistsById(dishId);
            if (!isDishExists)
            {
                TempData[ErrorMessage] = "This dish does not exists!";

                return RedirectToAction("Menu",new {id = restaurantId});
            }

           

            bool isRestaurant = await restaurantService.ExistsById(restaurantId);

            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be restaurant!";

                return RedirectToAction("Contact", "Home");
            }

           
          

            bool isOwner = await dishService.IsRestaurantOwnerToDish(dishId, restaurantId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "The dish must be in your menu to be edited";

                return RedirectToAction("Menu", "Dish", new{ id=restaurantId});
            }

            try
            {
                var dish = await dishService.GetDishById(dishId);
                dish.Categories = await categoryService.AllCategories();
                return View(dish);
            }
            catch (Exception ex)
            {

                return this.GeneralError();
            }

            


        }

        public async Task<IActionResult> Edit(int dishId, DishFormModel model)
        {

            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.AllCategories();

                return View(model);
            }

            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
            bool isDishExists = await dishService.ExistsById(dishId);

            if (!isDishExists)
            {
                TempData[ErrorMessage] = "This dish does not exists!";

                return RedirectToAction("Menu", new { id = restaurantId });
            }

            bool isRestaurant = await restaurantService.ExistsById(restaurantId);

            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be restaurant!";

                return RedirectToAction("Contact", "Home");
            }

            bool isOwner = await dishService.IsRestaurantOwnerToDish(dishId, restaurantId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "The dish must be in your menu to be edited";

                return RedirectToAction("Menu", "Dish", new { id = restaurantId });
            }

            try
            {
                await dishService.EditDish(dishId, model);
            }
            catch (Exception ex)
            {
                return this.GeneralError();
            }

            TempData[SuccessMessage] = "Successfully edited dish";

            return RedirectToAction("Menu", "Dish", new { id = restaurantId });

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
            bool isDishExists = await dishService.ExistsById(id);
            if (!isDishExists)
            {
                TempData[ErrorMessage] = "This dish does not exists!";

                return RedirectToAction("Menu", new { id = restaurantId });
            }



            bool isRestaurant = await restaurantService.ExistsById(restaurantId);

            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be restaurant!";

                return RedirectToAction("Contact", "Home");
            }




            bool isOwner = await dishService.IsRestaurantOwnerToDish(id, restaurantId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "The dish must be in your menu to be deleted";

                return RedirectToAction("Menu", "Dish", new { id = restaurantId });
            }

            try
            {
                PreDeleteDishViewModel model = await dishService.DishForDeleteById(id);

                return View(model);
            }
            catch(Exception ex)
            {
                return this.GeneralError();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id, PreDeleteDishViewModel model)
        {
            string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
            bool isDishExists = await dishService.ExistsById(id);

            if (!isDishExists)
            {
                TempData[ErrorMessage] = "This dish does not exists!";

                return RedirectToAction("Menu", new { id = restaurantId });
            }

            bool isRestaurant = await restaurantService.ExistsById(restaurantId);

            if (!isRestaurant)
            {
                TempData[ErrorMessage] = "You should be restaurant!";

                return RedirectToAction("Contact", "Home");
            }
            
            bool isOwner = await dishService.IsRestaurantOwnerToDish(id, restaurantId);

            if (!isOwner)
            {
                TempData[ErrorMessage] = "The dish must be in your menu to be deleted";

                return RedirectToAction("Menu", "Dish", new { id = restaurantId });
            }

            try
            {
                await dishService.Delete(id);

                TempData[WarningMessage] = "This dish was successfully deleted";

                return this.RedirectToAction("Menu", new { id = restaurantId });
            }
            catch (Exception ex)
            {
                return this.GeneralError();
            }
        }

        [AllowAnonymous]
        public async Task<IActionResult> AddToCart(int dishId)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            
            if (isRestaurant)
            {
                string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to order a dish";

                return RedirectToAction("Menu", new { id = restaurantId });

            }
            bool isDishExists = await dishService.ExistsById(dishId);
            
            if (!isDishExists)
            {
                TempData[ErrorMessage] = "This dish does not exists!";

                return RedirectToAction("All", "Restaurant");
            }

            string username = User.GetUsername();

            await dishService.AddDishToCart(username, dishId);
            

            return RedirectToAction("Cart");
        }

        

        [AllowAnonymous]
        public async Task<IActionResult> Cart()
        {
            
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            if (isRestaurant)
            {
                string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to order a dish";

                return RedirectToAction("Menu", new { id = restaurantId });
            }
            
            string username = User.GetUsername();


            var dishes = dishService.GetCartDishes(username);
            
            return View(dishes);

        }

        [AllowAnonymous]
        public async Task<IActionResult> RemoveFromCart(int dishId)
        {
            bool isRestaurant = await restaurantService.ExistsById(User.GetId());
            
            if (isRestaurant)
            {
                string restaurantId = await restaurantService.GetRestaurantId(User.GetId());
                TempData[ErrorMessage] = "You should be a client to order a dish";

                return RedirectToAction("Menu", new { id = restaurantId });
            }

            bool isDishExists = await dishService.ExistsById(dishId);

            if (!isDishExists)
            {
                TempData[ErrorMessage] = "This dish does not exists!";

                return RedirectToAction("All", "Restaurant");
            }

            List<OrderDishView> dishes =
                HttpContext.Session.GetObjectFromJson<List<OrderDishView>>($"cart{User.GetUsername()}");

            var dishToRemove = dishes.FirstOrDefault(d => d.Id == dishId);

            if (dishes.Remove(dishToRemove))
            {
                HttpContext.Session.SetObjectAsJson($"cart{User.GetUsername()}", dishes);
            }
            else
            {
                TempData[ErrorMessage] = "This dish is not is your cart";
                HttpContext.Session.SetObjectAsJson($"cart{User.GetUsername()}", dishes);

                return RedirectToAction("Cart");
            }
            TempData[SuccessMessage] = "Successfully removed dish from cart";

            return RedirectToAction("Cart");

        }

        private IActionResult GeneralError()
        {
            this.TempData[ErrorMessage] =
                "Unexpected error occurred! Please try again later or contact administrator";

            return this.RedirectToAction("Index", "Home");
        }

        


    }
}
