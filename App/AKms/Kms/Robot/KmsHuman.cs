using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Me.Amon.Uc;
using Me.Amon.Da;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Robot.img;
using Me.Amon.Kms.Robot.txt;
using Me.Amon.Kms.V;

namespace Me.Amon.Kms.Robot
{
    public partial class KmsHuman : UserControl
    {
        private readonly AKms _TrayPtn;
        private readonly MagicPtn _MagicPtn;
        private readonly KmsRobot _Robot;
        private DataModel _DataModel;

        #region 构造函数
        public KmsHuman()
        {
            InitializeComponent();
        }

        public KmsHuman(AKms trayPtn, KmsRobot robot, DataModel dataModel)
        {
            _TrayPtn = trayPtn;
            _Robot = robot;
            _DataModel = dataModel;

            InitializeComponent();
            BtRes.Image = _ResLeave;

            CbRes.Items.Add(new MCategory { C2010203 = "0", C2010205 = "请选择" });
            CbRes.Items.AddRange(_DataModel.ListCategory().ToArray());
            CbRes.SelectedIndex = 0;
            MiTxt.Checked = true;

            if (_TxtLast == null)
            {
                _TxtLast = new TxtDefault(this, _DataModel);
            }
            ShowControl(_TxtLast.Control);

            Rectangle rect = Screen.PrimaryScreen.WorkingArea;
            _MagicPtn = new MagicPtn(this);
            _MagicPtn.UseDefaultAction();
            _MagicPtn.ExitButtonHandler = PbExit_Click;
            _MagicPtn.Location = new Point(rect.Width - _MagicPtn.Width, rect.Height - _MagicPtn.Height);
            _MagicPtn.Text = "会话";
        }
        #endregion

        public new bool Visible
        {
            get { return _MagicPtn.Visible; }
            set { _MagicPtn.Visible = value; }
        }

        #region IHuman 成员
        public void Start()
        {
            if (!_MagicPtn.Visible)
            {
                _MagicPtn.Visible = true;
            }
            //if (_MagicPtn.WindowState != FormWindowState.Normal)
            //{
            //    _MagicPtn.WindowState = FormWindowState.Normal;
            //}
        }

        public void Close()
        {
            _MagicPtn.Close();
        }

        #endregion

        private IHuman<Image> _ImgLast;
        private IHuman<MSentence> _TxtLast;
        private void CbRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 语言资源
            if (MiTxt.Checked)
            {
                var cat = CbRes.SelectedItem as MCategory;
                if (cat == null || cat.C2010203 == "0")
                {
                    return;
                }
                _TxtLast.Init(cat.C2010203);
                return;
            }

            // 屏幕截图
            if (!MiImg.Checked)
            {
                return;
            }

            var item = CbRes.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            IHuman<Image> capture;
            switch (item.K)
            {
                case "screen":
                    if (_ImgScreen == null)
                    {
                        _ImgScreen = new ImgScreen(this);
                    }
                    capture = _ImgScreen;
                    break;
                case "window":
                    if (_ImgWindow == null)
                    {
                        _ImgWindow = new ImgWindow(this);
                    }
                    capture = _ImgWindow;
                    break;
                case "region":
                    if (_ImgRegion == null)
                    {
                        _ImgRegion = new ImgRegion(this);
                    }
                    capture = _ImgRegion;
                    break;
                case "control":
                    if (_ImgControl == null)
                    {
                        _ImgControl = new ImgControl(this);
                    }
                    capture = _ImgControl;
                    break;
                default:
                    if (_ImgDefault == null)
                    {
                        _ImgDefault = new ImgDefault(this);
                    }
                    capture = _ImgDefault;
                    break;
            }

            _ImgLast = capture;
            ShowControl(_ImgLast.Control);
        }
        private ImgScreen _ImgScreen;
        private ImgWindow _ImgWindow;
        private ImgRegion _ImgRegion;
        private ImgControl _ImgControl;
        private ImgDefault _ImgDefault;

