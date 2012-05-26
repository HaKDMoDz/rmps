using System;
using System.Drawing;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Me.Amon.Ico.V;
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

        #region 构造函数
        public AIco()
        {
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

        #region 事件处理
        private void AIco_Load(object sender, EventArgs e)
        {
            _XmlMenu = new XmlMenu<AIco>(this, null);
            _XmlMenu.GetPopMenu("AIco", CmMenu);
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void BnSave_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region 公共函数
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
