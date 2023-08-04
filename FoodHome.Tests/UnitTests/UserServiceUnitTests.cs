using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Constants;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

using static FoodHome.Infrastructure.Constants.AdministratorConstants;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class UserServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private IUserService userService;

        [SetUp]
        public async Task Setup()
        {
            this.repo = new Repository(this.context);
            this.userService = new UserService(repo);
        }

        [Test]
        [TestCase("admin@mail.com")]
        [TestCase("testUser1@mail.bg")]
        public async Task ExistsByEmailShouldReturnTrue(string email)
        {
            var user = await userService.ExistsByEmail(email);

            Assert.That(user, Is.EqualTo(true));
        }

        [Test]
        [TestCase("")]
        [TestCase("tedi@mail.bg")]
        [TestCase("sth")]
        [TestCase("")]
        [TestCase(null)]
        public async Task ExistsByEmailShouldReturnFalse(string email)
        {
            var user = await userService.ExistsByEmail(email);

            Assert.That(user, Is.EqualTo(false));
        }

        [Test]
        [TestCase("0885743623")]
        public async Task ExistsByPhoneShouldReturnTrue(string phone)
        {
            var user = await userService.ExistsByPhone(phone);

            Assert.That(user, Is.EqualTo(true));
        }

        [Test]
        [TestCase("08893475")]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("number")]
        public async Task ExistsByPhoneShouldReturnFalse(string phone)
        {
            var user = await userService.ExistsByPhone(phone);

            Assert.That(user, Is.EqualTo(false));
        }

        [Test]
        [TestCase("0d9e1416-60a8-4655-af48-614ff829b230")]
        public async Task ExistsByIdShouldReturnTrue(string id)
        {
            var user = await userService.ExistsById(id);

            Assert.That(user, Is.EqualTo(true));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("some id")]
        [TestCase("294872")]
        public async Task ExistsByIdShouldReturnFalse(string id)
        {
            var user = await userService.ExistsById(id);

            Assert.That(user, Is.EqualTo(false));
        }


        [Test]
        [TestCase("0d9e1416-60a8-4655-af48-614ff829b230")]
        public async Task DeleteUserShouldChangeIsActiveToFalse(string id)
        {
            await userService.DeleteUser(id);

            var user = await repo.All<User>()
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            
            Assert.AreEqual(user.IsActive, false);
        }

        [Test]
        public async Task GetAdminShouldReturnCorrectResult()
        {
            var admin = await userService.GetAdmin();

            var dbAdmin = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.Id == AdministratorConstants.Id);

            Assert.AreEqual(admin.Id, dbAdmin.Id);
            Assert.AreEqual(admin.Name, dbAdmin.Name);
        }

        [Test]
        public async Task GetAllUsersShouldReturnCorrectResult()
        {
            var allUsers = await userService.GetAllUsers();

            var dbUsers = await repo.All<User>()
                .Where(u => u.IsActive).ToListAsync();

            Assert.AreEqual(allUsers.Count, dbUsers.Count);
            Assert.AreEqual(allUsers[0].Id, allUsers[0].Id);
        }

        [Test]
        [TestCase("CustomerTestUser1")]
        public async Task GetUserByIdShouldReturnCorrectResult(string userId)
        {
            var user = await userService.GetUserByIdAsync(userId);

            var dbUser = await repo.All<User>().FirstOrDefaultAsync(u => u.Id == userId);

            Assert.AreEqual(user.Id, dbUser.Id);
            Assert.AreEqual(user.Name, dbUser.Name);
        }

        [Test]
        [TestCase("test")]
        [TestCase("")]
        [TestCase(null)]
        public async Task GetUserByIdShouldThrowException(string userId)
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await userService.GetUserByIdAsync(userId));
            Assert.AreEqual(ex.Message, "This user does not exists");


        }




    }
}
