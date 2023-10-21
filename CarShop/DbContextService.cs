using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop
{
    public class DbContextService : IDisposable
    {
        private CarShopDB context;

        public DbContextService()
        {
            context = new CarShopDB();
        }

        public CarShopDB GetDbContext()
        {
            return context;
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
