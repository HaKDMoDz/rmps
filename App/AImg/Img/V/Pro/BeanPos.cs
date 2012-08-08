using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class BeanPos : UserControl
    {
        public BeanPos()
        {
            InitializeComponent();
        }

        private void TlLabel_Click(object sender, EventArgs e)
        {
            TlLabel.BackColor = Color.Gray;
        }

        private void TrLabel_Click(object sender, EventArgs e)
        {
            TrLabel.BackColor = Color.Gray;
        }

        private void BlLabel_Click(object sender, EventArgs e)
        {
            BlLabel.BackColor = Color.Gray;
        }

        private void BrLabel_Click(object sender, EventArgs e)
        {
            BrLabel.BackColor = Color.Gray;
        }
    }
}
