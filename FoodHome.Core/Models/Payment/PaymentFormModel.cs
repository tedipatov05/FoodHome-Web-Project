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

        [Comment("Amount of payment")]
        [Precision(18, 2)]
        public decimal Amount { get; set; }

        [Comment("Number oif the card")]
        [StringLength(CardNumberMaxLength, MinimumLength = CardNumberMinLength)]
        public string CardNumber { get; set; } = null!;

        [Comment("Owner of the card")]
        [StringLength(CardHolderMaxLength, MinimumLength = CardHolderMinLength)]
        public string CardHolder { get; set; } = null!;

        [Comment("Date of expiration")] public DateTime ExpiryDate { get; set; }

        [Comment("Security code of the card")]
        [StringLength(SecurityCodeMaxLength, MinimumLength = SecurityCodeMinLength)]
        public string SecurityCode { get; set; } = null!;

        
    }
}
