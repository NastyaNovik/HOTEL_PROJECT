using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT.Classes
{
    public class Roomer
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public string PassportId { get; set; }
        public string DateOfBirthday { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfApartment { get; set; }
        public string Category { get; set; }
        public int CountsOfSeats { get; set; }
        public string ArrivalDate { get; set; }
        public string DateOfDeparture { get; set; }
        public string SurnameEmp { get; set; }
        public string NameEmp { get; set; }
        public string SecondnameEmp { get; set; }
        public string Service { get; set; }
        public double ServiceFee { get; set; }
        public double AccomodationFee { get; set; }
        public Roomer(int Id, string Surname, string Name, string Secondname, string PassportId, string DateOfBirthday,
            string PhoneNumber, int NumberOfApartment, string Category, int CountsOfSeats, string ArrivalDate, string DateOfDeparture,
            string SurnameEmp, string NameEmp, string SecondnameEmp, string Service, double ServiceFee, double AccomodationFee )
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Secondname = Secondname;
            this.PassportId = PassportId;
            this.DateOfBirthday = DateOfBirthday;
            this.PhoneNumber = PhoneNumber;
            this.NumberOfApartment = NumberOfApartment;
            this.Category = Category;
            this.CountsOfSeats = CountsOfSeats;
            this.ArrivalDate = ArrivalDate;
            this.DateOfDeparture = DateOfDeparture;
            this.SurnameEmp = SurnameEmp;
            this.NameEmp = NameEmp;
            this.SecondnameEmp = SecondnameEmp;
            this.Service = Service;
            this.ServiceFee = ServiceFee;
            this.AccomodationFee = AccomodationFee;
        }
        public Roomer(string Surname, string Name, string Secondname, string PassportId, string DateOfBirthday,
            string PhoneNumber, int NumberOfApartment, string Category, int CountsOfSeats, string ArrivalDate, string DateOfDeparture,
            string SurnameEmp, string NameEmp, string SecondnameEmp, string Service, double ServiceFee, double AccomodationFee)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Secondname = Secondname;
            this.PassportId = PassportId;
            this.DateOfBirthday = DateOfBirthday;
            this.PhoneNumber = PhoneNumber;
            this.NumberOfApartment = NumberOfApartment;
            this.Category = Category;
            this.CountsOfSeats = CountsOfSeats;
            this.ArrivalDate = ArrivalDate;
            this.DateOfDeparture = DateOfDeparture;
            this.SurnameEmp = SurnameEmp;
            this.NameEmp = NameEmp;
            this.SecondnameEmp = SecondnameEmp;
            this.Service = Service;
            this.ServiceFee = ServiceFee;
            this.AccomodationFee = AccomodationFee;
        }
    }
}
