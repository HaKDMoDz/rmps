using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class AWiz : UserControl, ISec
    {
        #region 全局变量
        private ASec _ASec;
        private IView _IFile;
        private IView _IText;
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
                CbFun.Items.Add(new Item { K = "MD5", V = "MD5" });
                CbFun.Items.Add(new Item { K = "SHA1", V = "SHA1" });
                CbFun.Items.Add(new Item { K = "SHA256", V = "SHA256" });
                CbFun.Items.Add(new Item { K = "SHA512", V = "SHA512" });
                CbFun.SelectedIndex = 0;
                ShowDigest();
                return;
            }
            if (item.K == "enc" || item.K == "dec")
            {
                CbFun.Items.Add(new Item { K = "AES", V = "AES" });
                CbFun.Items.Add(new Item { K = "DES", V = "DES" });
                CbFun.Items.Add(new Item { K = "RC4", V = "RC4" });
                CbFun.Items.Add(new Item { K = "RC6", V = "RC6" });
                CbFun.SelectedIndex = 0;
                ShowCipher();
                return;
            }
        }

        private void CbFun_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void CbMod_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }
        #endregion

        #region 私有函数
        private void ShowCipher()
        {
            if (_CFile == null)
            {
                _CFile = new CipherFile();
                _CFile.Dock = DockStyle.Fill;
            }
            if (_IFile != null)
            {
                TpFile.Controls.Remove(_IFile.Control);
            }
            TpFile.Controls.Add(_CFile);
            _IFile = _CFile;

            if (_CText == null)
            {
                _CText = new CipherText();
                _CText.Dock = DockStyle.Fill;
            }
            if (_IText != null)
            {
                TpText.Controls.Remove(_IText.Control);
            }
            TpText.Controls.Add(_CText);
            _IText = _CText;
        }
        private CipherFile _CFile;
        private CipherText _CText;

        private void ShowDigest()
        {
            if (_DFile == null)
            {
                _DFile = new DigestFile();
                _DFile.Dock = DockStyle.Fill;
            }
            if (_IFile != null)
            {
                TpFile.Controls.Remove(_IFile.Control);
            }
            TpFile.Controls.Add(_DFile);
            _IFile = _DFile;

            if (_DText == null)
            {
                _DText = new DigestText();
                _DText.Dock = DockStyle.Fill;
            }
            if (_IText != null)
            {
                TpText.Controls.Remove(_IText.Control);
            }
            TpText.Controls.Add(_DText);
            _IText = _DText;
        }
        private DigestFile _DFile;
        private DigestText _DText;
        #endregion
    }
}
