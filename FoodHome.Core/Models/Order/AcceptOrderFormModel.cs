using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Order
{
    public class AcceptOrderFormModel
    {
        public AcceptOrderFormModel()
        {
            this.Dishes = new List<OrderedDishInfo>();
        }

        public string Id { get; set; } = null!;

        public string CustomerName { get; set; }

        public string OrderTime { get; set; } = null!;

        public DateTime DeliveryTime { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public decimal Price { get; set; }

        public string Status { get; set; } = null!;

        public ICollection<OrderedDishInfo> Dishes { get; set; }
    }
}
