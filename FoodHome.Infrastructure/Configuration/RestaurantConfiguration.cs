using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Infrastructure.Configuration
{
    internal class RestaurantConfiguration : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            builder.HasData(new Restaurant()
            {
                Id = "5e364b5e-8bc2-4e8d-a3f8-72f5776fbe9d", 
                UserId = "1d1f8115-ebb2-45e0-a375-cf713385ae9c"
            });
        }
    }
}
