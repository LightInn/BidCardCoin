using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Npgsql;

namespace bidCardCoin.DAL
{
    static class DALconnection
    {
        private static string server;
        private static string database;
        private static string uid;
        private static string password;
        private static NpgsqlConnection connection;

        public static NpgsqlConnection OpenConnection()
        {
            if (connection == null)
            {
                server = Environment.GetEnvironmentVariable("SERVER_ENVIRONMENT");
                database = Environment.GetEnvironmentVariable("DATABASE_ENVIRONMENT");
                uid = Environment.GetEnvironmentVariable("UID_ENVIRONMENT");
                password = Environment.GetEnvironmentVariable("PASSWORD_ENVIRONMENT");
                var connectionString = $"Host={server};Username={uid};Password={password};Database={database}";


                connection = new NpgsqlConnection(connectionString);
                connection.Open();
            }

            return connection;
        }
    }
}