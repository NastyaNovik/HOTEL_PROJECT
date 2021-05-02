using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using HOTEL_PROJECT.Classes;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace HOTEL_PROJECT
{
    /// <summary>
    /// Логика взаимодействия для Number.xaml
    /// </summary>
    public partial class Number : Window
    {
        Apartment apartment;
        public Number(Apartment apartment)
        {
 
            InitializeComponent();
            this.apartment = apartment;
            numb.Text = apartment.Number.ToString();
            cat.Text = apartment.Category;
            countofseats.Text = apartment.CountOfSeats.ToString();
            cost.Text = apartment.CostPerDay.ToString();
            description.Text = apartment.Description;

            MemoryStream strIm = new MemoryStream(apartment.img);
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            myBitmapImage.StreamSource = strIm;
            myBitmapImage.DecodePixelWidth = 283;
            myBitmapImage.DecodePixelHeight = 184;
            myBitmapImage.EndInit();
            photo.Source = myBitmapImage;
        }
    }
}

