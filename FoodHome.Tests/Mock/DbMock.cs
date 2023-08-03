using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodHome.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FoodHome.Tests.Mock
{
    public class DbMock
    {
        public static FoodHomeDbContext Instance
        {
            get
            {
                var options = new DbContextOptionsBuilder<FoodHomeDbContext>()
                    .UseInMemoryDatabase("FoodHomeInMemoryDb" + DateTime.Now.Ticks.ToString())
                    .Options;

                return new FoodHomeDbContext(options, false);
            }
        } 
    }
}
