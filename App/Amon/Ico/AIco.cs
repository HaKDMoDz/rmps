using System;
using System.Drawing;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Me.Amon.Ico.V;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Ico
{
    public partial class AIco : Form, IApp
    {
        private int _TpCnt;
        private IIco _IIco;
        private MultiIcon _MIcon;
        private XmlMenu<AIco> _XmlMenu;
        private IcoEditor _IcoEditor;
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
        public void OpenIcl(string file)
        {
            _MIcon.Clear();
            _MIcon.Load(file);

            LvIco.Items.Clear();
            IlIco.Images.Clear();

            Image bmp;
            foreach (SingleIcon sIcon in _MIcon)
            {
                bmp = GetBitmap(sIcon);
                IlIco.Images.Add(sIcon.Name, bmp);
                LvIco.Items.Add(new ListViewItem { ImageKey = sIcon.Name, Name = sIcon.Name, Text = sIcon.Name });
            }
        }

        public void OpenImg(string file)
        {
        }

        public void SaveIcl(string file)
        {
        }

        public void SaveIco(string file)
        {
        }

        private OpenFileDialog _FdOpen;
        public OpenFileDialog OpenFileDialog
        {
            get
            {
                if (_FdOpen == null)
                {
                    _FdOpen = new OpenFileDialog();
                }
                return _FdOpen;
            }
        }

        private SaveFileDialog _FdSave;
        public SaveFileDialog SaveFileDialog
        {
            get
            {
                if (_FdSave == null)
                {
                    _FdSave = new SaveFileDialog();
                }
                return _FdSave;
            }
        }
        #endregion

        #region 事件处理
        private void AIco_Load(object sender, EventArgs e)
        {
            _MIcon = new MultiIcon();

            _XmlMenu = new XmlMenu<AIco>(this, null);
            _XmlMenu.Load("AIco.xml");
            _XmlMenu.GetPopMenu("AIco", CmMenu);
            _XmlMenu.GetStrokes("AIco");
        }

        private void TcIco_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = TcIco.TabCount < 2;
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void BnSave_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void LvIco_MouseDoubleClick(object sender, MouseEventArgs e)
        {
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

        #region 私有函数
        private void AddTab(string msg, SingleIcon ico)
        {
            _TpCnt += 1;

            TabPage page = new TabPage();
            page.TabIndex = _TpCnt;
            page.Text = msg;
            //page.UseVisualStyleBackColor = true;
            TcIco.TabPages.Add(page);
            TcIco.SelectedTab = page;

            IcoEditor png = new IcoEditor();
            png.InitOnce();
            png.Dock = DockStyle.Fill;
            png.SingleIcon = ico;
            page.Controls.Add(png);
        }

        private Image GetBitmap(SingleIcon sIcon)
        {
            Image bmp = sIcon.Icon.ToBitmap();
            if (bmp.Width != 32)
            {
                bmp = BeanUtil.ScaleImage(bmp, 32, true);
            }
            return bmp;
        }
        #endregion
    }
}
