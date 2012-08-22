using System;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcWeek : UserControl, ITime
    {
        public UcWeek()
        {
            InitializeComponent();

            CbWhen.Items.Add(new Itemi { K = 0, V = "星期日" });
            CbWhen.Items.Add(new Itemi { K = 0, V = "星期一" });
            CbWhen.Items.Add(new Itemi { K = 0, V = "星期二" });
            CbWhen.Items.Add(new Itemi { K = 0, V = "星期三" });
            CbWhen.Items.Add(new Itemi { K = 0, V = "星期四" });
            CbWhen.Items.Add(new Itemi { K = 0, V = "星期五" });
            CbWhen.Items.Add(new Itemi { K = 0, V = "星期六" });

            CbWhen.SelectedIndex = (int)DateTime.Now.DayOfWeek;
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                RbEach.Checked = true;
                return;
            }

            ADates dates;
            if (mgtd.Dates.Count == 1)
            {
                RbEach.Checked = true;
                dates = mgtd.Dates[0];
                SpEach.Value = dates.Values[0];
                return;
            }
            if (mgtd.Dates.Count == 1)
            {
                RbWhen.Checked = true;
                dates = mgtd.Dates[0];
                CbWhen.SelectedIndex = dates.Values[0];

                dates = mgtd.Dates[1];
                SpWhen.Minimum = dates.MinValue;
                SpWhen.Maximum = dates.MaxValue;
                SpWhen.Value = dates.Values[0];
                return;
            }
            RbEach.Checked = true;
        }

        public bool SaveData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return false;
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
