using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Core.Contracts;
using FoodHome.Core.Models.Payment;
using FoodHome.Core.Services;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using NUnit.Framework;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class PaymentServiceUnitTests : BaseTests
    {
        private IRepository repo;
        private IPaymentService paymentService;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(context);
            this.paymentService = new PaymentService(repo);
        }

        [Test]
        public async Task CreatePaymentShouldReturnCorrectResult()
        {
            var paymentFormModel = new PaymentFormModel()
            {
                Amount = 20.00m,
                CardHolder = "TestHolder",
                CardNumber = "0388599583095835323",
                ExpiryDate = "12/23",
                RestaurantId = "44b29798-13fa-487e-819e-710d59613dd2",
                SecurityCode = "123"
            };
            
             var id = await paymentService.CreatePayment("db27df32-4380-4098-9671-5df6d43cbc43", paymentFormModel);

            var payment = await repo.GetByIdAsync<Payment>(id);

            Assert.IsNotNull(payment);
            Assert.That(payment.Amount, Is.EqualTo(paymentFormModel.Amount));
            Assert.That(payment.CardHolder, Is.EqualTo(paymentFormModel.CardHolder));
            Assert.That(payment.CardNumber, Is.EqualTo(paymentFormModel.CardNumber));

        }


    }
}
