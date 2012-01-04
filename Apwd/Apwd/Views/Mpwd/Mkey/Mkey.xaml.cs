using System.Windows;
using System.Windows.Controls;
using Me.Amon.Apwd.Comn;

namespace Me.Amon.Apwd.Views.MkeyCmp
{
    public partial class Mkey : ChildWindow
    {
        private UserModel _UserModel;

        public Mkey()
        {
            InitializeComponent();
        }

        public Mkey(UserModel userModel)
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