        private UserControl _LastControl;
        private void ShowControl(UserControl control)
        {
            if (_LastControl != null)
            {
                Controls.Remove(_LastControl);
            }

            control.Location = new Point(5, 29);
            control.Name = "LsRes";
            control.Size = new Size(172, 208);
            control.TabIndex = 2;
            Controls.Add(control);
            _LastControl = control;
        }

        private void BtRes_Click(object sender, EventArgs e)
        {
            Point point = BtRes.PointToClient(MousePosition);

            // 显示菜单
            if (point.X > BtRes.Width - 14)
            {
                CtMenu.Show(BtRes, BtRes.Width - 14, BtRes.Height);
                return;
            }

            // 文本
            if (MiTxt.Checked)
            {
                DealTxt();
                return;
            }

            // 截图
            if (MiImg.Checked)
            {
                DealImg();
                return;
            }
        }

        public void Send(string text)
        {
            _Robot.Send(text);
        }

        private void DealTxt()
        {
            MSentence sen = _TxtLast.Deal();
            if (sen != null)
            {
                _Robot.Send(sen.P3100105);
            }
        }

        private void DealImg()
        {
            var item = CbRes.SelectedItem as Items;
            if (item == null || string.IsNullOrEmpty(item.K) || _ImgLast == null)
            {
                MessageBox.Show(_MagicPtn, "请选择您的截图方案！", "提示");
                CbRes.Focus();
                return;
            }

            // 隐藏主窗口
            if (_ImgLast.HideWindow())
            {
                _MagicPtn.Visible = false;
                _TrayPtn.Visible = false;
                // 执行等待
                Thread.Sleep(100);
            }

            // 执行截图
            Image image = _ImgLast.Deal();
            if (image == null)
            {
                return;
            }

            if (_ImgLast.HideWindow())
            {
                _TrayPtn.Visible = true;
                _MagicPtn.Visible = true;
            }

            _Robot.Send(image);
        }

        private void MiTxt_Click(object sender, EventArgs e)
        {
            if (MiTxt.Checked)
            {
                return;
            }

            MiImg.Checked = false;
            MiTxt.Checked = true;

            CbRes.Items.Clear();
            CbRes.Items.Add(new MCategory { C2010205 = "请选择", C2010203 = "0" });
            CbRes.Items.AddRange(_DataModel.ListCategory().ToArray());
            CbRes.SelectedIndex = 0;
            CbRes.Focus();

            if (_TxtLast == null)
            {
                _TxtLast = new TxtDefault(this, _DataModel);
            }
            ShowControl(_TxtLast.Control);
        }

        private void MiImg_Click(object sender, EventArgs e)
        {
            if (MiImg.Checked)
            {
                return;
            }

            MiTxt.Checked = false;
            MiImg.Checked = true;

            CbRes.Items.Clear();
            CbRes.Items.Add(new Items { K = "0", V = "请选择" });
            CbRes.Items.Add(new Items { K = "screen", V = "全屏模式" });
            CbRes.Items.Add(new Items { K = "window", V = "窗口模式" });
            CbRes.Items.Add(new Items { K = "region", V = "矩形区域" });
            CbRes.Items.Add(new Items { K = "control", V = "指定组件" });
            CbRes.SelectedIndex = 0;
            CbRes.Focus();
        }

        private void PbExit_Click(object sender, EventArgs e)
        {
            _TrayPtn.SessionClose();
            _Robot.Stop();
            _MagicPtn.Visible = false;
        }

        private readonly Image _ResEnter = Image.FromFile(string.Format("png/{0}/sende.png", "Gray"));
        private readonly Image _ResLeave = Image.FromFile(string.Format("png/{0}/sendd.png", "Gray"));
        private void BtRes_MouseEnter(object sender, EventArgs e)
        {
            BtRes.Image = _ResEnter;
        }

        private void BtRes_MouseLeave(object sender, EventArgs e)
        {
            BtRes.Image = _ResLeave;
        }
    }
}
