using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Wiz.Editer
{
    public partial class KeyGuid : UserControl, IKeyEditer
    {
        private WWiz _AWiz;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;

        #region 构造函数
        public KeyGuid()
        {
            InitializeComponent();
        }

        public KeyGuid(WWiz awiz, UserModel userModel, SafeModel safeModel)
        {
            _AWiz = awiz;
            _UserModel = userModel;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            PbFill.Image = viewModel.GetImage("script-fill-24");
            _AWiz.ShowTips(PbFill, "执行填充脚本");
            PbCard.Image = viewModel.GetImage("export-card-24");
            _AWiz.ShowTips(PbCard, "导出为卡片");

            string path = Path.Combine(_UserModel.SysHome, "Card");
            if (!Directory.Exists(path))
            {
                return;
            }

            EventHandler exportHandler = new EventHandler(ExportCard_Click);

            XmlDocument doc = new XmlDocument();
            ToolStripMenuItem item;
            XmlNode node;
            foreach (string cardFile in Directory.GetFiles(path, "*.acxml"))
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
        public void ShowData()
        {
            GuidAtt guid = _SafeModel.Guid;
            if (guid == null)
            {
                return;
            }

            PbCard.Visible = guid.Data == CApp.LIB_CARD;
            UcHint.Visible = false;

            Gtd.M.MGtd gtd = _SafeModel.Key.Gtd;
            if (gtd == null)
            {
                return;
            }

            if (gtd.Status == Gtd.CGtd.STATUS_EXPIRED)
            {
                ShowHint(string.Format("您有一个过期提醒：{0}{0}　　{1}{0}{0}{2}", Environment.NewLine, gtd.Title, gtd.NextTime.ToString(CApp.DATEIME_FORMAT)));
                return;
            }
            if (gtd.Status == Gtd.CGtd.STATUS_ONTIME)
            {
                ShowHint(string.Format("您有一个待办提醒：{0}{0}　　{1}{0}{0}{2}", Environment.NewLine, gtd.Title, gtd.NextTime.ToString(CApp.DATEIME_FORMAT)));
                return;
            }
        }

        public void CopyData(CopyType type)
        {
        }

        public void FillData()
        {
        }
        #endregion

        public void ShowHint(string hints)
        {
            UcHint.Visible = true;
            UcHint.Text = hints;
        }

        #region 事件处理
        private void PbFill_Click(object sender, EventArgs e)
        {
            _AWiz.FillData();
        }

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
            fd.Description = "请选择卡片保存目录：";
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

            Card card = new Card(_SafeModel, _UserModel.SysHome);
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

        public void InitView(Panel panel)
        {
            panel.Controls.Add(this);
            Dock = DockStyle.Fill;
        }

        public void HideView(Panel panel)
        {
            panel.Controls.Remove(this);
        }

        public bool SaveData()
        {
            return true;
        }

        public void CutData()
        {
        }

        public void PasteData()
        {
        }

        public void ClearData()
        {
        }

        private void Hint_Click(object sender, EventArgs e)
        {
            Gtd.M.MGtd gtd = _SafeModel.Key.Gtd;
            if (gtd != null)
            {
                DateTime now = DateTime.Now;
                gtd.LastTime = now;
                if (gtd.Next(now, 0))
                {
                    _DataModel.SaveVcs(gtd);
                }
            }
            UcHint.Visible = false;
        }
    }
}
