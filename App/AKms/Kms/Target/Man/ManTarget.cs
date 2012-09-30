using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Man
{
    public class ManTarget : ITarget
    {
        private ManWindow _ManWindow;

        public ManTarget()
        {
        }

        #region ITarget 成员

        public ETarget Target
        {
            get
            {
                return ETarget.Man;
            }
        }

        public string TargetName
        {
            get
            {
                return "人";
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
            if (_ManWindow == null)
            {
                _ManWindow = new ManWindow();
            }
            _ManWindow.Start();
            return true;
        }

        public bool Prepare(List<MFunction> functions)
        {
            //return _ManWindow.Prepare(functions);
            return false;
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
            return false;
            //return _ManWindow.Confirm(functions);
        }

        public bool Close()
        {
            return false;
        }

        #endregion

        public void ShowNotice(string notice)
        {
        }

        public void ShowOptions(EOptions options, string notice)
        {
        }
    }
}
