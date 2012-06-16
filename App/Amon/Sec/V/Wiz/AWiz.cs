using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AWiz : UserControl, ISec
    {
        #region 全局变量
        private ASec _ASec;
        private ICrypto _Crypto;
        private Encode _Encode;
        private Decode _Decode;
        private Digest _Digest;
        #endregion

        #region 构造函数
        public AWiz()
        {
            InitializeComponent();
        }

        public AWiz(ASec asec)
        {
            InitializeComponent();

            _ASec = asec;
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            _Digest = new Digest(UcFile, UcText);
            _Encode = new Encode(UcFile, UcText);
            _Decode = new Decode(UcFile, UcText);

            CbDir.Items.Add(new Item { K = "hash", V = "摘要" });
            CbDir.Items.Add(new Item { K = "enc", V = "加密" });
            CbDir.Items.Add(new Item { K = "dec", V = "解密" });
            CbDir.SelectedIndex = 0;
        }

        public void InitView()
        {
            Location = new Point(12, 12);
            Size = new Size(370, 219);
            TabIndex = 0;
            _ASec.Controls.Add(this);
            _ASec.ClientSize = new Size(394, 272);
        }

        public void HideView()
        {
            _ASec.Controls.Remove(this);
        }

        public void LoadFav()
        {
        }

        public void SaveFav()
        {
        }

        public void DoCrypto()
        {
            string pass = "";

            if (TbPass.Enabled)
            {
                pass = TbPass.Text;
                if (string.IsNullOrEmpty(pass))
                {
                    Main.ShowAlert("请输入您的密码！");
                    TbPass.Focus();
                }
            }

            _Crypto.IsText = TcCrypto.SelectedIndex == 1;
            if (_Crypto.DoCrypto(pass))
            {
                _ASec.ShowEcho("处理完成！");
            }
            else
            {
                _ASec.ShowEcho("处理失败！");
            }
        }
        #endregion

        #region 事件处理
        private void CbDir_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Item item = CbDir.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            CbFun.Items.Clear();
            if (item.K == "hash")
            {
                _Crypto = _Digest;
                _Crypto.Init();

                CbFun.Items.Add(new Item { K = "MD5", V = "MD5" });
                CbFun.Items.Add(new Item { K = "SHA1", V = "SHA1" });
                CbFun.Items.Add(new Item { K = "SHA256", V = "SHA256" });
                CbFun.Items.Add(new Item { K = "SHA512", V = "SHA512" });
                CbFun.SelectedIndex = 0;

                LlPass.Enabled = false;
                TbPass.Enabled = false;
                PbPass.Enabled = false;
                return;
            }
            if (item.K == "enc")
            {
                _Crypto = _Encode;
                _Crypto.Init();

                CbFun.Items.Add(new Item { K = "AES", V = "AES" });
                CbFun.Items.Add(new Item { K = "DES", V = "DES" });
                CbFun.Items.Add(new Item { K = "RC4", V = "RC4" });
                CbFun.Items.Add(new Item { K = "RC6", V = "RC6" });
                CbFun.SelectedIndex = 0;

                LlPass.Enabled = true;
                TbPass.Enabled = true;
                PbPass.Enabled = true;
                return;
            }
            if (item.K == "dec")
            {
                _Crypto = _Decode;
                _Crypto.Init();

                CbFun.Items.Add(new Item { K = "AES", V = "AES" });
                CbFun.Items.Add(new Item { K = "DES", V = "DES" });
                CbFun.Items.Add(new Item { K = "RC4", V = "RC4" });
                CbFun.Items.Add(new Item { K = "RC6", V = "RC6" });
                CbFun.SelectedIndex = 0;

                LlPass.Enabled = true;
                TbPass.Enabled = true;
                PbPass.Enabled = true;
                return;
            }
        }

        private void CbFun_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Item item = CbFun.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            if (_Crypto != null)
            {
                _Crypto.Algorithm = item.K;
            }
        }

        private void CbMod_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
