using FoodHome.Core.Contracts;
using FoodHome.Infrastructure.Data.Common;
using FoodHome.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        public UserService(IRepository repository)
        {
            repo = repository;
        }
        public async Task<bool> ExistsByEmail(string email)
        {
            var user = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.Email == email && u.IsActive == true);  
            
            return user != null;
        }

        public async Task<bool> ExistsByPhone(string phone)
        {
            var user = await repo.All<User>()
                .FirstOrDefaultAsync(u => u.PhoneNumber == phone);

            return user != null;
        }
    }
}
