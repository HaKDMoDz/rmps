using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Ce;
using Me.Amon.M;
using Me.Amon.Uc;

namespace Me.Amon.Ren
{
    public partial class ARen : Form, IApp
    {
        private UserModel _UserModel;

        #region 构造函数
        public ARen()
        {
            InitializeComponent();
        }

        public ARen(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId { get; set; }

        public Form Form
        {
            get { return this; }
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            LbEcho.Text = message;
            TpTips.SetToolTip(LbEcho, message);
        }

        public void ShowEcho(string message, int delay)
        {
            LbEcho.Text = message;
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 公共函数
        #endregion

        #region 事件处理
        private void ARen_Load(object sender, EventArgs e)
        {
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void BtReview_Click(object sender, EventArgs e)
        {
        }

        private void BtRename_Click(object sender, EventArgs e)
        {
        }

        private void PbSaveas_Click(object sender, EventArgs e)
        {
        }

        private void LsRule_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
            {
                return;
            }

            CmRule.Show(LsRule, e.Location);
        }

        private void LsRule_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void GvFile_DragEnter(object sender, DragEventArgs e)
        {
        }

        private void GvFile_DragDrop(object sender, DragEventArgs e)
        {
        }

        private void GvFile_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
        }

        private void BgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void BgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void BgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
        #endregion
    }
}