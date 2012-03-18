using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanGuid : UserControl, IWizView
    {
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        #region 构造函数
        public BeanGuid()
        {
            InitializeComponent();
        }

        public BeanGuid(AWiz awiz, SafeModel safeModel)
        {
            InitializeComponent();

            _SafeModel = safeModel;
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            PbCard.Image = viewModel.GetImage("export-card-24");

            if (!Directory.Exists("Card"))
            {
                return;
            }

            EventHandler exportHandler = new EventHandler(ExportCard_Click);

            XmlDocument doc = new XmlDocument();
            ToolStripMenuItem item;
            XmlNode node;
            foreach (string cardFile in Directory.GetFiles("Card", "*.acxml"))
            {
                try
                {
                    doc.Load(cardFile);

                    node = doc.SelectSingleNode("/amon/info/name");
                    string name = (node != null ? node.InnerText ?? "未知" : Path.GetFileName(cardFile));
                    node = doc.SelectSingleNode("/amon/info/type");
                    string type = (node != null ? node.InnerText ?? "" : "all").Trim().ToLower();

                    item = new ToolStripMenuItem();
                    item.Text = name;

                    if ("htm" == type)
                    {
                        item.Tag = "htm:" + cardFile;
                        item.Click += exportHandler;
                        CcHtm.DropDownItems.Add(item);
                        continue;
                    }
                    if ("svg" == type)
                    {
                        item.Tag = "svg:" + cardFile;
                        item.Click += exportHandler;
                        CcHtm.DropDownItems.Add(item);
                        continue;
                    }
                    if ("txt" == type)
                    {
                        item.Tag = "txt:" + cardFile;
                        item.Click += exportHandler;
                        CcTxt.DropDownItems.Add(item);
                        continue;
                    }
                    if ("vcf" == type)
                    {
                        item.Tag = "vcf:" + cardFile;
                        item.Click += exportHandler;
                        CcTxt.DropDownItems.Add(item);
                        continue;
                    }
                    if ("png" == type)
                    {
                        item.Tag = "png:" + cardFile;
                        item.Click += exportHandler;
                        CcImg.DropDownItems.Add(item);
                        continue;
                    }
                    if ("qrc" == type)
                    {
                        item.Tag = "qrc:" + cardFile;
                        item.Click += exportHandler;
                        CcImg.DropDownItems.Add(item);
                        continue;
                    }
                    item.Tag = "all:" + cardFile;
                    item.Click += exportHandler;
                    CmCard.Items.Add(item);
                }
                catch (Exception exp)
                {
                    Main.ShowError(exp);
                    return;
                }
            }
        }
        #endregion

        #region 接口实现
        public void InitView(TableLayoutPanel grid)
        {
            grid.Controls.Add(this, 0, 0);
            Dock = DockStyle.Fill;
            TabIndex = 0;
            grid.RowStyles[1].Height = 32;
        }

        public void HideView(TableLayoutPanel grid)
        {
            grid.Controls.Remove(this);
        }

        public void ShowData()
        {
            if ((_DataModel.LibModified & IEnv.KEY_AWIZ) > 0)
            {
                CbLib.DataSource = null;
                CbLib.DataSource = _DataModel.LibList;
                CbLib.DisplayMember = "Name";
                CbLib.ValueMember = "Id";
                _DataModel.LibModified &= ~IEnv.KEY_AWIZ;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (guid == null)
            {
                return;
            }

            CbLib.SelectedValue = new Item { K = guid.GetSpec(GuidAtt.SPEC_GUID_TPLT) };
        }

        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            LibHeader lib = CbLib.SelectedItem as LibHeader;
            if (lib == null || !CharUtil.IsValidateHash(lib.Id))
            {
                Main.ShowAlert("请选择您要使用的模板！");
                CbLib.Focus();
                return false;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (lib.Id != guid.GetSpec(GuidAtt.SPEC_GUID_TPLT))
            {
                guid.SetSpec(GuidAtt.SPEC_GUID_TPLT, lib.Id);
                if (!_SafeModel.Key.IsUpdate)
                {
                    _SafeModel.InitData(lib);
                }
                guid.Modified = true;
                _SafeModel.Key.Modified |= guid.Modified;
            }

            return true;
        }

        public void CopyData()
        {
        }
        #endregion

        #region 事件处理
        private void PbCard_Click(object sender, EventArgs e)
        {
            CmCard.Show(PbCard, 0, PbCard.Height);
        }

        private void ExportCard_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            string command = item.Tag as string;
            if (!CharUtil.IsValidate(command))
            {
                return;
            }

            int dot = command.IndexOf(':');
            if (dot < 0)
            {
                return;
            }

            string key = command.Substring(0, dot).ToLower();
            string src = command.Substring(dot + 1);
            if (!CharUtil.IsValidate(key) || !CharUtil.IsValidate(src))
            {
                return;
            }
            if (!File.Exists(src))
            {
                Main.ShowAlert(string.Format("无法读取卡片模板文件：{0}", src));
                return;
            }

            FolderBrowserDialog fd = new FolderBrowserDialog();
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            string dst = fd.SelectedPath;
            if (!CharUtil.IsValidate(dst))
            {
                Main.ShowAlert("您选择的目录不存在！");
                return;
            }

            Card card = new Card(_SafeModel);
            switch (key)
            {
                case "htm":
                    card.ExportHtm(src, dst);
                    break;
                case "svg":
                    card.ExportSvg(src, dst);
                    break;
                case "txt":
                    card.ExportTxt(src, dst);
                    break;
                case "vcf":
                    card.ExportVcf(src, dst);
                    break;
                case "png":
                    card.ExportPng(src, dst);
                    break;
                case "qrc":
                    card.ExportQrc(src, dst);
                    break;
                case "all":
                    card.ExportAll(src, dst);
                    break;
                default:
                    return;
            }
        }
        #endregion
    }
}
