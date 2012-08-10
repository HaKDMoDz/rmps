using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using Me.Amon.Lot.C;
using Me.Amon.Lot.M;
using Me.Amon.Lot.V;

namespace Me.Amon.Lot
{
    public partial class ALot : UserControl
    {
        private MLot _MLot;
        private VLot _VLot;
        private CLot _CLot;

        public ALot()
        {
            InitializeComponent();
        }

        private void ALot_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            string key = "";

            GenM(key);

            if (!string.IsNullOrWhiteSpace(_MLot.Title))
            {
                TbTitle.Text = _MLot.Title;
                TbTitle.Visibility = System.Windows.Visibility.Visible;
                GdPanel.Margin = new System.Windows.Thickness(0, 40, 0, 0);
            }
            else
            {
                TbTitle.Visibility = System.Windows.Visibility.Collapsed;
                GdPanel.Margin = new System.Windows.Thickness(0);
            }
            ImageBrush image = new ImageBrush();
            image.ImageSource = new BitmapImage(new Uri(_MLot.Fav.BackgroundImage, UriKind.Relative));
            image.Stretch = Stretch.Fill;
            LayoutRoot.Background = image;

            GenV(key);

            _VLot.Control.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            _VLot.Control.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            LayoutRoot.Children.Add(_VLot.Control);

            GenC(key);
        }

        private void ALot_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == _MLot.Fav.Run)
            {
                _CLot.Run();
                return;
            }
            if (e.Key == _MLot.Fav.AmonMe)
            {
                _CLot.AmonMe();
                return;
            }
            if (e.Key == _MLot.Fav.KeepOn)
            {
                _CLot.KeepOn();
                return;
            }
            if (e.Key == _MLot.Fav.End)
            {
                _CLot.End();
                return;
            }
        }

        #region 私有函数
        private MLot GenM(string key)
        {
            _MLot = new MLot();

            WebClient client = new WebClient();
            client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(DownloadStringCompleted);
            client.DownloadStringAsync(new Uri("/l.ashx", UriKind.Relative));

            LotCfg cfg = new LotCfg();
            cfg.RowCount = 3;
            cfg.ColCount = 1;
            cfg.Speed = 30;
            _MLot.Cfg = cfg;

            LotFav fav = new LotFav();
            fav.BackgroundImage = "/demo.jpg";
            fav.Run = System.Windows.Input.Key.R;
            fav.AmonMe = System.Windows.Input.Key.Space;
            fav.KeepOn = System.Windows.Input.Key.Enter;
            fav.End = System.Windows.Input.Key.S;
            _MLot.Fav = fav;

            return _MLot;
        }

        private VLot GenV(string key)
        {
            _VLot = new V.V01.Vc01();
            //_VLot.Init(_MLot.Cfg);
            return _VLot;
        }

        private CLot GenC(string key)
        {
            _CLot = new C.C01.Cc01();
            _CLot.Init(_MLot, _VLot);
            return _CLot;
        }
        #endregion

        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            string xml = e.Result;
            if (string.IsNullOrWhiteSpace(xml))
            {
                return;
            }
            System.IO.StringReader input = new System.IO.StringReader(xml);
            XmlReader reader = XmlReader.Create(input, new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true });
            if (reader.ReadToFollowing("Lot"))
            {
                _MLot.FromXml(reader);
            }
            reader.Close();
            input.Close();
        }
    }
}
