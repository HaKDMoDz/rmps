using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Bar;
using Me.Amon.Event;
using Me.Amon.Ico;
using Me.Amon.Model;
using Me.Amon.Properties;
using Me.Amon.Pwd;
using Me.Amon.Ren;
using Me.Amon.Sec;
using Me.Amon.Sql;
using Me.Amon.User;
using Me.Amon.User.Sign;
using Me.Amon.Util;
using Me.Amon.Uw;

namespace Me.Amon
{
    public partial class Main : Form
    {
        private static IApp _IApp;
        private static Alert _Alert;
        private static Error _Error;
        private static Input _Input;
        private static Waiting _Waiting;
        private UserModel _UserModel;
        private APwd _APwd;
        private ASec _ASec;
        private ABar _ABar;
        private ARen _ARen;
        private AIco _AIco;
        private List<MApp> _AppList;

        #region 构造函数
        public Main()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗口事件
        private void Main_Load(object sender, EventArgs e)
        {
            //Region = new Region(new Rectangle(0, 0, 25, 25));
            Region = new Region(new Rectangle(0, 0, 225, 225));
            TransparencyKey = this.BackColor;

            // 窗口位置
            int x = Settings.Default.LocX;
            if (x < 0)
            {
                x = Screen.PrimaryScreen.Bounds.Width - 200;
            }
            int y = Settings.Default.LocY;
            if (y < 0)
            {
                y = 40;
            }
            Location = new Point(x, y);

            _UserModel = new UserModel();
            if (File.Exists(EApp.FILE_LOG))
            {
                _Writer = new StreamWriter(EApp.FILE_LOG, true);
            }

            int pattern = Settings.Default.Pattern;
            if (pattern == 0)
            {
                pattern = -1;
            }
            NiTray.Visible = (pattern & EApp.PATTERN_TRAY) != 0;
            MgTray.Checked = NiTray.Visible;

            StreamReader reader = File.OpenText("App.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            MApp app;
            _AppList = new List<MApp>();
            foreach (XmlNode node in doc.SelectNodes("/Amon/Apps/App"))
            {
                app = new MApp();
                app.FromXml(node);
                _AppList.Add(app);

                IlApp.Images.Add(app.Id, BeanUtil.ReadImage(app.Logo, Resources.Logo32));
                LvApp.Items.Add(new ListViewItem { Name = app.Id, Text = app.Text, ImageKey = app.Id });
            }
        }

        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //_MouseOffset = new Point(-e.X, -e.Y);
                //_IsMouseDown = true;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            //if (_IsMouseDown)
            {
                Point mousePos = Control.MousePosition;
                //mousePos.Offset(_MouseOffset.X, _MouseOffset.Y);
                if (mousePos.X < 10)
                {
                    mousePos.X = 0;
                }
                else
                {
                    int t = SystemInformation.WorkingArea.Width - Width;
                    if (mousePos.X > t - 10)
                    {
                        mousePos.X = t;
                    }
                }
                if (mousePos.Y < 10)
                {
                    mousePos.Y = 0;
                }
                else
                {
                    int t = SystemInformation.WorkingArea.Height - Height;
                    if (mousePos.Y > t - 10)
                    {
                        mousePos.Y = t;
                    }
                }
                Location = mousePos;
            }
        }

        private void Main_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //_IsMouseDown = false;
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_IApp != null)
            {
                if (!_IApp.WillExit())
                {
                    e.Cancel = true;
                    return;
                }
                _IApp.SaveData();
            }

