using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT.Classes
{
    public class Apartment
    {
        public int Number { get; set; }
        public string Category { get; set; }
        public int CountOfSeats { get; set; }
        public double CostPerDay { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public byte[] img { get; set; }

        public Apartment(int Number,string Category, int CountOfSeats, double CostPerDay, string Status, string Description, byte[] img)
        {
            this.Number = Number;
            this.Category = Category;
            this.CountOfSeats = CountOfSeats;
            this.CostPerDay = CostPerDay;
            this.Status = Status;
            this.Description = Description;
            this.img = img;
        }
        public Apartment() { }
    }
}
