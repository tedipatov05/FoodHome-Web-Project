using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Category
{
    public class DishCategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }
}
