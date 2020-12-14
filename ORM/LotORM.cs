using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using BidCardCoin.Models;

namespace bidCardCoin.ORM
{
    public class LotORM
    {
        private static Dictionary<string, Lot> _lotsDictionary = new Dictionary<string, Lot>();
        private static bool LotAlreadyInDictionary(string id)
        {
            return _lotsDictionary.ContainsKey(id);
        }
        // todo -> liens vers des : lots
        
        public static void Populate(List<Lot> lots)
        {
            // todo
        }
        public static void Populate(Lot lot)
        {
            // todo
        }

        public static Lot GetLotById(string id, bool initializer = true)
        {
            // todo
            Lot lot = new Lot();

            return lot;
        }
        
        public static List<Lot> GetAllLot()
        {
            List<LotDAO> lldao = LotDAL.SelectAllLot();
            List<Lot> lots = new List<Lot>();

            foreach (var ldao in lldao)
            {
                lots.Add(GetLotById(ldao.IdLot));
            }

            return lots;
        }
    }
}
