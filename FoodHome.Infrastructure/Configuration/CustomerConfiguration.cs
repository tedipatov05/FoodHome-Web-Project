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
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasData(new Customer()
            {
                Id = "1f7e2314-f3a4-4ca1-b5e3-3a1bb8b6525a",
                UserId = "d44500a1-526b-49d0-b373-05ac34baab0a"
            });
        }

    }
}
