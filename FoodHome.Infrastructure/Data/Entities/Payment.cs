using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using static FoodHome.Infrastructure.Constants.ModelValidationConstants.PaymentConstants;

namespace FoodHome.Infrastructure.Data.Entities
{
    [Comment("Payment for the order")]
    public class Payment
    {
        public Payment()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Comment("Id of the payment")]
        public string Id { get; set; }

        [Comment("Time of payment")]
        public DateTime PaymentTime { get; set; }

        [Comment("Id of the customer making payment")]
        [ForeignKey(nameof(Customer))]
        public string CustomerId { get; set; } = null!;

        [Comment("Customer making payment")]
        public Customer Customer { get; set; } = null!;

        [Comment("Order Id")]
        [ForeignKey(nameof(Order))]
        public string? OrderId { get; set; }

        [Comment("Order")]
        public Order? Order { get; set; }

        [Comment("Amount of payment")]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        [Comment("Number oif the card")]
        [MaxLength(CardNumberMaxLength)]
        public string CardNumber { get; set; } = null!;

        [Comment("Owner of the card")]
        [MaxLength(CardHolderMaxLength)]
        public string CardHolder { get; set; } = null!;

        [Comment("Date of expiration")]
        public DateTime ExpiryDate { get; set; }

        [Comment("Security code of the card")]
        [MaxLength(SecurityCodeMaxLength)]
        public string SecurityCode { get; set; } = null!;

        [Comment("ZIP code")]
        [MaxLength(ZipCodeMaxLength)]
        public string ZipCode { get; set; } = null!;

    }
}
