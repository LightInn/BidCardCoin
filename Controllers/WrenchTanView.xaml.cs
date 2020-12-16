using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BidCardCoin.Vue.CRUD;

namespace BidCardCoin.Vue
{
    public partial class WrenchTanView : UserControl
    {
        private readonly MainWindow parent;

        public WrenchTanView(MainWindow parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        /* ------------------------------------------------ NAV -----------------------------------------------------*/


        private void NavHoverEffectEnter(object o, MouseEventArgs mouseEventArgs)
        {
            var border = (o as Button)?.Content as Border;
            border.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#F8F8F8");
            border.CornerRadius = new CornerRadius(8);
            border.BorderThickness = new Thickness(5);
            border.BorderBrush = (SolidColorBrush) new BrushConverter().ConvertFrom("#249181");
            border.Margin = new Thickness(15);
        }

        private void NavHoverEffectExit(object o, MouseEventArgs mouseEventArgs)
        {
            var border = (o as Button)?.Content as Border;
            border.Background = new SolidColorBrush();
            border.CornerRadius = new CornerRadius(0);
            border.BorderThickness = new Thickness(0);
            border.BorderBrush = new SolidColorBrush();
            border.Margin = new Thickness(0);
        }

        /* ------------------------------------------------ CRUD -----------------------------------------------------*/


        public void GRUD_adresses(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new ListeAdressesView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_utilisateurs(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new ListeUtilisateursView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_stocks(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new ListeUtilisateursView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_categories(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_commissaires(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_estimations(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_ordresAchats(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_produits(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_lots(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_paiement(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_encheres(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new ListeEncheresView());
            parent.SubView.Children.RemoveAt(0);
        }

        public void GRUD_ventes(object sender, RoutedEventArgs e)
        {
            parent.SubView.Children.Add(new AchatTabView());
            parent.SubView.Children.RemoveAt(0);
        }
    }
}