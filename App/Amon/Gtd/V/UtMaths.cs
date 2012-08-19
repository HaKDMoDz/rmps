using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
