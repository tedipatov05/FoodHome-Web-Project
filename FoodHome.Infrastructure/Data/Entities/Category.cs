using static FoodHome.Infrastructure.Constants.ModelValidationConstants.CategoryConstants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("Category of the dish")]
    public class Category
    {
        [Comment("Primary key ")]
        [Key]
        public int Id { get; set; }

        [Comment("Name of the category")]
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
