using System.Drawing;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitView();
        }

        public void InitView()
        {
            InitEcho();

            TcTool = new ToolStripContainer();
            TcTool.ContentPanel.Size = new Size(584, 363);
            TcTool.Dock = DockStyle.Fill;
            TcTool.Location = new Point(0, 24);
            TcTool.Name = "TcTool";
            TcTool.Size = new Size(584, 388);
            TcTool.TabIndex = 0;
            //TcTool.Text = "toolStripContainer1";
            Controls.Add(TcTool);

            HSplit = new SplitContainer();
            HSplit.Dock = DockStyle.Fill;
            //HSplit.Location = new System.Drawing.Point(0, 0);
            HSplit.Name = "HSplit";
            HSplit.Orientation = Orientation.Vertical;
            HSplit.Size = new Size(584, 363);
            HSplit.SplitterDistance = 194;
            HSplit.TabIndex = 0;
            HSplit.TabStop = false;
            TcTool.ContentPanel.Controls.Add(HSplit);

            VSplit = new SplitContainer();
            VSplit.Dock = DockStyle.Fill;
            VSplit.Location = new Point(0, 0);
            VSplit.Name = "VSplit";
            VSplit.Orientation = Orientation.Horizontal;
            VSplit.Size = new Size(194, 363);
            VSplit.SplitterDistance = 170;
            VSplit.TabIndex = 0;
            VSplit.TabStop = false;
            HSplit.Panel1.Controls.Add(VSplit);

            InitMenu();
            InitTool();
            InitGuid();
            InitBase();
        }

        private void InitMenu()
        {
            TmMenu = new MenuStrip();
            TmMenu.Location = new Point(0, 0);
            TmMenu.Name = "TmMenu";
            TmMenu.Size = new Size(584, 24);
            TmMenu.TabIndex = 1;
            //TmMenu.Text = "menuStrip1";
            Controls.Add(TmMenu);

            MainMenuStrip = TmMenu;
        }

        private void InitEcho()
        {
            SsEcho = new StatusStrip();
            SsEcho.Location = new Point(0, 390);
            SsEcho.Name = "SsEcho";
            SsEcho.Size = new Size(584, 22);
            SsEcho.TabIndex = 2;
            //SsEcho.Text = "statusStrip1";
            Controls.Add(SsEcho);
        }

        private void InitTool()
        {
            TsTool = new ToolStrip();
            TsTool.Dock = DockStyle.None;
            TsTool.Location = new Point(3, 0);
            TsTool.Name = "TsTool";
            //TsTool.Size = new Size(43, 25);
            TsTool.TabIndex = 0;
            TcTool.TopToolStripPanel.Controls.Add(this.TsTool);
        }

        private void InitGuid()
        {
            TvCatTree = new TreeView();
            TvCatTree.Dock = DockStyle.Fill;
            //TvCatTree.Location = new Point(0, 0);
            TvCatTree.Name = "TvCatTree";
            TvCatTree.Size = new Size(194, 170);
            TvCatTree.TabIndex = 0;
            VSplit.Panel1.Controls.Add(this.TvCatTree);

            LbKeyList = new ListBox();
            LbKeyList.Dock = DockStyle.Fill;
            LbKeyList.DrawMode = DrawMode.OwnerDrawVariable;
            LbKeyList.FormattingEnabled = true;
            //LbKeyList.Location = new Point(0, 0);
            LbKeyList.Name = "LbKeyList";
            LbKeyList.Size = new Size(194, 189);
            LbKeyList.TabIndex = 0;
            VSplit.Panel2.Controls.Add(LbKeyList);
        }

        private void InitBase()
        {
        }

        private ToolStripContainer TcTool;
        private ToolStrip TsTool;
        private MenuStrip TmMenu;
        private StatusStrip SsEcho;
        private SplitContainer HSplit;
        private SplitContainer VSplit;
        private TreeView TvCatTree;
        private ListBox LbKeyList;
    }
}
