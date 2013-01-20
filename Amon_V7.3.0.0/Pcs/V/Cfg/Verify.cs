using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V.Cfg
{
    public partial class Verify : UserControl, IMgr
    {
        private Me.Amon.Open.V1.App.OAuthV1Client _Client;

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
                    _Client = new Me.Amon.Open.V1.App.Pcs.KuaipanClient(OAuthConsumer.KuaipanConsumer(), true);
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
            if (!_Client.AccessToken())
            {
                return false;
            }
            mPcs.Token = _Client.Token.oauth_token;
            mPcs.TokenSecret = _Client.Token.oauth_token_secret;
            return true;
        }
        #endregion
    }
}
