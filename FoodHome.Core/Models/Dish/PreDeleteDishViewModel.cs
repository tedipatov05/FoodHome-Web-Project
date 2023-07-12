using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Dish
{
    public class PreDeleteDishViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string? ImageUrl { get; set; }
    }
}
