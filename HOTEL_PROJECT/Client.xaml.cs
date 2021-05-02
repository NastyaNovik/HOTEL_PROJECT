using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public ClientWindow()
        {
            InitializeComponent();
            Dateofbirthday.DisplayDateEnd = DateTime.Now;
        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    connection.Open();
                    OracleParameter surname = new OracleParameter
                    {
                        ParameterName = "Surname_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Surname.Text
                    };
                    OracleParameter name = new OracleParameter
                    {
                        ParameterName = "Name_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Name.Text
                    };
                    OracleParameter secondname = new OracleParameter
                    {
                        ParameterName = "SecondName_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Secondname.Text
                    };
                    OracleParameter passport = new OracleParameter
                    {
                        ParameterName = "PassportId_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = PassportId.Text
                    };
                    OracleParameter dateOfBirth = new OracleParameter
                    {
                        ParameterName = "DateOfBirth_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Dateofbirthday.SelectedDate
                    };
                    OracleParameter phoneNumber = new OracleParameter
                    {
                        ParameterName = "PhoneNumber",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = PhoneNumber.Text
                    };

                    using (OracleCommand command = new OracleCommand("addClient"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { surname,name,secondname,passport,dateOfBirth,phoneNumber});
                        command.ExecuteNonQuery();
                        MessageBox.Show("Клиент зарегистрирован!");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
