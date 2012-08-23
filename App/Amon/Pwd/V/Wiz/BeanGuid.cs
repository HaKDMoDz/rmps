using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz
{
    public partial class BeanGuid : UserControl, IWizView
    {
        private AWiz _AWiz;
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        #region 构造函数
        public BeanGuid()
        {
            InitializeComponent();
        }

        public BeanGuid(AWiz awiz, SafeModel safeModel)
        {
            _AWiz = awiz;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            PbCard.Image = viewModel.GetImage("export-card-24");
            _AWiz.ShowTips(PbCard, "导出为卡片");

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
                    CcAll.DropDownItems.Add(item);
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
            if ((_DataModel.LibModified & CPwd.KEY_AWIZ) > 0)
            {
                CbLib.Items.Clear();
                foreach (Lib header in _DataModel.LibList)
                {
                    CbLib.Items.Add(header);
                }
                _DataModel.LibModified &= ~CPwd.KEY_AWIZ;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (guid == null)
            {
                return;
            }

            CbLib.SelectedItem = new Lib { Id = guid.Data };
            PbCard.Visible = guid.Data == CApp.LIB_CARD;
        }

        public bool SaveData()
        {
            if (_SafeModel.Key == null)
            {
                return false;
            }

            Lib lib = CbLib.SelectedItem as Lib;
            if (lib == null || !CharUtil.IsValidateHash(lib.Id))
            {
                Main.ShowAlert("请选择您要使用的模板！");
                CbLib.Focus();
                return false;
            }

            GuidAtt guid = _SafeModel.Guid;
            if (lib.Id != guid.Data)
            {
                guid.Data = lib.Id;
                if (!_SafeModel.IsUpdate)
                {
                    _SafeModel.InitData(lib);
                }
                guid.Modified = true;
                _SafeModel.Modified |= guid.Modified;
            }

            return true;
        }

        public void CutData()
        {
        }

        public void CopyData()
        {
        }

        public void PasteData()
        {
        }

        public void ClearData()
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
