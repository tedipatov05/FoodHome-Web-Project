using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Tests.UnitTests
{
    public class ProfileServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private IOrderService orderService;
        private IRestaurantService restaurantService;
        private IDishService dishService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
            this.restaurantService = new RestaurantService(repo);
            this.orderService = new OrderService(repo, restaurantService, null);
            this.dishService = new DishService(repo, null, null);
        }


    }
}
