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
    public class StockORM
    {
        private static Dictionary<string, Stock> _stocksDictionary = new Dictionary<string, Stock>();

        private static bool StockAlreadyInDictionary(string id)
        {
            return _stocksDictionary.ContainsKey(id);
        }
        // todo -> liens vers un : Adresse

        public static void Populate(List<Stock> stocks)
        {
            // liste des stocks qui on beusoin de se faire peupler (leurs liste utilisateurs)

            foreach (var stock in stocks)
            {
                if (!StockAlreadyInDictionary(stock.IdStock))
                {
                    GetStockById(stock.IdStock);
                }

                stock.AdresseStock = _stocksDictionary[stock.IdStock].AdresseStock;
            }
        }

        public static void Populate(Stock stock)
        {
            // liste des stocks qui on beusoin de se faire peupler (leurs liste utilisateurs)

            if (!StockAlreadyInDictionary(stock.IdStock))
            {
                GetStockById(stock.IdStock);
            }

            stock.AdresseStock = _stocksDictionary[stock.IdStock].AdresseStock;
        }

        public static Stock GetStockById(string id, bool initializer = true)
        {
            StockDAO sdao = StockDAL.SelectStockById(id);
            Adresse adresseStock = new Adresse();

            if (initializer)
            {
                adresseStock = AdresseORM.GetAdresseById(AdresseDAL.SelectAdresseById(sdao.AdresseId).IdAdresse, false);
            }


            Stock stock = new Stock(sdao.IdStock, adresseStock);

            if (initializer)
            {
                _stocksDictionary[stock.IdStock] = stock;
                AdresseORM.Populate(new List<Adresse>(new []{stock.AdresseStock}));
            }

            return stock;
        }

        public static List<Stock> GetAllStock()
        {
            List<StockDAO> lsdao = StockDAL.SelectAllStock();
            List<Stock> stocks = new List<Stock>();

            foreach (var sdao in lsdao)
            {
                stocks.Add(GetStockById(sdao.IdStock));
            }

            return stocks;
        }
    }
}