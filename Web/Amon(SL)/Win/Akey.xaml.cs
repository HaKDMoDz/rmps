﻿using System.Windows;
using System.Windows.Controls;
using Me.Amon.Model;

namespace Me.Amon.Win
{
    public partial class Akey : ChildWindow
    {
        private UserModel _UserModel;

        public Akey()
        {
            InitializeComponent();
        }

        public Akey(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

