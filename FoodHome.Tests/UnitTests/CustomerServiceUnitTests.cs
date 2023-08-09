using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class CustomerServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private ICustomerService customerService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
            this.customerService = new CustomerService(repo);
        }

        [Test]
        [TestCase("CustomerTest")]
        public async Task CreateCustomerShouldReturnCorrectResult(string userId)
        {
            var user = new User()
            {
                Id = userId,
                UserName = "customer12",
                Email = "customer@gmail.com",
                NormalizedEmail = "CUSTOMER@GMAIL.COM",
                NormalizedUserName = "CUSTOMER12",
                Name = "Customer",
                City = "Kazanlak",
                Country = "Bulgaria",
                Address = "Test"
            };

            var customer = new Customer()
            {
                Id = "customerId",
                User = user,
                UserId = userId
            };

            await repo.AddAsync(customer);
            await repo.SaveChangesAsync();

            await customerService.Create(userId);

            var dbCustomer = await repo.GetByIdAsync<Customer>(customer.Id);

            Assert.IsNotNull(dbCustomer);
            Assert.That(dbCustomer.User.Id, Is.EqualTo(userId));

        }

        [Test]
        [TestCase("CustomerTestUser1")]
        public async Task GetCustomerIdShouldRetunrCorrectResult(string userId)
        {
            var customerId = await customerService.GetCustomerId(userId);

            var customer = await repo.GetByIdAsync<Customer>(customerId);

            Assert.IsNotNull(customer);
            Assert.That(customer.UserId, Is.EqualTo(userId));
        }

        [Test]
        [TestCase("CustomerTestUser2")]
        public async Task GetCustomerIdShouldRetunrCorrectNull(string userId)
        {
            var customerId = await customerService.GetCustomerId(userId);

            Assert.IsNull(customerId);
        }

    }
}
