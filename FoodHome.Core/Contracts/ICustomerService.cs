using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface ICustomerService
    {
        Task Create(string userId);
        
        Task<string> GetCustomerId(string userId);
        
    }
}
