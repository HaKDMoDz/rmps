using System;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V.Cfg
{
    public partial class Config : UserControl, IMgr
    {
        public Config()
        {
            InitializeComponent();
        }

        public void Init()
        {
        }

        #region 接口实现
        public void ShowData(MPcs mPcs)
        {
            TbLocal.Text = mPcs.LocalRoot;
        }

        public bool SaveData(MPcs mPcs)
        {
            string path = TbLocal.Text.Trim();
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("请输入或选择本地存储路径！");
                TbLocal.Focus();
                return false;
            }
            if (!Directory.Exists(path))
            {
                MessageBox.Show("您选择的目录不存在！");
                return false;
            }
            try
            {
                string file = Path.Combine(path, "amon.sync");
                FileInfo info = new FileInfo(file);
                if (!info.Exists)
                {
                    StreamWriter writer = info.CreateText();
                    writer.Write("Demo");
                    writer.Close();
                }
                mPcs.LocalRoot = path;
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
                TbLocal.Focus();
                return false;
            }
        }
        #endregion

        private void BnLocal_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fdDialog = new FolderBrowserDialog();
            fdDialog.Description = "请选择您要存储的位置：";
            fdDialog.SelectedPath = TbLocal.Text;
            if (DialogResult.OK != fdDialog.ShowDialog(this))
            {
                return;
            }
            TbLocal.Text = fdDialog.SelectedPath;
        }
    }
}
