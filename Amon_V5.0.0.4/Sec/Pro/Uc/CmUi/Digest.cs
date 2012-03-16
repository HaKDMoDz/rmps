using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;

namespace Me.Amon.Sec.Pro.Uc.CmUi
{
    public class Digest : ACm
    {
        public Digest(ASec asec, Cm cm)
            : base(asec, cm)
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

            BeanUtil.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_GOST3411, V = "Gost3411" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_MD2, V = "MD2" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_MD4, V = "MD4" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_MD5, V = "MD5" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_NULL, V = "Null" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_RIPEMD128, V = "RipeMD128" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_RIPEMD160, V = "RipeMD160" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_RIPEMD256, V = "RipeMD256" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_RIPEMD320, V = "RipeMD320" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_SHA1, V = "Sha1" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_SHA224, V = "Sha224" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_SHA256, V = "Sha256" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_SHA384, V = "Sha384" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_SHA512, V = "Sha512" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_TIGER, V = "Tiger" });
            _Cm.CbName.Items.Add(new Item { K = IData.DIGEST_WHIRLPOOL, V = "Whirlpool" });
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
                case IData.DIGEST_GOST3411:
                    _Cipher = new Gost3411Digest();
                    break;
                case IData.DIGEST_MD2:
                    _Cipher = new MD2Digest();
                    break;
                case IData.DIGEST_MD4:
                    _Cipher = new MD4Digest();
                    break;
                case IData.DIGEST_MD5:
                    _Cipher = new MD5Digest();
                    break;
                case IData.DIGEST_NULL:
                    _Cipher = new NullDigest();
                    break;
                case IData.DIGEST_RIPEMD128:
                    _Cipher = new RipeMD128Digest();
                    break;
                case IData.DIGEST_RIPEMD160:
                    _Cipher = new RipeMD160Digest();
                    break;
                case IData.DIGEST_RIPEMD256:
                    _Cipher = new RipeMD256Digest();
                    break;
                case IData.DIGEST_RIPEMD320:
                    _Cipher = new RipeMD320Digest();
                    break;
                case IData.DIGEST_SHA1:
                    _Cipher = new Sha1Digest();
                    break;
                case IData.DIGEST_SHA224:
                    _Cipher = new Sha224Digest();
                    break;
                case IData.DIGEST_SHA256:
                    _Cipher = new Sha256Digest();
                    break;
                case IData.DIGEST_SHA384:
                    _Cipher = new Sha384Digest();
                    break;
                case IData.DIGEST_SHA512:
                    _Cipher = new Sha512Digest();
                    break;
                case IData.DIGEST_TIGER:
                    _Cipher = new TigerDigest();
                    break;
                case IData.DIGEST_WHIRLPOOL:
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