﻿using System;
using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    public partial class UtMaths : UserControl, IDate
    {
        public UtMaths()
        {
            InitializeComponent();

            label2.Text = string.Format("n/nian/year：{0}代表年{1}y/yue/month：{0}代表月{1}r/ri/day：{0}代表日{1}s/shi/hour：{0}代表时{1}f/fen/minute：{0}代表分{1}m/miao/second：{0}代表秒", "\t", Environment.NewLine);
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public MGtd MGtd { get; set; }

        public void ShowData()
        {
            if (MGtd == null)
            {
                return;
            }

            TbMaths.Text = MGtd.Maths;
        }

        public bool SaveData()
        {
            if (MGtd == null)
            {
                return false;
            }

            MGtd.Maths = TbMaths.Text;
            return true;
        }
        #endregion
    }
}
