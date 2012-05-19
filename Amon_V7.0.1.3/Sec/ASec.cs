using System;
using System.ComponentModel;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Sec;
using Me.Amon.Sec.Pro;
using Me.Amon.Sec.Wiz;

namespace Me.Amon.Sec
{
    public partial class ASec : Form, IApp
    {
        #region 全局变量
        private UserModel _UserModel;
        private ISec _ISec;
        #endregion

        #region 构造函数
        public ASec()
        {
            InitializeComponent();
        }

        public ASec(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            ShowPro();
        }

        public int AppId { get; set; }

        public Form Form { get { return this; } }

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
        private void BtDo_Click(object sender, EventArgs e)
        {
            if (!Worker.IsBusy)
            {
                Worker.RunWorkerAsync();
                BtDo.Text = "取消(&R)";
                return;
            }

            if (DialogResult.Yes == MessageBox.Show(this, "确认要取消操作吗？", "友情提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                Worker.CancelAsync();
                return;
            }
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void MiLoad_Click(object sender, EventArgs e)
        {
            _ISec.LoadFav();
        }

        private void MiSave_Click(object sender, EventArgs e)
        {
            _ISec.SaveFav();
        }

        private void MiWiz_Click(object sender, EventArgs e)
        {
            ShowWiz();
        }

        private void MiPro_Click(object sender, EventArgs e)
        {
            ShowPro();
        }
        #endregion

        #region 公有方法
        public void ShowEcho(string msg)
        {
            LbInfo.Text = msg;
            TpTips.SetToolTip(LbInfo, msg);
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }
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
            if (_ISec != null && _ISec.Name != "pro")
            {
                _ISec.HideView();
            }

            if (_APro == null)
            {
                _APro = new APro(this);
                _APro.InitOnce(_UserModel);
                _APro.Name = "pro";
            }
            _ISec = _APro;
            _ISec.InitView();
        }

        private AWiz _AWiz;
        private void ShowWiz()
        {
            if (_ISec != null && _ISec.Name != "wiz")
            {
                _ISec.HideView();
            }

            if (_AWiz == null)
            {
                _AWiz = new AWiz(this);
                _AWiz.InitOnce();
                _AWiz.Name = "wiz";
            }
            _ISec = _AWiz;
            _ISec.InitView();
        }
        #endregion
    }
}
