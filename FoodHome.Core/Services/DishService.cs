using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Services
{
    public class DishService : IDishService
    {
        private readonly IRepository repo;
        private readonly IRestaurantService restaurantService;
        private readonly IImageService imageService;

        public DishService(IRepository _repo, IRestaurantService _restaurantService, IImageService _imageService)
        {
            this.repo = _repo;
            this.restaurantService = _restaurantService;
            this.imageService = _imageService;
        }

        public async Task AddDish(string restaurantId, DishAddModel model)
        {
            
            Dish dish = new Dish
            {
                Name = model.Name, 
                Price = model.Price, 
                Description = model.Description, 
                Ingredients = model.Ingredients,
                CategoryId = model.CategoryId,
                Quantity = model.Quantity
            };

            if (model.DishUrlImage != null)
            {
                dish.DishUrlImage = await imageService.UploadImage(model.DishUrlImage, "images", dish);

            }

            RestaurantDish restaurantDish = new RestaurantDish()
            {
                Dish = dish,
                RestaurantId = restaurantId
            };

            await repo.AddAsync(restaurantDish);
            await repo.SaveChangesAsync();


        }

        public async Task<List<string>> AllDishesImagesByRestaurantId(string restaurantId)
        {
            var dishes = await repo.All<RestaurantDish>()
                .Where(rd => rd.RestaurantId == restaurantId)
                .Select(rd => rd.Dish.DishUrlImage)
                .ToListAsync();

            return dishes!;
                
        }
    }
}
