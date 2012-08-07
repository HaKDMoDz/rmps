using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Me.Amon.Lot.V
{
    public partial class Uc2 : UserControl
    {
        private string _BgImage;

        public Uc2()
        {
            InitializeComponent();
        }

        public string Background
        {
            get
            {
                return _BgImage;
            }
            set
            {
                IbImage.ImageSource = new BitmapImage(new Uri(value, UriKind.RelativeOrAbsolute));
                _BgImage = value;
            }
        }
    }
}
