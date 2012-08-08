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
    public partial class APro : UserControl, IImg
    {
        public APro()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void InitOnce()
        {
        }

        public new Control Control
        {
            get { return this; }
        }

        public void OpenFile(string file)
        {
        }
        #endregion
    }
}
