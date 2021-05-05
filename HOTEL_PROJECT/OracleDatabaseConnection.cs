using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HOTEL_PROJECT
{
    class OracleDatabaseConnection
    {
        public static string str = "Data Source = (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.56.104)" +
               "(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = NAD_PDB.be.by)));User Id=admin;Password=Administrator1;";
        public static string str2 = "Data Source = (DESCRIPTION =(ADDRESS_LIST =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.56.104)" +
               "(PORT = 1521)))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = NAD_PDB.be.by)));User Id=employee;Password=emppass;";
    }
}

