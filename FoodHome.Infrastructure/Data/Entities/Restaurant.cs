using static FoodHome.Infrastructure.Constants.ModelValidationConstants.RestaurantConstants;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("Restaurant")]
    public class Restaurant
    {
        public Restaurant()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.Orders = new List<Order>();
            this.Menu = new HashSet<RestaurantDish>();
        }

        [Comment("Primary Key")]
        [Key]
        public string Id { get; set; }

        [Comment("User Id")]
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Comment("User")]
        public User User { get; set; } = null!;

        [Comment("Is active restaurant")]
        public bool IsActive { get; set; }

        [Comment("Description of the restaurant")]
        [MaxLength(DescriptionMaxLength)]
        
        public string? Description { get; set; }

        public ICollection<Order> Orders { get; set; }

        public ICollection<RestaurantDish> Menu { get; set; }

    }
}
