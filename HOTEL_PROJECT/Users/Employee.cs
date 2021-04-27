using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT.Users
{
    class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public DateTime DateOfHiring { get; set; }
        public DateTime DateOfBirthday { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int EmployeeId { get; set; }
    }
}
