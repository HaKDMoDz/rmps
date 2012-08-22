using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Img;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd.M;
using Me.Amon.Util;
using Me.Amon.Uw;

namespace Me.Amon.Pwd.Bean
{
    public partial class AFile : UserControl
    {
        protected Att _Att;
        private TextBox _Box;
        protected DataModel _DataModel;

        #region 构造函数
        public AFile()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        protected void InitSpec(TextBox box)
        {
            _Box = box;
        }

        protected void ShowSpec(Control ctl)
        {
            CmMenu.Show(ctl, 0, ctl.Height);
        }

        protected void OpenFile()
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(EApp.FILE_OPEN_ALL, "", false))
            {
                return;
            }

            string srcFile = Main.OpenFileDialog.FileName;
            if (!File.Exists(srcFile))
            {
                MessageBox.Show("您选择的文件不存在！");
                return;
            }
            string name = _Att.GetSpec(FileAtt.SPEC_FILE_NAME);
            if (!CharUtil.IsValidateHash(name))
            {
                name = HashUtil.UtcTimeInEnc(true);
            }
            string dstFile = Path.Combine(_DataModel.AcfDir, name + EApp.FILE_ACF);
            string alg = "aes";
            string key = new string(SafeUtil.GenerateFileKeys());

            FileInfo info = new FileInfo(srcFile);
            _Att.SetSpec(FileAtt.SPEC_FILE_NAME, name);
            _Att.SetSpec(FileAtt.SPEC_FILE_EXTS, info.Extension.ToLower());
            _Att.SetSpec(FileAtt.SPEC_FILE_ALG, alg);
            _Att.SetSpec(FileAtt.SPEC_FILE_KEY, key);
            if (SafeUtil.EncryptFile(alg, key, srcFile, dstFile))
            {
                _Box.Text = info.Name;
            }
        }

        protected void ViewFile(bool inner)
        {
            string srcFile = Path.Combine(_DataModel.AcfDir, _Att.GetSpec(FileAtt.SPEC_FILE_NAME) + EApp.FILE_ACF);
            if (!File.Exists(srcFile))
            {
                MessageBox.Show("系统错误，找不到来源文件！");
                return;
            }
            string dstFile = Path.Combine(Path.GetTempPath(), _Box.Text);
            try
            {
                SafeUtil.DecryptFile(_Att.GetSpec(FileAtt.SPEC_FILE_ALG), _Att.GetSpec(FileAtt.SPEC_FILE_KEY), srcFile, dstFile);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
                return;
            }

            if (inner)
            {
                string exts = _Att.GetSpec(FileAtt.SPEC_FILE_EXTS);
                if (exts == ".png" || exts == ".jpg" || exts == ".jpeg" || exts == ".bmp")
                {
                    AImg viewer = new AImg();
                    viewer.Show(this);
                    viewer.OpenFile(dstFile);
                    return;
                }
                if (exts == ".txt" || exts == ".ini")
                {
                    TxtEditor editor = new TxtEditor();
                    editor.Init(dstFile);
                    editor.Show(this);
                    return;
                }
            }

            try
            {
                Process.Start(dstFile);
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }
        #endregion

        #region 事件处理
        private void MiPwdViewer_Click(object sender, EventArgs e)
        {
            ViewFile(true);
        }

        private void MiSysViewer_Click(object sender, EventArgs e)
        {
            ViewFile(false);
        }
        #endregion
    }
}
