using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static FoodHome.Infrastructure.Constants.ModelValidationConstants.PaymentConstants;

namespace FoodHome.Core.Models.Payment
{
    public class PaymentFormModel
    {

        public decimal Amount { get; set; }

        [Required]
        [StringLength(CardNumberMaxLength, MinimumLength = CardNumberMinLength)]
        public string CardNumber { get; set; } = null!;

        [Required]
        [Comment("Owner of the card")]
        [StringLength(CardHolderMaxLength, MinimumLength = CardHolderMinLength)]
        public string CardHolder { get; set; } = null!;

        [Required]
        public string ExpiryDate { get; set; } = null!;

        [Required]
        [StringLength(SecurityCodeMaxLength, MinimumLength = SecurityCodeMinLength)]
        public string SecurityCode { get; set; } = null!;

        public string RestaurantId { get; set; } = null!;


    }
}
