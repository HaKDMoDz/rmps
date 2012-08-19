using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcDay : UserControl, ITime
    {
        public UcDay()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd != null)
            {
                if (mgtd.RedoType == CGtd.TYPE_MINOR_EACH)
                {
                    RbEach.Checked = true;
                    SpEach.Value = mgtd.EachValue;
                    return;
                }

                if (mgtd.RedoType == CGtd.TYPE_MINOR_WHEN)
                {
                    RbWhen.Checked = true;
                    foreach (int val in mgtd.WhenValues)
                    {
                        SpWhen.Value = val;
                    }
                    return;
                }
            }
            RbEach.Checked = true;
        }

        public bool SaveData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return false;
            }

            if (RbEach.Checked)
            {
                mgtd.RedoType = CGtd.TYPE_MINOR_EACH;
                mgtd.EachValue = decimal.ToInt32(SpEach.Value);
                return true;
            }

            if (RbWhen.Checked)
            {
                mgtd.RedoType = CGtd.TYPE_MINOR_WHEN;
                mgtd.WhenValues.Clear();
                mgtd.WhenValues.Add(decimal.ToInt32(SpWhen.Value));
                return true;
            }

            return false;
        }
        #endregion

        #region 事件处理
        private void RbEach_CheckedChanged(object sender, EventArgs e)
        {
            SpEach.Enabled = true;
            SpWhen.Enabled = false;
        }

        private void RbWhen_CheckedChanged(object sender, EventArgs e)
        {
            SpEach.Enabled = false;
            SpWhen.Enabled = true;
        }
        #endregion
    }
}
