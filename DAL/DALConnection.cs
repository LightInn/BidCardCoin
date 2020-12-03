using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace bidCardCoin.DAL
{
    class DALconnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        private static MySqlConnection connection;

        public static MySqlConnection OpenConnection()
        {
            if (connection == null)
            {
                server = Environment.GetEnvironmentVariable("SERVER_ENVIRONMENT");
                database = Environment.GetEnvironmentVariable("DATABASE_ENVIRONMENT");
                uid = Environment.GetEnvironmentVariable("UID_ENVIRONMENT");
                password = Environment.GetEnvironmentVariable("PASSWORD_ENVIRONMENT");
                string connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
                connection = new MySqlConnection(connectionString);
                connection.Open();
            }
            return connection;
        }
    }
}
