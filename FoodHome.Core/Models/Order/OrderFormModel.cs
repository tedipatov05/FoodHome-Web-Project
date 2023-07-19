using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Dish;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using static FoodHome.Infrastructure.Constants.ModelValidationConstants.OrdersConstants;
using static FoodHome.Infrastructure.Constants.ModelValidationConstants.UserConstants;

namespace FoodHome.Core.Models.Order
{
    public class OrderFormModel
    {
        public OrderFormModel()
        {
            this.DishesForOrder = new List<OrderDishView>();

        }
        [StringLength(OrderDeliveryAddressMaxLength, MinimumLength = OrdersDeliveryAddressMinLength)]
        public string Address { get; set; } = null!;


        [StringLength(CityMaxLength, MinimumLength = CityMinLength)]
        public string City { get; set; }

        public ICollection<OrderDishView> DishesForOrder { get; set; }

        public string RestaurantId { get; set; }
    }
}
