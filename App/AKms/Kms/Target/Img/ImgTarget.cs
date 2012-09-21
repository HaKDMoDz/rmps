using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;

namespace Me.Amon.Kms.Target.Img
{
    public class ImgTarget : ITarget
    {
        #region ITarget 成员

        public ETarget Target
        {
            get { return ETarget.Img; }
        }

        public string TargetName
        {
            get { return "文件系统"; }
        }

        public AKms TrayWin
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

        public void SendMessage(string text)
        {
        }

        public void SendMessage(Image image)
        {
            // 显示保存对话框
            var dialog = new SaveFileDialog();
            dialog.FileName = DateTime.Now.ToString("yyyyMMdd-HHmmssffff") + ".PNG";
            dialog.Filter = "PNG图像 | *.PNG";
            if (DialogResult.OK == dialog.ShowDialog())
            {
                image.Save(dialog.FileName, ImageFormat.Png);
            }
            image.Dispose();
        }

        public void ShowWarning(string text)
        {
        }

        public DialogResult ShowConfirm(string text)
        {
            return DialogResult.OK;
        }

        public bool Close()
        {
            return true;
        }

        #endregion
    }
}
