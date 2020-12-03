using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public class MetierDAL
    {
        public static MetierDAO getMetier(int idMetier)
        {
            string query = "SELECT * FROM metier WHERE idMetier=" + idMetier + ";";
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            MetierDAO met = new MetierDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return met;
        }

        public static void updateMetier(int idMetier, string libMetier)
        {
            string query = "UPDATE metier set libMetier=\"" + libMetier + "\" where idMetier=" + idMetier + ";";
            
            MySqlCommand cmd = new MySqlCommand(query, DALConnection.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd);
            cmd.ExecuteNonQuery();
        }
    }
}