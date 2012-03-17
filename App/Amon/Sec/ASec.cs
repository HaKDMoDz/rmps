using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Uc;

namespace Me.Amon.Sec
{
    public partial class ASec : Form, IApp
    {
        #region 全局变量
        private UserModel _UserModel;
        private DataModel _DataModel;
        #endregion

        #region 构造函数
        public ASec()
        {
            InitializeComponent();
        }

        public ASec(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            //BtDo.Text = "执行(&R)";
        }

        public int AppId { get; set; }

        public Form Form { get { return this; } }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void BtDo_Click(object sender, EventArgs e)
        {
            //if (!Worker.IsBusy)
            //{
            //    Worker.RunWorkerAsync();
            //    BtDo.Text = "取消(&R)";
            //    return;
            //}

            //if (DialogResult.Yes == MessageBox.Show(this, "确认要取消操作吗？", "友情提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            //{
            //    Worker.CancelAsync();
            //    return;
            //}
            DoWork(null, null);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            Item opt = CbOpt.SelectedItem as Item;
            if (opt == null || opt.K == "0")
            {
                Main.ShowAlert("请选择您要执行的操作！");
                CbOpt.Focus();
                return;
            }

            Item key = CbKey.SelectedItem as Item;

            ShowInfo("处理中，请稍候……");

            if (!_UcCm.Check())
            {
                return;
            }
            if (!_UcUk.Check())
            {
                return;
            }
            if (!_UcDi.Check())
            {
                return;
            }
            if (!_UcDo.Check())
            {
                return;
            }

            switch (opt.K)
            {
                case IData.OPT_DIGEST:
                    Digest();
                    break;
                case IData.OPT_RANDKEY:
                    Randkey();
                    break;
                case IData.OPT_WRAPPER:
                    if (key == null || key.K == "0")
                    {
                        Main.ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Wrapper();
                    break;
                case IData.OPT_SCRYPTO:
                    if (key == null || key.K == "0")
                    {
                        Main.ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Scrypto(key.K != IData.DIR_DEC);
                    break;
                case IData.OPT_SSTREAM:
                    if (key == null || key.K == "0")
                    {
                        Main.ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Sstream(key.K != IData.DIR_DEC);
                    break;
                case IData.OPT_ACRYPTO:
                    if (key == null || key.K == "0")
                    {
                        Main.ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Acrypto(key.K != IData.DIR_DEC);
                    break;
                case IData.OPT_TXT2IMG:
                    Txt2Img();
                    break;
                default:
                    break;
            }
        }

        private void DoWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ShowInfo("用户已取消！");
            }
        }
        #endregion

        #region 公有方法
        public void ShowInfo(string info)
        {
            LbInfo.Text = info;
            TpTips.SetToolTip(LbInfo, info);
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }
        #endregion

        private void MiSave_Click(object sender, EventArgs e)
        {
            Item item = CbOpt.SelectedItem as Item;
            if (item == null || item.K == "0")
            {
                Main.ShowAlert("默认操作不需要保存！");
                return;
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.AddExtension = true;
            fd.DefaultExt = ".asxml";
            fd.Filter = "加密器文件(*.asxml)|*.asxml";
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(dec);

            XmlElement root = doc.CreateElement("msec");
            doc.AppendChild(root);

            XmlElement node = doc.CreateElement("operation");
            root.AppendChild(node);
            XmlAttribute attr = doc.CreateAttribute("key");
            node.Attributes.Append(attr);
            if (item != null)
            {
                attr.Value = item.K;
            }

            attr = doc.CreateAttribute("dir");
            node.Attributes.Append(attr);
            item = CbKey.SelectedItem as Item;
            if (item != null)
            {
                attr.Value = item.K;
            }

            root.AppendChild(_UcCm.SaveXml(doc));
            root.AppendChild(_UcUk.SaveXml(doc));
            root.AppendChild(_UcDi.SaveXml(doc));
            root.AppendChild(_UcDo.SaveXml(doc));

            doc.Save(fd.FileName);
        }

        private void MiLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.AddExtension = true;
            fd.DefaultExt = ".asxml";
            fd.Filter = "加密器文件(*.asxml)|*.asxml";
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            XmlDocument doc = new XmlDocument();
            doc.Load(fd.FileName);

            XmlNode node = doc.SelectSingleNode("/msec/operation");
            if (node != null)
            {
                XmlAttribute attr = node.Attributes["key"];
                if (attr != null)
                {
                    CbOpt.SelectedItem = new Item { K = attr.Value };
                }
                attr = node.Attributes["dir"];
                if (attr != null)
                {
                    CbKey.SelectedItem = new Item { K = attr.Value };
                }
            }

            _UcCm.LoadXml(doc);
            _UcUk.LoadXml(doc);
            _UcDi.LoadXml(doc);
            _UcDo.LoadXml(doc);
        }
    }
}
