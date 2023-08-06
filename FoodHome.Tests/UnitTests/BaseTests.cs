using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Infrastructure.Data;
using FoodHome.Infrastructure.Data.Entities;
using FoodHome.Infrastructure.Data.Entities.Enums;
using FoodHome.Tests.Mock;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;

namespace FoodHome.Tests.UnitTests
{
    public class BaseTests
    {
        protected List<IdentityRole> roles;
        protected List<User> users;
        protected List<Customer> customers;
        protected List<Restaurant> restaurants;
        protected List<Order> orders;
        protected List<Dish> dishes;
        protected List<OrderDish> orderDishes;
        protected List<Payment> payments;
        protected List<Category> categories;
        protected List<IdentityUserRole<string>> userRoles;

        protected FoodHomeDbContext context;

        [SetUp]
        public async Task SetUpBase()
        {
            this.context = DbMock.Instance;
            await this.SeedData();
        }

        public async Task SeedData()
        {
            categories = new List<Category>()
            {
                new Category
                {
                    Id = 1,
                    Name = "Предястия"
                },
                new Category
                {
                    Id = 2,
                    Name = "Ястия с месо"
                },
                new Category
                {
                    Id = 3,
                    Name = "Пици",

                },
                new Category
                {
                    Id = 4,
                    Name = "Салати"
                },
                new Category()
                {
                    Id = 5,
                    Name = "Бургери",
                },
                new Category()
                {
                    Id = 6,
                    Name = "Сандвичи"
                },
                new Category()
                {
                    Id = 7,
                    Name = "Десерти"
                },
                new Category()
                {
                    Id = 8,
                    Name = "Безалкохолни напитки"
                },
                new Category()
                {
                    Id = 9,
                    Name = "Алкохолни напитки"
                }
            };

            await context.Categories.AddRangeAsync(categories);


            users = new List<User>()
            {
                new User()
                {
                    Id = "0d9e1416-60a8-4655-af48-614ff829b230",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@mail.com",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    PhoneNumber = "0885743623",
                    Name = "Admin",
                    City = "Kazanlak",
                    Address = "Al. Stamboliiski 30",
                    Country = "Bulgaria"
                }
            };


            customers = new List<Customer>()
            {
                new Customer()
                {
                    Id = "db27df32-4380-4098-9671-5df6d43cbc43",
                    User = new User()
                    {
                        Id = "CustomerTestUser1",
                        UserName = "TestUser",
                        NormalizedUserName = "TESTUSER",
                        Email = "testUser1@mail.bg",
                        NormalizedEmail = "TESTUSER1@MAIL.BG",
                        PhoneNumber = "0887896734",
                        Name = "Test Client",
                        City = "Kazanlak",
                        Country = "Bulgaria",
                        Address = "Test address"

                    }

                },
                new Customer()
                {
                    Id = "e6a48c42-469a-4b69-871b-c8554602afff",
                    User = new User()
                    {
                        Id = "CustomerTestUser2",
                        UserName = "TestUser2",
                        NormalizedUserName = "TESTUSER2",
                        Email = "testUser2@mail.bg",
                        NormalizedEmail = "TESTUSER2@MAIL.BG",
                        PhoneNumber = "0887896723",
                        Name = "Test Client2",
                        City = "Kazanlak2",
                        Country = "Bulgaria2",
                        Address = "Test address2", 
                        IsActive = false

                    },
                    IsActive = false

                }


            };

            restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Id = "44b29798-13fa-487e-819e-710d59613dd2",
                    User = new User()
                    {
                        Id = "RestaurantTestUser1",
                        UserName = "RestaurantUser1",
                        NormalizedUserName = "RESTAURANTUSER1",
                        Email = "restUser1@mail.bg",
                        NormalizedEmail = "RESTUSER1@MAIL.BG",
                        PhoneNumber = "0884396723",
                        Name = "Test Restaurant1",
                        City = "Kazanlak",
                        Country = "Bulgaria",
                        Address = "Test address",
                    }
                },
                new Restaurant()
                {
                    Id = "b84e701c-b917-411d-946d-20be982f6da1",
                    User = new User()
                    {
                        Id = "RestaurantTestUser2",
                        UserName = "RestaurantUser2",
                        NormalizedUserName = "RESTAURANTUSER2",
                        Email = "restUser2@mail.bg",
                        NormalizedEmail = "RESTUSER2@MAIL.BG",
                        PhoneNumber = "0884354723",
                        Name = "Test Restaurant2",
                        City = "Kazanlak",
                        Country = "Bulgaria",
                        Address = "Test address",
                        IsActive = false
                    }, 
                    IsActive = false
                }
            };

