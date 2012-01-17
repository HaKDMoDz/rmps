using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Att;
using Me.Amon.Util;
using Me.Amon.Uw;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanFile : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private DataModel _DataModel;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private AAtt _Att;

        #region 构造函数
        public BeanFile()
        {
            InitializeComponent();
        }

        public BeanFile(BeanBody body, TableLayoutPanel grid)
        {
            _Body = body;
            _Grid = grid;

            InitializeComponent();

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            _Style = new RowStyle(SizeType.Absolute, 27F);
            Dock = DockStyle.Fill;
        }
        #endregion

        #region 接口实现
        public void InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);
        }

        public bool ShowData(DataModel dataModel, AAtt att)
        {
            _DataModel = dataModel;

            _Att = att;
            if (_Att != null)
            {
                _Label.Text = _Att.Name;
                TbData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(TbData.Text);
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            if (TbData.Text != _Att.Data)
            {
                _Att.Data = TbData.Text;
                _Att.Modified = true;
            }
            return true;
        }
        #endregion

        private void TbData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

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
                name = HashUtil.GetCurrTimeHex(true);
            }
            string dstFile = _DataModel.AsfDir + name + ".asf";

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

        private void MiSysViewer_Click(object sender, EventArgs e)
        {
            ViewFile(false);
        }

        private void MiPwdViewer_Click(object sender, EventArgs e)
        {
            ViewFile(true);
        }

        private void ViewFile(bool inner)
        {
            string srcFile = _DataModel.AsfDir + _Att.GetSpec(FileAtt.SPEC_FILE_NAME) + ".asf";
            if (!File.Exists(srcFile))
            {
                MessageBox.Show("系统错误，找不到来源文件！");
                return;
            }
            string dstFile = Path.GetTempPath() + TbData.Text;
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
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
