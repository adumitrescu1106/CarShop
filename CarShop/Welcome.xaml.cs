using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using CarShop.Data;
using Microsoft.EntityFrameworkCore;

namespace CarShop
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public int ClientId;
        CarShopDB _dbContainer;
        Car NewCar = new Car();

        public Welcome()
        {
            var dbContextService = Application.Current.Properties["DbContextService"] as DbContextService;
            this._dbContainer = dbContextService.GetDbContext();
            InitializeComponent();
            GetCars();
            AddNewCarGrid.DataContext = NewCar;

        }

        public Welcome(int clientId)
        {
            ClientId = clientId;
            var dbContextService = Application.Current.Properties["DbContextService"] as DbContextService;
            this._dbContainer = dbContextService.GetDbContext();
            InitializeComponent();
            GetCars();
            AddNewCarGrid.DataContext = NewCar;
        }

        private void Welcome_OnLoaded(object sender, RoutedEventArgs e)
        {
            _dbContainer = new CarShopDB();
        }    

        private void GetCars()
        {
            CarDG.ItemsSource = _dbContainer.Cars.Where(x => x.IdClient == ClientId).ToList();
        }

        private void AddCar(object s, RoutedEventArgs e)
        {
            NewCar.CreatedAt = DateTime.Now;
            NewCar.LastUpdatedAt = DateTime.Now;
            NewCar.IdClient = ClientId;
            NewCar.Client = _dbContainer.Clients.Find(ClientId);
            _dbContainer.Cars.Add(NewCar);
            _dbContainer.SaveChanges();
            GetCars();
            NewCar = new Car();
            AddNewCarGrid.DataContext = NewCar;
        }

        Car selectedCar = new Car();

        private void UpdateCarForEdit(object s, RoutedEventArgs e)
        {
            selectedCar = (s as FrameworkElement).DataContext as Car;
            UpdateCarGrid.DataContext = selectedCar;
        }

        private void UpdateCar(object s, RoutedEventArgs e)
        {
            _dbContainer.SaveChanges();
            GetCars();
        }

        private void DeleteCar(object s, RoutedEventArgs e)
        {
            var productToBeDeleted = (s as FrameworkElement).DataContext as Car;
            _dbContainer.Cars.Remove(productToBeDeleted);
            _dbContainer.SaveChanges();
            GetCars();
        }
    }
}
