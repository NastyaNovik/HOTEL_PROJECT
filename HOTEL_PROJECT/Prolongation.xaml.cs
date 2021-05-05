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
    /// Логика взаимодействия для Prolongation.xaml
    /// </summary>
    public partial class Prolongation : Window
    {
        Roomer current_roomer;
        int id;
        public Prolongation(Roomer roomer)
        {
            InitializeComponent();
            current_roomer = roomer;
            surnameClient.Text = roomer.Surname;
            nameClient.Text = roomer.Name;
            secondNameClient.Text = roomer.Secondname;
            newDeparture.DisplayDateStart = Convert.ToDateTime(roomer.DateOfDeparture).AddDays(1);
            getClientId();
        }

        private void prolong_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                {
                    connection.Open();
                    OracleParameter idapart = new OracleParameter
                    {
                        ParameterName = "ApartmentId_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = current_roomer.NumberOfApartment
                    };
                    OracleParameter idclient = new OracleParameter
                    {
                        ParameterName = "Clientid_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Int32,
                        Value = id
                    };
                    OracleParameter arrivaldate = new OracleParameter
                    {
                        ParameterName = "ArrivalDate_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Convert.ToDateTime(current_roomer.ArrivalDate)
                    };
                    OracleParameter departdate = new OracleParameter
                    {
                        ParameterName = "DateOfDeparture_in",
                        Direction = ParameterDirection.Input,
                        OracleDbType = OracleDbType.Date,
                        Value = Convert.ToDateTime(newDeparture.Text)
                    };

                    using (OracleCommand command = new OracleCommand("admin.ProlongationForRoomer"))
                    {
                        command.Connection = connection;
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddRange(new OracleParameter[] { idapart,idclient,arrivaldate,departdate });
                        command.ExecuteNonQuery();
                        MessageBox.Show("Продление проживания прошло успешно!");
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();

        }
        public void getClientId()
        {   
                try
                {
                    using (OracleConnection connection = new OracleConnection(OracleDatabaseConnection.str2))
                    {
                        connection.Open();
                        OracleParameter surnamec = new OracleParameter
                        {
                            ParameterName = "ClientSur_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Varchar2,
                            Value = current_roomer.Surname
                        };
                        OracleParameter namec = new OracleParameter
                        {
                            ParameterName = "ClientNam_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Varchar2,
                            Value = current_roomer.Name
                        };
                        OracleParameter secondnamec = new OracleParameter
                        {
                            ParameterName = "ClientSecon_in",
                            Direction = ParameterDirection.Input,
                            OracleDbType = OracleDbType.Varchar2,
                            Value = current_roomer.Secondname
                        };
                        OracleParameter clie = new OracleParameter
                        {
                            ParameterName = "clie",
                            Direction = ParameterDirection.Output,
                            OracleDbType = OracleDbType.RefCursor
                        };

                        using (OracleCommand command = new OracleCommand("admin.getClientId"))
                        {
                            command.Connection = connection;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddRange(new OracleParameter[] { surnamec, namec,secondnamec, clie });
                            var reader = command.ExecuteReader();
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            foreach (DataRow row in dt.Rows)
                            {
                                id = Convert.ToInt32(row["Id"]);
                            }
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
