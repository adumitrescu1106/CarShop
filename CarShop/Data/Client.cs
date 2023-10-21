using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Car> Cars { get; set; } = new List<Car>();
    }

    public class CarShopDB : DbContext
    {
        public CarShopDB() : base(ConfigurationManager.ConnectionStrings["CarShopDb"].ConnectionString) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Car> Cars { get; set;}


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                        .HasRequired(c => c.Client)
                        .WithMany(client => client.Cars)
                        .HasForeignKey(c => c.IdClient);
        }
    }
}