            Settings.Default.LocX = Location.X;
            Settings.Default.LocY = Location.Y;
            Settings.Default.Save();
        }

        private void PbLogo_DoubleClick(object sender, EventArgs e)
        {
            ShowLast();
        }

        private void NiTray_DoubleClick(object sender, EventArgs e)
        {
            ShowLast();
        }
        #endregion

        #region 选单事件
        #region 导航选单
        private void MgTopMost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            MgTopMost.Checked = TopMost;
        }

        private void MgTray_Click(object sender, EventArgs e)
        {
            NiTray.Visible = !NiTray.Visible;
            MgTray.Checked = NiTray.Visible;

            if (NiTray.Visible)
            {
                Settings.Default.Pattern |= EApp.PATTERN_TRAY;
            }
            else
            {
                Settings.Default.Pattern ^= EApp.PATTERN_TRAY;
            }
            Settings.Default.Save();
        }

        private void MgAPwd_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowAPwd));
                return;
            }

            if (_IApp.AppId != EApp.IAPP_APWD)
            {
                _IApp.Visible = false;
                ShowAPwd(EApp.IAPP_APWD);
                return;
            }
        }

        private void MgASec_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowASec));
                return;
            }

            if (_IApp.AppId != EApp.IAPP_ASEC)
            {
                _IApp.Visible = false;
                ShowASec(EApp.IAPP_ASEC);
                return;
            }
        }

        private void MgABar_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowABar));
                return;
            }

            if (_IApp.AppId != EApp.IAPP_ABAR)
            {
                _IApp.Visible = false;
                ShowABar(EApp.IAPP_ABAR);
                return;
            }
        }

        private void MgARen_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowARen));
                return;
            }

            if (_IApp.AppId != EApp.IAPP_AREN)
            {
                _IApp.Visible = false;
                ShowARen(EApp.IAPP_AREN);
                return;
            }
        }

        private void MgSignOl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignOl, new AmonHandler<int>(DoSignOl));
            SignAc(ESignAc.SignOl, new AmonHandler<int>(ShowAPwd));
        }

        private void MgSignUl_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignUl, new AmonHandler<int>(ShowAPwd));
        }

        private void MgSignPc_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<int>(ShowAPwd));
        }

        private void MgSignIn_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignIn, new AmonHandler<int>(DoSignIn));
            SignAc(ESignAc.SignIn, new AmonHandler<int>(ShowAPwd));
        }

        private void MgSignOf_Click(object sender, EventArgs e)
        {
            SignOf();
        }

        private void MgSignFp_Click(object sender, EventArgs e)
        {
        }

        private void MgInfo_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void MgExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #endregion

        #region 全局函数
        public static DialogResult ShowConfirm(string message)
        {
            return MessageBox.Show(_IApp.Form, message, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static void ShowWaiting(string message)
        {
            if (_Waiting == null)
            {
                _Waiting = new Waiting();
            }
            BeanUtil.CenterToParent(_Waiting, _IApp.Form);
            _Waiting.Show(_IApp.Form, message);
        }

        public static void ShowAlert(string alert)
        {
            if (_Alert == null)
            {
                _Alert = new Alert();
            }
            BeanUtil.CenterToParent(_Alert, _IApp.Form);
            _Alert.Show(_IApp.Form, alert);
        }

        public static void ShowError(Exception error)
        {
            if (_Error == null)
            {
                _Error = new Error();
            }
            BeanUtil.CenterToParent(_Error, _IApp.Form);
            _Error.Show(_IApp.Form, error);
        }

        public static string ShowInput(string message, string deftext)
        {
            if (_Input == null)
            {
                _Input = new Input();
            }
            BeanUtil.CenterToParent(_Input, _IApp.Form);
            _Input.Show(_IApp.Form, message, deftext);
            return _Input.Message;
        }

        private static StreamWriter _Writer;
        public static void LogInfo(string msg)
        {
            if (_Writer != null)
            {
                _Writer.WriteLine(msg);
            }
        }
        #endregion

        #region 私有函数
        private SignAc _SignAc;
        private void SignAc(ESignAc signAc, AmonHandler<int> handler)
        {
            if (_SignAc == null || !_SignAc.Visible)
            {
                _SignAc = new SignAc(_UserModel);
                _SignAc.InitOnce();
            }
            _SignAc.CallBackHandler = handler;
            _SignAc.ShowView(signAc);
            _SignAc.Show();
        }

        private void SignOf()
        {
            if (_IApp != null)
            {
                if (!_IApp.WillExit())
                {
                    return;
                }
                _IApp.SaveData();
                _IApp.Dispose();
            }

            _UserModel.CaSignOf();

            MgSignUp.Visible = true;
            MgSignIn.Visible = true;
            MgSignOf.Visible = false;
        }

        private SignRc _SignRc;
        private void CheckUser(AmonHandler<int> handler)
        {
            if (!CharUtil.IsValidateCode(_UserModel.Code))
            {
                SignAc(ESignAc.SignIn, handler);
            }
            else
            {
                if (_SignRc == null || !_SignRc.Visible)
                {
                    _SignRc = new SignRc(_UserModel);
                    _SignRc.InitOnce();
                    _SignRc.Show();
                }
                _SignRc.CallBackHandler = handler;
            }
        }

        private void DoSignIn(int view)
        {
            MgSignIn.Visible = false;
            MgSignUp.Visible = false;
            MgSignOf.Visible = true;
        }

        private void DoSignOl(int view)
        {
        }

        private void ShowLast(int view)
        {
            if (_IApp == null || _IApp.IsDisposed)
            {
                ShowAPwd(EApp.IAPP_APWD);
            }
            else
            {
                _IApp.Visible = true;
            }
        }

        private void ShowAPwd(int view)
        {
            if (_APwd == null || _APwd.IsDisposed)
            {
                _APwd = new APwd(_UserModel);
            }
            _IApp = _APwd;

            _APwd.Show();

            DoSignIn(view);
        }

        private void ShowASec(int view)
        {
            if (_ASec == null || _ASec.IsDisposed)
            {
                _ASec = new ASec(_UserModel);
            }
            _IApp = _ASec;

            _ASec.Show();
        }

        private void ShowABar(int view)
        {
            if (_ABar == null || _ABar.IsDisposed)
            {
                _ABar = new ABar(_UserModel);
            }
            _IApp = _ABar;

            _ABar.Show();
        }

        private void ShowARen(int view)
        {
            if (_ARen == null || _ARen.IsDisposed)
            {
                _ARen = new ARen(_UserModel);
            }
            _IApp = _ARen;

            _ARen.Show();
        }

        private void ShowAIco(int view)
        {
            if (_AIco == null || _AIco.IsDisposed)
            {
                _AIco = new AIco(_UserModel);
            }
            _IApp = _AIco;

            _AIco.Show();
        }

        private void ShowLast()
        {
            if (_IApp == null || _IApp.IsDisposed || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowLast));
                return;
            }

            _IApp.Visible = true;
            _IApp.BringToFront();
        }
        #endregion

        private void MgSignUp_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<int>(ShowAPwd));
        }

        private void LvApp_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ASql sql = new ASql();
            sql.Show();
        }

        private void LvApp_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MgAIco_Click(object sender, EventArgs e)
        {
            ShowAIco(0);
        }
    }
}