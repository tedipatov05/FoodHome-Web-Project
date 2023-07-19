using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Dish
{
    public class OrderDishView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public string RestaurantId { get; set; }
    }
}
