using System;
using System.Data;
using System.Windows.Forms;
using Me.Amon.Da;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Cat
{
    public partial class CatView : Form
    {
        private UserModel _UserModel;
        private TreeNode _RootNode;

        #region 构造函数
        public CatView()
        {
            InitializeComponent();
        }

        public CatView(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init(ImageList imgList)
        {
            TvCatTree.ImageList = imgList;

            Cat cat = new Cat { Id = "0", Text = "阿木密码箱", Tips = "阿木密码箱", Icon = "0" };
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Id };
            _RootNode.Tag = cat;
            TvCatTree.Nodes.Add(_RootNode);

            DBAccess dba = _UserModel.DBAccess;
            dba.ReInit();
            dba.AddTable(DBConst.ACAT0200);
            dba.AddColumn(DBConst.ACAT0201);
            dba.AddColumn(DBConst.ACAT0203);
            dba.AddColumn(DBConst.ACAT0204);
            dba.AddColumn(DBConst.ACAT0205);
            dba.AddColumn(DBConst.ACAT0206);
            dba.AddColumn(DBConst.ACAT0207);
            dba.AddColumn(DBConst.ACAT0208);
            dba.AddColumn(DBConst.ACAT0209);
            dba.AddWhere(DBConst.ACAT0202, _UserModel.Code);
            dba.AddWhere(DBConst.ACAT020D, ">", DBConst.OPT_DELETE.ToString(), false);
            DataTable dt = dba.ExecuteSelect();
            InitCat(_RootNode, dt);
            _RootNode.Expand();
        }

        private void InitCat(TreeNode root, DataTable data)
        {
            int i = 0;
            while (i < data.Rows.Count)
            {
                DataRow row = data.Rows[i];
                string tmp = row[DBConst.ACAT0204] as string;
                if (tmp != root.Name)
                {
                    i += 1;
                    continue;
                }

                Cat cat = new Cat();
                cat.Id = row[DBConst.ACAT0203] as string;
                cat.Text = row[DBConst.ACAT0205] as string;
                cat.Tips = row[DBConst.ACAT0206] as string;
                cat.Icon = row[DBConst.ACAT0207] as string;
                cat.Meta = row[DBConst.ACAT0208] as string;
                cat.Memo = row[DBConst.ACAT0209] as string;

                TreeNode node = new TreeNode();
                node.Name = cat.Id;
                node.Text = cat.Text;
                node.ToolTipText = cat.Tips;
                node.Tag = cat;
                if (CharUtil.IsValidateHash(cat.Icon))
                {
                    node.ImageKey = cat.Icon;
                }
                else
                {
                    node.ImageKey = "0";
                }

                root.Nodes.Add(node);
                data.Rows.RemoveAt(i);
                InitCat(node, data);
            }
        }
        #endregion

        public AmonHandler<string> CallBack { get; set; }

        private void BtSelect_Click(object sender, EventArgs e)
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                MessageBox.Show("请选择一个类别！");
                return;
            }

            Cat item = node.Tag as Cat;
            if (item == null)
            {
                return;
            }

            DialogResult = DialogResult.OK;
            if (CallBack != null)
            {
                CallBack.Invoke(item.Id);
            }
            Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
