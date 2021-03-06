﻿using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Api.User32;
using Me.Amon.Util;
using System.IO;

namespace Me.Amon.Kms.Robot.img
{
    public partial class ImgControl : UserControl, IHuman<Image>
    {
        private IntPtr _findWindow;

        public ImgControl()
            : this(null)
        {
        }

        public ImgControl(KmsHuman human)
        {
            InitializeComponent();
        }

        #region ICapture 成员

        public UserControl Control
        {
            get { return this; }
        }

        public bool HideWindow()
        {
            return true;
        }

        public void Init(string key)
        {
        }

        public Image Deal()
        {
            return BeanUtil.CaptureImage(_findWindow);
        }

        #endregion

        #region 鼠标事件处理
        private IntPtr _lastWindow = IntPtr.Zero;
        private void PbApp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Stream stream = File.OpenRead(@"ico\_cur.png");
                var bmp = (Bitmap)Image.FromStream(stream);
                stream.Close();
                Cursor = new Cursor(bmp.GetHicon());
                PbApp.Image = Properties.Resources._run;
            }
        }

        private void PbApp_MouseMove(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                IntPtr FoundWindow = User32.ChildWindowFromPoint(Cursor.Position);

                // not this application
                Control control = System.Windows.Forms.Control.FromHandle(FoundWindow);
                if (control == null)
                {
                    if (FoundWindow != _lastWindow)
                    {
                        // clear old window
                        User32.ShowInvertRectTracker(_lastWindow);
                        // set new window
                        _lastWindow = FoundWindow;
                        // paint new window
                        User32.ShowInvertRectTracker(_lastWindow);
                    }
                    DisplayInfo(_lastWindow);
                }
                // show global mouse cursor
                //Point p = Cursor.Position;
                //LbPos.Text = "位置：[" + p.X + "," + p.Y + "]";
            }
        }

        private void PbApp_MouseUp(object sender, MouseEventArgs e)
        {
            if (Cursor != Cursors.Default)
            {
                // reset all done things from mouse_down and mouse_move ...
                User32.ShowInvertRectTracker(_lastWindow);
                _findWindow = _lastWindow;
                _lastWindow = IntPtr.Zero;

                Cursor = Cursors.Default;
                PbApp.Image = Properties.Resources._def;
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
                // reset all edit box
                LbCmpLoc.Text = "";
            }
            else
            {
                // Handler
                //LbTitle.Text = "组件句柄：" + window;

                // Point
                Point point = Cursor.Position;
                User32API.ScreenToClient(window, ref point);
                TbCmpLoc.Text = point.ToString();

                // Rect
                Rectangle WindowRect = User32.GetWindowRect(window);
                TbCmpDim.Text = WindowRect.ToString();

                // Caption
                TbCmpTitle.Text = User32.GetWindowText(window);

                // Class
                var ClassName = new StringBuilder(256);
                User32API.GetClassName(window, ClassName, ClassName.Capacity);
                TbCmpClass.Text = ClassName.ToString();
            }
        }
        #endregion

    }
}
