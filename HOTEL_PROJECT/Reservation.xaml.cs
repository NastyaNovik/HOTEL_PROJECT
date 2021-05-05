using HOTEL_PROJECT.Classes;
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
    /// Логика взаимодействия для Reservation.xaml
    /// </summary>
    public partial class Reservation : Window
    {
        Client client = new Client();
        Service serviceobj = new Service();
        Employee employee = new Employee();
        Apartment apartid = new Apartment();
        public Reservation(string login, string surnameClient_in, string nameClient_in, string secondnameClient_in, int ClientId,
            int EmployeeId)
        {
            InitializeComponent();
            loginName.Text = login;
            surnameClient.Text = surnameClient_in;
            nameClient.Text = nameClient_in;
            secondNameClient.Text = secondnameClient_in;
            client.Id = ClientId;
            employee.EmployeeId = EmployeeId;
            getFIOEMp();
            getServices();
            getEmptyApartments();
            Dateofarrival.DisplayDateStart = DateTime.Now;
           
        }
        public void getFIOEMp()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter login = new OracleParameter
                    {
                        ParameterName = "in_password",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = loginName.Text
                    };
                    OracleParameter emp = new OracleParameter
                    {
                        ParameterName = "emp",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getEmployeeFIO"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { login, emp });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            string surname = row["Surname"].ToString();
                            string name = row["Name"].ToString();
                            string secondname = row["SecondName"].ToString();
                            FEmp.Text = surname;
                            IEmp.Text = name;
                            OEmp.Text= secondname;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getServices()
        {
            servic_combo.Items.Clear();
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter servic = new OracleParameter
                    {
                        ParameterName = "servic",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getServices"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { servic });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            servic_combo.Items.Add(row["Service"].ToString());
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getEmptyApartmentsbeforereservation()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter arivpart = new OracleParameter
                    {
                        ParameterName = "ArrivalDate_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Dateofarrival.SelectedDate
                    };
                    OracleParameter depart = new OracleParameter
                    {
                        ParameterName = "DateOfDeparture_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Dateofadeparture.SelectedDate
                    };
                    OracleParameter apart = new OracleParameter
                    {
                        ParameterName = "apart",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getEmptyApartmentsbeforereservation"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { arivpart,depart,apart });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            apartment_combo.Items.Add(row["NumberOfApartment"].ToString() + " " + row["Category"].ToString() + " " +
                                 row["CountsOfSeats"].ToString());
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getEmptyApartments()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter apart = new OracleParameter
                    {
                        ParameterName = "apart",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getEmptyApartments"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { apart });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            apartment_combo.Items.Add(row["NumberOfApartment"].ToString()+" "+ row["Category"].ToString()+" "+
                                 row["CountsOfSeats"].ToString());
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getServiceId()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter service = new OracleParameter
                    {
                        ParameterName = "nameofservice",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Varchar2,
                        Value = servic_combo.Text
                    };
                    OracleParameter servic = new OracleParameter
                    {
                        ParameterName = "servic",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getServiceId"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { service,servic });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            serviceobj.Id =Convert.ToInt32(row["Id"]);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getApartmentId()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter service = new OracleParameter
                    {
                        ParameterName = "Numberofapartment_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = Convert.ToInt32(apartment_combo.Text.Substring(0,3))
                    };
                    OracleParameter ap = new OracleParameter
                    {
                        ParameterName = "ap",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getApartmentId"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { service, ap });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            apartid.Id = Convert.ToInt32(row["Id"]);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Dateofarrival_CalendarClosed(object sender, RoutedEventArgs e)
        {
            Dateofadeparture.DisplayDateStart = Dateofarrival.SelectedDate.Value.AddDays(1);
            Dateofadeparture.IsEnabled = true;
          // Dateofadeparture.DisplayDateStart = Dateofarrival.SelectedDate;

        }

        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            if (apartment_combo.Text == ""||Dateofarrival.SelectedDate==null||Dateofadeparture.SelectedDate==null||servic_combo.Text=="")
            {
                MessageBox.Show("Не все поля заполнены");
            }
            else
            {
                getServiceId();
                getApartmentId();
            
            
                try
                {
                    using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                    {
                        connection.Open();
                        OracleParameter clientid = new OracleParameter
                        {
                            ParameterName = "ClientId_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Int32,
                            Value = client.Id
                        };
                        OracleParameter apartmentid = new OracleParameter
                        {
                            ParameterName = " ApartmentId_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Int32,
                            Value = apartid.Id
                        };
                        OracleParameter arrivaldate = new OracleParameter
                        {
                            ParameterName = "ArrivalDate_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Date,
                            Value = Dateofarrival.SelectedDate
                        };
                        OracleParameter departdate = new OracleParameter
                        {
                            ParameterName = "DateOfDeparture_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Date,
                            Value = Dateofadeparture.SelectedDate
                        };
                        OracleParameter semplid = new OracleParameter
                        {
                            ParameterName = "EmployeeId_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Int32,
                            Value = employee.EmployeeId
                        };
                        OracleParameter servid = new OracleParameter
                        {
                            ParameterName = "ServiceId_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Int32,
                            Value = serviceobj.Id
                        };
                        using (OracleCommand command = new OracleCommand("admin.addPostoyalec"))
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[] { clientid,apartmentid,arrivaldate,departdate,semplid,
                        servid});
                            command.ExecuteNonQuery();
                            MessageBox.Show("Бронирование прошло успешно!");
                        }
                    }
                }
                catch (OracleException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            getEmptyApartments();
        }

        private void apartment_combo_GotFocus(object sender, RoutedEventArgs e)
        {
            
        }

        private void Dateofadeparture_CalendarClosed(object sender, RoutedEventArgs e)
        {
            apartment_combo.Items.Clear();
            getEmptyApartmentsbeforereservation();
            getEmptyApartments();
        }
    }
}
