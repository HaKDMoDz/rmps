using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Msec.Uc.CmUi
{
    public class Digest : ACm
    {
        public Digest(Main main, Cm cm)
            : base(main, cm)
        {
        }

        private IDigest _Cipher;
        public IDigest Cipher
        {
            get
            {
                return _Cipher;
            }
        }

        #region 接口实现
        public override void InitOpt()
        {
            _Cm.Enabled = true;

            Util.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = "Gost3411", V = "Gost3411" });
            _Cm.CbName.Items.Add(new Item { K = "MD2", V = "MD2" });
            _Cm.CbName.Items.Add(new Item { K = "MD4", V = "MD4" });
            _Cm.CbName.Items.Add(new Item { K = "MD5", V = "MD5" });
            _Cm.CbName.Items.Add(new Item { K = "Null", V = "Null" });
            _Cm.CbName.Items.Add(new Item { K = "RipeMD128", V = "RipeMD128" });
            _Cm.CbName.Items.Add(new Item { K = "RipeMD160", V = "RipeMD160" });
            _Cm.CbName.Items.Add(new Item { K = "RipeMD256", V = "RipeMD256" });
            _Cm.CbName.Items.Add(new Item { K = "RipeMD320", V = "RipeMD320" });
            _Cm.CbName.Items.Add(new Item { K = "Sha1", V = "Sha1" });
            _Cm.CbName.Items.Add(new Item { K = "Sha224", V = "Sha224" });
            _Cm.CbName.Items.Add(new Item { K = "Sha256", V = "Sha256" });
            _Cm.CbName.Items.Add(new Item { K = "Sha384", V = "Sha384" });
            _Cm.CbName.Items.Add(new Item { K = "Sha512", V = "Sha512" });
            _Cm.CbName.Items.Add(new Item { K = "Tiger", V = "Tiger" });
            _Cm.CbName.Items.Add(new Item { K = "Whirlpool", V = "Whirlpool" });
            _Cm.CbName.Enabled = true;

            _Cm.LbMode.Visible = false;
            _Cm.CbMode.Visible = false;

            _Cm.LbPads.Visible = false;
            _Cm.CbPads.Visible = false;
        }

        public override void InitKey(string key)
        {
            bool b = key != "0";

            _Cm.CbName.Enabled = b;
        }

        public override void ChangeName(string name)
        {
            if (name == "0")
            {
                _Cipher = null;
                return;
            }

            switch (name)
            {
                case "Gost3411":
                    _Cipher = new Gost3411Digest();
                    break;
                case "MD2":
                    _Cipher = new MD2Digest();
                    break;
                case "MD4":
                    _Cipher = new MD4Digest();
                    break;
                case "MD5":
                    _Cipher = new MD5Digest();
                    break;
                case "Null":
                    _Cipher = new NullDigest();
                    break;
                case "RipeMD128":
                    _Cipher = new RipeMD128Digest();
                    break;
                case "RipeMD160":
                    _Cipher = new RipeMD160Digest();
                    break;
                case "RipeMD256":
                    _Cipher = new RipeMD256Digest();
                    break;
                case "RipeMD320":
                    _Cipher = new RipeMD320Digest();
                    break;
                case "Sha1":
                    _Cipher = new Sha1Digest();
                    break;
                case "Sha224":
                    _Cipher = new Sha224Digest();
                    break;
                case "Sha256":
                    _Cipher = new Sha256Digest();
                    break;
                case "Sha384":
                    _Cipher = new Sha384Digest();
                    break;
                case "Sha512":
                    _Cipher = new Sha512Digest();
                    break;
                case "Tiger":
                    _Cipher = new TigerDigest();
                    break;
                case "Whirlpool":
                    _Cipher = new WhirlpoolDigest();
                    break;
            }

            _Cm.CbMode.SelectedIndex = 0;

            _Cm.CbPads.SelectedIndex = 0;
        }

        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
        #endregion
    }
}