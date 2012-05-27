using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Sec.V.Wiz
{
    public partial class CipherText : UserControl, IView
    {
        public CipherText()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }
        #endregion
    }
}
