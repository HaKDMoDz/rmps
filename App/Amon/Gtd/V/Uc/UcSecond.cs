﻿using System;
using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcSecond : UserControl, ITime
    {
        public UcSecond()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init(DateTime time)
        {
            SpWhen.Value = time.Second;
        }

        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd != null && mgtd.Dates.Count == 1)
            {
                ADates dates = mgtd.Dates[0];
                if (dates.Unit == CGtd.UNIT_SECOND)
                {
                    if (dates.Type == CGtd.DATES_TYPE_EACH)
                    {
                        RbEach.Checked = true;
                        SpEach.Value = dates.Values[0];
                        return;
                    }

                    if (dates.Type == CGtd.DATES_TYPE_WHEN)
                    {
                        RbWhen.Checked = true;
                        foreach (int val in dates.Values)
                        {
                            SpWhen.Value = val;
                        }
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
            if (dates == null || dates.Unit != CGtd.UNIT_SECOND)
            {
                dates = new M.Dates.Second();
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

            if (RbWhen.Checked)
            {
                dates.Type = CGtd.DATES_TYPE_WHEN;
                dates.Values.Clear();
                dates.Values.Add(decimal.ToInt32(SpWhen.Value));
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
