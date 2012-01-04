using System;
using System.Text;
using System.Windows.Forms;
using Msec.Uc.DoUi;

namespace Msec.Uc
{
    public partial class Do : UserControl, IView
    {
        #region 全局变量
        private Main _Main;
        private ADo _Ado;

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
        public Do()
        {
            InitializeComponent();
        }

        public Do(Main main)
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

            _Ado = _Default;

            CbType.Items.Add(ADo._TypeDef);
            CbType.SelectedIndex = 0;
            CbMask.Items.Add(ADo._MaskDef);
            CbMask.SelectedIndex = 0;
        }

        public void InitOpt(string dir)
        {
            switch (dir)
            {
                case IData.OPT_DIGEST:
                    _Ado = _Digest;
                    break;
                case IData.OPT_RANDKEY:
                    _Ado = _RandKey;
                    break;
                case IData.OPT_WRAPPER:
                    _Ado = _Wrapper;
                    break;
                case IData.OPT_CONFUSE:
                    _Ado = _Confuse;
                    break;
                case IData.OPT_SCRYPTO:
                    _Ado = _Scrypto;
                    break;
                case IData.OPT_SSTREAM:
                    _Ado = _Sstream;
                    break;
                case IData.OPT_ACRYPTO:
                    _Ado = _Acrypto;
                    break;
                case IData.OPT_TXT2IMG:
                    _Ado = _Txt2Img;
                    break;
                default:
                    _Ado = _Default;
                    break;
            }
            _Ado.InitOpt();
        }

        public void InitKey(string key)
        {
            _Ado.InitKey(key);
        }

        public void FocusIn()
        {
        }

        public bool Check()
        {
            Item item = CbType.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                _Main.ShowAlert("请选择输出方式！");
                CbType.Focus();
                return false;
            }
            return _Ado.Check();
        }
        #endregion

        #region 事项处理
        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbType.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _Ado.ChangedType(item);
        }

        private void BtData_Click(object sender, EventArgs e)
        {
            _Ado.MoreData();
        }

        private void CbMask_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbMask.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _Ado.ChangedMask(item);
        }

        private void BtMask_Click(object sender, EventArgs e)
        {
            _Ado.MoreMask();
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
            _Ado.Begin();
        }

        public void Write(byte[] buffer, int offset, int count)
        {
            _Ado.Write(buffer, offset, count);
        }

        public void End()
        {
            _Ado.End();
        }
        #endregion

        private void TbData_DragDrop(object sender, DragEventArgs e)
        {
            _Ado.DragDrop(e);
        }

        private void TbData_DragEnter(object sender, DragEventArgs e)
        {
            _Ado.DragEnter(e);
        }
    }
}