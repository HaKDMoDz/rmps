using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V.Mgr
{
    public partial class Verify : UserControl, IMgr
    {
        private OAuthClient _Client;

        public Verify()
        {
            InitializeComponent();
        }

        public void Init()
        {
        }

        #region 接口实现
        public void ShowData(MPcs mPcs)
        {
            switch (mPcs.ServerType)
            {
                case CPcs.PCS_TYPE_KUAIPAN:
                    _Client = new Me.Amon.Open.V1.App.Pcs.KuaipanClient(OAuthConsumer.KuaipanConsumer());
                    if (!_Client.RequestToken())
                    {
                        return;
                    }
                    WbBrowser.Navigate(_Client.GetAuthorizeUrl());
                    break;
            }
        }

        public bool SaveData(MPcs mPcs)
        {
            string token = TbToken.Text.Trim();
            if (string.IsNullOrEmpty(token))
            {
                MessageBox.Show("请输入授权码！");
                TbToken.Focus();
                return false;
            }
            //mPcs.Token = token;

            if (_Client == null)
            {
                return false;
            }
            return _Client.AccessToken();
        }
        #endregion
    }
}
