using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Dish.Enums;

using static FoodHome.Common.ApplicationConstants;

namespace FoodHome.Core.Models.Dish
{
    public class DishesQueryModel
    {
        public DishesQueryModel()
        {
            this.CurrentPage = DefaultPage;
            this.DishesPerPage = EntitiesPerPage;

            this.Categories = new HashSet<string>();
            this.Dishes = new HashSet<DishViewModel>();

        }
        public string? Category { get; set; }

        [Display(Name = "Search by word")]
        public string? SearchString {get; set; }

        [Display(Name = "Sort Dishes By")]
        public DishSorting DishSorting { get; set; }

        public int CurrentPage { get; set; }

        [Display(Name = "Show Dishes On Page")]
        public int DishesPerPage { get; set; }

        public int TotalDishes { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public IEnumerable<DishViewModel> Dishes { get; set; }


    }
}
