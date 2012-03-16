using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanHead : UserControl, IWizView
    {
        private AWiz _AWiz;
        private Bean.Ico _AIco;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private TextBox _TBox;

        #region 构造函数
        public BeanHead()
        {
            InitializeComponent();
        }

        public BeanHead(AWiz awiz, SafeModel safeModel)
        {
            _AWiz = awiz;
            _SafeModel = safeModel;

            InitializeComponent();
        }

        public void Init(DataModel dataModel)
        {
            _DataModel = dataModel;
            _AIco = new Bean.Ico();

            TbName.GotFocus += new EventHandler(TbName_GotFocus);
            TbMeta.GotFocus += new EventHandler(TbMeta_GotFocus);
            TbHint.GotFocus += new EventHandler(TbHint_GotFocus);
            TbMemo.GotFocus += new EventHandler(TbMemo_GotFocus);
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

            MetaAtt meta = _SafeModel.Meta;
            if (meta == null)
            {
                return;
            }
            TbName.Text = meta.Name;
            TbMeta.Text = meta.Data;

            LogoAtt logo = _SafeModel.Logo;
            if (logo == null)
            {
                return;
            }
            _AIco.File = logo.Name;
            _AIco.Path = logo.Path;
            if (!CharUtil.IsValidateHash(logo.Name))
            {
                PbLogo.Image = BeanUtil.NaN16;
            }
            else
            {
                string path = _DataModel.KeyDir;
                if (CharUtil.IsValidateHash(logo.Path))
                {
                    path = Path.Combine(path, logo.Path, logo.Name + IEnv.IMG_KEY_EDIT_EXT);
                }
                else
                {
                    path = Path.Combine(path, logo.Name + IEnv.IMG_KEY_EDIT_EXT);
                }
                PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
            }

            HintAtt hint = _SafeModel.Hint;
            if (hint == null)
            {
                return;
            }
            TbHint.Text = hint.Data;

            Focus();
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

            string name = TbName.Text;
            if (!CharUtil.IsValidate(name))
            {
                Main.ShowAlert("请输入口令标题！");
                TbName.Focus();
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

            MetaAtt meta = _SafeModel.Meta;
            if (meta.Name != name)
            {
                meta.Name = name;
                meta.Modified = true;
            }
            if (meta.Data != TbMeta.Text)
            {
                meta.Data = TbMeta.Text;
                meta.Modified = true;
            }
            _SafeModel.Key.Modified |= meta.Modified;

            LogoAtt logo = _SafeModel.Logo;
            if (logo.Name != _AIco.File)
            {
                logo.Name = _AIco.File;
                logo.Modified = true;
            }
            if (logo.Path != _AIco.Path)
            {
                logo.Path = _AIco.Path;
                logo.Modified = true;
            }
            _SafeModel.Key.Modified |= logo.Modified;

            HintAtt hint = _SafeModel.Hint;
            hint.Name = "";
            if (hint.Data != TbHint.Text)
            {
                hint.Data = TbHint.Text;
                hint.Modified = true;
            }
            _SafeModel.Key.Modified |= hint.Modified;

            return true;
        }

        public void CopyData()
        {
            if (_TBox != null && !string.IsNullOrEmpty(_TBox.Text))
            {
                Clipboard.SetText(_TBox.Text);
            }
        }
        #endregion

        #region 事件处理
        private void CbLib_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void PbLogo_Click(object sender, EventArgs e)
        {
            _AWiz.ShowIcoSeeker(_DataModel.KeyDir, new AmonHandler<Bean.Ico>(ChangeImgByKey));
        }

        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbName;
        }

        private void TbMeta_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMeta;
        }

        private void TbHint_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbHint;
        }

        private void TbMemo_GotFocus(object sender, EventArgs e)
        {
            _TBox = TbMemo;
        }
        #endregion

        #region 私有函数
        private void ChangeImgByKey(Bean.Ico ico)
        {
            _AIco = ico;
            string path;
            if (CharUtil.IsValidateHash(ico.Path))
            {
                path = Path.Combine(_DataModel.KeyDir, ico.Path, ico.File + IEnv.IMG_KEY_EDIT_EXT);
            }
            else
            {
                path = Path.Combine(_DataModel.KeyDir, ico.File + IEnv.IMG_KEY_EDIT_EXT);
            }
            PbLogo.Image = BeanUtil.ReadImage(path, BeanUtil.NaN16);
        }
        #endregion

        private bool processing;
        private bool NeedDo;
        private ContextMenuStrip PmCardMenu;
        private ToolStripMenuItem MuHtmMenu;
        private ToolStripMenuItem MuTxtMenu;
        private ToolStripMenuItem MuPngMenu;
        private ToolStripMenuItem MuSvgMenu;
        private ToolStripMenuItem MuVcfMenu;

        private void dd()
        {
            if (processing)
            {
                return;
            }

            processing = true;
            if (NeedDo)
            {
                //fileTM = new FileTM("card", Pattern.compile("[^.]+[.]amc$", Pattern.CASE_INSENSITIVE), false);

                PmCardMenu = new ContextMenuStrip();
                MuHtmMenu = new ToolStripMenuItem();
                MuHtmMenu.Text = "HTM";
                MuTxtMenu = new ToolStripMenuItem();
                MuTxtMenu.Text = "TXT";
                MuPngMenu = new ToolStripMenuItem();
                MuPngMenu.Text = "PNG";
                MuSvgMenu = new ToolStripMenuItem();
                MuSvgMenu.Text = "SVG";
            }

            if (NeedDo)
            {
                MuHtmMenu.DropDownItems.Clear();
                MuTxtMenu.DropDownItems.Clear();
                MuPngMenu.DropDownItems.Clear();
                MuSvgMenu.DropDownItems.Clear();

                XmlDocument doc = new XmlDocument();
                ToolStripMenuItem item;
                foreach (string cardFile in Directory.GetFiles("card", "*.acxml"))
                {
                    try
                    {
                        doc.Load(cardFile);
                        EventHandler htmHandler = new EventHandler(HtmItem_Click);
                        EventHandler txtHandler = new EventHandler(TxtItem_Click);
                        EventHandler svgHandler = new EventHandler(SvgItem_Click);
                        EventHandler vcfHandler = new EventHandler(VcfItem_Click);
                        EventHandler pngHandler = new EventHandler(PngItem_Click);
                        EventHandler qrcHandler = new EventHandler(QrcItem_Click);

                        XmlNode name = doc.SelectSingleNode("/amon/base/name");
                        item = new ToolStripMenuItem();
                        item.Text = (name != null ? name.InnerText : Path.GetFileName(cardFile));

                        XmlNode type = doc.SelectSingleNode("/amon/base/type");
                        if (type != null)
                        {
                            string text = (type.InnerText + "").Trim().ToLower();
                            if ("htm" == text)
                            {
                                item.Tag = "htm/" + cardFile;
                                item.Click += htmHandler;
                                MuHtmMenu.DropDownItems.Add(item);
                                continue;
                            }
                            if ("txt" == text)
                            {
                                item.Tag = "txt/" + cardFile;
                                item.Click += txtHandler;
                                MuTxtMenu.DropDownItems.Add(item);
                                continue;
                            }
                            if ("png" == text)
                            {
                                item.Tag = "png/" + cardFile;
                                item.Click += pngHandler;
                                MuPngMenu.DropDownItems.Add(item);
                                continue;
                            }
                            if ("svg" == text)
                            {
                                item.Tag = "svg/" + cardFile;
                                item.Click += svgHandler;
                                MuSvgMenu.DropDownItems.Add(item);
                                continue;
                            }
                            if ("vcf" == text)
                            {
                                item.Tag = "svg/" + cardFile;
                                item.Click += vcfHandler;
                                MuSvgMenu.DropDownItems.Add(item);
                                continue;
                            }
                            if ("qrc" == text)
                            {
                                item.Tag = "svg/" + cardFile;
                                item.Click += qrcHandler;
                                MuSvgMenu.DropDownItems.Add(item);
                                continue;
                            }
                        }
                        item.Tag = "all/" + cardFile;
                        PmCardMenu.Items.Add(item);
                    }
                    catch (Exception exp)
                    {
                        processing = false;
                        Main.ShowError(exp);
                        return;
                    }
                }
            }
            PmCardMenu.Show(null, 0, 0);

            processing = false;
        }

        private void HtmItem_Click(object sender, EventArgs e)
        {
        }

        private void TxtItem_Click(object sender, EventArgs e)
        {
        }

        private void SvgItem_Click(object sender, EventArgs e)
        {
        }

        private void VcfItem_Click(object sender, EventArgs e)
        {
        }

        private void PngItem_Click(object sender, EventArgs e)
        {
        }

        private void QrcItem_Click(object sender, EventArgs e)
        {
        }

        private void cardItemActionPerformed()
        {
            ToolStripMenuItem item = null;
            if (item == null)
            {
                return;
            }

            string command = item.Tag as string;
            if (!CharUtil.IsValidate(command))
            {
                return;
            }

            int dot = command.IndexOf('/');
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
                case "txt":
                    card.ExportTxt(src, dst);
                    break;
                case "png":
                    card.ExportPng(src, dst);
                    break;
                case "svg":
                    card.ExportSvg(src, dst);
                    break;
                case "vcf":
                    card.ExportVcf(src, dst);
                    break;
                default:
                    card.ExportAll(src, dst);
                    break;
            }
            //mainPtn.exportCard(srcFile, dstFile, key);
        }
    }
}
