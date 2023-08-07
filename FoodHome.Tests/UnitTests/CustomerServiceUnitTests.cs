using FoodHome.Infrastructure.Data.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodHome.Tests.UnitTests
{
    [TestFixture]
    public class CustomerServiceUnitTests : BaseTests
    {
        private IRepository repo;

        [SetUp]
        public async Task SetUp()
        {
            this.repo = new Repository(this.context);
        }


    }
}
