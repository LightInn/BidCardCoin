using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BidCardCoin.Vue;


namespace BidCardCoin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {


        public static string onglet;
        
        public MainWindow()
        {
            InitializeComponent();
            this.BorderThickness = new System.Windows.Thickness(1);
            MaxHeight = SystemParameters.VirtualScreenHeight;
            MaxWidth = SystemParameters.VirtualScreenWidth;

            body.Width = this.Width;
            nav.Height = this.Height;


            SubView.Children.Add(new Controlle_Test());
        }

        public void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            body.Width = this.Width;
            nav.Height = this.Height;
            if (this.WindowState == WindowState.Maximized)
            {
                this.BorderThickness = new System.Windows.Thickness(7);
            }
            else
            {
                this.BorderThickness = new System.Windows.Thickness(1);
            }
        }


        private void SwitchState()
        {
            switch (WindowState)
            {
                case WindowState.Normal:
                {
                    WindowState = WindowState.Maximized;
                    body.Width = this.Width;
                    nav.Height = this.Height;
                    break;
                }
                case WindowState.Maximized:
                {
                    WindowState = WindowState.Normal;
                    body.Width = this.Width;
                    nav.Height = this.Height;
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
                    if ((ResizeMode == ResizeMode.CanResize) ||
                        (ResizeMode == ResizeMode.CanResizeWithGrip))
                    {
                        SwitchState();
                    }
                }
                else
                {
                    if (WindowState == WindowState.Maximized)
                    {
                        SwitchState();
                    }

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
    }
}