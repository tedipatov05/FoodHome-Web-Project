using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Dish
{
    public class AllDishesFilteredAndPages
    {
        public AllDishesFilteredAndPages()
        {
            this.Dishes = new HashSet<DishViewModel>();
        }

        public int TotalDishes { get; set; }

        public IEnumerable<DishViewModel> Dishes { get; set; }
    }
}
