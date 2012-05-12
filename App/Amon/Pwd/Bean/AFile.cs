﻿using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Model.Pwd;
using Me.Amon.Pwd._Att;
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
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "所有文件|*.*";
            if (DialogResult.OK != fd.ShowDialog())
            {
                return;
            }

            string srcFile = fd.FileName;
            if (!File.Exists(srcFile))
            {
                MessageBox.Show("您选择的文件不存在！");
                return;
            }
            string name = _Att.GetSpec(FileAtt.SPEC_FILE_NAME);
            if (!CharUtil.IsValidateHash(name))
            {
                name = HashUtil.UtcTimeInHex(true);
            }
            string dstFile = Path.Combine(_DataModel.AcfDir, name + IEnv.FILE_ACF);

            FileInfo info = new FileInfo(srcFile);
            _Att.SetSpec(FileAtt.SPEC_FILE_NAME, name);
            _Att.SetSpec(FileAtt.SPEC_FILE_EXTS, info.Extension.ToLower());
            string alg = "aes";
            string key = new string(SafeUtil.GenerateFileKeys());
            _Att.SetSpec(FileAtt.SPEC_FILE_ALG, alg);
            _Att.SetSpec(FileAtt.SPEC_FILE_KEY, key);
            if (SafeUtil.EncryptFile(alg, key, srcFile, dstFile))
            {
                _Box.Text = info.Name;
            }
        }

        protected void ViewFile(bool inner)
        {
            string srcFile = Path.Combine(_DataModel.AcfDir, _Att.GetSpec(FileAtt.SPEC_FILE_NAME) + IEnv.FILE_ACF);
            if (!File.Exists(srcFile))
            {
                MessageBox.Show("系统错误，找不到来源文件！");
                return;
            }
            string dstFile = Path.Combine(Path.GetTempPath(), _Box.Text);
            if (!SafeUtil.DecryptFile(_Att.GetSpec(FileAtt.SPEC_FILE_ALG), _Att.GetSpec(FileAtt.SPEC_FILE_KEY), srcFile, dstFile))
            {
                MessageBox.Show("系统错误，无法解密指定文件！");
                return;
            }

            if (inner)
            {
                string exts = _Att.GetSpec(FileAtt.SPEC_FILE_EXTS);
                if (exts == ".png" || exts == ".jpg" || exts == ".jpeg" || exts == ".bmp")
                {
                    ImgViewer viewer = new ImgViewer();
                    viewer.Init(dstFile);
                    viewer.Show(this);
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
