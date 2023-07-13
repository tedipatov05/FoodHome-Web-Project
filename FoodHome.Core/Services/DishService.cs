using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Dish.Enums;

namespace FoodHome.Core.Services
{
    public class DishService : IDishService
    {
        private readonly IRepository repo;
        private readonly IImageService imageService;

        public DishService(IRepository _repo, IImageService _imageService)
        {
            this.repo = _repo;
            this.imageService = _imageService;
        }

        public async Task AddDish(string restaurantId, DishFormModel model)
        {
            
            Dish dish = new Dish
            {
                Name = model.Name, 
                Price = model.Price, 
                Description = model.Description, 
                Ingredients = model.Ingredients,
                CategoryId = model.CategoryId,
                Quantity = model.Quantity, 
                RestaurantId = restaurantId
            };

            if (model.DishUrlImage != null)
            {
                dish.DishUrlImage = await imageService.UploadImage(model.DishUrlImage, "images", dish);

            }

           
            await repo.AddAsync(dish);
            await repo.SaveChangesAsync();


        }

        public async Task<List<string>> AllDishesImagesByRestaurantId(string restaurantId)
        {
            var dishes = await repo.All<Dish>()
                .Where(rd => rd.RestaurantId == restaurantId && rd.IsActive == true)
                .Select(rd => rd.DishUrlImage)
                .ToListAsync();

            return dishes!;
                
        }

        public async Task<DishFormModel> GetDishById(int id)
        {
            var dish = await repo.All<Dish>()
                .Where(rd =>  rd.Id == id && rd.Quantity > 0 && rd.IsActive == true)
                .Select(rd => new DishFormModel()
                {
                    Name = rd.Name,
                    Description = rd.Description,
                    Ingredients = rd.Ingredients,
                    Price = rd.Price,
                    DishUrlImage = null,
                    Quantity = rd.Quantity,
                    CategoryId = rd.CategoryId

                })
                .FirstOrDefaultAsync();

            return dish;
        }

        public async Task<bool> ExistsById(int dishId)
        {
            var dish = await repo.All<Dish>(d => d.Id == dishId && d.IsActive == true)
                .FirstOrDefaultAsync();  

            return dish != null;


                
        }

        public async Task<bool> IsRestaurantOwnerToDish(int dishId, string restaurantId)
        {
            var dish = await repo.All<Dish>()
                .Where(d => d.IsActive)
                .FirstAsync(d => d.Id == dishId);

            return dish.RestaurantId == restaurantId;
        }

        public async Task EditDish(int dishId, DishFormModel model)
        {
            var dish = await repo.All<Dish>()
                .Where(d => d.IsActive)
                .FirstOrDefaultAsync(d => d.Id == dishId);

            dish.Name = model.Name;
            dish.Description = model.Description;
            dish.CategoryId = model.CategoryId;
            dish.Ingredients = model.Ingredients;
            dish.Quantity = model.Quantity;
            dish.Price = model.Price;

            if(model.DishUrlImage != null)
                dish.DishUrlImage = await imageService.UploadImage(model.DishUrlImage, "images", dish);

            await repo.SaveChangesAsync();
        }

        public async Task Delete(int dishId)
        {
            var dish = await repo.All<Dish>()
                .Where(d => d.IsActive && d.Id == dishId)
                .FirstOrDefaultAsync();

            dish!.IsActive = false;

            await repo.SaveChangesAsync();

        }

        public async Task<PreDeleteDishViewModel> DishForDeleteById(int dishId)
        {
            var dish = await repo.All<Dish>()
                .Where(d => d.Id == dishId && d.IsActive==true)
                .Select(d => new PreDeleteDishViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Ingredients = d.Ingredients,
                    ImageUrl = d.DishUrlImage
                })
                .FirstOrDefaultAsync();

            return dish!;


        }

        public async Task<AllDishesFilteredAndPages> DishesFiltered(DishesQueryModel model, string id)
        {
            IQueryable<Dish> dishesQuery = repo.All<Dish>()
                .Where(d => d.IsActive == true);

            if (!string.IsNullOrEmpty(model.Category))
            {
                dishesQuery = dishesQuery
                    .Where(d => d.Category.Name == model.Category);
            }

            if (!string.IsNullOrEmpty(model.SearchString))
            {
                string wildCard = $"%{model.SearchString.ToLower()}%";

                dishesQuery = dishesQuery
                    .Where(d => EF.Functions.Like(d.Name, wildCard) ||
                                EF.Functions.Like(d.Ingredients, wildCard) ||
                                EF.Functions.Like(d.Description, wildCard));
                
            }

            dishesQuery = model.DishSorting switch
            {
                DishSorting.Name => dishesQuery.OrderBy(d => d.Name),
                DishSorting.PriceAscending => dishesQuery.OrderBy(d => d.Price),
                DishSorting.PriceDescending => dishesQuery.OrderByDescending(d => d.Price),
                DishSorting.IngredientsAscending => dishesQuery.OrderBy(d => d.Ingredients),
                DishSorting.IngredientsDescending => dishesQuery.OrderByDescending(d => d.Ingredients)


            };

            IEnumerable<DishViewModel> dishModel = await dishesQuery
                .Where(d => d.IsActive)
                .Skip((model.CurrentPage - 1) * model.DishesPerPage)
                .Take(model.DishesPerPage)
                .Where(d => d.RestaurantId == id)
                .Select(d => new DishViewModel()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Ingredients = d.Ingredients,
                    Description = d.Description,
                    Price = d.Price,
                    DishImageUrl = d.DishUrlImage,
                    RestaurantUserId = d.Restaurant.UserId
                })
                .ToListAsync();
            int totalDishes = dishesQuery.Count();

            return new AllDishesFilteredAndPages()
            {
                Dishes = dishModel,
                TotalDishes = totalDishes
            };
        }
        public async Task<List<DishViewModel>> GetDishesByRestaurantId(string restaurantId)
        {
            var dihes = await repo.All<Dish>()
                .Where(rd => rd.RestaurantId == restaurantId && rd.Quantity > 0 && rd.IsActive == true)
                .Select(rd => new DishViewModel()
                {
                    Id = rd.Id,
                    Name = rd.Name,
                    Description = rd.Description,
                    Ingredients = rd.Ingredients,
                    Price = rd.Price,
                    DishImageUrl = rd.DishUrlImage, 
                    RestaurantUserId = rd.Restaurant.UserId
                })
                .ToListAsync();

            return dihes!;
        }
    }
}
