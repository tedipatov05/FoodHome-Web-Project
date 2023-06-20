using static FoodHome.Infrastructure.Constants.ModelValidationConstants.UserConstants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("User")]
    public class User : IdentityUser
    {
        public User()
        {
            
            this.IsActive = true;  
        }

        [Comment("Name")]       
        
        [Required]
        [MaxLength(UserNameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("User Address")]
        [Required]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; } = null!;

        [Comment("User city")]
        [Required]
        [MaxLength(CityMaxLength)]
        public string City { get; set; } = null!;

        [Comment("User country")]
        [Required]
        [MaxLength(CountryMaxLength)]
        public string Country { get; set; } = null!;

        [Comment("User profile picture url")]
        public string? ProfilePictureUrl { get; set; }

        [Comment("Is active User")]
        public bool IsActive { get; set; }


    }
}
