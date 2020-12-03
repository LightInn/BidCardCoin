using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCardCoin
{
    public class MetierDAO
    {
        public int idMetierDAO;
        public string libMetierDAO;
        public MetierDAO(int idMetierDAO, string libMetierDAO)
        {
            this.idMetierDAO = idMetierDAO;
            this.libMetierDAO = libMetierDAO;
        }
        public static MetierDAO getMetier(int idMetier)
        {
            MetierDAO metier = MetierDAL.getMetier(idMetier);
             return metier;
        }
        public static void updateMetier(MetierDAO m)
        {
            MetierDAL.updateMetier(m.idMetierDAO, m.libMetierDAO);
        }
    }
}
