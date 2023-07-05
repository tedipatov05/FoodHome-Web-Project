using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Models.Restaurant
{
    public class RestaurantDetailsViewModel
    {
        public string Id { get; set; }

        public string? PictureUrl { get; set; }

        public string? Description { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; } 
    }
}
