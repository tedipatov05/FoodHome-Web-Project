using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface IUserService
    {
        Task<bool> ExistsByEmail(string email);

        Task<bool> ExistsByPhone(string phone);
    }
}
