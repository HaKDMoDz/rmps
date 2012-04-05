using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Wiz
{
    public partial class AWiz : UserControl, ISec
    {
        private ASec _ASec;

        public AWiz()
        {
            InitializeComponent();
        }

        public AWiz(ASec asec)
        {
            InitializeComponent();

            _ASec = asec;
        }

        public void InitOnce()
        {
            CbDir.Items.Add(new Item { K = "enc", V = "加密" });
            CbDir.Items.Add(new Item { K = "dec", V = "解密" });
            CbDir.Items.Add(new Item { K = "hash", V = "摘要" });
            CbDir.SelectedIndex = 0;

            CbMod.Items.Add(new Item { K = "file", V = "文件" });
            CbMod.Items.Add(new Item { K = "text", V = "文本" });
            CbMod.SelectedIndex = 0;
        }

        public void InitView()
        {
            Location = new Point(12, 12);
            Size = new Size(240, 236);
            TabIndex = 0;
            _ASec.Controls.Add(this);
            _ASec.ClientSize = new Size(264, 305);
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

        private void CbDir_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Item item = CbDir.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            CbFun.Items.Clear();
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
        }

        private void CbFun_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void CbMod_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void ShowCipher()
        {
            //_WizView = new Cipher();
            //_WizView.InitOnce();
        }

        private void ShowDigest()
        {
            //_WizView = new Digest();
            //_WizView.InitOnce();
        }
    }
}
