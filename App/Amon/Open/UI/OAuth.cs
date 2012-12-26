using System.Windows.Forms;

namespace Me.Amon.Open.UI
{
    public partial class OAuth : Form
    {
        public string Token { get; private set; }

        #region 构造函数
        public OAuth()
        {
            InitializeComponent();
        }

        public OAuth(string url)
        {
            InitializeComponent();

            this.WbBrowser.Navigate(url);
        }

        public OAuth(string url, bool req)
        {
            InitializeComponent();

            this.WbBrowser.Navigate(url);
            this.TbToken.Enabled = req;
        }
        #endregion

        #region 事件处理
        private void Auth_Load(object sender, System.EventArgs e)
        {
            this.Icon = Me.Amon.Properties.Resources.Icon;

            LlOAuth.Text = "OAuth（开放授权）是一个开放标准，为用户资源的授权提供了一个安全、开放而又简易的操作方式。\r\n详细请了解：http://oauth.net/";
        }

        private void BtOk_Click(object sender, System.EventArgs e)
        {
            if (TbToken.Enabled)
            {
                string code = this.TbToken.Text.Trim();
                if (string.IsNullOrEmpty(code))
                {
                    MessageBox.Show(this, "请输入授权码！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Token = code;
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
