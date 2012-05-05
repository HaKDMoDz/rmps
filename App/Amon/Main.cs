using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Bar;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Properties;
using Me.Amon.Pwd;
using Me.Amon.Ren;
using Me.Amon.Sec;
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

        #region 构造函数
        public Main()
        {
            InitializeComponent();
        }

        public void InitOnce()
        {
            Region = new Region(new Rectangle(0, 0, 25, 25));
            TransparencyKey = this.BackColor;

            _ScreenW = Screen.PrimaryScreen.Bounds.Width;
            _ScreenH = Screen.PrimaryScreen.Bounds.Height;

            int x = Settings.Default.LocX;
            if (x < 0)
            {
                x = _ScreenW >> 1;
            }
            int y = Settings.Default.LocY;
            if (y < 0)
            {
                y = 0;
            }
            Location = new Point(x, y);

            _AlienRadius = 11;
            _AlienCenterX = 12;
            _AlienCenterY = 12;
            x = _AlienRadius << 1;
            _AlienRect = new Rectangle(0, 0, x, x);

            _PupilImg = Resources.Pupil;
            _PupilRadius = 6;
            _PupilCenterX = _AlienRadius;
            _PupilCenterY = _AlienRadius;

            _BufImage = new Bitmap(PbLogo.Width, PbLogo.Height);
            _BRect = new Rectangle(0, 0, PbLogo.Width, PbLogo.Height);
            _BufBrush = new LinearGradientBrush(_BRect, Color.FromArgb(96, 96, 96), Color.FromArgb(0, 0, 0), LinearGradientMode.Vertical);

            _TmpImage = new Bitmap(x, x);
            _TmpBrush = new SolidBrush(Color.White);

            x = (_BufImage.Width - _TmpImage.Width) / 3;
            y = (_BufImage.Height - _TmpImage.Height) >> 1;
            _LRect = new Rectangle(x, y, _AlienRadius, _TmpImage.Height);
            _RRect = new Rectangle(x + _AlienRadius + x, y, _AlienRadius, _TmpImage.Height);

            GenImage(_PupilCenterX, _PupilCenterY);

            BgWorker.Interval = 30;
            BgWorker.Start();

            _UserModel = new UserModel();
            if (File.Exists(IEnv.FILE_LOG))
            {
                _Writer = new StreamWriter(IEnv.FILE_LOG, true);
            }
        }
        #endregion

        #region 眼睛动画
        /// <summary>
        /// 屏幕
        /// </summary>
        private int _ScreenW;
        private int _ScreenH;
        /// <summary>
        /// 瞳仁
        /// </summary>
        private Rectangle _AlienRect;
        private int _AlienRadius;
        private int _AlienCenterX;
        private int _AlienCenterY;
        /// <summary>
        /// 瞳孔
        /// </summary>
        private Image _PupilImg;
        private int _PupilRadius;
        private int _PupilCenterX;
        private int _PupilCenterY;
        /// <summary>
        /// 成像
        /// </summary>
        private Image _BufImage;
        private Brush _BufBrush;
        private Image _TmpImage;
        private Brush _TmpBrush;
        private Rectangle _BRect;
        private Rectangle _LRect;
        private Rectangle _RRect;

        private Point _MouseOffset;
        private bool _IsMouseDown;

        private void BgWorker_Tick(object sender, System.EventArgs e)
        {
            if (!_IsMouseDown)
            {
                DoSpy(Cursor.Position.X, Cursor.Position.Y);
            }
        }

        private void DoSpy(int x, int y)
        {
            if (x < 0)
            {
                x = 0;
            }
            else if (x > _ScreenW)
            {
                x = _ScreenW;
            }
            if (y < 0)
            {
                y = 0;
            }
            else if (y > _ScreenH)
            {
                y = _ScreenH;
            }

            // 眼睛中心坐标
            int cx = Location.X + _AlienCenterX;
            int cy = Location.Y + _AlienCenterY;

            int mw = x - cx;//象限水平鼠标距离
            int mh = y - cy;//象限垂直鼠标距离
            int sw = mw < 0 ? cx : (_ScreenW - cx);//象限屏幕宽度
            if (sw < 1)
            {
                sw = 1;
            }
            int sh = mh < 0 ? cy : (_ScreenH - cy);//象限屏幕高度
            if (sh < 1)
            {
                sh = 1;
            }
            int dr = _AlienRadius - _PupilRadius;//可绘制半径
            double rw = (double)mw / sw;
            double rh = (double)mh / sh;
            double rr = Math.Sqrt(rw * rw + rh * rh);//比例半径
            if (rr == 0)
            {
                rr = 1;
            }

            x = (int)(dr * rw / rr) + _PupilCenterX;
            y = (int)(dr * rh / rr) + _PupilCenterY;

            GenImage(x, y);
        }

        private void GenImage(int x, int y)
        {
            using (Graphics g1 = Graphics.FromImage(_BufImage))
            {
                g1.SmoothingMode = SmoothingMode.HighQuality;
                //g1.TextRenderingHint = TextRenderingHint.AntiAlias;

                using (Graphics g2 = Graphics.FromImage(_TmpImage))
                {
                    g2.SmoothingMode = SmoothingMode.HighQuality;
                    //g2.TextRenderingHint = TextRenderingHint.AntiAlias;

                    g2.FillRectangle(_BufBrush, _AlienRect);
                    g2.FillEllipse(_TmpBrush, _AlienRect);

                    g2.DrawImage(_PupilImg, x - _PupilRadius, y - _PupilRadius, _PupilImg.Width, _PupilImg.Height);

                    g2.Flush();
                }

                //g1.Clear(Color.FromArgb(0, 0, 0, 0));
                g1.FillRectangle(_BufBrush, _BRect);
                //g1.DrawImage(Resources.Alien, 0, 0);
                g1.DrawImage(_TmpImage, _LRect);
                g1.DrawImage(_TmpImage, _RRect);

                g1.Flush();
            }
            PbLogo.Image = _BufImage;
        }
        #endregion

        #region 窗口事件
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _MouseOffset = new Point(-e.X, -e.Y);
                _IsMouseDown = true;
            }
        }

        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (_IsMouseDown)
            {
                Point mousePos = Control.MousePosition;
                mousePos.Offset(_MouseOffset.X, _MouseOffset.Y);
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
                _IsMouseDown = false;
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

        private void NiTray_DoubleClick(object sender, EventArgs e)
        {
            BringToFront();
        }
        #endregion

        #region 菜单事件
        #region 导航菜单
        private void MgTopMost_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            MgTopMost.Checked = TopMost;
        }

        private void MgTray_Click(object sender, EventArgs e)
        {
            NiTray.Visible = !NiTray.Visible;
            MgTray.Checked = NiTray.Visible;
        }

        private void MgAPwd_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowAPwd));
                return;
            }

            if (_IApp.AppId != IEnv.IAPP_APWD)
            {
                _IApp.Visible = false;
                ShowAPwd(IEnv.IAPP_APWD);
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

            if (_IApp.AppId != IEnv.IAPP_ASEC)
            {
                _IApp.Visible = false;
                ShowASec(IEnv.IAPP_ASEC);
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

            if (_IApp.AppId != IEnv.IAPP_ABAR)
            {
                _IApp.Visible = false;
                ShowABar(IEnv.IAPP_ABAR);
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

            if (_IApp.AppId != IEnv.IAPP_AREN)
            {
                _IApp.Visible = false;
                ShowARen(IEnv.IAPP_AREN);
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

        private void MtSignFp_Click(object sender, EventArgs e)
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

        #region 托盘菜单
        private void MtGuid_Click(object sender, EventArgs e)
        {
            Visible = !Visible;
            MtGuid.Checked = Visible;
        }

        private void MtAPwd_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowAPwd));
                return;
            }

            if (_IApp.AppId != IEnv.IAPP_APWD)
            {
                _IApp.Visible = false;
                ShowAPwd(IEnv.IAPP_APWD);
                return;
            }
        }

        private void MtASec_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowASec));
                return;
            }

            if (_IApp.AppId != IEnv.IAPP_ASEC)
            {
                _IApp.Visible = false;
                ShowASec(IEnv.IAPP_ASEC);
                return;
            }
        }

        private void MtABar_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowABar));
                return;
            }

            if (_IApp.AppId != IEnv.IAPP_ABAR)
            {
                _IApp.Visible = false;
                ShowABar(IEnv.IAPP_ABAR);
                return;
            }
        }

        private void MtARen_Click(object sender, EventArgs e)
        {
            if (_IApp == null || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowARen));
                return;
            }

            if (_IApp.AppId != IEnv.IAPP_AREN)
            {
                _IApp.Visible = false;
                ShowARen(IEnv.IAPP_AREN);
                return;
            }
        }

        private void MtSignOl_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignOl, new AmonHandler<int>(DoSignOl));
            SignAc(ESignAc.SignOl, new AmonHandler<int>(ShowAPwd));
        }

        private void MtSignUl_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignUl, new AmonHandler<int>(ShowAPwd));
        }

        private void MtSignPc_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<int>(ShowAPwd));
        }

        private void MtSignIn_Click(object sender, EventArgs e)
        {
            //SignAc(ESignAc.SignIn, new AmonHandler<int>(DoSignIn));
            SignAc(ESignAc.SignIn, new AmonHandler<int>(ShowAPwd));
        }

        private void MtSignOf_Click(object sender, EventArgs e)
        {
            SignOf();
        }

        private void MgSignFp_Click(object sender, EventArgs e)
        {

        }

        private void MtInfo_Click(object sender, EventArgs e)
        {
            new About().ShowDialog();
        }

        private void MtExit_Click(object sender, EventArgs e)
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
            MtSignUp.Visible = true;

            MgSignIn.Visible = true;
            MtSignIn.Visible = true;

            MgSignOf.Visible = false;
            MtSignOf.Visible = false;
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
            MtSignIn.Visible = false;

            MgSignUp.Visible = false;
            MtSignUp.Visible = false;

            MgSignOf.Visible = true;
            MtSignOf.Visible = true;
        }

        private void DoSignOl(int view)
        {
        }

        private void ShowLast(int view)
        {
            if (_IApp == null || _IApp.IsDisposed)
            {
                ShowAPwd(IEnv.IAPP_APWD);
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
                _APwd.Show();
                _APwd.InitOnce();
            }
            else
            {
                _APwd.Show();
            }

            _IApp = _APwd;

            DoSignIn(view);
        }

        private void ShowASec(int view)
        {
            if (_ASec == null || _ASec.IsDisposed)
            {
                _ASec = new ASec(_UserModel);
                _ASec.InitOnce();
            }
            _IApp = _ASec;

            _ASec.Show();
        }

        private void ShowABar(int view)
        {
            if (_ABar == null || _ABar.IsDisposed)
            {
                _ABar = new ABar(_UserModel);
                _ABar.InitOnce();
            }
            _IApp = _ABar;

            _ABar.Show();
        }

        private void ShowARen(int view)
        {
            if (_ARen == null || _ARen.IsDisposed)
            {
                _ARen = new ARen(_UserModel);
                _ARen.InitOnce();
            }
            _IApp = _ARen;

            _ARen.Show();
        }
        #endregion

        private void PbLogo_DoubleClick(object sender, EventArgs e)
        {
            if (_IApp == null || _IApp.IsDisposed || !_IApp.Visible)
            {
                CheckUser(new AmonHandler<int>(ShowLast));
                return;
            }

            _IApp.Visible = true;
            _IApp.BringToFront();
        }

        private void MgSignUp_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<int>(ShowAPwd));
        }

        private void MtSignUp_Click(object sender, EventArgs e)
        {
            SignAc(ESignAc.SignPc, new AmonHandler<int>(ShowAPwd));
        }
    }
}