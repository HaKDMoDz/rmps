using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Pcs.V
{
    public partial class MetaUri : UserControl
    {
        public MetaUri()
        {
            InitializeComponent();
        }

        public MetaUri(WPcs wPcs)
        {
            InitializeComponent();
        }

        #region 公共属性
        public string Text
        {
            get
            {
                return TbUri.Text;
            }
            set
            {
                TbUri.Text = value;
            }
        }

        public Image Icon
        {
            get
            {
                return BnUri.Image;
            }
            set
            {
                BnUri.Image = value;
            }
        }
        #endregion
    }
}
