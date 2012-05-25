using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Sql.Editor
{
    public partial class SqlEditor : UserControl, IEditor
    {
        public SqlEditor()
        {
            InitializeComponent();
        }

        #region 接口实现
        public bool Check()
        {
            string sql = TbSql.Text.Trim();
            if (string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("请输入您的查询条件！");
                TbSql.Focus();
                return false;
            }
            return true;
        }

        public string GetSQL()
        {
            return TbSql.Text;
        }
        #endregion
    }
}
