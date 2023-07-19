using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FoodHome.Infrastructure.Constants.ModelValidationConstants.DishConstants;
using FoodHome.Core.Models.Category;
using Microsoft.AspNetCore.Http;

namespace FoodHome.Core.Models.Dish
{
    public class DishFormModel
    {
        public DishFormModel()
        {
            this.Categories = new List<DishCategoryModel>();
        }

        [Required]
        [StringLength(DishNameMaxLength, MinimumLength = DishNameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DishDescriptionMaxLength, MinimumLength = DishDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [StringLength(DishIngredientsMaxLength, MinimumLength = DishIngredientsMinLength)]
        public string Ingredients { get; set; } = null!;

        public IFormFile? DishUrlImage { get; set; }

        [Precision(18, 2)]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<DishCategoryModel> Categories { get; set; }
    }
}
