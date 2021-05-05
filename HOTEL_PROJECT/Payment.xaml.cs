using HOTEL_PROJECT.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Image = System.Drawing.Image;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Bitmap printscreen = new Bitmap(500, 900);
                Graphics graphics = Graphics.FromImage(printscreen as Image);
                graphics.CopyFromScreen(700, 50, 0, 0, printscreen.Size);
                printscreen.Save("D:\\Ucheba\\3course_2sem\\Курсовой по БД\\screenshots\\1.jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
                 using(MailMessage mess = new MailMessage())
                {
                    SmtpClient client = new SmtpClient("smtp.mail.ru", Convert.ToInt32(587))
                    {
                        Credentials = new NetworkCredential("nastiuchanovik00@mail.ru", "kurtkobeyn"),
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };
                    mess.From = new MailAddress("nastiuchanovik00@mail.ru");
                    mess.To.Add(new MailAddress("nastyanovik0211@gmail.com"));
                    mess.Subject = Environment.UserName;
                    mess.SubjectEncoding = Encoding.UTF8;
                    mess.IsBodyHtml = true;
                    mess.Body = $"<html><h1>Ваш счет</h1></html>";
                    try
                    {
                        mess.Attachments.Add(new Attachment("D:\\Ucheba\\3course_2sem\\Курсовой по БД\\screenshots\\1.jpeg"));
                    }
                    catch { }
                    client.Send(mess);
                    mess.Dispose();
                    client.Dispose();
                    System.Windows.MessageBox.Show("Отправлено");
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Не удалось отправить счет");
            }
        }
    }
}
