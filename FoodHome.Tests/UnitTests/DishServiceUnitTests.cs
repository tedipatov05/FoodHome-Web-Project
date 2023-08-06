using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Dish;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class DishServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private IImageService imageService;
        private IHttpContextAccessor accessor;
        private IDishService dishService;
        

        
        [SetUp]
        public async Task SetUp()
        {
           
            this.repo = new Repository(this.context);
            this.imageService = new ImageService(null, repo);
            this.accessor = new HttpContextAccessor();
            this.dishService = new DishService(repo, imageService, accessor);
        }

        [Test]
        [TestCase("44b29798-13fa-487e-819e-710d59613dd2")]
        public async Task AddDishShouldReturnCorrectResult(string restaurantId)
        {
            var model = new DishFormModel()
            {
                Name = "Test",
                Price = 21.00m,
                Description = "test description",
                Ingredients = "test ingredients",
                CategoryId = 3,
                Quantity = 12,
            };

            await dishService.AddDish(restaurantId, model);

            var dbDish = await repo.GetByIdAsync<Dish>(4);

            Assert.IsNotNull(dbDish);
            Assert.That(dbDish.Name, Is.EqualTo(model.Name));
            Assert.That(dbDish.CategoryId, Is.EqualTo(model.CategoryId));
            Assert.That(dbDish.Description, Is.EqualTo(model.Description));
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetDishByIdShouldReturnCorrectValue(int dishId)
        {
            var dish = await dishService.GetDishById(dishId);

            var dbDish = await repo.GetByIdAsync<Dish>(dishId);

            Assert.That(dish.Name, Is.EqualTo(dbDish.Name));
            Assert.That(dish.Description, Is.EqualTo(dbDish.Description));
            Assert.That(dish.Ingredients, Is.EqualTo(dbDish.Ingredients));
            
            
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        public async Task ExistsByIdShouldReturnTrue(int dishId)
        {
            var isExists = await dishService.ExistsById(dishId);

            Assert.That(isExists, Is.EqualTo(true));
        }

        [Test]
        [TestCase(8)]
        [TestCase(6)]
        public async Task ExistsByIdShouldReturnFalse(int dishId)
        {
            var isExists = await dishService.ExistsById(dishId);

            Assert.That(isExists, Is.EqualTo(false));
        }

        [Test]
        [TestCase(2, "44b29798-13fa-487e-819e-710d59613dd2")]
        public async Task IsRestaurantOwnerToDishShouldReturnTrue(int dishId, string restaurantId)
        {
            bool result = await dishService.IsRestaurantOwnerToDish(dishId, restaurantId);

            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase(12, "tr1444th67fgg345sr")]
        [TestCase(15, "tr1444the4wrt54fgg345sr")]
        [TestCase(5, "tr14w4ergb56etsr")]
        public async Task IsRestaurantOwnerToDishShouldReturnFalse(int dishId, string restaurantId)
        {
            bool result = await dishService.IsRestaurantOwnerToDish(dishId, restaurantId);

            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public async Task EditDishShouldReturnCorrectResult()
        {
            var model = new DishFormModel()
            {
                Name = "Test",
                Price = 21.00m,
                Description = "test description",
                Ingredients = "test ingredients",
                CategoryId = 3,
                Quantity = 12,
            };

            await dishService.EditDish(2, model);

            var dbDish = await repo.GetByIdAsync<Dish>(2);

            Assert.That(dbDish.Name, Is.EqualTo(model.Name));
            Assert.That(dbDish.Description, Is.EqualTo(model.Description));
            Assert.That(dbDish.Quantity, Is.EqualTo(model.Quantity));
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task DeleteShouldReturnCorrectResult(int dishId)
        {
            await dishService.Delete(dishId);

            var dish = await repo.GetByIdAsync<Dish>(dishId);

            Assert.That(dish.IsActive, Is.EqualTo(false));
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public async Task GetDishForDeleteShouldReturnCorrectResult(int dishId)
        {
            var dishForDelete = await dishService.DishForDeleteById(dishId);

            var dish = await repo.GetByIdAsync<Dish>(dishId);

            Assert.That(dishForDelete.Ingredients, Is.EqualTo(dish.Ingredients));
            Assert.That(dishForDelete.Name, Is.EqualTo(dish.Name));

        }
    }
}
