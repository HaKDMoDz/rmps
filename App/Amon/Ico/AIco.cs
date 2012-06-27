using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.IconLib;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Ico.V;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Ico
{
    /// <summary>
    /// 图标提取、编辑及预览。
    /// </summary>
    public partial class AIco : Form, IApp
    {
        private int _TpCnt;
        private IIco _IIco;
        private MultiIcon _MIcon;
        private XmlMenu<AIco> _XmlMenu;
        private UserModel _UserModel;

        #region 构造函数
        public AIco()
        {
            InitializeComponent();
        }

        public AIco(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public Form Form
        {
            get { return this; }
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 公共函数
        public TIco TIco { get; set; }
        public AmonHandler<TIco> AmonHandler { get; set; }

        public ContextMenuStrip IclMenu
        {
            get
            {
                return CmIcl;
            }
        }

        public ContextMenuStrip IcoMenu
        {
            get
            {
                return CmIco;
            }
        }

        public void Open(string file)
        {
            try
            {
                _MIcon.Clear();
                _MIcon.Load(file);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
                return;
            }

            LvIco.Items.Clear();
            IlIco.Images.Clear();

            Image bmp;
            foreach (SingleIcon sIcon in _MIcon)
            {
                bmp = GetBitmap(sIcon, EIco.PREVIEW_ICL_DIM);
                IlIco.Images.Add(sIcon.Name, bmp);
                LvIco.Items.Add(new ListViewItem { ImageKey = sIcon.Name, Name = sIcon.Name, Text = sIcon.Name });
            }
        }

        public void Save()
        {
            if (TcIco.SelectedTab == TpIco0)
            {
                SaveIcl();
            }
            else
            {
                SaveIco();
            }
        }

        public void OpenIcl()
        {
            if (TcIco.SelectedTab != TpIco0)
            {
                return;
            }
            if (LvIco.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem item = LvIco.SelectedItems[0];
            SingleIcon sIcon = _MIcon[item.Name];
            if (sIcon == null)
            {
                return;
            }
            AddTab(item.Text, sIcon);
        }

        public void SaveIcl()
        {
            if (TcIco.SelectedTab != TpIco0)
            {
                return;
            }

            // 外部调用模式
            if (AmonHandler == null)
            {
                if (DialogResult.OK == Main.ShowSaveFileDialog(this, EApp.FILE_SAVE_ICL, ""))
                {
                    SaveIcl(Main.SaveFileDialog.FileName);
                }
                return;
            }

            // 独立编辑模式
            if (TIco.Images == null)
            {
                List<Image> list = new List<Image>();
            }
            else
            {
                TIco.Images.Clear();
            }
            ListViewItem item = LvIco.SelectedItems[0];
            SingleIcon sIcon = _MIcon[item.Name];
            if (sIcon != null)
            {
                foreach (IconImage ico in sIcon)
                {
                    TIco.Images.Add(ico.Icon.ToBitmap());
                }
            }
            AmonHandler.Invoke(TIco);
        }

        public void SaveIcl(string file)
        {
            if (_MIcon != null && _MIcon.Count > 0)
            {
                _MIcon.Save(file, MultiIconFormat.ICL);
            }
        }

        public void SaveIco()
        {
            if (TcIco.SelectedTab == TpIco0)
            {
                return;
            }

            // 独立编辑模式
            if (AmonHandler == null)
            {
                if (DialogResult.OK == Main.ShowSaveFileDialog(this, EApp.FILE_SAVE_ICO, ""))
                {
                    SaveIco(Main.SaveFileDialog.FileName);
                }
                return;
            }

            // 独立编辑模式
            if (TIco.Images == null)
            {
                List<Image> list = new List<Image>();
            }
            else
            {
                TIco.Images.Clear();
            }
            _IIco.ToImages(TIco.Images);
        }

        public void SaveIco(string file)
        {
            if (_IIco != null)
            {
                _IIco.SingleIcon.Save(file);
            }
        }

        public void Import(string file)
        {
            if (_IIco != null)
            {
                _IIco.Import(file);
            }
        }

        public void Export(string file)
        {
            if (_IIco != null)
            {
                _IIco.Export(file);
            }
        }

        public void RemoveIco()
        {
            if (TcIco.SelectedTab != TpIco0)
            {
                return;
            }
            if (LvIco.SelectedItems.Count < 1)
            {
                return;
            }
            ListViewItem item = LvIco.SelectedItems[0];
            LvIco.Items.Remove(item);
        }

        public void RemoveImg()
        {
            if (TcIco.SelectedTab == TpIco0)
            {
                return;
            }
            _IIco.RemoveImg();
        }

        public void AppendImg(int dim)
        {
            if (TcIco.SelectedTab == TpIco0)
            {
                return;
            }
            _IIco.AppendImg(dim);
        }

        public static Image GetBitmap(SingleIcon sIcon, int dim)
        {
            IconImage img = sIcon[0];
            int max = img.Image.Width;
            int tmp;
            for (int i = 1; i < sIcon.Count; i += 1)
            {
                if (img.PixelFormat < sIcon[i].PixelFormat)
                {
                    img = sIcon[i];
                    max = img.Image.Width;
                    continue;
                }

                tmp = sIcon[i].Image.Width;
                tmp = tmp > dim ? tmp - dim : dim - tmp;
                if (tmp < max)
                {
                    max = tmp;
                    img = sIcon[i];
                    continue;
                }
            }

            Image bmp = img.Icon.ToBitmap();
            if (bmp.Width != dim)
            {
                bmp = BeanUtil.ScaleImage(bmp, dim, true);
            }
            return bmp;
        }
        #endregion

        #region 事件处理
        private void AIco_Load(object sender, EventArgs e)
        {
            _MIcon = new MultiIcon();

            _XmlMenu = new XmlMenu<AIco>(this, null);
            if (_XmlMenu.Load(Path.Combine(_UserModel.Home, EIco.XML_MENU)))
            {
                _XmlMenu.GetStrokes("AIco");
                _XmlMenu.GetPopMenu("AIco", CmMenu);
                _XmlMenu.GetPopMenu("Icl", CmIcl);
                _XmlMenu.GetPopMenu("Ico", CmIco);
            }
        }

        private void AIco_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (KeyStroke<AIco> stroke in _XmlMenu.KeyStrokes)
            {
                if (stroke.Action == null ||
                    e.Control ^ stroke.Control ||
                    e.Shift ^ stroke.Shift ||
                    e.Alt ^ stroke.Alt ||
                    e.KeyCode != stroke.Code)
                {
                    continue;
                }

                e.Handled = true;
                stroke.Action.EventHandler(stroke, null);
                break;
            }
        }

        private void TcIco_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TcIco.SelectedTab == null || TcIco.SelectedTab == TpIco0)
            {
                _IIco = null;
                return;
            }

            if (TcIco.SelectedTab.Controls.Count > 0)
            {
                _IIco = TcIco.SelectedTab.Controls[0] as IIco;
            }
        }

        private void TcIco_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = TcIco.SelectedIndex == 0;
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void BnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void LvIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenIcl();
        }

        private void LvIco_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != System.Windows.Forms.MouseButtons.Right)
            {
                return;
            }

            ListViewItem item = LvIco.GetItemAt(e.X, e.Y);
            if (item == null)
            {
                return;
            }
            item.Selected = true;
            CmIcl.Show(MousePosition);
        }
        #endregion

        #region 私有函数
        private void AddTab(string msg, SingleIcon ico)
        {
            _TpCnt += 1;

            TabPage page = new TabPage();
            page.TabIndex = _TpCnt;
            page.Text = msg;
            //page.UseVisualStyleBackColor = true;
            TcIco.TabPages.Add(page);

            IcoEditor editor = new IcoEditor(this);
            editor.InitOnce();
            editor.Dock = DockStyle.Fill;
            editor.SingleIcon = ico;
            page.Controls.Add(editor);

            TcIco.SelectedTab = page;
            _IIco = editor;
        }
        #endregion
    }
}