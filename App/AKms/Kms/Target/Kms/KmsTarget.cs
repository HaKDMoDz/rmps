using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Kms
{
    public class KmsTarget : ITarget
    {
        private KmsWindow _KmsWindow;

        #region ITarget 成员

        public ETarget Target
        {
            get { return ETarget.Kms; }
        }

        public string TargetName
        {
            get
            {
                return "机器人";
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
            if (_KmsWindow == null)
            {
                _KmsWindow = new KmsWindow();
            }
            ShowWarning("目前还不支持此会话对象，恭请关注后续版本！");
            return false;
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
            MessageBox.Show(_KmsWindow, text, "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public DialogResult ShowConfirm(string text)
        {
            return MessageBox.Show(_KmsWindow, text, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public bool Confirm(List<MFunction> functions)
        {
            return true;
        }

        public bool Close()
        {
            return false;
        }

        #endregion
    }
}
