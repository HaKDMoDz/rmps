using Me.Amon.Uc;
using Me.Amon.Util;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;

namespace Me.Amon.Sec.V.Pro.Uc.CmUi
{
    public class Scrypto : ACm
    {
        private IBlockCipher _Engine;
        private BufferedBlockCipher _Cipher;

        public Scrypto(APro apro, Cm cm)
            : base(apro, cm)
        {
        }

        public BufferedBlockCipher Cipher
        {
            get
            {
                if (_Cipher == null)
                {
                    _Cipher = new PaddedBufferedBlockCipher(_Engine);
                }
                return _Cipher;
            }
        }

        #region 接口实现
        public override void InitOpt()
        {
            _Cm.Enabled = true;

            BeanUtil.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_AES, V = "Aes" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_AESFAST, V = "AesFast" });
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_AESLIGHT, V = "AesLight" });
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_BLOWFISH, V = "Blowfish" });//0 .. 448
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_CAMELLIA, V = "Camellia" });//128, 192, 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_CAMELLIALIGHT, V = "CamelliaLight" });
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_CAST5, V = "Cast5" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_CAST6, V = "Cast6" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_DES, V = "Des" });//64
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_DESEDE, V = "DesEde" });//128, 192
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_GOST28147, V = "Gost28147" });//256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_NOEKEON, V = "Noekeon" });//128
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_NULL, V = "Null" });
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_RC2, V = "RC2" });//0 .. 1024
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_RC532, V = "RC5" });//0 .. 128
            //_Cm.CbName.Items.Add(new Item { K = IData.SCRYPTO_RC564, V = "RC5（64位）" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_RC6, V = "RC6" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_RIJNDAEL, V = "Rijndael" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_SEED, V = "Seed" });//128
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_SERPENT, V = "Serpent" });//128, 192, 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_SKIPJACK, V = "Skipjack" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_TEA, V = "Tea" });//128
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_TWOFISH, V = "Twofish" });//128, 192, 256
            _Cm.CbName.Items.Add(new Item { K = ESec.SCRYPTO_XTEA, V = "Xtea" });//128
            _Cm.CbName.Enabled = false;

            BeanUtil.Clear(_Cm.CbMode);
            _Cm.CbMode.Items.Add(new Item { K = "CBC", V = "CBC" });
            _Cm.CbMode.Items.Add(new Item { K = "CCM", V = "CCM" });
            _Cm.CbMode.Items.Add(new Item { K = "CFB", V = "CFB" });
            _Cm.CbMode.Items.Add(new Item { K = "EAX", V = "EAX" });
            _Cm.CbMode.Items.Add(new Item { K = "ECB", V = "ECB" });
            _Cm.CbMode.Items.Add(new Item { K = "GCM", V = "GCM" });
            //_Cm.CbMode.Items.Add(new Item { K = "GOFB", V = "GOFB" });
            _Cm.CbMode.Items.Add(new Item { K = "OFB", V = "OFB" });
            _Cm.CbMode.Items.Add(new Item { K = "CTS", V = "CTS" });
            _Cm.CbMode.Items.Add(new Item { K = "OpenPgpCFB", V = "OpenPgpCFB" });
            //_Cm.CbMode.Items.Add(new Item { K = "SIC", V = "SIC" });
            _Cm.LbMode.Visible = true;
            _Cm.CbMode.Enabled = false;
            _Cm.CbMode.Visible = true;

            BeanUtil.Clear(_Cm.CbPads);
            _Cm.CbPads.Items.Add(new Item { K = "ISO10126d2", V = "ISO10126d2" });
            _Cm.CbPads.Items.Add(new Item { K = "ISO7816d4", V = "ISO7816d4" });
            _Cm.CbPads.Items.Add(new Item { K = "Pkcs7", V = "Pkcs7" });
            _Cm.CbPads.Items.Add(new Item { K = "Tbc", V = "Tbc" });
            _Cm.CbPads.Items.Add(new Item { K = "X923", V = "X923" });
            _Cm.CbPads.Items.Add(new Item { K = "ZeroByte", V = "ZeroByte" });
            _Cm.LbPads.Visible = true;
            _Cm.CbPads.Enabled = false;
            _Cm.CbPads.Visible = true;
        }

        public override void InitKey(string key)
        {
            bool b = key != "0";

            _Cm.CbName.Enabled = b;

            _Cm.CbMode.Enabled = b;

            _Cm.CbPads.Enabled = b;
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
                case ESec.SCRYPTO_AES:
                    _Engine = new AesEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_AESFAST:
                    _Engine = new AesFastEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_AESLIGHT:
                    _Engine = new AesLightEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_BLOWFISH:
                    _Engine = new BlowfishEngine();
                    _KeySize = 56;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAMELLIA:
                    _Engine = new CamelliaEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAMELLIALIGHT:
                    _Engine = new CamelliaLightEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAST5:
                    _Engine = new Cast5Engine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_CAST6:
                    _Engine = new Cast6Engine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_DES:
                    _Engine = new DesEngine();
                    _KeySize = 8;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_DESEDE:
                    _Engine = new DesEdeEngine();
                    _KeySize = 24;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_GOST28147:
                    _Engine = new Gost28147Engine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_NOEKEON:
                    _Engine = new NoekeonEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_NULL:
                    _Engine = new NullEngine();
                    _KeySize = 32;
                    _IVSize = 16;
                    break;
                case ESec.SCRYPTO_RC2:
                    _Engine = new RC2Engine();
                    _KeySize = 128;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC532:
                    _Engine = new RC532Engine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC564:
                    _Engine = new RC564Engine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_RC6:
                    _Engine = new RC6Engine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_RIJNDAEL:
                    _Engine = new RijndaelEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_SEED:
                    _Engine = new SeedEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_SERPENT:
                    _Engine = new SerpentEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_SKIPJACK:
                    _Engine = new SkipjackEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_TEA:
                    _Engine = new TeaEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_TWOFISH:
                    _Engine = new TwofishEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case ESec.SCRYPTO_XTEA:
                    _Engine = new XteaEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                default:
                    _Engine = null;
                    _KeySize = 0;
                    _IVSize = 0;
                    break;
            }

            _Cm.CbMode.SelectedIndex = 0;

            _Cm.CbPads.SelectedIndex = 0;
            _Cipher = null;
        }

        public override void ChangeMode(string mode)
        {
            switch (mode)
            {
                case "CBC":
                    _Engine = new CbcBlockCipher(_Engine);
                    break;
                case "CFB":
                    _Engine = new CfbBlockCipher(_Engine, 8);
                    break;
                case "GOFB":
                    _Engine = new GOfbBlockCipher(_Engine);
                    break;
                case "OFB":
                    _Engine = new OfbBlockCipher(_Engine, 8);
                    break;
                case "OpenPgpCFB":
                    _Engine = new OpenPgpCfbBlockCipher(_Engine);
                    break;
                case "SIC":
                    _Engine = new SicBlockCipher(_Engine);
                    break;
            }

            _Cm.CbPads.SelectedIndex = 0;
            _Cipher = null;
        }

        public override void ChangePads(string pads)
        {
            IBlockCipherPadding padding = null;
            switch (pads)
            {
                case "ISO10126d2":
                    padding = new ISO10126d2Padding();
                    break;
                case "ISO7816d4":
                    padding = new ISO7816d4Padding();
                    break;
                case "Pkcs7":
                    padding = new Pkcs7Padding();
                    break;
                case "Tbc":
                    padding = new TbcPadding();
                    break;
                case "X923":
                    padding = new X923Padding();
                    break;
                case "ZeroByte":
                    padding = new ZeroBytePadding();
                    break;
            }

            _Cipher = new PaddedBufferedBlockCipher(_Engine, padding);
        }
        #endregion
    }
}