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
    internal class UsersRolesConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(GetUserRoles());
        }

        public List<IdentityUserRole<string>> GetUserRoles()
        {
            return new List<IdentityUserRole<string>>(){ 

                new IdentityUserRole<string>()
                {
                    RoleId = "a297aac9-aa64-4313-8c50-1d3cf7f379ba",
                    UserId = "0d9e1416-60a8-4655-af48-614ff829b230"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "a03f9f62-f106-4b1a-b1f9-eba622db3c92",
                    UserId =  "d44500a1-526b-49d0-b373-05ac34baab0a"
                },
                new IdentityUserRole<string>()
                {
                    RoleId = "c34ebc61-94a5-40c5-a310-798532235d8e", 
                    UserId = "1d1f8115-ebb2-45e0-a375-cf713385ae9c"
                }

            };
        }
    }
}
