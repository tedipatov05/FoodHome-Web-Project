using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Order;

namespace FoodHome.Core.Contracts
{
    public interface IOrderService
    {
        Task<List<string>> GetOrdersIdByUserId(string restaurantId);

        Task CreateOrder(OrderFormModel model, string userId);

        Task<List<OrderViewModel>> GetOrdersByCustomerId(string customerId);

        Task ChangeStatusOrder(string orderId, string status);

        

        Task<bool> IsOrderExists(string orderId);

        Task<bool> IsOrderInRestaurant(string orderId, string restaurantId);

        Task<List<OrderViewModel>> GetOrdersByRestaurantId(string restaurantId);

        Task<AcceptOrderFormModel> GetOrderById(string orderId);

        Task AddOrderDeliveryTime(AcceptOrderFormModel model);
    }
}
