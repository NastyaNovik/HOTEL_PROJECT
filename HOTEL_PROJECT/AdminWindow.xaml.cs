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
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.ComponentModel;
using HOTEL_PROJECT.Classes;

namespace HOTEL_PROJECT
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        BindingList<Employee> all_employees = new BindingList<Employee>();
        Employee employee;
        BindingList<Apartment> all_apartments = new BindingList<Apartment>();
        Apartment apartment;
        public AdminWindow(string login)
        {
            InitializeComponent();
            loginName.Text = login;
            getEmployees();
            employees.ItemsSource = all_employees;
            getApartments();
            aparty.ItemsSource = all_apartments;
            getPosition();
            Dateofbirthday.DisplayDateEnd = DateTime.Now;
            Dateofhiring.DisplayDateEnd = DateTime.Now;

        }
        public void getEmployees()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    connection.Open();
                    OracleParameter employ = new OracleParameter
                    {
                        ParameterName = "employee",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("getEmployees"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { employ });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            string Surname = row["Surname"].ToString();
                            string Name = row["Name"].ToString();
                            string Secondname = row["Secondname"].ToString();
                            double Salary = Convert.ToDouble(row["Salary"]);
                            string PhoneNumber = row["PhoneNumber"].ToString();
                            string Position = row["Position"].ToString();
                            string DateOfBirthday = Convert.ToDateTime(row["to_char(DateOfBirth,'DD-MM-YYYY')"]).ToString("D");
                            string DateOfHiring = Convert.ToDateTime(row["to_char(DateOfHiring,'DD-MM-YYYY')"]).ToString("D");
                            string DateOfDismissal= row["DateOfDismissal"].ToString();
                            employee = new Employee(Surname, Name, Secondname, Salary, PhoneNumber, Position, DateOfBirthday, DateOfHiring, DateOfDismissal);
                            all_employees.Add(employee);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getPosition()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    connection.Open();
                    OracleParameter employ = new OracleParameter
                    {
                        ParameterName = "position",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };
                    using (OracleCommand command = new OracleCommand("getPosition"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { employ });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                           
                            position_combo.Items.Add(row["Position"].ToString());
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void addEmployee()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    connection.Open();
                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "Login",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = loginEnter.Text
                    };
                    OracleParameter password = new OracleParameter
                    {
                        ParameterName = "Password",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = passwordEnter.Text
                    };
                    OracleParameter surname = new OracleParameter
                    {
                        ParameterName = "Surname",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Surname.Text
                    };
                    OracleParameter name = new OracleParameter
                    {
                        ParameterName = "Name",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Name.Text
                    };
                    OracleParameter secondName = new OracleParameter
                    {
                        ParameterName = "SecondName",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Secondname.Text
                    };
                    OracleParameter salary = new OracleParameter
                    {
                        ParameterName = "Salary",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Decimal,
                        Value = Decimal.Parse(Salary.Text)
                    };
                    OracleParameter phoneNumber = new OracleParameter
                    {
                        ParameterName = "PhoneNumber",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = PhoneNumber.Text
                    };
                    OracleParameter position = new OracleParameter
                    {
                        ParameterName = "EmpPosition",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = position_combo.Text
                    };
                    OracleParameter dateOfHiring = new OracleParameter
                    {
                        ParameterName = "DateOfHiring",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Dateofhiring.SelectedDate
                    };
                    OracleParameter dateOfBirth = new OracleParameter
                    {
                        ParameterName = "DateOfBirth",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Dateofbirthday.SelectedDate
                    };
                    OracleParameter accesslevel = new OracleParameter
                    {
                        ParameterName = "AccessLevel",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = AccessLevel.Text
                    };

                    using (OracleCommand command = new OracleCommand("addUser_record"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { login,password,surname,name,secondName,salary,phoneNumber,
                        position,dateOfHiring,dateOfBirth,accesslevel});
                        command.ExecuteNonQuery();
                        MessageBox.Show("Сотрудник успешно добавлен!");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getApartments()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    connection.Open();
                    OracleParameter apart = new OracleParameter
                    {
                        ParameterName = "apartment",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("getApartments"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { apart });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            int Number = Convert.ToInt32(row["NumberOfApartment"]);
                            string Category = row["Category"].ToString();
                            int CountOfSeats = Convert.ToInt32(row["CountsOfSeats"]);
                            double CostPerDay = Convert.ToDouble(row["CostPerDay"]);
                            string Status = row["Status"].ToString();
                            string Description = row["Description"].ToString();
                            byte[] img = (byte[])(row["img"]);
                            apartment = new Apartment(Number,Category,CountOfSeats,CostPerDay,Status,Description,img);
                            all_apartments.Add(apartment);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loginEnter_GotFocus(object sender, RoutedEventArgs e)
        {
            loginEnter.IsReadOnly = true;

            if (AccessLevel.Text == "1" || AccessLevel.Text == "2")
            {
                loginEnter.IsReadOnly = false;
            }
        }

        private void loginEnter_LostFocus(object sender, RoutedEventArgs e)
        {
            loginEnter.IsReadOnly = true;

            if (AccessLevel.Text == "1" || AccessLevel.Text == "2")
            {
                loginEnter.IsReadOnly = false;
            }
        }

        private void passwordEnter_LostFocus(object sender, RoutedEventArgs e)
        {
            passwordEnter.IsReadOnly = true;

            if (AccessLevel.Text == "1" || AccessLevel.Text == "2")
            {
                passwordEnter.IsReadOnly = false;
            }
        }

        private void passwordEnter_GotFocus(object sender, RoutedEventArgs e)
        {
            passwordEnter.IsReadOnly = true;

            if (AccessLevel.Text == "1" || AccessLevel.Text == "2")
            {
                passwordEnter.IsReadOnly = false;
            }
        }

        private void aparty_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Number number = new Number(all_apartments[aparty.SelectedIndex]);
            number.Show();
        }

        private void out_Click(object sender, RoutedEventArgs e)
        {
            Authorization author = new Authorization();
            author.Show();
            this.Close();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            if (Surname.Text == "" || Name.Text == "" || Secondname.Text == "" || Salary.Text == "" || PhoneNumber.Text == "" || Dateofbirthday.Text == "" ||
                Dateofhiring.Text == "")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                addEmployee();
            }

        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            all_employees.Clear();
            getEmployees();
            employees.ItemsSource = all_employees;
        }

        private void dismissal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str))
                {
                    connection.Open();
                    string Surname = all_employees[employees.SelectedIndex].Surname;
                    string Name = all_employees[employees.SelectedIndex].Name;
                    string SecondName = all_employees[employees.SelectedIndex].Secondname;
                    string PhoneNumber = all_employees[employees.SelectedIndex].PhoneNumber;

                    OracleParameter surname = new OracleParameter
                    {
                        ParameterName = "Surname_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Surname
                    };
                    OracleParameter name = new OracleParameter
                    {
                        ParameterName = "Name_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = Name
                    };
                    OracleParameter secondName = new OracleParameter
                    {
                        ParameterName = "SecondName_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = SecondName
                    };
                    OracleParameter phoneNumber = new OracleParameter
                    {
                        ParameterName = "PhoneNumber_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = PhoneNumber
                    };
                   
                    using (OracleCommand command = new OracleCommand("DismissalEmployee"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { surname,name,secondName,phoneNumber});
                        command.ExecuteNonQuery();
                        MessageBox.Show("Сотрудник успешно уволен!");
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
    

