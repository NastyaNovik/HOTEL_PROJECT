using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT.Classes
{
    public class Service
    {
        public int Id { get; set; }
        public string ServiceItem { get; set; }
        public double Cost { get; set; }
        public string Description { get; set; }

        public Service(int Id,string ServiceItem, double Cost, string Description)
        {
            this.Id = Id;
            this.ServiceItem = ServiceItem;
            this.Cost = Cost;
            this.Description = Description;
        }
        public Service(string ServiceItem, double Cost, string Description)
        {
            this.ServiceItem = ServiceItem;
            this.Cost = Cost;
            this.Description = Description;
        }
        public Service() { }
    }
}
