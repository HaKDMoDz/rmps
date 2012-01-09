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
    public partial class BeanFile : UserControl, IProEdit
    {
        public BeanFile()
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
    }
}
