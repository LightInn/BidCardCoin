using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCardCoin.Models;

namespace BidCardCoin
{
    class MetierORM
    {

        public static MetierViewModel getMetier(int idMetier)
        {
            MetierDAO m = MetierDAO.getMetier(idMetier);
            MetierViewModel metier = new MetierViewModel(m.idMetierDAO, m.libMetierDAO);
            return metier;
        }

        public static void updateMetier(MetierViewModel p)
        {
            MetierDAO.updateMetier(new MetierDAO(p.idMetier, p.libMetier));
        }
    }
}