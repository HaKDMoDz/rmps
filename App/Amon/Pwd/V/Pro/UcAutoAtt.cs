using System;
using System.Windows.Forms;
using Me.Amon.Api.User32;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Pro
{
    public partial class UcAutoAtt : UserControl, IAttEditer
    {
        private WPro _APro;
        private Att _Att;
        private TextBox _Ctl;
        private IntPtr _LastWindow = IntPtr.Zero;

        #region 构造函数
        public UcAutoAtt()
        {
            InitializeComponent();
        }

        public UcAutoAtt(WPro aPro)
        {
            _APro = aPro;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbText.GotFocus += new EventHandler(TbText_GotFocus);
            this.TbData.GotFocus += new EventHandler(TbData_GotFocus);
        }

        public Control Control { get { return this; } }

        public string Title { get { return "填充"; } }

        public bool ShowData(Att att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbText.Text = _Att.Text;
                TbData.Text = _Att.Data;
            }

            return true;
        }

        public new bool Focus()
        {
            if (string.IsNullOrEmpty(TbText.Text))
            {
                return TbText.Focus();
            }

            return TbData.Focus();
        }

        public void Cut()
        {
            if (_Ctl != null)
            {
                _Ctl.Cut();
            }
        }

        public void Copy()
        {
            if (_Ctl == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(_Ctl.SelectedText))
            {
                _Ctl.Copy();
                return;
            }
            if (!string.IsNullOrEmpty(_Ctl.Text))
            {
                Clipboard.SetText(_Ctl.Text);
            }
        }

        public void Paste()
        {
            if (_Ctl != null)
            {
                _Ctl.Paste();
            }
        }

        public void Clear()
        {
            if (_Ctl != null)
            {
                _Ctl.Clear();
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbText.Text != _Att.Text)
            {
                _Att.Text = TbText.Text;
                _Att.Modified = true;
            }
            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void TbText_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbText;
            TbText.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }
        #endregion

        private void PbText_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //Stream stream = File.OpenRead(@"ico\_cur.png");
                //var bmp = (Bitmap)Image.FromStream(stream);
                //stream.Close();
                //Cursor = new Cursor(Properties.Resources._cu.GetHicon());
                Cursor = Cursors.Hand;
                //PbApp.Image = Resources.AppNan;
            }
        }

        private void PbText_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                IntPtr FoundWindow = User32.ChildWindowFromPoint(Cursor.Position);

                Control control = FromHandle(FoundWindow);
                if (control == null)
                {
                    if (FoundWindow != _LastWindow)
                    {
                        // clear old window
                        User32.ShowInvertRectTracker(_LastWindow);
                        // set new window
                        _LastWindow = FoundWindow;
                        // paint new window
                        User32.ShowInvertRectTracker(_LastWindow);
                    }
                    DisplayInfo(_LastWindow);
                }
            }
        }

        private void PbText_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                User32.ShowInvertRectTracker(_LastWindow);
                _LastWindow = IntPtr.Zero;

                Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Show informations about the given window
        /// </summary>
        /// <param name="window"></param>
        private void DisplayInfo(IntPtr window)
        {
            if (window == IntPtr.Zero)
            {
                TbText.Text = "";
            }
            else
            {
                TbText.Text = User32.GetWindowText(window);
            }
        }
    }
}
