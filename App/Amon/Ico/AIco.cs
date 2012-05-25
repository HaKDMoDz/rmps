using System;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Ico
{
    public partial class AIco : Form, IApp
    {
        private IIco _IIco;
        private XmlMenu<AIco> _XmlMenu;
        private IclEditor _IclEditor;
        private IcoEditor _IcoEditor;

        public AIco()
        {
            InitializeComponent();
        }

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

        private void AIco_Load(object sender, EventArgs e)
        {
            _XmlMenu = new XmlMenu<AIco>(this, null);
            _XmlMenu.GetPopMenu("AIco", CmMenu);

            _IclEditor = new IclEditor(this);
            _IclEditor.InitOnce();
            _IclEditor.Dock = DockStyle.Fill;
            //_IclEditor.Location = new System.Drawing.Point(3, 3);
            _IclEditor.Name = "iclEditor1";
            //_IclEditor.Size = new System.Drawing.Size(435, 290);
            _IclEditor.TabIndex = 0;
            tabPage1.Controls.Add(_IclEditor);

            _IIco = _IclEditor;
        }

        public void AddTab(string msg, SingleIcon ico)
        {
            TabPage page = new TabPage();
            page.TabIndex = tabControl1.TabCount;
            page.Text = msg;
            //page.UseVisualStyleBackColor = true;
            IcoEditor png = new IcoEditor();
            png.InitOnce();
            png.Dock = DockStyle.Fill;
            page.Controls.Add(png);
            tabControl1.TabPages.Add(page);

            png.SingleIcon = ico;
        }

        private void ShowIco()
        {
            //if (_IImg != null)
            //{
            //    Controls.Remove(_IImg.Control);
            //}

            //if (_AIco == null)
            //{
            //    _AIco = new AIco(this);
            //    _AIco.InitOnce();
            //}

            //_AIco.Location = new System.Drawing.Point(12, 12);
            //_AIco.Size = new System.Drawing.Size(260, 231);
            //_AIco.TabIndex = 0;
            //Controls.Add(_AIco);

            //_IImg = _AIco;
        }
    }
}
