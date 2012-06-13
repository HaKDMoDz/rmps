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
            Size = new Size(356, 207);
            TabIndex = 0;
            _ASec.Controls.Add(this);
            _ASec.ClientSize = new Size(380, 260);
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
            Item dir = CbDir.SelectedItem as Item;
            if (dir == null)
            {
                Main.ShowAlert("请选择操作类型！");
                CbDir.Focus();
                return;
            }

            Item fun = CbFun.SelectedItem as Item;
            if (fun == null)
            {
                Main.ShowAlert("请选择算法！");
                CbFun.Focus();
                return;
            }

            _Crypto.Algorithm = fun.K;
            _Crypto.DoCrypto();
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
                _Crypto = _Digest;
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
                _Crypto = _Decode;
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
                _Crypto = _Encode;
                return;
            }
        }

        private void CbFun_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //Item item = CbDir.SelectedItem as Item;
            //if (item == null)
            //{
            //    return;
            //}

            //if (_Crypto != null)
            //{
            //    _Crypto.Algorithm = item.K;
            //}
        }

        private void CbMod_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        #endregion
    }
}
