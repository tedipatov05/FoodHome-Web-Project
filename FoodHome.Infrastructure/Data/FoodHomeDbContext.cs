using FoodHome.Infrastructure.Configuration;
using FoodHome.Infrastructure.Data.Entities;
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
        private bool seedDb;

        public FoodHomeDbContext(DbContextOptions<FoodHomeDbContext> options, bool seed = true)
            : base(options)
        {
            if (this.Database.IsRelational())
            {
                this.Database.Migrate();
            }
            else
            {
                this.Database.EnsureCreated();
            }

            seedDb = seed;
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Dish> Dishes { get; set; }

        public DbSet<Order> Orders { get; set; }    

        public DbSet<OrderDish> OrdersDishes { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantDish> RestaurantDishes { get; set; }

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

            builder.Entity<OrderDish>()
                .HasKey(od => new { od.OrderId, od.DishId });

            builder.Entity<RestaurantDish>()
                .HasKey(rd => new { rd.RestaurantId, rd.DishId });

            if (seedDb)
            {
                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new RolesConfiguration());
                builder.ApplyConfiguration(new UsersRolesConfiguration());
                builder.ApplyConfiguration(new CustomerConfiguration());
                builder.ApplyConfiguration(new RestaurantConfiguration());
            }


            
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
