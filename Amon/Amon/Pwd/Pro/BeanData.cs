using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanData : UserControl, IRecEdit
    {
        public BeanData()
        {
            InitializeComponent();
        }

        #region 接口实现
        public bool ShowData(Model.AAtt att)
        {
            return true;
        }

        public void InitView()
        {
        }

        public void Copy()
        {
        }

        public void Save()
        {
        }

        public void Drop()
        {
        }
        #endregion

        private void BtOpt_Click(object sender, EventArgs e)
        {

        }
    }
}
