using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Category;
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
    public class CategoryService : ICategoryService
    {
        private readonly IRepository repo;
        public CategoryService(IRepository _repo)
        {
            repo = _repo;
            
        }
        public async Task<IEnumerable<DishCategoryModel>> AllCategories()
        {
            var categories = await repo.All<Category>()
                .Select(c => new DishCategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,

                })
                .ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<string>> AllCategoryNames()
        {
            return await repo.All<Category>()
                .Select(c => c.Name)
                .ToListAsync();
        }

        public async Task<int> GetDishCategory(int dishId)
        {
            var dish = await repo.All<Dish>()
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.Id == dishId);

            return dish.Category.Id;
        }
    }
}
