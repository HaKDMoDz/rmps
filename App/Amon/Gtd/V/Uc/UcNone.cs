﻿using System;
using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V.Uc
{
    public partial class UcNone : UserControl, ITime
    {
        public UcNone()
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
        }

        public bool SaveData(MGtd mgtd)
        {
            return true;
        }
        #endregion
    }
}
