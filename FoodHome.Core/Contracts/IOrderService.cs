using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Core.Contracts
{
    public interface IOrderService
    {
        Task<List<string>> GetOrdersIdByUserId(string userId);
    }
}
