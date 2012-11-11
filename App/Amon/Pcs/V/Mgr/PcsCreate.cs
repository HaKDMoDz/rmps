using System;
using System.Windows.Forms;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V.Mgr
{
    public partial class PcsCreate : Form
    {
        private IMgr _Mgr;

        public PcsCreate()
        {
            InitializeComponent();

            Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void Init()
        {
            MPcs = new MPcs();
            ShowServer();
        }

        public MPcs MPcs { get; private set; }

        #region 事件处理
        private void BnPrev_Click(object sender, EventArgs e)
        {
            switch (_Mgr.Name)
            {
                case "config":
                    ShowVerify();
                    break;
                case "verify":
                    ShowServer();
                    break;
            }
        }

        private void BnNext_Click(object sender, EventArgs e)
        {
            if (!_Mgr.SaveData(MPcs))
            {
                return;
            }

            if (_Mgr.Name == "server")
            {
                ShowVerify();
                _Mgr.ShowData(MPcs);
                return;
            }
            if (_Mgr.Name == "verify")
            {
                ShowConfig();
                _Mgr.ShowData(MPcs);
                return;
            }
            if (_Mgr.Name == "config")
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }

        private void BnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有函数
        private Server _Server;
        private void ShowServer()
        {
            if (_Server == null)
            {
                _Server = new Server();
                _Server.Init();
                _Server.Dock = DockStyle.Fill;
                _Server.Name = "server";
            }

            PlStep.Controls.Clear();
            PlStep.Controls.Add(_Server);
            _Mgr = _Server;

            BnPrev.Visible = false;
        }

        private Verify _Verify;
        private void ShowVerify()
        {
            if (_Verify == null)
            {
                _Verify = new Verify();
                _Verify.Init();
                _Verify.Dock = DockStyle.Fill;
                _Verify.Name = "verify";
            }

            PlStep.Controls.Clear();
            PlStep.Controls.Add(_Verify);
            _Mgr = _Verify;

            BnPrev.Visible = true;
            BnNext.Text = "下一步(&N)";
        }

        private Config _Config;
        private void ShowConfig()
        {
            if (_Config == null)
            {
                _Config = new Config();
                _Config.Init();
                _Config.Dock = DockStyle.Fill;
                _Config.Name = "config";
            }

            PlStep.Controls.Clear();
            PlStep.Controls.Add(_Config);
            _Mgr = _Config;

            BnNext.Text = "完成(&O)";
        }
        #endregion
    }
}
