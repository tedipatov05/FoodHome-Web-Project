using static FoodHome.Infrastructure.Constants.ModelValidationConstants.DishConstants;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("Dish for the restaurant")]
    public class Dish
    {
        public Dish()
        {
            this.IsActive = true;
            this.Orders = new List<OrderDish>();
            this.RestaurantDishes = new List<RestaurantDish>();
           
        }
        [Comment("Primary key")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the dish")]
        [Required]
        [MaxLength(DishNameMaxLength)]
        public string Name { get; set; } = null!;


        [Comment("Category Id for the dish")]
        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [Comment("Category")]
        public Category Category { get; set; } = null!;

        [Comment("Description of the dish")]
        [Required]
        [MaxLength(DishDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Ingredients of the dish")]
        [Required]
        [MaxLength(DishDescriptionMaxLength)]
        public string Ingredients { get; set; } = null!;

        [Comment("Image Url for the dish")]
        public string? DishUrlImage { get; set; }

        [Comment("Price of the dish")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Comment("Price of the dish")]
        public int Quantity { get; set; }

        [Comment("Is actice dish")]
        public bool IsActive { get; set; }

        public ICollection<OrderDish> Orders { get; set;}

        public ICollection<RestaurantDish> RestaurantDishes { get; set; }

    }
}
