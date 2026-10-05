using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C09.DAOs
{
    class DBConnector
    {
        public static MySqlConnection GetConnection()
        {
            string server = "127.0.0.1";
            string port = "3306";
            string database = "registruip";
            string uid = "root";
            string password = "";
            string connectionString = "SERVER=" + server + ";PORT=" + port + ";DATABASE=" +
                database + ";UID=" + uid + ";PASSWORD=" + password + ";";

            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            return conn;
        }

    }
}
