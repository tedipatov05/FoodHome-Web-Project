using FoodHome.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<DishCategoryModel>> AllCategories();


        Task<IEnumerable<string>> AllCategoryNames();
    }
}
