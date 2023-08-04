using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class RestaurantServiceUnitTest : BaseTests
    {
        private IRepository repo;
        private IRestaurantService restaurantService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
            restaurantService = new RestaurantService(repo);
        }

        [Test]
        [TestCase("44b29798-13fa-487e-819e-710d59613dd2")]
        public async Task ExistsByIdShouldReturnTrue(string id)
        {
            var restaurant = await restaurantService.ExistsById(id);

            Assert.That(restaurant, Is.EqualTo(true));
        }

        [Test]
        [TestCase("")]
        [TestCase("e6a48c42-469a-4b69-871b-c8554602afff")]
        [TestCase(null)]
        public async Task ExistsByIdShouldReturnFalse(string id)
        {
            var restaurant = await restaurantService.ExistsById(id);

            Assert.That(restaurant, Is.EqualTo(false));
        }

        [Test]
        [TestCase("RestaurantTest12")]
        public async Task CreateRestaurantShouldReturnCorrectResult(string userId)
        {
            User user = new User()
            {
                Id = userId,
                UserName = "restaurant12",
                Email = "restaurant12@gmail.com",
                NormalizedEmail = "RESTAURANT12@GMAIL.COM",
                NormalizedUserName = "RESTAURANT12",
                Name = "Restaurant45",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "Test"
            };

            var restaurant = new Restaurant()
            {
                Id = "TestRest",
                User = user, 
                UserId = userId
            };

            await repo.AddAsync(restaurant);
            await repo.SaveChangesAsync();

            await restaurantService.Create(userId);

            var dbRest = await repo.GetByIdAsync<Restaurant>("TestRest");

            Assert.IsNotNull(dbRest);
            Assert.That(dbRest.User.Id, Is.EqualTo(restaurant.User.Id));
        }

        [Test]
        [TestCase("44b29798-13fa-487e-819e-710d59613dd2")]
        public async Task GetRestaurantByIdShouldReturnCorrectResult(string id)
        {
            var restaurant = await restaurantService.GetRestaurantById(id);

            var dbRestaurant = await repo.All<Restaurant>()
                .FirstOrDefaultAsync(r => r.Id == id && r.IsActive);

            Assert.That(restaurant.Id, Is.EqualTo(dbRestaurant.Id));
            Assert.That(restaurant.Name, Is.EqualTo(dbRestaurant.User.Name));
        }


        [Test]
        [TestCase("5")]
        public async Task GetRestaurantByIdShouldReturnNull(string id)
        {
            var restaurant = await restaurantService.GetRestaurantById(id);
            
            Assert.IsNull(restaurant);
        }

        [Test]
        [TestCase("RestaurantTestUser1")]
        public async Task GetRestaurantIdShouldReturnCorrectResult(string id)
        {
            var restaurantId = await restaurantService.GetRestaurantId(id);

            var dbRestaurantId = await repo.GetByIdAsync<Restaurant>(restaurantId);
            var dbUser = await repo.GetByIdAsync<User>(id);

            Assert.IsNotNull(dbUser);
            Assert.That(restaurantId, Is.EqualTo(dbRestaurantId.Id));

        }

        [Test]
        [TestCase("some id")]
        [TestCase("test id")]
        public async Task GetRestaurantIdShouldThrowException(string id)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await restaurantService.GetRestaurantId(id));
            Assert.AreEqual(ex.Message, "This restaurant doesn't exists");
        }

        [Test]
        public async Task GetAllRestaurantsShouldReturnCorrectResult()
        {
            var allRestaurants = await restaurantService.GetRestaurantsAsync();

            var dbRestaurants = await repo.All<Restaurant>()
                .Where(r => r.IsActive)
                .ToListAsync();

            Assert.AreEqual(allRestaurants.Count, dbRestaurants.Count);
            Assert.AreEqual(allRestaurants[0].Id, dbRestaurants[0].Id);

        }
    }
        
    
}
