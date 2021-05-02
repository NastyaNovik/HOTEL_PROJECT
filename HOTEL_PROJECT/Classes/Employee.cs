using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT.Classes
{
    public class Employee
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string DateOfHiring { get; set; }
        public string DateOfBirthday { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int EmployeeId { get; set; }
        public string DateOfDismissal { get; set; }


        public Employee(string Surname, string Name, string Secondname, double Salary, string PhoneNumber, string Position,
            string DateOfBirthday, string DateOfHiring, string DateOfDismissal)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Secondname = Secondname;
            this.Salary = Salary;
            this.PhoneNumber = PhoneNumber;
            this.Position = Position;
            this.DateOfBirthday = DateOfBirthday;
            this.DateOfHiring = DateOfHiring;
            this.DateOfDismissal = DateOfDismissal;
        }
        public Employee() { }
    }
}
