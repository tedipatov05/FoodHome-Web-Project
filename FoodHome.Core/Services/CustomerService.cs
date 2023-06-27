using FoodHome.Core.Contracts;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository repo;

        public CustomerService(IRepository repository)
        {
            repo = repository;  
        }
        public async Task Create(string userId)
        {
            var customer = new Customer()
            {
                UserId = userId,
            };

            await repo.AddAsync(customer);
            await repo.SaveChangesAsync();
        }
    }
}
