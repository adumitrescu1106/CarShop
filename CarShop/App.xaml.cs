using CarShop.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var dbContextService = new DbContextService();
            Application.Current.Properties["DbContextService"] = dbContextService;

            // Your custom initialization code here
            var dbContext = new CarShopDB();
            dbContext.Database.CreateIfNotExists();
        }
    }
}
