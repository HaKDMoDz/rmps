using System;
using System.Windows;
using System.Windows.Controls;

namespace Me.Amon.Apwd.Bean
{
    public partial class Error : ChildWindow
    {
        public Error(Exception e)
        {
            InitializeComponent();
            if (e != null)
            {
                ErrorTextBox.Text = e.Message + Environment.NewLine + Environment.NewLine + e.StackTrace;
            }
        }

        public Error(Uri uri)
        {
            InitializeComponent();
            if (uri != null)
            {
                ErrorTextBox.Text = "未找到页面: \"" + uri.ToString() + "\"";
            }
        }

        public Error(string message, string details)
        {
            InitializeComponent();
            ErrorTextBox.Text = message + Environment.NewLine + Environment.NewLine + details;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}