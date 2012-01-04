using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;

namespace Msec.Uc.CmUi
{
    public class Scrypto : ACm
    {
        private IBlockCipher _Engine;
        private BufferedBlockCipher _Cipher;

        public Scrypto(Main main, Cm cm)
            : base(main, cm)
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

            Util.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = "Aes", V = "Aes" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = "AesFast", V = "AesFast" });
            _Cm.CbName.Items.Add(new Item { K = "AesLight", V = "AesLight" });
            _Cm.CbName.Items.Add(new Item { K = "Blowfish", V = "Blowfish" });//0 .. 448
            _Cm.CbName.Items.Add(new Item { K = "Camellia", V = "Camellia" });//128, 192, 256
            _Cm.CbName.Items.Add(new Item { K = "CamelliaLight", V = "CamelliaLight" });
            _Cm.CbName.Items.Add(new Item { K = "Cast5", V = "Cast5" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = "Cast6", V = "Cast6" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = "Des", V = "Des" });//64
            _Cm.CbName.Items.Add(new Item { K = "DesEde", V = "DesEde" });//128, 192
            _Cm.CbName.Items.Add(new Item { K = "Gost28147", V = "Gost28147" });//256
            _Cm.CbName.Items.Add(new Item { K = "Noekeon", V = "Noekeon" });//128
            _Cm.CbName.Items.Add(new Item { K = "Null", V = "Null" });
            _Cm.CbName.Items.Add(new Item { K = "RC2", V = "RC2" });//0 .. 1024
            _Cm.CbName.Items.Add(new Item { K = "RC532", V = "RC532" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = "RC564", V = "RC564" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = "RC6", V = "RC6" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = "Rijndael", V = "Rijndael" });//0 .. 256
            _Cm.CbName.Items.Add(new Item { K = "Seed", V = "Seed" });//128
            _Cm.CbName.Items.Add(new Item { K = "Serpent", V = "Serpent" });//128, 192, 256
            _Cm.CbName.Items.Add(new Item { K = "Skipjack", V = "Skipjack" });//0 .. 128
            _Cm.CbName.Items.Add(new Item { K = "Tea", V = "Tea" });//128
            _Cm.CbName.Items.Add(new Item { K = "Twofish", V = "Twofish" });//128, 192, 256
            _Cm.CbName.Items.Add(new Item { K = "Xtea", V = "Xtea" });//128
            _Cm.CbName.Enabled = false;

            Util.Clear(_Cm.CbMode);
            _Cm.CbMode.Items.Add(new Item { K = "CBC", V = "CBC" });
            _Cm.CbMode.Items.Add(new Item { K = "CCM", V = "CCM" });
            _Cm.CbMode.Items.Add(new Item { K = "CFB", V = "CFB" });
            _Cm.CbMode.Items.Add(new Item { K = "EAX", V = "EAX" });
            _Cm.CbMode.Items.Add(new Item { K = "ECB", V = "ECB" });
            _Cm.CbMode.Items.Add(new Item { K = "GCM", V = "GCM" });
            _Cm.CbMode.Items.Add(new Item { K = "GOFB", V = "GOFB" });
            _Cm.CbMode.Items.Add(new Item { K = "OFB", V = "OFB" });
            _Cm.CbMode.Items.Add(new Item { K = "CTS", V = "CTS" });
            _Cm.CbMode.Items.Add(new Item { K = "OpenPgpCFB", V = "OpenPgpCFB" });
            _Cm.CbMode.Items.Add(new Item { K = "SIC", V = "SIC" });
            _Cm.LbMode.Visible = true;
            _Cm.CbMode.Enabled = false;
            _Cm.CbMode.Visible = true;

            Util.Clear(_Cm.CbPads);
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
                case "Aes":
                    _Engine = new AesEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "AesFast":
                    _Engine = new AesFastEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "AesLight":
                    _Engine = new AesLightEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Blowfish":
                    _Engine = new BlowfishEngine();
                    _KeySize = 56;
                    _IVSize = 0;
                    break;
                case "Camellia":
                    _Engine = new CamelliaEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "CamelliaLight":
                    _Engine = new CamelliaLightEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Cast5":
                    _Engine = new Cast5Engine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "Cast6":
                    _Engine = new Cast6Engine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Des":
                    _Engine = new DesEngine();
                    _KeySize = 8;
                    _IVSize = 0;
                    break;
                case "DesEde":
                    _Engine = new DesEdeEngine();
                    _KeySize = 24;
                    _IVSize = 0;
                    break;
                case "Gost28147":
                    _Engine = new Gost28147Engine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Noekeon":
                    _Engine = new NoekeonEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "Null":
                    _Engine = new NullEngine();
                    _KeySize = 32;
                    _IVSize = 16;
                    break;
                case "RC2":
                    _Engine = new RC2Engine();
                    _KeySize = 128;
                    _IVSize = 0;
                    break;
                case "RC532":
                    _Engine = new RC532Engine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "RC564":
                    _Engine = new RC564Engine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "RC6":
                    _Engine = new RC6Engine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Rijndael":
                    _Engine = new RijndaelEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Seed":
                    _Engine = new SeedEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "Serpent":
                    _Engine = new SerpentEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Skipjack":
                    _Engine = new SkipjackEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "Tea":
                    _Engine = new TeaEngine();
                    _KeySize = 16;
                    _IVSize = 0;
                    break;
                case "Twofish":
                    _Engine = new TwofishEngine();
                    _KeySize = 32;
                    _IVSize = 0;
                    break;
                case "Xtea":
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