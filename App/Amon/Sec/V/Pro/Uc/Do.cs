using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd;
using Me.Amon.Sec.V.Pro.Uc.DoUi;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc
{
    public partial class Do : UserControl, IView
    {
        #region 全局变量
        private APro _APro;
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

        public Do(APro apro)
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

            _Ado = _Default;

            CbMask.Items.Add(ADo._MaskDef);
            CbMask.SelectedIndex = 0;

            CbType.Items.Add(ADo._TypeDef);
            CbType.SelectedIndex = 0;
        }

        public void InitOpt(string dir)
        {
            switch (dir)
            {
                case ESec.OPT_DIGEST:
                    _Ado = _Digest;
                    break;
                case ESec.OPT_RANDKEY:
                    _Ado = _RandKey;
                    break;
                case ESec.OPT_WRAPPER:
                    _Ado = _Wrapper;
                    break;
                case ESec.OPT_CONFUSE:
                    _Ado = _Confuse;
                    break;
                case ESec.OPT_SCRYPTO:
                    _Ado = _Scrypto;
                    break;
                case ESec.OPT_SSTREAM:
                    _Ado = _Sstream;
                    break;
                case ESec.OPT_ACRYPTO:
                    _Ado = _Acrypto;
                    break;
                case ESec.OPT_TXT2IMG:
                    _Ado = _Txt2Img;
                    break;
                default:
                    _Ado = _Default;
                    break;
            }
            _Ado.InitOpt();
        }

        public void InitDir(string dir)
        {
            _Ado.InitKey(dir);
        }

        public void InitAlg(string alg)
        {
        }

        public void FocusIn()
        {
        }

        public bool Check()
        {
            Items item = CbType.SelectedItem as Items;
            if (item == null || item.K == "0")
            {
                Main.ShowAlert("请选择输出方式！");
                CbType.Focus();
                return false;
            }
            return _Ado.Check();
        }

        public XmlElement SaveXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("output");

            XmlAttribute attr = doc.CreateAttribute("type");
            node.Attributes.Append(attr);
            Items item = CbType.SelectedItem as Items;
            if (item != null)
            {
                attr.Value = item.K;
            }

            attr = doc.CreateAttribute("key");
            node.Attributes.Append(attr);
            item = CbMask.SelectedItem as Items;
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
            XmlNode node = doc.SelectSingleNode("/msec/output");
            if (node != null)
            {
                XmlAttribute attr = node.Attributes["type"];
                if (attr != null)
                {
                    CbType.SelectedItem = new Items { K = attr.Value };
                }

                attr = node.Attributes["key"];
                if (attr == null)
                {
                    return;
                }
                for (int i = 0, j = CbMask.Items.Count; i < j; i += 1)
                {
                    Items item = CbMask.Items[i] as Items;
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
            Main.LogInfo("DO:    CbType_SelectedIndexChanged...");
#endif
            Items item = CbType.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("DO:    CbType_SelectedIndexChanged:" + item.K);
#endif
            _Ado.ChangedType(item);
        }

        private void BtData_Click(object sender, EventArgs e)
        {
            _Ado.MoreData();
        }

        private void CbMask_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("DO:    CbMask_SelectedIndexChanged...");
#endif
            Udc udc = CbMask.SelectedItem as Udc;
            if (udc == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("DO:    CbMask_SelectedIndexChanged:" + udc.Id);
#endif
            _Ado.ChangedMask(udc);
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