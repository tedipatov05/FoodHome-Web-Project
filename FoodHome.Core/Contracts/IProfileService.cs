using FoodHome.Core.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface IProfileService
    {
        Task<ProfileViewModel> MyProfile(string userId, bool IsRestaurant);
    }
}
