using System;
using System.Text;
using System.Windows.Forms;
using Msec.Uc.UkUi;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

namespace Msec.Uc
{
    public partial class Uk : UserControl, IView
    {
        #region 全局变量
        private Main _Main;
        private AUk _Auk;

        private Default _Default;
        private Digest _Digest;
        private RandKey _RandKey;
        private Wrapper _Wrapper;
        private Confuse _Confuse;
        private Scrypto _Scrypto;
        private Sstream _Sstream;
        private Acrypto _Acrypto;
        private Txt2Img _Txt2Img;
        #endregion

        #region 构造函数
        public Uk()
        {
            InitializeComponent();
        }

        public Uk(Main main)
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

            _Auk = _Default;
        }

        public void InitOpt(string dir)
        {
            switch (dir)
            {
                case IData.OPT_DIGEST:
                    _Auk = _Digest;
                    break;
                case IData.OPT_RANDKEY:
                    _Auk = _RandKey;
                    break;
                case IData.OPT_WRAPPER:
                    _Auk = _Wrapper;
                    break;
                case IData.OPT_CONFUSE:
                    _Auk = _Confuse;
                    break;
                case IData.OPT_SCRYPTO:
                    _Auk = _Scrypto;
                    break;
                case IData.OPT_SSTREAM:
                    _Auk = _Sstream;
                    break;
                case IData.OPT_ACRYPTO:
                    _Auk = _Acrypto;
                    break;
                case IData.OPT_TXT2IMG:
                    _Auk = _Txt2Img;
                    break;
                default:
                    _Auk = _Default;
                    break;
            }
            _Auk.InitOpt();
        }

        public void InitKey(string key)
        {
            _Auk.InitKey(key);
        }

        public void FocusIn()
        {
        }

        public bool Check()
        {
            return _Auk.Check();
        }
        #endregion

        #region 事项处理
        private void BtPass_Click(object sender, EventArgs e)
        {
            _Auk.MorePass();
        }

        private void BtSalt_Click(object sender, EventArgs e)
        {
            _Auk.MoreSalt();
        }
        #endregion

        public ICipherParameters GenParam(int keySize, int ivSize)
        {
            StringBuilder buf = new StringBuilder(TbPass.Text);
            for (int i = buf.Length, j = keySize; i < j; i += 1)
            {
                buf.Append(' ');
            }
            byte[] pass = Encoding.UTF8.GetBytes(buf.ToString());

            ICipherParameters param = new KeyParameter(pass);
            if (ivSize > 0)
            {
                buf.Clear().Append(TbSalt.Text);
                for (int i = buf.Length, j = ivSize; i < j; i += 1)
                {
                    buf.Append(' ');
                }
                byte[] iv = Encoding.UTF8.GetBytes(buf.ToString());
                param = new ParametersWithIV(new KeyParameter(pass), iv);
            }
            return param;
            //return new ParametersWithSalt(_Auk.GenParam("", TbPass.Text), Encoding.Default.GetBytes(buf.ToString()));
        }
    }
}