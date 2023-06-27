using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Infrastructure.Configuration
{
    internal class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(GetRoles());
        }

        public List<IdentityRole> GetRoles()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole()
                {
                    Id = "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                    Name = "Administrator",
                    NormalizedName = "ADMINISTRATOR"
                },
                new IdentityRole()
                {
                    Id = "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole()
                {
                    Id = "c34ebc61-94a5-40c5-a310-798532235d8e",
                    Name = "Restaurant",
                    NormalizedName = "RESTAURANT"
                }
            };
        }

        
    }
}
