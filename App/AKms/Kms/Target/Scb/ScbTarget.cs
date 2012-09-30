using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Scb
{
    /// <summary>
    /// 系统剪贴板
    /// </summary>
    public class ScbTarget : ITarget
    {
        private UserModel _UserModel;
        private ScbWindow _ScbWindow;

        #region ITarget 成员

        public ETarget Target
        {
            get
            {
                return ETarget.Scb;
            }
        }

        public string TargetName
        {
            get
            {
                return "剪贴板";
            }
        }

        public bool HintByStep
        {
            get;
            set;
        }

        public Main TrayWin
        {
            get;
            set;
        }

        public bool Start()
        {
            //if (_ScbWindow == null)
            //{
            //    _ScbWindow = new ScbWindow(_);
            //}
            //_ScbWindow.Start();
            return true;
        }

        public bool Prepare(List<MFunction> functions)
        {
            //return _ScbWindow.Prepare(functions);
            return true;
        }

        public void SendMessage(string text)
        {
            //_ScbWindow.SendMessage(text);
            Clipboard.SetText(text);
        }

        public void SendMessage(Image image)
        {
            //_ScbWindow.SendMessage(image);
            Clipboard.SetImage(image);
        }

        public void ShowWarning(string text)
        {
            MessageBox.Show(_ScbWindow, _UserModel.Decode(text), "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult ShowConfirm(string text)
        {
            return MessageBox.Show(_ScbWindow, _UserModel.Decode(text), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public bool Confirm(List<MFunction> functions)
        {
            //return _ScbWindow.Confirm(functions);
            return true;
        }

        public bool Close()
        {
            //User32.ChangeClipboardChain(_ScbWindow.Handle, _nextViewer);
            return true;
        }

        #endregion
    }
}
