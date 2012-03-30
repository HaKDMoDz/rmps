using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd;
using Me.Amon.Sec.Pro.Uc.DiUi;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Pro.Uc
{
    public partial class Di : UserControl, IView
    {
        #region 全局变量
        private APro _APro;
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

        public Di(APro apro)
        {
            _APro = apro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void Init()
        {
            _Default = new Default(_APro, this);
            _Digest = new Digest(_APro, this);
            _RandKey = new RandKey(_APro, this);
            _Wrapper = new Wrapper(_APro, this);
            _Confuse = new Confuse(_APro, this);
            _Scrypto = new Scrypto(_APro, this);
            _Sstream = new Sstream(_APro, this);
            _Acrypto = new Acrypto(_APro, this);
            _Txt2Img = new Txt2Img(_APro, this);

            _Adi = _Default;

            CbMask.Items.Add(ADi._MaskDef);
            CbMask.SelectedIndex = 0;

            CbType.Items.Add(ADi._TypeDef);
            CbType.SelectedIndex = 0;
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

        public void InitDir(string dir)
        {
            _Adi.InitKey(dir);
        }

        public void InitAlg(string alg)
        {
        }

        public void FocusIn()
        {
        }

        public bool Check()
        {
            Item item = CbType.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                Main.ShowAlert("请选择输入方式！");
                CbType.Focus();
                return false;
            }

            return _Adi.Check();
        }

        public XmlElement SaveXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("input");

            XmlAttribute attr = doc.CreateAttribute("type");
            node.Attributes.Append(attr);
            Item item = CbType.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            attr = doc.CreateAttribute("key");
            node.Attributes.Append(attr);
            item = CbMask.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            attr = doc.CreateAttribute("value");
            node.Attributes.Append(attr);
            if (item != null)
            {
                attr.Value = item.D;
            }

            return node;
        }

        public void LoadXml(XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode("/msec/input");
            if (node != null)
            {
                XmlAttribute attr = node.Attributes["type"];
                if (attr != null)
                {
                    CbType.SelectedItem = new Item { K = attr.Value };
                }

                attr = node.Attributes["key"];
                if (attr == null)
                {
                    return;
                }
                for (int i = 0, j = CbMask.Items.Count; i < j; i += 1)
                {
                    Item item = CbMask.Items[i] as Item;
                    if (item == null)
                    {
                        continue;
                    }
                    if (item.K != attr.Value)
                    {
                        continue;
                    }
                    attr = node.Attributes["value"];
                    if (attr != null)
                    {
                        item.D = attr.Value;
                    }
                    CbMask.SelectedIndex = i;
                    break;
                }
            }
        }
        #endregion

        #region 事件处理
        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("DI:    CbType_SelectedIndexChanged...");
#endif
            Item item = CbType.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("DI:    CbType_SelectedIndexChanged:" + item.K);
#endif
            _Adi.ChangedType(item);
        }

        private void BtData_Click(object sender, EventArgs e)
        {
            _Adi.MoreData();
        }

        private void CbMask_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("DI:    CbMask_SelectedIndexChanged...");
#endif
            Udc udc = CbMask.SelectedItem as Udc;
            if (udc == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("DI:    CbMask_SelectedIndexChanged:" + udc.Id);
#endif
            _Adi.ChangedMask(udc);
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