using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ManageMyPasswords
{
    public class ConnectionManager
    {
        public string ConnectionString { get; private set; }

        public ConnectionManager(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public bool TestConnection()
        {
            try
            {
                using (var connection = new MySqlConnection(ConnectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public static string BuildConnectionString(string server, string port, string database, string username, string password)
        {
            return $"server={server};port={port};database={database};user={username};password={password}";
        }
    }
}
