using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Api.Enums;
using Me.Amon.Api.User32;
using Me.Amon.Kms.M;
using Me.Amon.Kms.Robot;

namespace Me.Amon.Kms.Target.Scb
{
    public partial class ScbWindow : Form
    {
        private IRobot _robot;
        private MSession _session;
        private IntPtr _nextViewer;

        public ScbWindow()
            : this(null)
        {
        }

        public ScbWindow(IRobot robot)
        {
            InitializeComponent();

            _robot = robot;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case (int)WindowMessage.WM_DRAWCLIPBOARD:
                    try
                    {
                        _session.LastInput = Clipboard.GetText();
                        _robot.Deal(null, null);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(this, e.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    User32API.SendMessage(_nextViewer, m.Msg, m.WParam, m.LParam);
                    break;

                case (int)WindowMessage.WM_CHANGECBCHAIN:
                    if (m.WParam == _nextViewer)
                    {
                        _nextViewer = m.LParam;
                    }
                    else
                    {
                        User32API.SendMessage(_nextViewer, m.Msg, m.WParam, m.LParam);
                    }
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        #region IScbTarget 成员

        #endregion

        public void Start()
        {
            if (_session == null)
            {
                _session = new MSession();
            }
            //TODO:
            //_nextViewer = User32.SetClipboardViewer(this.Handle);
            _robot.Deal(null, null);
        }

        public bool Prepare(List<MFunction> functions)
        {
            return true;
        }

        public void SendMessage(string text)
        {
            Clipboard.SetText(text);
        }

        public void SendMessage(Image image)
        {
            Clipboard.SetImage(image);
        }

        public bool Confirm(List<MFunction> functions)
        {
            return true;
        }
    }
}
