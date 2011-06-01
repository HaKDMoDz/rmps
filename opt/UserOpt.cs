using System;
using System.Windows.Forms;
using com.magickms.api.Struct;
using com.magickms.api.Enum;

namespace com.magickms.od
{
    public partial class UserOpt : Form
    {
        public UserOpt()
        {
            InitializeComponent();
        }

        #region 前置操作事件
        private void PbTop1_Click(object sender, EventArgs e)
        {

        }

        private void PbBot1_Click(object sender, EventArgs e)
        {

        }

        private void PbDel1_Click(object sender, EventArgs e)
        {

        }

        private void PbAdd1_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbNew1, 0, PbNew1.Height);
        }
        #endregion

        #region 后置操作
        private void PbTop3_Click(object sender, EventArgs e)
        {

        }

        private void PbBot3_Click(object sender, EventArgs e)
        {

        }

        private void PbDel3_Click(object sender, EventArgs e)
        {

        }

        private void PbAdd3_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbNew3, 0, PbNew3.Height);
        }
        #endregion

        private void BtAppend_Click(object sender, EventArgs e)
        {
            api.User32.User32.SendKeys(findCmp1.SelectWindow, "中文");
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            api.User32.User32.PastMessage(findCmp1.SelectWindow, "中文2");
            //user32.User32.SendKeys(findCmp1.SelectWindow, "{ENTER}");
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
