﻿using System;
using System.Windows.Forms;
using Me.Amon.Api.User32;
using Me.Amon.M;
using Me.Amon.Spy.M;

namespace Me.Amon.Spy
{
    public partial class WSpy : Form, IApp
    {
        private UserModel _UserModel;

        #region 构造函数
        public WSpy()
        {
            InitializeComponent();
        }

        public WSpy(AUserModel userModel)
        {
            _UserModel = userModel as UserModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get;
            set;
        }

        public Form Form
        {
            get { return this; }
        }

        public void ShowTips(Control control, string caption)
        {
            //TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            //LbEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            //LbEcho.Text = message;
        }

        public bool CanExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 鼠标事件处理
        private IntPtr _LastWindow = IntPtr.Zero;
        private void PbApp_MouseDown(object sender, MouseEventArgs e)
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

        private void PbApp_MouseMove(object sender, MouseEventArgs e)
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

        private void PbApp_MouseUp(object sender, MouseEventArgs e)
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
                TbSpy.Text = "";
            }
            else
            {
                TbSpy.Text = User32.GetWindowText(window);
            }
        }
        #endregion
    }
}
