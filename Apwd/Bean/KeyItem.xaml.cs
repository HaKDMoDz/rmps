using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Views.Bean
{
    public partial class KeyItem : UserControl
    {
        private Key _Key;

        public KeyItem()
        {
            InitializeComponent();
        }

        public Key Key
        {
            get
            {
                return _Key;
            }
            set
            {
                _Key = value;
                if (_Key != null)
                {
                    KeyName.Text = _Key.Title;

                    string path = CharUtil.isValidateHash(_Key.IcoName) ? _Key.IcoPath + '/' + _Key.IcoName : "0";
                    LogoImg.Source = new BitmapImage(new Uri("/ico/key/" + path + ".png", UriKind.Relative));

                    path = CharUtil.isValidateHash(_Key.GtdId) ? "hint" : "0";
                    HintImg.Source = new BitmapImage(new Uri("/img/key/" + path + ".png", UriKind.Relative));

                    path = "label" + _Key.Label;
                    LabelImg.Source = new BitmapImage(new Uri("/img/key/" + path + ".png", UriKind.Relative));

                    path = (_Key.Major > 0 ? "major+" : "major") + _Key.Major;
                    MajorImg.Source = new BitmapImage(new Uri("/img/key/" + path + ".png", UriKind.Relative));
                }
            }
        }
    }
}
