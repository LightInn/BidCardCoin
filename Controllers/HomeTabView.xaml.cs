using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using bidCardCoin.DAL;
using bidCardCoin.DAO;
using bidCardCoin.ORM;

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

            var user = UtilisateurORM.GetAllUtilisateur();


            var test = EnchereDAL.SelectAllEnchere();
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