using System.Collections.Generic;
using System.Windows.Controls;
using bidCardCoin.DAL;
using bidCardCoin.DAO;

namespace BidCardCoin.Vue
{
    public partial class HomeTabView : UserControl
    {
        public HomeTabView()
        {
            InitializeComponent();

            DALconnection.OpenConnection();

        }
    }
}