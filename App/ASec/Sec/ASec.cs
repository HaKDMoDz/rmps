using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Sec.M;
using Me.Amon.Sec.V.Pro;
using Me.Amon.Sec.V.Wiz;
using Me.Amon.Uc;

namespace Me.Amon.Sec
{
    public partial class ASec : Form, IApp
    {
        #region 全局变量
        private UserModel _UserModel;
        private ISec _ISec;
        #endregion
        private XmlMenu<ASec> _XmlMenu;

        #region 构造函数
        public ASec()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public ASec(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId { get; set; }

        public Form Form { get { return this; } }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            LlEcho.Text = message;
            TpTips.SetToolTip(LlEcho, message);
        }

        public void ShowEcho(string message, int delay)
        {
            LlEcho.Text = message;
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
        public void LoadFav()
        {
            _ISec.LoadFav();
        }

        public void SaveFav()
        {
            _ISec.SaveFav();
        }
        #endregion

        #region 事件处理
        private void ASec_Load(object sender, EventArgs e)
        {
            _UserModel = new UserModel();
            _UserModel.Init();
            _UserModel.Load();

            _XmlMenu = new XmlMenu<ASec>(this, null);
            if (_XmlMenu.Load(Path.Combine(_UserModel.DatHome, "ASec.xml")))
            {
                _XmlMenu.GetStrokes("ASec", this);
                _XmlMenu.GetPopMenu("ASec", CmMenu);
                _XmlMenu.GetPopMenu("ASec-Src", CmSrc);
                _XmlMenu.GetPopMenu("ASec-Dst", CmDst);
            }
            ShowWiz();
        }

        private void BtDo_Click(object sender, EventArgs e)
        {
            //if (!Worker.IsBusy)
            //{
            //    Worker.RunWorkerAsync();
            //    BtDo.Text = "取消(&R)";
            //    return;
            //}

            //if (DialogResult.Yes == MessageBox.Show(this, "确认要取消操作吗？", "友情提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            //{
            //    Worker.CancelAsync();
            //    return;
            //}
            _ISec.DoCrypto();
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }
        #endregion

        #region 公有方法
        #endregion

        #region 私有函数
        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            _ISec.DoCrypto();
        }

        private void DoWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ShowEcho("用户已取消！");
            }
            BtDo.Text = "执行(&R)";
        }

        private APro _APro;
        private void ShowPro()
        {
            if (_ISec != null && _ISec.Name == "pro")
            {
                return;
            }

            if (_APro == null)
            {
                _APro = new APro(this);
                _APro.InitOnce(_UserModel);
                _APro.Dock = DockStyle.Fill;
                _APro.Name = "pro";
                _APro.TabIndex = 0;
            }

            Size size = _APro.Size;
            size.Width += 24;
            size.Height += 60;
            PlMain.Controls.Clear();
            PlMain.Controls.Add(_APro);
            ClientSize = size;

            _ISec = _APro;
        }

        private AWiz _AWiz;
        private void ShowWiz()
        {
            if (_ISec != null && _ISec.Name == "wiz")
            {
                return;
            }

            if (_AWiz == null)
            {
                _AWiz = new AWiz(this);
                _AWiz.InitOnce();
                _AWiz.Name = "wiz";
                _AWiz.Dock = DockStyle.Fill;
                _AWiz.TabIndex = 0;
            }

            Size size = _AWiz.Size;
            size.Width += 24;
            size.Height += 60;

            PlMain.Controls.Clear();
            PlMain.Controls.Add(_AWiz);
            ClientSize = size;

            _ISec = _AWiz;
        }
        #endregion
    }
}
