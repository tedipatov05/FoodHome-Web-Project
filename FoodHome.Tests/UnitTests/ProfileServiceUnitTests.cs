using FoodHome.Core.Contracts;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Account;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Http;

namespace FoodHome.Tests.UnitTests
{
    public class ProfileServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private IOrderService orderService;
        private IRestaurantService restaurantService;
        private IDishService dishService;
        private IProfileService profileService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
            this.restaurantService = new RestaurantService(repo);
            this.orderService = new OrderService(repo);
            this.dishService = new DishService(repo, null, null);
            this.profileService = new ProfileService(repo, orderService, restaurantService, null, dishService);
        }

        [Test]
        public async Task EditUserShouldReturnCorrectResult()
        {
            await profileService.Edit("0d9e1416-60a8-4655-af48-614ff829b230", new EditProfileModel()
            {
                Address = "The address is edited",
                City = "city [edited]",
                Country = " country [edited]",
                Email = "email [edited]",
                Name = "name [edited]",
                PhoneNumber = "Phone [edited]",
                ProfilePicture = null
                
            });

            var dbProfile = await repo.GetByIdAsync<User>("0d9e1416-60a8-4655-af48-614ff829b230");

            Assert.That(dbProfile.Address, Is.EqualTo("The address is edited"));
            Assert.That(dbProfile.Name, Is.EqualTo("name [edited]"));
            Assert.That(dbProfile.City, Is.EqualTo("city [edited]"));
        }

        [Test]
        public async Task EditUserShoukThrowException()
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => 
                await profileService.Edit("nukf", new EditProfileModel()
                {
                    Address = "The address is edited",
                    City = "city [edited]",
                    Country = " country [edited]",
                    Email = "email [edited]",
                    Name = "name [edited]",
                    PhoneNumber = "Phone [edited]",
                    ProfilePicture = null

                }));

            Assert.That(ex.Message, Is.EqualTo("This user does not exists"));
        }

        [Test]
        public async Task MyProfileShouldReturnCorrectResultIfCustomer()
        {
            var userProfile = await profileService.MyProfile("0d9e1416-60a8-4655-af48-614ff829b230", false);

            var dbUser = await repo.GetByIdAsync<User>("0d9e1416-60a8-4655-af48-614ff829b230");

            Assert.That(userProfile.Name, Is.EqualTo(dbUser.Name));
            Assert.That(userProfile.Address, Is.EqualTo(dbUser.Address));
            Assert.IsNull(userProfile.Description);
            Assert.That(userProfile.Email, Is.EqualTo(dbUser.Email));
        }

        [Test]
        public async Task MyProfileShouldThrowException()
        {
            var ex = Assert.ThrowsAsync<NullReferenceException>(async () => await
                profileService.MyProfile("some id", false));

            Assert.That(ex.Message, Is.EqualTo("This user does not exists"));
        }

        [Test]
        public async Task MyProfileShouldReturnCorrectResultIfRestaurant()
        {
            var userProfile = await profileService.MyProfile("RestaurantTestUser1", true);

            var restaurantId = await restaurantService.GetRestaurantId("RestaurantTestUser1");

            var dbUser = await repo.GetByIdAsync<Restaurant>(restaurantId);

            Assert.That(userProfile.Description, Is.EqualTo(dbUser.Description));
        }


    }
}
