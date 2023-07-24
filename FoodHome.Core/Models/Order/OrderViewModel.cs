using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Order
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Dishes = new List<OrderedDishInfo>(); 
        }

        public string Id { get; set; } = null!;

        public string RestaurantName { get; set; } = null!;

        public string OrderTime { get; set; } = null!;

        public string? DeliveryTime { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string? CustomerPhoneNumber { get; set; }
        public decimal Price { get; set; }

        public string Status { get; set; } = null!;
       
        public ICollection<OrderedDishInfo> Dishes { get; set; }
    }
}
