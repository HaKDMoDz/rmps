using System;
using System.Windows.Forms;
using Me.Amon.Gtd.M;
using Me.Amon.Uc;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcWeek : UserControl, ITime
    {
        public UcWeek()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init(DateTime time)
        {
            CbWhen.Items.Add(new Itemi { K = 1, V = "第一个" });
            CbWhen.Items.Add(new Itemi { K = 2, V = "第二个" });
            CbWhen.Items.Add(new Itemi { K = 3, V = "第三个" });
            CbWhen.Items.Add(new Itemi { K = 4, V = "第四个" });
            CbWhen.Items.Add(new Itemi { K = -1, V = "最后一个" });
            CbWhen.SelectedIndex = time.Day / 7;

            CbDate.Items.Add(new Itemi { K = 0, V = "星期日" });
            CbDate.Items.Add(new Itemi { K = 1, V = "星期一" });
            CbDate.Items.Add(new Itemi { K = 2, V = "星期二" });
            CbDate.Items.Add(new Itemi { K = 3, V = "星期三" });
            CbDate.Items.Add(new Itemi { K = 4, V = "星期四" });
            CbDate.Items.Add(new Itemi { K = 5, V = "星期五" });
            CbDate.Items.Add(new Itemi { K = 6, V = "星期六" });
            CbDate.SelectedIndex = (int)time.DayOfWeek;
        }

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
            if (mgtd.Dates.Count == 2)
            {
                RbWhen.Checked = true;
                dates = mgtd.Dates[0];
                CbDate.SelectedItem = new Itemi { K = dates.Values[0] };

                dates = mgtd.Dates[1];
                CbWhen.SelectedItem = new Itemi { K = dates.Values[0] };
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
            CbWhen.Enabled = false;
        }

        private void RbWhen_CheckedChanged(object sender, EventArgs e)
        {
            SpEach.Enabled = false;
            CbWhen.Enabled = true;
        }
        #endregion
    }
}
