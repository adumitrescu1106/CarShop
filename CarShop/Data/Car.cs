using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Data
{
    public class Car
    {
        public int Id { get; set; }

        public string Make { get; set; }
        
        public string Model { get; set; }
        
        public int Year { get; set; }
        
        public string Color { get; set; }
        
        public DateTime CreatedAt {  get; set; }

        public DateTime LastUpdatedAt { get; set;}

        public int IdClient { get; set; }

        public Client Client { get; set; }
    }
}
