using System;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Uw;

namespace Me.Amon
{
    public class Main
    {
        #region 全局变量
        private static Alert _Alert;
        private static Error _Error;
        private static Input _Input;
        private static Waiting _Waiting;
        #endregion

        #region 全局函数
        public static DialogResult ShowConfirm(string message)
        {
            Form window = null;
            return MessageBox.Show(window, message, "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
        }

        public static void ShowAbout(IWin32Window owner)
        {
            About about = new About();
            about.ShowDialog(owner);
        }

        public static void ShowAlert(IWin32Window owner, string alert)
        {
            if (_Alert == null)
            {
                _Alert = new Alert(Me.Amon.Properties.Resources.Icon);
            }
            _Alert.Show(owner, alert);
        }

        public static void ShowError(IWin32Window owner, Exception error)
        {
            if (_Error == null)
            {
                _Error = new Error(Me.Amon.Properties.Resources.Icon);
            }
            _Error.Show(owner, error);
        }

        public static string ShowInput(IWin32Window owner, string message, string deftext)
        {
            if (_Input == null)
            {
                _Input = new Input(Me.Amon.Properties.Resources.Icon);
            }
            _Input.Show(owner, message, deftext);
            return _Input.DialogResult == DialogResult.OK ? _Input.Message : null;
        }

        public static void ShowWaiting(IWin32Window owner, string message)
        {
            if (_Waiting == null)
            {
                _Waiting = new Waiting();
            }
            _Waiting.Show(owner, message);
        }
        #endregion

        #region 文件打开对话框
        private static OpenFileDialog _FdOpen;
        public static OpenFileDialog OpenFileDialog
        {
            get
            {
                if (_FdOpen == null)
                {
                    _FdOpen = new OpenFileDialog();
                }
                return _FdOpen;
            }
        }

        public static DialogResult ShowOpenFileDialog(string filter, string file, bool multi)
        {
            OpenFileDialog.Filter = filter;
            OpenFileDialog.FileName = file;
            OpenFileDialog.Multiselect = multi;
            return OpenFileDialog.ShowDialog();
        }

        public static DialogResult ShowOpenFileDialog(IWin32Window owner, string filter, string file, bool multi)
        {
            OpenFileDialog.Filter = filter;
            OpenFileDialog.FileName = file;
            OpenFileDialog.Multiselect = multi;
            return OpenFileDialog.ShowDialog(owner);
        }
        #endregion

        #region 文件保存对话框
        private static SaveFileDialog _FdSave;
        public static SaveFileDialog SaveFileDialog
        {
            get
            {
                if (_FdSave == null)
                {
                    _FdSave = new SaveFileDialog();
                }
                return _FdSave;
            }
        }

        public static DialogResult ShowSaveFileDialog(string filter, string file)
        {
            SaveFileDialog.Filter = filter;
            SaveFileDialog.FileName = file;
            return SaveFileDialog.ShowDialog();
        }

        public static DialogResult ShowSaveFileDialog(IWin32Window owner, string filter, string file)
        {
            SaveFileDialog.Filter = filter;
            SaveFileDialog.FileName = file;
            return SaveFileDialog.ShowDialog(owner);
        }
        #endregion

        #region 日志记录
        private static StreamWriter _Writer;
        public static void LogInfo(string msg)
        {
            if (_Writer != null)
            {
                _Writer.WriteLine(msg);
                _Writer.Flush();
            }
        }
        #endregion
    }
}
