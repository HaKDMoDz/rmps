using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Bean.Att;
using Me.Amon.Model;
using Me.Amon.Util;
using Me.Amon.Uw;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanFile : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBox _Ctl;
        private DataModel _DataModel;

        #region 构造函数
        public BeanFile()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            _DataModel = dataModel;

            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.TbData.GotFocus += new EventHandler(TbData_GotFocus);

            BtView.Image = viewModel.GetImage("att-file-preview");
            BtOpen.Image = viewModel.GetImage("att-file-append");
        }

        public Control Control { get { return this; } }

        public string Title { get { return "文件"; } }

        public bool ShowData(AAtt att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }

            if (string.IsNullOrEmpty(TbName.Text))
            {
                TbName.Focus();
            }
            else
            {
                TbData.Focus();
            }
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(_Ctl.Text);
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbName.Text != _Att.Name)
            {
                _Att.Name = TbName.Text;
                _Att.Modified = true;
            }
            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }

            return true;
        }
        #endregion

        #region 事件处理
        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbName;
            TbName.SelectAll();
        }

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbData;
            TbData.SelectAll();
        }

        #region 按钮事件
        private void BtView_Click(object sender, EventArgs e)
        {
            CmMenu.Show(BtView, 0, BtView.Height);
        }

        private void BtOpen_Click(object sender, EventArgs e)
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
            string dstFile = _DataModel.AcfDir + name + IEnv.FILE_ACF;

            FileInfo info = new FileInfo(srcFile);
            _Att.SetSpec(FileAtt.SPEC_FILE_NAME, name);
            _Att.SetSpec(FileAtt.SPEC_FILE_EXTS, info.Extension.ToLower());
            string alg = "aes";
            string key = new string(CharUtil.GenerateFileKeys());
            _Att.SetSpec(FileAtt.SPEC_FILE_ALG, alg);
            _Att.SetSpec(FileAtt.SPEC_FILE_KEY, key);
            if (SafeUtil.EncryptFile(alg, key, srcFile, dstFile))
            {
                TbData.Text = info.Name;
            }
        }
        #endregion

        #region 菜单事件
        private void MiPwdViewer_Click(object sender, EventArgs e)
        {
            ViewFile(true);
        }

        private void MiSysViewer_Click(object sender, EventArgs e)
        {
            ViewFile(false);
        }
        #endregion
        #endregion

        #region 私有函数
        private void ViewFile(bool inner)
        {
            string srcFile = Path.Combine(_DataModel.AcfDir, _Att.GetSpec(FileAtt.SPEC_FILE_NAME) + IEnv.FILE_ACF);
            if (!File.Exists(srcFile))
            {
                MessageBox.Show("系统错误，找不到来源文件！");
                return;
            }
            string dstFile = Path.Combine(Path.GetTempPath(), TbData.Text);
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
    }
}
