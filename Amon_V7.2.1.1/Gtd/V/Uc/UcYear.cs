using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcYear : UserControl, ITime
    {
        public UcYear()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init(DateTime time)
        {
        }

        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd != null && mgtd.Dates.Count == 1)
            {
                ADates dates = mgtd.Dates[0];
                if (dates.Unit == CGtd.UNIT_YEAR)
                {
                    if (dates.Type == CGtd.DATES_TYPE_EACH)
                    {
                        RbEach.Checked = true;
                        SpEach.Value = dates.Values[0];
                        return;
                    }
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

            ADates dates = null;
            if (mgtd.Dates.Count == 1)
            {
                dates = mgtd.Dates[0];
            }
            if (dates == null || dates.Unit != CGtd.UNIT_YEAR)
            {
                dates = new Dates.Year();
                mgtd.Dates.Clear();
                mgtd.Dates.Add(dates);
            }

            if (RbEach.Checked)
            {
                dates.Type = CGtd.DATES_TYPE_EACH;
                dates.Values.Clear();
                dates.Values.Add(decimal.ToInt32(SpEach.Value));
                return true;
            }

            return false;
        }
        #endregion

        #region 事件处理
        private void RbEach_CheckedChanged(object sender, EventArgs e)
        {
            SpEach.Enabled = true;
        }
        #endregion
    }
}
