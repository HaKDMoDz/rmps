using System;
using System.Windows.Forms;
using Msec.Uc.CmUi;
using Org.BouncyCastle.Crypto;

namespace Msec.Uc
{
    public partial class Cm : UserControl, IView
    {
        private Main _Main;
        private ACm _Acm;

        private Default _Default;
        private Digest _Digest;
        private RandKey _RandKey;
        private Wrapper _Wrapper;
        private Confuse _Confuse;
        private Scrypto _Scrypto;
        private Sstream _Sstream;
        private Acrypto _Acrypto;
        private Txt2Img _Txt2Img;

        #region 构造函数
        public Cm()
        {
            InitializeComponent();
        }

        public Cm(Main main)
        {
            _Main = main;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void Init()
        {
            _Default = new Default(_Main, this);
            _Digest = new Digest(_Main, this);
            _RandKey = new RandKey(_Main, this);
            _Wrapper = new Wrapper(_Main, this);
            _Confuse = new Confuse(_Main, this);
            _Scrypto = new Scrypto(_Main, this);
            _Sstream = new Sstream(_Main, this);
            _Acrypto = new Acrypto(_Main, this);
            _Txt2Img = new Txt2Img(_Main, this);

            _Acm = _Default;

            CbName.Items.Add(ACm._NameDef);
            CbName.SelectedIndex = 0;

            CbMode.Items.Add(ACm._ModeDef);
            CbMode.SelectedIndex = 0;

            CbPads.Items.Add(ACm._SizeDef);
            CbPads.SelectedIndex = 0;
        }

        public void InitOpt(string opt)
        {
            switch (opt)
            {
                case IData.OPT_DIGEST:
                    _Acm = _Digest;
                    break;
                case IData.OPT_RANDKEY:
                    _Acm = _RandKey;
                    break;
                case IData.OPT_WRAPPER:
                    _Acm = _Wrapper;
                    break;
                case IData.OPT_CONFUSE:
                    _Acm = _Confuse;
                    break;
                case IData.OPT_SCRYPTO:
                    _Acm = _Scrypto;
                    break;
                case IData.OPT_SSTREAM:
                    _Acm = _Sstream;
                    break;
                case IData.OPT_ACRYPTO:
                    _Acm = _Acrypto;
                    break;
                case IData.OPT_TXT2IMG:
                    _Acm = _Txt2Img;
                    break;
                default:
                    _Acm = _Default;
                    break;
            }
            _Acm.InitOpt();
        }

        public void InitKey(string key)
        {
            _Acm.InitKey(key);
        }

        public void FocusIn()
        {
            CbName.Focus();
        }

        public bool Check()
        {
            Item item = CbName.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                _Main.ShowAlert("请选择算法名称！");
                CbName.Focus();
                return false;
            }
            return true;
        }
        #endregion

        #region 事项处理
        private void CbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbName.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _Acm.ChangeName(item.K);
        }

        private void CbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbMode.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            string mode = item.K == "0" ? item.D : item.K;
            if (mode != null)
            {
                _Acm.ChangeMode(mode);
            }
        }

        private void CbPads_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbPads.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            string size = item.K == "0" ? item.D : item.K;
            if (size != null)
            {
                _Acm.ChangePads(size);
            }
        }
        #endregion

        public int KeySize
        {
            get
            {
                return _Acm.KeySize;
            }
        }

        public int IVSize
        {
            get
            {
                return _Acm.IVSize;
            }
        }

        public BufferedBlockCipher SBlock
        {
            get
            {
                return _Scrypto.Cipher;
            }
        }

        public BufferedAsymmetricBlockCipher ABlock
        {
            get
            {
                return _Acrypto.Cipher;
            }
        }

        public IDigest Digest
        {
            get
            {
                return _Digest.Cipher;
            }
        }

        public Ce.Wrapper Confuse
        {
            get
            {
                return _Confuse.Cipher;
            }
        }

        public BufferedStreamCipher Stream
        {
            get
            {
                return _Sstream.Cipher;
            }
        }

        public string Txt2Img
        {
            get
            {
                return "txt2img";
            }
        }
    }
}