using System;
using System.Text;
using System.Windows.Forms;
using Msec.Uc.DiUi;

namespace Msec.Uc
{
    public partial class Di : UserControl, IView
    {
        #region 全局变量
        private Main _Main;
        private ADi _Adi;

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
        public Di()
        {
            InitializeComponent();
        }

        public Di(Main main)
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

            _Adi = _Default;

            CbType.Items.Add(ADi._TypeDef);
            CbType.SelectedIndex = 0;
            CbMask.Items.Add(ADi._MaskDef);
            CbMask.SelectedIndex = 0;
        }

        public void InitOpt(string opt)
        {
            switch (opt)
            {
                case IData.OPT_DIGEST:
                    _Adi = _Digest;
                    break;
                case IData.OPT_RANDKEY:
                    _Adi = _RandKey;
                    break;
                case IData.OPT_WRAPPER:
                    _Adi = _Wrapper;
                    break;
                case IData.OPT_CONFUSE:
                    _Adi = _Confuse;
                    break;
                case IData.OPT_SCRYPTO:
                    _Adi = _Scrypto;
                    break;
                case IData.OPT_SSTREAM:
                    _Adi = _Sstream;
                    break;
                case IData.OPT_ACRYPTO:
                    _Adi = _Acrypto;
                    break;
                case IData.OPT_TXT2IMG:
                    _Adi = _Txt2Img;
                    break;
                default:
                    _Adi = _Default;
                    break;
            }
            _Adi.InitOpt();
        }

        public void InitKey(string key)
        {
            _Adi.InitKey(key);
        }

        public void FocusIn()
        {
        }

        public bool Check()
        {
            Item item = CbType.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                _Main.ShowAlert("请选择输入方式！");
                CbType.Focus();
                return false;
            }

            return _Adi.Check();
        }
        #endregion

        #region 事件处理
        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbType.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _Adi.ChangedType(item);
        }

        private void BtData_Click(object sender, EventArgs e)
        {
            _Adi.MoreData();
        }

        private void CbMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbMask.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _Adi.ChangedMask(item);
        }

        private void BtMask_Click(object sender, EventArgs e)
        {
            _Adi.MoreMask();
        }
        #endregion

        #region 方法重载
        private StringBuilder _Data = new StringBuilder();
        public StringBuilder UserData
        {
            get
            {
                return _Data;
            }
        }

        public void ShowData()
        {
            TbData.Text = _Data.Length > 20 ? _Data.ToString(0, 15) + "……" : _Data.ToString();
        }
        #endregion

        #region 数据处理
        public void Begin()
        {
            _Adi.Begin();
        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return _Adi.Read(buffer, offset, count);
        }

        public void End()
        {
            _Adi.End();
        }
        #endregion

        private void TbData_DragDrop(object sender, DragEventArgs e)
        {
            _Adi.DragDrop(e);
        }

        private void TbData_DragEnter(object sender, DragEventArgs e)
        {
            _Adi.DragEnter(e);
        }
    }
}