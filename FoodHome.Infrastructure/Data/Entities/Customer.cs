using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("Customer in the restaurant")]
    public class Customer
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsActive = true;
            this.Orders = new List<Order>();
        }

        [Comment("Primary key")]
        [Key]
        public string Id { get; set; }

        [Comment("User Id")]
        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        [Comment("User")]
        public User User { get; set; } = null!;

        [Comment("Is active Customer")]
        public bool IsActive { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
