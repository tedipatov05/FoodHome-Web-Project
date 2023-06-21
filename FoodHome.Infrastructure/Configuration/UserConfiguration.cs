using FoodHome.Infrastructure.Data.Entities;
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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(CreateUsers());
        }

        public List<User> CreateUsers()
        {
            List<User> users = new List<User>();
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            var user = new User()
            {
                Id = "d44500a1-526b-49d0-b373-05ac34baab0a",
                UserName = "ivon",
                NormalizedUserName = "IVON",
                Email = "ivonpatova@abv.bg",
                NormalizedEmail = "IVONPATOVA@ABV.BG",
                PhoneNumber = "0887399847",
                Name = "Ивон Патова",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Ал. Стамболийски 30 ет.3 ап.11",
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1687251175/images/photo-1574701148212-8518049c7b2c_zmlive.jpg"
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "100722");
            users.Add(user);

            var user2 = new User()
            {
                Id = "0d9e1416-60a8-4655-af48-614ff829b230", 
                UserName = "teodor", 
                NormalizedUserName = "TEODOR", 
                Email = "tedipatov19@abv.bg", 
                NormalizedEmail = "TEDIPATOV19@ABV.BG", 
                PhoneNumber = "0898392743", 
                Name = "Теодор Патов", 
                City = "Казанлък",
                Country = "България", 
                Address = "ул. Ал. Батенберг 15 ет.5 ап.20", 
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1687251587/images/ap22312071681283-0d9c328f69a7c7f15320e8750d6ea447532dff66-s1100-c50_puo5bp.jpg"

            };
            user2.PasswordHash = passwordHasher.HashPassword(user2, "ivon1007");
            users.Add(user2);

            var user3 = new User()
            {
                Id = "1d1f8115-ebb2-45e0-a375-cf713385ae9c",
                UserName = "VikiFoods",
                NormalizedUserName = "VIKIFOODS",
                Email = "vikifoods@abv.bg",
                NormalizedEmail = "VIKIFOODS@ABV.BG",
                PhoneNumber = "0885732771",
                Name = "Viki Foods",
                City = "Казанлък",
                Country = "България",
                Address = "ул. Цар Освободител 21",
                ProfilePictureUrl = "https://res.cloudinary.com/ddriqreo7/image/upload/v1687252340/images/logo-no-background_yvrwc2.png"
            };

            user3.PasswordHash = passwordHasher.HashPassword(user3, "vikiFoods234");
            users.Add(user3);

            return users;

        }
    }
}
