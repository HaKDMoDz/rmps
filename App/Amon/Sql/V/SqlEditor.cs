using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Sql.C;

namespace Me.Amon.Sql.V
{
    public partial class SqlEditor : UserControl, IEditor
    {
        private string _Buffer;
        private TreeNode TnTbl;
        private TreeNode TnView;
        private TreeNode TnPro;
        private TreeNode TnFun;
        private UserModel _UserModel;

        #region 构造函数
        public SqlEditor()
        {
            InitializeComponent();
        }

        public SqlEditor(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void Init(IEngine engine)
        {
            TnTbl = new TreeNode("表格");
            TvObj.Nodes.Add(TnTbl);

            TnView = new TreeNode("视图");
            TvObj.Nodes.Add(TnView);

            TnPro = new TreeNode("规则");
            TvObj.Nodes.Add(TnPro);

            TnFun = new TreeNode("函数");
            TvObj.Nodes.Add(TnFun);

            List<string> tables = engine.TableList;
            if (tables != null)
            {
                foreach (string obj in tables)
                {
                    TreeNode node = new TreeNode();
                    node.Text = obj;
                    node.Tag = obj;
                    TnTbl.Nodes.Add(node);
                }
            }

            List<string> views = engine.ViewList;
            if (views != null)
            {
                foreach (string obj in views)
                {
                    TreeNode node = new TreeNode();
                    node.Text = obj;
                    node.Tag = obj;
                    TnView.Nodes.Add(node);
                }
            }
        }

        public bool Check()
        {
            string sql = TbSql.Text.Trim();
            if (string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("请输入您的查询条件！");
                TbSql.Focus();
                return false;
            }

            _Buffer = TbSql.SelectedText.Trim();
            if (!string.IsNullOrWhiteSpace(_Buffer))
            {
                return true;
            }

            int s = TbSql.SelectionStart;
            if (s < 0)
            {
                _Buffer = sql;
                return true;
            }

            int e = sql.IndexOf(';', s);
            if (e < 0)
            {
                e = sql.Length;
            }
            s -= 1;
            if (s > 0)
            {
                s = sql.LastIndexOf(';', s);
            }
            s += 1;
            _Buffer = sql.Substring(s, e - s);
            return !string.IsNullOrWhiteSpace(_Buffer);
        }

        public string GetSQL()
        {
            if (_Buffer[_Buffer.Length - 1] == ';')
            {
                _Buffer = _Buffer.Substring(0, _Buffer.Length - 1);
            }
            return _Buffer;
        }
        #endregion

        private void TvObj_DoubleClick(object sender, System.EventArgs e)
        {
            TreeNode node = TvObj.SelectedNode;
            if (node == null)
            {
                return;
            }
            string obj = node.Tag as string;
            if (obj == null)
            {
                return;
            }
            TbSql.Paste(obj);
        }
    }
}
