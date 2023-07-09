using FoodHome.Core.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Dish
{
    public class DishViewModel
    {
        public int Id { get; set; }      

        public string Name { get; set; }

        public string Description { get; set; }

        public string Ingredients { get; set; }

        public decimal Price { get; set; }

        public string DishImageUrl { get; set; }

    
    }
}