            roles = new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "admin",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole()
                {
                    Id = "customer",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole()
                {
                    Id = "restaurant",
                    Name = "Restaurant",
                    NormalizedName = "RESTAURANT"
                }
            };

            userRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>()
                {
                    RoleId = "restaurant",
                    UserId = "RestaurantTestUser1"
                }
            };

            

            dishes = new List<Dish>()
            {
                new Dish()
                {
                    Id = 1, 
                    Name = "Test Dish",
                    CategoryId = 1, 
                    Description = "test description", 
                    Ingredients = "some ingredients", 
                    Price = 12.00m, 
                    IsActive = true, 
                    RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2",
                    Quantity = 10

                },
                new Dish()
                {
                    Id = 2,
                    Name = "Test Dish2",
                    CategoryId = 2,
                    Description = "test description2",
                    Ingredients = "some ingredients2",
                    Price = 13.00m,
                    IsActive = true,
                    RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2",
                    Quantity = 12

                },
                new Dish()
                {
                    Id = 3,
                    Name = "Test Dish3",
                    CategoryId = 1,
                    Description = "test description3",
                    Ingredients = "some ingredients3",
                    Price = 15.00m,
                    IsActive = true,
                    RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2",
                    Quantity = 17

                },
            };

            

            orders = new List<Order>()
            {
                new Order()
                {
                    Id = "order1", 
                    CustomerId = "db27df32-4380-4098-9671-5df6d43cbc43", 
                    DeliveryAddress = "delivery address test 1",
                    DeliveryTime = null,
                    OrderTime = DateTime.Now,
                    Price = 30.00m,
                    Status = OrderStatusEnum.Waiting.ToString(), 
                    PaymentId = "payment1",
                    RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2"
                },
                new Order()
                {
                    Id = "order2",
                    CustomerId = "db27df32-4380-4098-9671-5df6d43cbc43",
                    DeliveryAddress = "delivery address test 2",
                    DeliveryTime = DateTime.Now,
                    OrderTime = DateTime.Now,
                    Price = 20.00m,
                    Status = OrderStatusEnum.Confirmed.ToString(),
                    PaymentId = "payment2",
                    RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2"
                },
            };

            payments = new List<Payment>()
            {
                new Payment()
                {
                    Id = "payment1",
                    Amount = 30.00m,
                    CardHolder = "Ivan",
                    CardNumber = "9088347299048284",
                    CustomerId = "db27df32-4380-4098-9671-5df6d43cbc43",
                    ExpiryDate = DateTime.Parse("01/12/2023"),
                    OrderId = "order1",
                    SecurityCode = "136"


                },
                new Payment()
                {
                    Id = "payment2",
                    Amount = 20.00m,
                    CardHolder = "Peter",
                    CardNumber = "9088347297848284",
                    CustomerId = "db27df32-4380-4098-9671-5df6d43cbc43",
                    ExpiryDate = DateTime.Parse("01/11/2023"),
                    OrderId = "order2",
                    SecurityCode = "134"

                },

            };

            orderDishes = new List<OrderDish>()
            {
                new OrderDish()
                {
                    DishId = 1,
                    OrderId = "order1"
                },
                new OrderDish()
                {
                    DishId = 2,
                    OrderId = "order1"
                }, 
                new OrderDish()
                {
                    DishId = 3, 
                    OrderId = "order2"
                }, 
                new OrderDish()
                {
                    DishId = 2, 
                    OrderId = "order2"
                }
            };



            await context.Users.AddRangeAsync(users);
            await context.Roles.AddRangeAsync(roles);
            await context.UserRoles.AddRangeAsync(userRoles);
            await context.Customers.AddRangeAsync(customers);
            await context.Categories.AddRangeAsync(categories);
            await context.Restaurants.AddRangeAsync(restaurants);
            await context.Dishes.AddRangeAsync(dishes);
            await context.Orders.AddRangeAsync(orders);
            await context.OrdersDishes.AddRangeAsync(orderDishes);
            await context.Payments.AddRangeAsync(payments);

            await context.SaveChangesAsync();

        }

        public async Task TearDownBase()
        {
            await this.context.DisposeAsync();
        }

    }
}
