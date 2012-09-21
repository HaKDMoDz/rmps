using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class UcStop : UserControl
    {
        public UcStop()
        {
            InitializeComponent();

            DtTime.CustomFormat = CApp.DATEIME_FORMAT;
        }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                RbEver.Checked = true;
                return;
            }

            if (mgtd.EndType == CGtd.END_TYPE_LOOP)
            {
                RbLoop.Checked = true;
                if (mgtd.ExeCount > 0)
                {
                    SpLoop.Value = mgtd.ExeCount;
                }
                return;
            }

            if (mgtd.EndType == CGtd.END_TYPE_TIME)
            {
                RbTime.Checked = true;
                if (mgtd.EndTime > DtTime.MinDate && mgtd.EndTime < DtTime.MaxDate)
                {
                    DtTime.Value = mgtd.EndTime;
                }
                return;
            }

            RbEver.Checked = true;
        }

        public bool SaveData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return false;
            }
            if (RbEver.Checked)
            {
                mgtd.EndType = CGtd.END_TYPE_EVER;
                return true;
            }
            if (RbLoop.Checked)
            {
                mgtd.EndType = CGtd.END_TYPE_LOOP;
                mgtd.ExeCount = decimal.ToInt32(SpLoop.Value);
                return true;
            }
            if (RbTime.Checked)
            {
                mgtd.EndType = CGtd.END_TYPE_TIME;
                mgtd.EndTime = DtTime.Value;
                return true;
            }
            return false;
        }

        #region 事件处理
        private void RbEver_CheckedChanged(object sender, EventArgs e)
        {
            if (RbEver.Checked)
            {
                SpLoop.Enabled = false;
                DtTime.Enabled = false;
            }
        }

        private void RbLoop_CheckedChanged(object sender, EventArgs e)
        {
            if (RbLoop.Checked)
            {
                SpLoop.Enabled = true;
                DtTime.Enabled = false;
            }
        }

        private void RbTime_CheckedChanged(object sender, EventArgs e)
        {
            if (RbTime.Checked)
            {
                SpLoop.Enabled = false;
                DtTime.Enabled = true;
            }
        }
        #endregion
    }
}
