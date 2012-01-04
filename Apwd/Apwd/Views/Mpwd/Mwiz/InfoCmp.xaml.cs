using System.IO;
using System.Threading;
using System.Windows.Controls;
using Me.Amon.Apwd.Comn;

namespace Me.Amon.Apwd.Views.Mpwd.Mwiz
{
    public partial class InfoCmp : UserControl, ICardCtl
    {
        private Mwiz _Mwiz;
        private SafeModel _SafeModel;

        public InfoCmp()
        {
            InitializeComponent();
        }

        public InfoCmp(Mwiz mwiz, SafeModel safeModel)
        {
            _Mwiz = mwiz;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        #region 接口实现
        public void InitView(Grid grid)
        {
            //grid.Children.Add(this);
            //SetValue(Grid.RowProperty, 0);
            //SetValue(Grid.ColumnProperty, 0);
            //SetValue(Grid.RowSpanProperty, 2);
        }

        public void HideView(Grid grid)
        {
            //grid.Children.Remove(this);
        }

        public void ShowData()
        {
        }

        public bool SaveData()
        {
            return true;
        }

        public void CopyData()
        {
        }
        #endregion

        private void HbOpts_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            StringReader reader = new StringReader(BodyTxt.Text);

            // 版本判断
            string ver = reader.ReadLine();
            if (string.IsNullOrEmpty(ver) || "2" != ver)
            {
                return;
            }

            string line = reader.ReadLine();
            while (line != null)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    _SafeModel.ImportByTxt(line);
                    _SafeModel.Encode();
                    Post("&o=att&m=3&d=" + _SafeModel.Key.ToXml());
                    Thread.Sleep(500);
                }
                line = reader.ReadLine();
            }
        }

        public void Post(string data)
        {
            System.Net.WebClient client = new System.Net.WebClient();
            client.Headers["Content-type"] = "application/x-www-form-urlencoded";
            client.UploadStringCompleted += new System.Net.UploadStringCompletedEventHandler(client_UploadStringCompleted);
            client.UploadStringAsync(new System.Uri(Me.Amon.Apwd.Const.EnvConst.SERVER_PATH), "POST", "c=" + _SafeModel.Code + "&t=0" + data);
        }

        void client_UploadStringCompleted(object sender, System.Net.UploadStringCompletedEventArgs e)
        {
            BodyTxt.Text += e.Result + System.Environment.NewLine;
        }
    }
}
