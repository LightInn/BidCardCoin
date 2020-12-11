using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace BidCardCoin.Vue
{
    public partial class WrenchTanView : UserControl
    {
        public WrenchTanView()
        {
            InitializeComponent();
        }




        /* ------------------------------------------------ NAV -----------------------------------------------------*/


        private void NavHoverEffectEnter(object o, MouseEventArgs mouseEventArgs)
        {
            var stack = ((o as Button)?.Content as StackPanel);
            stack.Background = (SolidColorBrush)new BrushConverter().ConvertFrom("#DE4F4E");
        }

        private void NavHoverEffectExit(object o, MouseEventArgs mouseEventArgs)
        {
            var stack = ((o as Button)?.Content as StackPanel);
            stack.Background = new SolidColorBrush();
        }

        /* ------------------------------------------------ CRUD -----------------------------------------------------*/


        public void GRUD_adresse(object sender, RoutedEventArgs e)
        {
            //parent.SubView.Children.Add(new AchatTabView());
        }

   

    }
}