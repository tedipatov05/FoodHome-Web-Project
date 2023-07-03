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
    [Comment("Restaurant dish")]
    public class RestaurantDish
    {
        [Comment("Restaurant Id")]
        [Required]
        [ForeignKey(nameof(Restaurant))]
        public string RestaurantId { get; set; } = null!;

        [Comment("Restaurant")]
        public Restaurant Restaurant { get; set; } = null!;

        [Comment("Dish Id")]
        [Required]
        [ForeignKey(nameof(Dish))]
        public int DishId { get; set; }

        [Comment("Dish")]
        public Dish Dish { get; set; } = null!;

    }
}
