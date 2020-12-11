using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace bidCardCoin.DAL
{
    static class DALconnection
    {
        private static string _server;
        private static string _database;
        private static string _uid;
        private static string _password;
        private static NpgsqlConnection _connection;

        public static NpgsqlConnection OpenConnection()
        {
            if (_connection == null)
            {
                _server = Environment.GetEnvironmentVariable("SERVER_ENVIRONMENT");
                _database = Environment.GetEnvironmentVariable("DATABASE_ENVIRONMENT");
                _uid = Environment.GetEnvironmentVariable("UID_ENVIRONMENT");
                _password = Environment.GetEnvironmentVariable("PASSWORD_ENVIRONMENT");
                var connectionString = $"Host={_server};Username={_uid};Password={_password};Database={_database};Pooling=false";


                _connection = new NpgsqlConnection(connectionString);
                _connection.Open();
            }

            return _connection;
        }
    }
}