using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using Me.Amon.Properties;

namespace Me.Amon.V.Tray
{
    public class ATray : IAmon
    {
        private Main _Main;
        private NotifyIcon _Tray;

        private Timer _Timer;
        private int _Index;
        private bool _Running;
        private string _Tips;

        public ATray(Main main)
        {
            _Main = main;

            _Tray = new NotifyIcon(new System.ComponentModel.Container());
            _Tray.BalloonTipTitle = "阿木密码箱";
            _Tray.Icon = Me.Amon.Properties.Resources.Icon;
            _Tray.Text = "阿木密码箱";
            _Tray.Visible = true;
            _Tray.DoubleClick += new System.EventHandler(Tray_DoubleClick);
            _Tray.MouseClick += TrayMouseClick;
            //_Tray.MouseUp += new MouseEventHandler(Tray_MouseUp);

            _Timer = new Timer();
            _Timer.Interval = 400;
            _Timer.Tick += new System.EventHandler(this.Timer_Tick);
        }

        #region 接口实现
        public void InitData()
        {
            LoadMenu();
            _Tray.ContextMenuStrip = _Menu;
        }

        public void LoadMenu(List<TApp> apps)
        {
            foreach (TApp app in apps)
            {
                ToolStripMenuItem item = new ToolStripMenuItem { Text = app.Text, Tag = app };
                item.Click += new EventHandler(AppItem_Click);
                MuApps.DropDownItems.Add(item);
            }
        }

        public void SaveView()
        {
        }

        public void DeInit()
        {
        }

        public bool WillExit()
        {
            return true;
        }

        public void Close()
        {
        }

        public void ShowBubbleTips(string tips)
        {
            _Tips = tips;
            _Tray.ShowBalloonTip(0, "阿木密码箱", tips, ToolTipIcon.Info);
        }

        public void ShowFlicker()
        {
            if (!_Running)
            {
                _Timer.Start();
                _Running = true;
            }
        }

        public void HideFlicker()
        {
            if (_Running)
            {
                _Timer.Stop();
                _Running = false;
                _Tray.Icon = Resources.Icon;
            }
        }
        #endregion

        public bool Visible
        {
            get
            {
                return _Tray.Visible;
            }
            set
            {
                _Tray.Visible = value;
            }
        }

        #region 事件处理
        private void Tray_DoubleClick(object sender, System.EventArgs e)
        {
            HideFlicker();
            _Main.ShowDefaultApp();
        }

        private void TrayMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _Tray.ShowBalloonTip(0, "阿木密码箱", _Tips, ToolTipIcon.Info);
            }
        }

        private void Tray_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MethodInfo mi = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                if (mi != null)
                {
                    mi.Invoke(_Tray, null);
                }
                return;
            }
        }

        public void AppItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            TApp app = item.Tag as TApp;
            if (app == null)
            {
                return;
            }
            _Main.ShowIApp(app);
        }

        private void MiReset_Click(object sender, EventArgs e)
        {
            _Main.ShowReset();
        }

        private void MiLogo_Click(object sender, EventArgs e)
        {
            _Main.ShowGuid();
            Settings.Default.Pattern = CApp.PATTERN_LOGO;
            Settings.Default.Save();
        }

        #region 权限相关
        /// <summary>
        /// 在线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignOl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignOl, new AmonHandler<string>(DoSignOl));
        }

        /// <summary>
        /// 离线注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignUl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignUl, new AmonHandler<string>(ShowWPwd));
        }

        /// <summary>
        /// 脱机注册
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignPc_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignPc, new AmonHandler<string>(ShowWPwd));
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignIn_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignIn, new AmonHandler<string>(DoSignIn));
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignOf_Click(object sender, EventArgs e)
        {
            if (_Main.SaveData())
            {
                _Main.SignOf();
            }
        }

        /// <summary>
        /// 口令找回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSignFp_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 其它
        private void MiInfo_Click(object sender, EventArgs e)
        {
            if (Main.DefaultApp.App.Visible)
            {
                Main.ShowAbout(Main.DefaultApp.App.Form);
            }
            else
            {
                Main.ShowAbout(null);
            }
        }

        private void MiExit_Click(object sender, EventArgs e)
        {
            _Main.ExitSystem();
        }
        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            switch (_Index)
            {
                case 0:
                    _Tray.Icon = Resources.Icon;
                    break;
                case 1:
                    _Tray.Icon = Resources.None;
                    break;
                default:
                    _Index = 0;
                    _Tray.Icon = Resources.Icon;
                    break;
            }
            _Index = 1 - _Index;
        }
        #endregion

        #region 私有函数
        private ContextMenuStrip _Menu;
        private ToolStripMenuItem MuApps;
        private ToolStripMenuItem MiReset;
        private ToolStripSeparator MiSep0;
        private ToolStripMenuItem MiLogo;
        private ToolStripSeparator MiSep1;
        private ToolStripMenuItem MiInfo;
        private ToolStripMenuItem MiExit;
        private void LoadMenu()
        {
            if (_Menu != null)
            {
                return;
            }

            _Menu = new ContextMenuStrip();
            // 
            // MiApps
            // 
            MuApps = new ToolStripMenuItem();
            MuApps.Text = "应用(&A)";
            MuApps.Visible = false;
            _Menu.Items.Add(MuApps);
            // 
            // MiReset
            // 
            MiReset = new ToolStripMenuItem();
            MiReset.Text = "重置(&R)";
            MiReset.Visible = false;
            MiReset.Click += new EventHandler(MiReset_Click);
            _Menu.Items.Add(MiReset);
            // 
            // MiSep0
            // 
            MiSep0 = new ToolStripSeparator();
            MiSep0.Visible = false;
            _Menu.Items.Add(MiSep0);
            // 
            // MiLogo
            // 
            MiLogo = new ToolStripMenuItem();
            MiLogo.Text = "显示为导航图标(&L)";
            MiLogo.Click += new EventHandler(MiLogo_Click);
            _Menu.Items.Add(MiLogo);
            // 
            // MiSep1
            // 
            MiSep1 = new ToolStripSeparator();
            _Menu.Items.Add(MiSep1);
            // 
            // MiInfo
            // 
            MiInfo = new ToolStripMenuItem();
            MiInfo.Text = "关于(&I)";
            MiInfo.Click += new EventHandler(MiInfo_Click);
            _Menu.Items.Add(MiInfo);
            // 
            // MiExit
            // 
            MiExit = new ToolStripMenuItem();
            MiExit.Text = "退出(&X)";
            MiExit.Click += new EventHandler(MiExit_Click);
            _Menu.Items.Add(MiExit);
        }
        #endregion
    }
}
