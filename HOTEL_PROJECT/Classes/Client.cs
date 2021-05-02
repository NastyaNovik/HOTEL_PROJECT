using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT.Classes
{
    public class Client
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public string PassportId { get; set; }
        public string DateOfBirthday { get; set; }
        public string PhoneNumber { get; set; }

        public Client(int Id, string Surname, string Name, string Secondname, string PassportId, string DateOfBirthday,
            string PhoneNumber)
        {
            this.Id = Id;
            this.Surname = Surname;
            this.Name = Name;
            this.Secondname = Secondname;
            this.PassportId = PassportId;
            this.DateOfBirthday = DateOfBirthday;
            this.PhoneNumber = PhoneNumber;
        }
        public Client() { }

    }
}
