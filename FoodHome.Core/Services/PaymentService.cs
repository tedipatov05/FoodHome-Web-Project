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
using Microsoft.EntityFrameworkCore;

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
            string[] expiryDate = model.ExpiryDate.Split('/');
            var payment = new Payment()
            {
                Amount = model.Amount,
                CardHolder = model.CardHolder,
                CardNumber = model.CardNumber,
                CustomerId = customerId,
                ExpiryDate = DateTime.Parse($"01/{expiryDate[0]}/20{expiryDate[1]}"),
                PaymentTime = DateTime.Now,
                SecurityCode = model.SecurityCode
               
            };

            await repo.AddAsync<Payment>(payment);
            await repo.SaveChangesAsync();

            return payment.Id;
        }

        public async Task AddPaymentOrderId(string paymentId, string orderId)
        {
            var payment = await repo.All<Payment>()
                .FirstOrDefaultAsync(p => p.Id == paymentId);

            payment.OrderId = orderId;

            await repo.SaveChangesAsync();
        }
    }
}
