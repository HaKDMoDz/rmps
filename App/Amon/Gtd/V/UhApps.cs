using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class UhApps : UserControl, IHint
    {
        public UhApps()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return;
            }

            TbPath.Text = mgtd.Command;
            TbArgs.Text = mgtd.Params;
        }

        public bool SaveData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return false;
            }
            string path = TbPath.Text.Trim();
            if (string.IsNullOrWhiteSpace(path))
            {
                Main.ShowAlert("请输入或选择文件路径！");
                TbPath.Focus();
                return false;
            }
            mgtd.Command = path;
            mgtd.Params = TbArgs.Text;
            return true;
        }
        #endregion

        private void BtPath_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == Main.ShowOpenFileDialog(EApp.FILE_OPEN_ALL, TbPath.Text, false))
            {
                TbPath.Text = Main.OpenFileDialog.FileName;
            }
        }
    }
}
