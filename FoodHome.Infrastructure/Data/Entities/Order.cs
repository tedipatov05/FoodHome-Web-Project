using FoodHome.Infrastructure.Data.Entities.Enums;
using static FoodHome.Infrastructure.Constants.ModelValidationConstants.OrdersConstants;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("Order")]
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Dishes = new List<OrderDish>();
        }
        [Comment("Primary key")]
        [Key]
        public string Id { get; set; }

        [Comment("Order status")]
        [Required]
        [EnumDataType(typeof(OrderStatusEnum))]
        public string Status { get; set; } = null!;

        [Comment("Restaurant Id")]
        [Required]
        [ForeignKey(nameof(Restaurant))]
        public string RestaurantId { get; set; } = null!;

        [Comment("Restaurant")]
        public Restaurant Restaurant { get; set; } = null!;

        [Comment("Time order made")]
        [Required]
        public DateTime OrderTime { get; set; }

        [Comment("Time for delivery")]
        public DateTime? DeliveryTime { get; set; }

        [Comment("Address fot delivery")]
        [Required]
        [MaxLength(OrderDeliveryAddressMaxLength)]
        public string DeliveryAddress { get; set; } = null!;

        [Comment("Customer Id")]
        [Required]
        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; } = null!;

        [Comment("Customer")]
        public Customer Customer { get; set; } = null!;

        [Comment("Price of the order")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        public virtual ICollection<OrderDish> Dishes { get; set; }
    }
}
