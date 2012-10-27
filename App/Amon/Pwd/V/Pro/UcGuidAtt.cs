using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Pwd.M;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcGuidAtt : UserControl, IAttEditer
    {
        private APro _APro;
        private Att _Att;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private DataTable _DataTable;

        #region 构造函数
        public UcGuidAtt()
        {
            InitializeComponent();
        }

        public UcGuidAtt(APro aPro, SafeModel safeModel, DataTable dataTable)
        {
            _APro = aPro;
            _SafeModel = safeModel;
            _DataTable = dataTable;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            PbCard.Image = viewModel.GetImage("export-card-16");
            _APro.ShowTips(PbCard, "导出为卡片");

            if (!Directory.Exists("Card"))
            {
                return;
            }

            #region 名片模板初始化
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
            #endregion
        }

        public Control Control { get { return this; } }

        public string Title { get { return "向导"; } }

        public bool ShowData(Att att)
        {
            if ((_DataModel.LibModified & CPwd.KEY_APRO) > 0)
            {
                CbName.Items.Clear();
                foreach (Lib header in _DataModel.LibList)
                {
                    CbName.Items.Add(header);
                }
                _DataModel.LibModified &= ~CPwd.KEY_APRO;
            }

            _Att = att;

            CbName.SelectedItem = new Lib { Id = _Att.Data };
            PbCard.Visible = _Att.Data == CApp.LIB_CARD;
            return true;
        }

        public new bool Focus()
        {
            return CbName.Focus();
        }

        public void Cut()
        {
        }

        public void Copy()
        {
        }

        public void Paste()
        {
        }

        public void Clear()
        {
        }

        public bool Save()
        {
            Lib header = CbName.SelectedItem as Lib;
            if (header == null || header.Id == "0")
            {
                return false;
            }

            if (header.Id != _Att.Data)
            {
                _Att.Data = header.Id;
                if (!_SafeModel.IsUpdate)
                {
                    Att att;
                    if (_SafeModel.Count < Att.HEAD_SIZE)
                    {
                        att = _SafeModel.InitMeta();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitLogo();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitHint();
                        _DataTable.Rows.Add(att.Order, att);
                        att = _SafeModel.InitAuto();
                        _DataTable.Rows.Add(att.Order, att);
                    }
                    _SafeModel.InitData(header);
                    for (int i = _DataTable.Rows.Count - 1; i >= Att.HEAD_SIZE; i -= 1)
                    {
                        _DataTable.Rows.RemoveAt(i);
                    }
                    for (int i = Att.HEAD_SIZE; i < _SafeModel.Count; i += 1)
                    {
                        att = _SafeModel.GetAtt(i);
                        _DataTable.Rows.Add(att.Order, att);
                    }
                }
                _Att.Modified = true;
            }

            return true;
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
