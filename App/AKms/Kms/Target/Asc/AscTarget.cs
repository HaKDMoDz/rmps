using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Asc
{
    /// <summary>
    /// Auto Screen Capture
    /// 屏幕截图
    /// </summary>
    public class AscTarget : ITarget
    {
        #region ITarget 成员

        public ETarget Target
        {
            get { return ETarget.Scb; }
        }

        public string TargetName
        {
            get { return ""; }
        }

        public Main TrayWin
        {
            get;
            set;
        }

        public bool HintByStep
        {
            get;
            set;
        }

        public bool Start()
        {
            return true;
        }

        public bool Prepare(List<MFunction> functions)
        {
            return true;
        }

        public void SendMessage(string text)
        {
        }

        public void SendMessage(Image image)
        {
        }

        public void ShowWarning(string text)
        {
        }

        public DialogResult ShowConfirm(string text)
        {
            return DialogResult.OK;
        }

        public bool Confirm(List<MFunction> functions)
        {
            return true;
        }

        public bool Close()
        {
            return true;
        }

        #endregion
    }
}
