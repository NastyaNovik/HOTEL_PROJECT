using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Oracle.ManagedDataAccess.Client;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using HOTEL_PROJECT.Classes;

namespace HOTEL_PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        
        Employee employee=new Employee();
        public Authorization()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string currUserPos = loginText.Text;
            try
            {
                using (OracleConnection oracleconnection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    oracleconnection.Open();
                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "in_login",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = loginText.Text
                    };
                    OracleParameter password = new OracleParameter
                    {
                        ParameterName = "in_password",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = passwordText.Password
                    };
                    OracleParameter user = new OracleParameter
                    {
                        ParameterName = "user_cur",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    using (OracleCommand command = new OracleCommand("findUser"))
                    {
                        command.Connection = oracleconnection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { login, password, user });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            employee.login = row["Login"].ToString();
                            employee.password = row["Password"].ToString();
                            employee.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
                        }
                    }

                    oracleconnection.Close();
                    if (currUserPos == employee.login)
                    {
                        if (currUserPos == "Администратор")
                        {
                            AdminWindow adminWindow = new AdminWindow(loginText.Text);
                            adminWindow.Show();
                            this.Close();
                        }
                        else
                        {
                            Empuser empWindow = new Empuser(loginText.Text, employee.EmployeeId);
                            empWindow.Show();
                            this.Close();
                        }
                    }
                };
            }
            catch(OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
      

        private void View_Click(object sender, RoutedEventArgs e)
        {
            if (View.IsChecked==true)
            {
                passwordTextB.Text = passwordText.Password;
                passwordTextB.Visibility = Visibility.Visible;
                passwordText.Visibility = Visibility.Hidden;
            }
            else
            {
                passwordText.Visibility = Visibility.Visible;
                passwordTextB.Visibility = Visibility.Hidden;

            }
        }
    }
}
