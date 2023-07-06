using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.User
{
    public class UserModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string ProfilePictureUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
