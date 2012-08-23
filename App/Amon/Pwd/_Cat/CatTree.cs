using System;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.M;

namespace Me.Amon.Pwd._Cat
{
    public partial class CatTree : Form
    {
        private UserModel _UserModel;
        private TreeNode _RootNode;

        #region 构造函数
        public CatTree()
        {
            InitializeComponent();
        }

        public CatTree(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void Init(ImageList imgList)
        {
            TvCatTree.ImageList = imgList;

            Cat cat = new Cat { Id = CPwd.DEF_CAT_ID, Text = "阿木密码箱", Tips = "阿木密码箱", Icon = "Amon" };
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Icon, SelectedImageKey = cat.Icon };
            _RootNode.Tag = cat;
            TvCatTree.Nodes.Add(_RootNode);
            InitCat(_RootNode);
            _RootNode.Expand();
        }

        private void InitCat(TreeNode root)
        {
            foreach (Cat cat in _UserModel.DBA.ListCat(root.Name))
            {
                TreeNode node = new TreeNode();
                node.Name = cat.Id;
                node.Text = cat.Text;
                node.ToolTipText = cat.Tips;
                node.Tag = cat;
                node.ImageKey = cat.Icon;
                node.SelectedImageKey = node.ImageKey;

                root.Nodes.Add(node);
                if (!cat.IsLeaf)
                {
                    InitCat(node);
                }
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
                CallBack(item.Id);
            }
            Close();
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
