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
    [Comment("Order Dish")]
    public class OrderDish
    {
        [Comment("Order Id")]
        [Required]
        [ForeignKey(nameof(Order))]
        public string OrderId { get; set; } = null!;

        [Comment("Order")]
        public Order Order { get; set; } = null!;

        [Comment("Dish Id")]
        [ForeignKey(nameof(Dish))]
        public int DishId { get; set; }

        [Comment("Dish")]
        public Dish Dish { get; set; } = null!;

        [Comment("Ordered quantity")]
        public int Quantity { get; set; }
    }
}
