﻿// <auto-generated />
using System;
using FoodHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FoodHome.Infrastructure.Migrations
{
    [DbContext(typeof(FoodHomeDbContext))]
    [Migration("20230731060112_Area")]
    partial class Area
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name of the category");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasComment("Category of the dish");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Предястия"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ястия с месо"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Пици"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Салати"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Бургери"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Сандвичи"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Десерти"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Безалкохолни напитки"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Алкохолни напитки"
                        });
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Customer", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Primary key");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is active Customer");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Customers");

                    b.HasComment("Customer in the restaurant");

                    b.HasData(
                        new
                        {
                            Id = "1f7e2314-f3a4-4ca1-b5e3-3a1bb8b6525a",
                            IsActive = true,
                            UserId = "d44500a1-526b-49d0-b373-05ac34baab0a"
                        });
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasComment("Primary key");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasComment("Category Id for the dish");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Description of the dish");

                    b.Property<string>("DishUrlImage")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Image Url for the dish");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)")
                        .HasComment("Ingredients of the dish");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is active dish");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)")
                        .HasComment("Name of the dish");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the dish");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Price of the dish");

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("RestaurantId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Dishes");

                    b.HasComment("Dish for the restaurant");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Primary key");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Customer Id");

                    b.Property<string>("DeliveryAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("Address fot delivery");

                    b.Property<DateTime?>("DeliveryTime")
                        .HasColumnType("datetime2")
                        .HasComment("Time for delivery");

                    b.Property<DateTime>("OrderTime")
                        .HasColumnType("datetime2")
                        .HasComment("Time order made");

                    b.Property<string>("PaymentId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Price of the order");

                    b.Property<string>("RestaurantId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Restaurant Id");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("Order status");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("RestaurantId");

                    b.ToTable("Orders");

                    b.HasComment("Order");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.OrderDish", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Order Id");

                    b.Property<int>("DishId")
                        .HasColumnType("int")
                        .HasComment("Dish Id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasComment("Ordered quantity");

                    b.HasKey("OrderId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("OrdersDishes");

                    b.HasComment("Order Dish");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Payment", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Id of the payment");

                    b.Property<decimal>("Amount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)")
                        .HasComment("Amount of payment");

                    b.Property<string>("CardHolder")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasComment("Owner of the card");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasComment("Number oif the card");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Id of the customer making payment");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("DATE")
                        .HasComment("Date of expiration");

                    b.Property<string>("OrderId")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Order Id");

                    b.Property<DateTime>("PaymentTime")
                        .HasColumnType("datetime2")
                        .HasComment("Time of payment");

                    b.Property<string>("SecurityCode")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)")
                        .HasComment("Security code of the card");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("OrderId")
                        .IsUnique()
                        .HasFilter("[OrderId] IS NOT NULL");

                    b.ToTable("Payments");

                    b.HasComment("Payment for the order");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Restaurant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasComment("Primary Key");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasComment("Description of the restaurant");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is active restaurant");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)")
                        .HasComment("User Id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Restaurants");

                    b.HasComment("Restaurant");

                    b.HasData(
                        new
                        {
                            Id = "5e364b5e-8bc2-4e8d-a3f8-72f5776fbe9d",
                            Description = "Welcome to our restaurant, where the gourmet experience becomes a real symphony of flavors. Our establishment offers a cozy and sophisticated environment where you can enjoy the unique combination of culinary delights and refined drinks.",
                            IsActive = true,
                            UserId = "1d1f8115-ebb2-45e0-a375-cf713385ae9c"
                        });
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasComment("User Address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(169)
                        .HasColumnType("nvarchar(169)")
                        .HasComment("User city");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(56)
                        .HasColumnType("nvarchar(56)")
                        .HasComment("User country");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasComment("Is active User");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePictureUrl")
                        .HasColumnType("nvarchar(max)")
                        .HasComment("User profile picture url");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasComment("User");

                    b.HasData(
                        new
                        {
                            Id = "d44500a1-526b-49d0-b373-05ac34baab0a",
                            AccessFailedCount = 0,
                            Address = "ул. Ал. Стамболийски 30 ет.3 ап.11",
                            City = "Казанлък",
                            ConcurrencyStamp = "5904044e-adc8-48ac-990d-40f9399ade78",
                            Country = "България",
                            Email = "ivonpatova@abv.bg",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            Name = "Ивон Патова",
                            NormalizedEmail = "IVONPATOVA@ABV.BG",
                            NormalizedUserName = "IVON",
                            PasswordHash = "AQAAAAEAACcQAAAAEBsZ4slGY+QRs+lDfk5gqHINlcIVedkgv/aQB7nXz5LvuxtkrESJ18kwDImLCW4pDw==",
                            PhoneNumber = "0887399847",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1687251175/images/photo-1574701148212-8518049c7b2c_zmlive.jpg",
                            SecurityStamp = "23b2dffd-508d-401c-b4e4-cbdb340a3fa1",
                            TwoFactorEnabled = false,
                            UserName = "ivon"
                        },
                        new
                        {
                            Id = "0d9e1416-60a8-4655-af48-614ff829b230",
                            AccessFailedCount = 0,
                            Address = "ул. Ал. Батенберг 15 ет.5 ап.20",
                            City = "Казанлък",
                            ConcurrencyStamp = "9c9a4611-ea3b-48a7-991b-481d69976dd0",
                            Country = "България",
                            Email = "tedipatov19@abv.bg",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            Name = "Теодор Патов",
                            NormalizedEmail = "TEDIPATOV19@ABV.BG",
                            NormalizedUserName = "TEODOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEIdrJffrC04yQCClsI1is2FPYWgpW1nKzOs3dMQ6N+1aNsST0hhzHnFHbk48jMGcgg==",
                            PhoneNumber = "0898392743",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1687251587/images/ap22312071681283-0d9c328f69a7c7f15320e8750d6ea447532dff66-s1100-c50_puo5bp.jpg",
                            SecurityStamp = "96402ba9-1b00-4415-94b2-0cffd159451e",
                            TwoFactorEnabled = false,
                            UserName = "teodor"
                        },
                        new
                        {
                            Id = "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                            AccessFailedCount = 0,
                            Address = "ул. Цар Освободител 21",
                            City = "Казанлък",
                            ConcurrencyStamp = "24e963b0-03c3-4908-9dba-c7fa661ba273",
                            Country = "България",
                            Email = "vikifoods@abv.bg",
                            EmailConfirmed = false,
                            IsActive = true,
                            LockoutEnabled = false,
                            Name = "Viki Foods",
                            NormalizedEmail = "VIKIFOODS@ABV.BG",
                            NormalizedUserName = "VIKIFOODS",
                            PasswordHash = "AQAAAAEAACcQAAAAECUKAu3GJ20EYANCgNWCX7avFiYkoyjqTqqeMQW7lplctMEcgi9AQsRhT+9f2Ba+yA==",
                            PhoneNumber = "0885732771",
                            PhoneNumberConfirmed = false,
                            ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1687252340/images/logo-no-background_yvrwc2.png",
                            SecurityStamp = "9b0d189f-443f-4f25-ac79-05fb6e473ab6",
                            TwoFactorEnabled = false,
                            UserName = "VikiFoods"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                            ConcurrencyStamp = "043b7791-69ea-45c1-b08c-afd9c10b8885",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                            ConcurrencyStamp = "d6a25c34-2994-4c26-9020-de6ae366f37d",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "c34ebc61-94a5-40c5-a310-798532235d8e",
                            ConcurrencyStamp = "5a88f61c-b306-49ff-9fd1-3f06fc3f84a0",
                            Name = "Restaurant",
                            NormalizedName = "RESTAURANT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "0d9e1416-60a8-4655-af48-614ff829b230",
                            RoleId = "a297aac9-aa64-4313-8c50-1d3cf7f379ba"
                        },
                        new
                        {
                            UserId = "d44500a1-526b-49d0-b373-05ac34baab0a",
                            RoleId = "a03f9f62-f106-4b1a-b1f9-eba622db3c92"
                        },
                        new
                        {
                            UserId = "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                            RoleId = "c34ebc61-94a5-40c5-a310-798532235d8e"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Customer", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Dish", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("Menu")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Order", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Restaurant", "Restaurant")
                        .WithMany("Orders")
                        .HasForeignKey("RestaurantId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Restaurant");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.OrderDish", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Dish", "Dish")
                        .WithMany("Orders")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Order", "Order")
                        .WithMany("Dishes")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Payment", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHome.Infrastructure.Data.Entities.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("FoodHome.Infrastructure.Data.Entities.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Restaurant", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FoodHome.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FoodHome.Infrastructure.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Dish", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Order", b =>
                {
                    b.Navigation("Dishes");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("FoodHome.Infrastructure.Data.Entities.Restaurant", b =>
                {
                    b.Navigation("Menu");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
