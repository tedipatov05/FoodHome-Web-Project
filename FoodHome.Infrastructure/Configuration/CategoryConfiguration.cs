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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(GetCategories());
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>();

            categories.Add(new Category
            {
                Id = 1,
                Name = "Предястия"
            });
            categories.Add(new Category
            {
                Id = 2,
                Name = "Ястия с месо"
            });
            categories.Add(new Category
            {
                Id = 3,
                Name = "Пици",

            });
            categories.Add(new Category
            {
                Id = 4,
                Name = "Салати"
            });
            categories.Add(new Category()
            {
                Id= 5,
                Name = "Бургери", 
            });
            categories.Add(new Category()
            {
                Id = 6,
                Name = "Сандвичи"
            });
            categories.Add(new Category()
            {
                Id = 7,
                Name = "Десерти"
            });
            categories.Add(new Category()
            {
                Id = 8,
                Name = "Безалкохолни напитки"
            });
            categories.Add(new Category()
            {
                Id = 9, 
                Name = "Алкохолни напитки"
            });

            return categories;
            
        }
    }
}
