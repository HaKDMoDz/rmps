﻿using System;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Sec.Pro.Uc.UkUi;
using Me.Amon.Uc;
using Org.BouncyCastle.Crypto;

namespace Me.Amon.Sec.Pro.Uc
{
    public partial class Uk : UserControl, IView
    {
        #region 全局变量
        private ASec _ASec;
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

        public Uk(ASec asec)
        {
            _ASec = asec;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void Init()
        {
            _Default = new Default(_ASec, this);
            _Digest = new Digest(_ASec, this);
            _RandKey = new RandKey(_ASec, this);
            _Wrapper = new Wrapper(_ASec, this);
            _Confuse = new Confuse(_ASec, this);
            _Scrypto = new Scrypto(_ASec, this);
            _Sstream = new Sstream(_ASec, this);
            _Acrypto = new Acrypto(_ASec, this);
            _Txt2Img = new Txt2Img(_ASec, this);

            _Auk = _Default;

            CbSize.Items.Add(AUk._SizeDef);
            CbSize.SelectedIndex = 0;
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

        public void InitDir(string dir)
        {
            _Auk.InitDir(dir);
        }

        public void InitAlg(string alg)
        {
            _Auk.InitAlg(alg);
        }

        public void FocusIn()
        {
        }

        public bool Check()
        {
            return _Auk.Check();
        }

        public XmlElement SaveXml(XmlDocument doc)
        {
            XmlElement node = doc.CreateElement("key");

            XmlAttribute attr = doc.CreateAttribute("size");
            node.Attributes.Append(attr);
            Item item = CbSize.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            return node;
        }

        public void LoadXml(XmlDocument doc)
        {
            XmlNode node = doc.SelectSingleNode("/msec/key");
            if (node != null)
            {
                XmlAttribute attr = node.Attributes["size"];
                if (attr != null)
                {
                    CbSize.SelectedItem = new Item { K = attr.Value };
                }
            }
        }
        #endregion

        #region 事项处理
        private void CbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
#if DEBUG
            Main.LogInfo("CbSize_SelectedIndexChanged...");
#endif
            Item item = CbSize.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

#if DEBUG
            Main.LogInfo("CbSize_SelectedIndexChanged:" + item.K);
#endif
            int len = int.Parse(item.K == "0" ? item.D : item.K);
            if (TbPass.Text.Length > len)
            {
                TbPass.Text = TbPass.Text.Substring(0, len);
            }
            if (TbSalt.Text.Length > len)
            {
                TbSalt.Text = TbSalt.Text.Substring(0, len);
            }
            TbPass.MaxLength = len;
            TbSalt.MaxLength = len;
        }

        private void BtPass_Click(object sender, EventArgs e)
        {
            _Auk.MorePass();
        }

        private void BtSalt_Click(object sender, EventArgs e)
        {
            _Auk.MoreSalt();
        }
        #endregion

        public ICipherParameters GenParam()
        {
            return _Auk.GenParam();
        }

        private void TbPass_GotFocus(object sender, EventArgs e)
        {
            TbPass.SelectAll();
        }

        private void TbSalt_GotFocus(object sender, EventArgs e)
        {
            TbSalt.SelectAll();
        }
    }
}