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
        private string _motClef;

        public AddMotClefView(string motclef = null)
        {
            InitializeComponent();
            _motClef = motclef ?? "";
        }


        private void CreateMotClef(object sender, RoutedEventArgs e)
        {
            _motClef = InputMotClef.Text;
        }
    }
}