﻿using FoodHome.Infrastructure.Configuration;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Infrastructure.Data
{
    public class FoodHomeDbContext : IdentityDbContext<User>
    {
        //private bool seedDb;

        public FoodHomeDbContext(DbContextOptions<FoodHomeDbContext> options)
            : base(options)
        {
           
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Dish> Dishes { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public DbSet<OrderDish> OrdersDishes { get; set; } = null!;

        public DbSet<Restaurant> Restaurants { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            


            builder.Entity<User>()
                .Property(u => u.UserName)
                .HasMaxLength(20)
                .IsRequired();

            builder.Entity<User>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            builder.Entity<Order>()
                .HasOne(o => o.Restaurant)
                .WithMany(r => r.Orders)
                .OnDelete(DeleteBehavior.NoAction);
                

            builder.Entity<Restaurant>()
                .HasMany(r => r.Orders)
                .WithOne(o => o.Restaurant)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Restaurant>()
                .HasMany(r => r.Menu)
                .WithOne(d => d.Restaurant)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Restaurant>()
                .Property(r => r.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Entity<OrderDish>()
                .HasKey(od => new { od.OrderId, od.DishId });

            builder.Entity<Dish>()
                .HasOne(d => d.Restaurant)
                .WithMany(d => d.Menu)
                .HasForeignKey(d => d.RestaurantId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(builder);




            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RolesConfiguration());
            builder.ApplyConfiguration(new UsersRolesConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new RestaurantConfiguration());
            

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
