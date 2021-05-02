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
    /// Логика взаимодействия для Empuser.xaml
    /// </summary>
    public partial class Empuser : Window
    {
        public Empuser(string login)
        {
            InitializeComponent();
            loginName.Text = login;
        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void out_Click(object sender, RoutedEventArgs e)
        {
            Authorization author = new Authorization();
            author.Show();
            this.Close();
        }
    }
}
