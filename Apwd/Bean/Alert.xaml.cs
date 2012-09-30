using System.Windows;
using System.Windows.Controls;

namespace Me.Amon.Apwd.Bean
{
    public partial class Alert : ChildWindow
    {
        public Alert()
        {
            InitializeComponent();
        }

        public Alert(string message)
        {
            InitializeComponent();

            tbAlert.Text = message;
        }

        public Alert(string message, string title)
        {
            InitializeComponent();

            tbAlert.Text = message;
            Title = title;
        }

        public string Message
        {
            get
            {
                return tbAlert.Text;
            }
            set
            {
                tbAlert.Text = value;
            }
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

