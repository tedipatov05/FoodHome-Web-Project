using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Models.Payment;

namespace FoodHome.Core.Contracts
{
    public interface IPaymentService
    {
        Task<string> CreatePayment(string customerId, PaymentFormModel model);
    }
}
