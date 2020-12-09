using System.Windows.Controls;
using bidCardCoin.DAL;

namespace BidCardCoin.Vue
{
    public partial class HomeTabView : UserControl
    {
        public HomeTabView()
        {
            InitializeComponent();

            DALconnection.OpenConnection();
            var test = AdresseDAL.SelectAllAdresse();
        }
    }
}