using System;
using Npgsql;

namespace bidCardCoin.DAL
{
    internal static class DALconnection
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
                // _server = "127.0.0.1";
                _server = "172.16.2.7";
                _database = "andy_cinquin";
                _uid = "andy_cinquin";
                _password = "Epsi2021!";
                var connectionString =
                    $"Host={_server};Username={_uid};Password={_password};Database={_database};Pooling=false";


                _connection = new NpgsqlConnection(connectionString);
                _connection.Open();
            }

            return _connection;
        }
    }
}