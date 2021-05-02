using HOTEL_PROJECT.Classes;
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
using System.Windows.Shapes;

namespace HOTEL_PROJECT
{
    /// <summary>
    /// Логика взаимодействия для Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        Roomer currentRoomer;
        public Payment(Roomer roomer)
        {
            InitializeComponent();
            this.currentRoomer = roomer;
            surnameClient.Text = roomer.Surname;
            nameClient.Text = roomer.Name;
            secondNameClient.Text = roomer.Secondname;
            phone.Text = roomer.PhoneNumber;
            dateb.Text = roomer.DateOfBirthday;
            numb.Text = roomer.NumberOfApartment.ToString();
            categ.Text = roomer.Category;
            countsofseats.Text = roomer.CountsOfSeats.ToString();
            arrival.Text = roomer.ArrivalDate;
            depart.Text = roomer.DateOfDeparture;
            surnameEmp.Text = roomer.SurnameEmp;
            nameEmp.Text = roomer.NameEmp;
            secondNameEmp.Text = roomer.SecondnameEmp;
            serv.Text = roomer.Service;
            servfee.Text = roomer.ServiceFee + " руб.";
            accomofee.Text = roomer.AccomodationFee + " руб.";
            total.Text = Convert.ToString(Sum(roomer.ServiceFee, roomer.AccomodationFee)) + " руб.";
        }
        public double Sum(double serv, double numb)
        {
            double sum;
            sum = serv + numb;
            return sum;
        }
    }
}
