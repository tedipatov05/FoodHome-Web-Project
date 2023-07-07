using FoodHome.Core.Contracts;
using FoodHome.Core.Models.User;
using FoodHome.Infrastructure.Constants;
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

        public async Task<UserModel> GetAdmin()
        {
            var admin = await repo.All<User>()
                .Where(u => u.Id == AdministratorConstants.Id)
                .Select(u => new UserModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber, 
                    Country = u.Country,
                    City = u.City, 
                    Address = u.Address, 
                    ProfilePictureUrl = u.ProfilePictureUrl,
                    IsActive = u.IsActive
                })
                .FirstOrDefaultAsync();

            return admin;
            
        }

        public async Task<UserModel> GetUserByIdAsync(string userId)
        {
            var user = await repo.GetByIdAsync<User>(userId);

            if (user == null || !user.IsActive)
            {
                throw new NullReferenceException("This user does not exists");
            }

            var userModel = new UserModel()
            {
                Id = userId,
                Name = user.Name,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country, 
                City = user.City,
                Address = user.Address, 
                ProfilePictureUrl = user.ProfilePictureUrl,
                
            };

            return userModel;
        }
    }
}
