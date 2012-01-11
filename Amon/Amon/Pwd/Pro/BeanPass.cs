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
    public partial class BeanPass : UserControl, IRecEdit
    {
        public BeanPass()
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

        private void BtMod_Click(object sender, EventArgs e)
        {

        }

        private void BtGen_Click(object sender, EventArgs e)
        {

        }

        private void BtOpt_Click(object sender, EventArgs e)
        {

        }
    }
}
