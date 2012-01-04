using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Me.Amon.Apwd.Model;
using Me.Amon.Apwd.Utils;

namespace Me.Amon.Apwd.Views.Bean
{
    public partial class CatItem : UserControl
    {
        private Cat _Cat;

        public CatItem()
        {
            InitializeComponent();
        }

        public Cat Cat
        {
            get
            {
                return _Cat;
            }
            set
            {
                _Cat = value;
                if (_Cat != null)
                {
                    NameTxt.Text = _Cat.Text;
                    LogoImg.Source = new BitmapImage(new Uri("/ico/cat/" + (CharUtil.isValidateHash(_Cat.Icon) ? _Cat.Icon : "0") + ".png", UriKind.Relative));
                    //LogoImg.Source = new BitmapImage(new Uri("/cat/web.png", UriKind.Relative));
                }
            }
        }
    }
}
