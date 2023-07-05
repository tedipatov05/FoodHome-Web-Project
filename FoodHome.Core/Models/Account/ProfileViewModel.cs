using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Account
{
    public class ProfileViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }   
      
        public string Address { get; set; } 
      
        public string City { get; set; } 

        public string Country { get; set; } 

        public string? ProfilePictureUrl { get; set; }

        public bool IsRestaurant { get; set; }

        public string Role { get; set; }

        public int OrdersCount { get; set; }

        



    }
}
