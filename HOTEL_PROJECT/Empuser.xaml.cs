using HOTEL_PROJECT.Classes;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для Empuser.xaml
    /// </summary>
    public partial class Empuser : Window
    {
        BindingList<Client> all_clients = new BindingList<Client>();
        Client client;
        BindingList<Service> all_services = new BindingList<Service>();
        Service service;
        BindingList<Roomer> all_roomers = new BindingList<Roomer>();
        Roomer roomer;
        BindingList<Apartment> all_apartments = new BindingList<Apartment>();
        Apartment apartment;
        Employee employee = new Employee();
        public Empuser(string login, int EmployeeId)
        {
            InitializeComponent();
            loginName.Text = login;
            employee.EmployeeId = EmployeeId;
            getClients();
            clientsgrid.ItemsSource = all_clients;
            getServices();
            all_services.RemoveAt(0);
            servicegrid.ItemsSource = all_services;
            getRoomersServices();
            postolgrid.ItemsSource = all_roomers;
            getApartments();
            aparty.ItemsSource = all_apartments;
        }
        public void getClients()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter clien = new OracleParameter
                    {
                        ParameterName = "clien",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getClients"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { clien });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            int Id = Convert.ToInt32(row["Id"]);
                            string Surname = row["Surname"].ToString();
                            string Name = row["Name"].ToString();
                            string Secondname = row["SecondName"].ToString();
                            string PassportId = row["PassportId"].ToString();
                            string DateOfBirthday = Convert.ToDateTime(row["DateOfBirth"]).ToString("D");
                            string PhoneNumber = row["PhoneNumber"].ToString();
                            client = new Client(Id, Surname, Name, Secondname, PassportId, DateOfBirthday, PhoneNumber);
                            all_clients.Add(client);
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
                            string serviceitem = row["Service"].ToString();
                            double cost = Convert.ToDouble(row["Cost"]);
                            string description = row["Description"].ToString();
                            service = new Service(serviceitem, cost, description);
                            all_services.Add(service);
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getRoomersServices()
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter room = new OracleParameter
                    {
                        ParameterName = "roomer",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getRoomers"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { room });
                        var reader = command.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        foreach (DataRow row in dt.Rows)
                        {
                            string Surname = row["Client_Sur"].ToString();
                            string Name = row["Client_Name"].ToString();
                            string Secondname = row["Client_Secon"].ToString();
                            string PassportId = row["PassportId"].ToString();
                            string DateOfBirthday = Convert.ToDateTime(row["DateOfBirth"]).ToString("D");
                            string PhoneNumber = row["PhoneNumber"].ToString();
                            int NumberOfApartment = Convert.ToInt32(row["NumberOfApartment"]);
                            string Category = row["Category"].ToString();
                            int CountsOfSeats = Convert.ToInt32(row["CountsOfSeats"]);
                            string ArrivalDate = Convert.ToDateTime(row["ArrivalDate"]).ToString("D");
                            string DateOfDeparture = Convert.ToDateTime(row["DateOfDeparture"]).ToString("D");
                            string SurnameEmp = row["Employee_Sur"].ToString();
                            string NameEmp = row["Employee_Name"].ToString();
                            string SecondnameEmp = row["Employee_Secon"].ToString();
                            string Servicee = row["Service"].ToString();
                            double ServiceFee = Convert.ToDouble(row["ServiceFee"]);
                            double AccomodationFee = Convert.ToDouble(row["AccomodationFee"]);
                            roomer = new Roomer(Surname, Name, Secondname, PassportId, DateOfBirthday,
                                                PhoneNumber, NumberOfApartment, Category, CountsOfSeats, ArrivalDate,
                                                DateOfDeparture, SurnameEmp, NameEmp, SecondnameEmp, Servicee, ServiceFee,
                                                AccomodationFee);
                            all_roomers.Add(roomer);
                        }
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
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter apart = new OracleParameter
                    {
                        ParameterName = "apartment",
                        Direction = ParameterDirection.Output,
                        OracleDbType = OracleDbType.RefCursor
                    };

                    using (OracleCommand command = new OracleCommand("admin.getApartments"))
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
                            apartment = new Apartment(Number, Category, CountOfSeats, CostPerDay, Status, Description, img);
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
        private void addClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow client = new ClientWindow();
            client.Show();
        }

        private void out_Click(object sender, RoutedEventArgs e)
        {
            Authorization author = new Authorization();
            author.Show();
            this.Close();
        }

        private void clientsgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Reservation reservation = new Reservation(loginName.Text, all_clients[clientsgrid.SelectedIndex].Surname,
                all_clients[clientsgrid.SelectedIndex].Name, all_clients[clientsgrid.SelectedIndex].Secondname,
                all_clients[clientsgrid.SelectedIndex].Id, employee.EmployeeId);
            reservation.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            all_apartments.Clear();
            all_clients.Clear();
            all_roomers.Clear();
            getClients();
            clientsgrid.ItemsSource = all_clients;
            getRoomersServices();
            postolgrid.ItemsSource = all_roomers;
            getApartments();
            aparty.ItemsSource = all_apartments;
        }

        private void aparty_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Number number = new Number(all_apartments[aparty.SelectedIndex]);
            number.Show();
        }

        private void postolgrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           Payment payment = new Payment(all_roomers[postolgrid.SelectedIndex]);
           payment.Show();
        }

        private void prodlen_Click(object sender, RoutedEventArgs e)
        {
            Prolongation prolongation = new Prolongation(all_roomers[postolgrid.SelectedIndex]);
            prolongation.Show();
        }

        private void sokr_Click(object sender, RoutedEventArgs e)
        {
            Decrease decrease = new Decrease(all_roomers[postolgrid.SelectedIndex]);
            decrease.Show();
        }



        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            all_roomers.Clear();
            getRoomersServices();
            postolgrid.ItemsSource = all_roomers;
        }

        private void refreshapart_Click(object sender, RoutedEventArgs e)
        {
            all_apartments.Clear();
            getApartments();
            aparty.ItemsSource = all_apartments;
        }
    }
}
