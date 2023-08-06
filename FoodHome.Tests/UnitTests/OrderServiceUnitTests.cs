using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Models.Order;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using FoodHome.Infrastructure.Data.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class OrderServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private IOrderService orderService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
            this.orderService = new OrderService(repo);
        }

        [Test]
        [TestCase("44b29798-13fa-487e-819e-710d59613dd2")]
        public async Task GetOrdersByIdShouldReturnCorrectValue(string restaurantId)
        {
            var ordersIds = await orderService.GetOrdersIdByRestaurantId(restaurantId);

            var restaurant = await repo.GetByIdAsync<Restaurant>(restaurantId);
            var dbOrders = restaurant.Orders.ToList();

            Assert.AreEqual(ordersIds.Count, dbOrders.Count);
            Assert.AreEqual(ordersIds[0], dbOrders[0].Id);
        }

        [Test]
        [TestCase("CustomerTestUser1")]
        public async Task GetOrdersCountByUserIdShpuldReturnCorrectResult(string userId)
        {
            var count = await orderService.GetOrdersCountByUserId(userId);

            var customer = await repo.All<Customer>()
                .FirstOrDefaultAsync(c => c.User.Id == userId);
                
            Assert.AreEqual(count, customer.Orders.Count);
            
        }

        [Test]
        public async Task CreateOrderShouldReturnCorrectResult()
        {
            OrderFormModel model = new OrderFormModel()
            {
                PaymentId = "payment1", 
                Address = "some address", 
                City = "Kanzas city", 
                RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2", 
                DishesForOrder = new List<OrderDishView>()
                {
                    new OrderDishView()
                    {
                        Id = 9, 
                        Name = "Test", 
                        Ingredients = "Some ingredients", 
                        Price = 12.00m,
                        Quantity = 3
                    }
                }

            };

            var id = await orderService.CreateOrder(model, "CustomerTestUser1");


            var dbOrder = await repo.GetByIdAsync<Order>(id);

            var price = (decimal)(model.DishesForOrder.Select(d => d.Price * d.Quantity).Sum() +
                                  0.05m * model.DishesForOrder.Select(d => d.Price * d.Quantity).Sum() + 5);

            Assert.IsNotNull(dbOrder);
            Assert.That(dbOrder.Id, Is.EqualTo(id));
            Assert.That(dbOrder.DeliveryAddress, Is.EqualTo(model.Address));
            Assert.That(dbOrder.Price, Is.EqualTo(price));
        }

        [Test]
        [TestCase("db27df32-4380-4098-9671-5df6d43cbc43")]
        public async Task GetOrdersByCustomerIdShouldReturnCorrectValue(string customerId)
        {
            var orders = await orderService.GetOrdersByCustomerId(customerId);

            var customer = await repo.GetByIdAsync<Customer>(customerId);

            var dbOrders = customer.Orders.Where(o => o.Status != OrderStatusEnum.Delivered.ToString()).ToList();


            Assert.AreEqual(orders.Count, dbOrders.Count);
            Assert.That(orders[0].Id, Is.EqualTo(dbOrders[0].Id));
            Assert.That(orders[0].DeliveryAddress, Is.EqualTo(dbOrders[0].DeliveryAddress));
        }

        [Test]
        [TestCase("order1")]
        public async Task ChangeStatusOrderShouldReturnCorrectValue(string orderId)
        {
            await orderService.ChangeStatusOrder(orderId, OrderStatusEnum.Send.ToString());

            var order = await repo.GetByIdAsync<Order>(orderId);

            Assert.AreEqual(order.Status, OrderStatusEnum.Send.ToString());
        }

        [Test]
        [TestCase("order2")]
        [TestCase("order1")]
        public async Task IsOrderExistsShouldReturnTrue(string orderId)
        {
            var isExists = await orderService.IsOrderExists(orderId);

            Assert.That(isExists, Is.EqualTo(true));
        }

        [Test]
        [TestCase("testId")]
        [TestCase("test")]
        public async Task IsOrderExistsShouldReturnFalse(string orderId)
        {
            var isExists = await orderService.IsOrderExists(orderId);

            Assert.That(isExists, Is.EqualTo(false));
        }

        [Test]
        [TestCase("44b29798-13fa-487e-819e-710d59613dd2", "order2")]
        public async Task IsOrderInRestaurantShouldReturnTrue(string restaurantId, string orderId)
        {
            bool IsInRestaurant = await orderService.IsOrderInRestaurant(orderId, restaurantId);

            Assert.That(IsInRestaurant, Is.EqualTo(true));
        }

        [Test]
        [TestCase("44b29798-13fa-487e-819e-r3f", "orderwe2")]
        public async Task IsOrderInRestaurantShouldReturnFalse(string restaurantId, string orderId)
        {
            bool IsInRestaurant = await orderService.IsOrderInRestaurant(orderId, restaurantId);

            Assert.That(IsInRestaurant, Is.EqualTo(false));
        }
    }
}
