using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodHome.Tests.UnitTests
{
    public class CategoryServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private ICategoryService categoryService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
            this.categoryService = new CategoryService(this.repo);
        }

        [Test]
        public async Task AllCategoriesShouldReturnCorrectResult()
        {
            var allCategories = await categoryService.AllCategories();

            var dbAllCategories = await repo.All<Category>().ToListAsync();


            Assert.That(allCategories.Count(), Is.EqualTo(dbAllCategories.Count));
            Assert.That(allCategories.First().Name, Is.EqualTo(dbAllCategories[0].Name));
        }

        [Test]
        public async Task AllCategoryNamesShouldReturnCorrectResult()
        {
            var allCategories = await categoryService.AllCategoryNames();

            var dbAllCategories = await repo.All<Category>().ToListAsync();


            Assert.That(allCategories.Count(), Is.EqualTo(dbAllCategories.Count));
            Assert.That(allCategories.First(), Is.EqualTo(dbAllCategories[0].Name));
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]

        public async Task GetDishCategoryShouldRetunrCorrectResult(int dishId)
        {
            var dishCategory = await categoryService.GetDishCategory(dishId);

            var dbDishCategory = await repo.GetByIdAsync<Dish>(dishId);

            Assert.That(dishCategory, Is.EqualTo(dbDishCategory.CategoryId));
        }

        [Test]
        [TestCase(23)]
        [TestCase(34)]
        [TestCase(9)]
    
        public async Task GetDishCategoryShouldRetunrZerot(int dishId)
        {
            var dishCategory = await categoryService.GetDishCategory(dishId);

          
            Assert.That(dishCategory, Is.EqualTo(0));
        }
    }
}
