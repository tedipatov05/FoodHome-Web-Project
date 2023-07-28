using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Payment;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;

namespace FoodHome.Core.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IRepository repo;

        public PaymentService(IRepository _repo)
        {
            this.repo = _repo;
        }
        public async Task<string> CreatePayment(string customerId, PaymentFormModel model)
        {
            var payment = new Payment()
            {
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                CardNumber = model.CardNumber,
                CustomerId = customerId,
                ExpiryDate = DateTime.Parse(model.ExpiryDate),
                PaymentTime = DateTime.Now,
               
            };

            await repo.AddAsync<Payment>(payment);
            await repo.SaveChangesAsync();

            return payment.Id;
        }
    }
}
