using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using bidCardCoin.DAL;
using bidCardCoin.DAO;

namespace BidCardCoin.Vue
{
    public partial class HomeTabView : UserControl
    {
        private MainWindow parent;

        public HomeTabView(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();

            DALconnection.OpenConnection();

            EnchereDAL.InsertNewEnchere(new EnchereDAO("5e558c62-3a28-11eb-adc1-0242ac120002", 32.0, false,
                DateTime.Now, "b98517be-e15f-407f-b37b-8dedf74497e2", "33520d82-39f6-11eb-adc1-0242ac120002",
                null, "20ef2fcc-39f5-11eb-adc1-0242ac120002"));
        }


        /* ------------------------------------------------ NAV -----------------------------------------------------*/


        private void NavHoverEffectEnter(object o, MouseEventArgs mouseEventArgs)
        {
            var border = ((o as Button)?.Content as Border);
            border.CornerRadius = new CornerRadius(12);
            border.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#7289DA");
        }

        private void NavHoverEffectExit(object o, MouseEventArgs mouseEventArgs)
        {
            var border = ((o as Button)?.Content as Border);
            border.CornerRadius = new CornerRadius(8);
            border.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43");
        }

        /* ------------------------------------------------ TABS -----------------------------------------------------*/


        public void Tab_Achat(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void Tab_Solde(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new SoldeTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        private void Tab_Wrench(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new WrenchTanView());
            parent.SubView.Children.RemoveAt(0);
        }
    }
}