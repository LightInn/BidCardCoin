using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BidCardCoin.Vue.CRUD
{
    public partial class AddMotClefView : UserControl
    {
        private readonly List<string> _motsClefs;
        private readonly Window _win;

        public AddMotClefView(Window win, List<string> listMot)
        {
            InitializeComponent();
            _motsClefs = listMot;
            _win = win;
        }


        private void CreateMotClef(object sender, RoutedEventArgs e)
        {
            _motsClefs.Add(InputMotClef.Text);
            _win.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            _win.Close();
        }
    }
}