using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using bidCardCoin.DAL;
using BidCardCoin.Models;
using bidCardCoin.ORM;

namespace BidCardCoin.Vue.CRUD
{
    public partial class AddMotClefView : UserControl
    {
        private List<string> _motsClefs;
        private Window _win;

        public AddMotClefView(Window win,List<string> listMot)
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
    }
}