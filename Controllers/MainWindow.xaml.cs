using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using BidCardCoin.Vue;

namespace BidCardCoin
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public static string onglet;

        public MainWindow()
        {
            InitializeComponent();
            BorderThickness = new Thickness(1);
            MaxHeight = SystemParameters.VirtualScreenHeight;
            MaxWidth = SystemParameters.VirtualScreenWidth;

            body.Width = Width;
            nav.Height = Height;

            SubView.Children.Add(new HomeTabView(this));
        }

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            body.Width = Width;
            nav.Height = Height;
            if (WindowState == WindowState.Maximized)
                BorderThickness = new Thickness(7);
            else
                BorderThickness = new Thickness(1);
        }

        private void SwitchState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                {
                    WindowState = WindowState.Maximized;
                    body.Width = Width;
                    nav.Height = Height;
                    break;
                }
                case WindowState.Maximized:
                {
                    WindowState = WindowState.Normal;
                    body.Width = Width;
                    nav.Height = Height;
                    break;
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 2)
                {
                    if (ResizeMode == ResizeMode.CanResize ||
                        ResizeMode == ResizeMode.CanResizeWithGrip)
                        SwitchState();
                }
                else
                {
                    if (WindowState == WindowState.Maximized) SwitchState();

                    DragMove();
                }
            }
        }


        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void MaximizeClick(object sender, RoutedEventArgs e)
        {
            SwitchState();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /* ------------------------------------------------ NAV -----------------------------------------------------*/


        private void NavHoverEffectEnter(object o, MouseEventArgs mouseEventArgs)
        {
            var border = (o as Button)?.Content as Border;
            border.CornerRadius = new CornerRadius(10);
            border.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#7289DA");
        }

        private void NavHoverEffectExit(object o, MouseEventArgs mouseEventArgs)
        {
            var border = (o as Button)?.Content as Border;
            border.CornerRadius = new CornerRadius(100);
            border.Background = (SolidColorBrush) new BrushConverter().ConvertFrom("#393C43");
        }


        /* ------------------------------------------------ TABS -----------------------------------------------------*/

        public void Tab_Home(object sender, RoutedEventArgs e)
        {
            if (SubView.Children.Count == 1) SubView.Children.RemoveAt(0);

            SubView.Children.Add(new HomeTabView(this));
        }

        public void Tab_Achat(object sender, RoutedEventArgs e)
        {
            if (SubView.Children.Count == 1) SubView.Children.RemoveAt(0);

            SubView.Children.Add(new AchatTabView());
        }

        public void Tab_Solde(object sender, RoutedEventArgs e)
        {
            if (SubView.Children.Count == 1) SubView.Children.RemoveAt(0);

            SubView.Children.Add(new SoldeTabView());
        }

        public void Tab_Wrench(object sender, RoutedEventArgs e)
        {
            if (SubView.Children.Count == 1) SubView.Children.RemoveAt(0);

            SubView.Children.Add(new WrenchTanView(this));
        }
    }
}