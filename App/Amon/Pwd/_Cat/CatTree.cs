using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Properties;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V;
using Me.Amon.Util;

namespace Me.Amon.Pwd._Cat
{
    public partial class CatTree : UserControl, ICatTree
    {
        #region 全局变量
        private APwd _APwd;
        private DataModel _DataModel;

        private TreeNode _RootNode;
        private TreeNode _LastNode;
        /// <summary>
        /// 待提示节点
        /// </summary>
        private TreeNode _TaskNode;
        /// <summary>
        /// 快过期节点
        /// </summary>
        private TreeNode _TaskExpiredNode;
        private TreeNode _LastDnDNode;
        #endregion

        #region 构造函数
        public CatTree()
        {
            InitializeComponent();
        }

        public CatTree(APwd aPwd)
        {
            _APwd = aPwd;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public ContextMenuStrip PopupMenu { get; set; }

        public IKeyList KeyList { get; set; }

        public Cat SelectedCat { get; set; }

        public void Init(DataModel dataModel)
        {
            _DataModel = dataModel;

            IlCat.Images.Add(CPwd.DEF_CAT_IMG, BeanUtil.NaN16);

            Cat cat = new Cat { Id = CPwd.DEF_CAT_ID, Text = "默认类别", Tips = "默认类别", Icon = "Amon" };
            IlCat.Images.Add(cat.Icon, Resources.Logo);
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Icon, SelectedImageKey = cat.Icon };
            _RootNode.Tag = cat;
            TvCat.Nodes.Add(_RootNode);
            DoInitCat(_RootNode);
            _RootNode.Expand();
        }
        #endregion

        #region 公共函数
        /// <summary>
        /// 提升一级
        /// </summary>
        public void CatPromotion()
        {
            TreeNode node = TvCat.SelectedNode;
            if (node == null || node == _RootNode)
            {
                return;
            }
            Cat curCat = node.Tag as Cat;
            if (curCat == null)
            {
                return;
            }

            TreeNode parent = node.Parent;
            if (parent == null || parent == _RootNode)
            {
                return;
            }
            Cat parentCat = parent.Tag as Cat;
            if (parentCat == null)
            {
                return;
            }

            TreeNode grand = parent.Parent;
            if (grand == null)
            {
                return;
            }
            Cat grandCat = grand.Tag as Cat;
            if (grandCat == null)
            {
                return;
            }

            node.Remove();
            grand.Nodes.Add(node);

            curCat.Parent = grandCat.Id;
            parentCat.IsLeaf = parent.Nodes.Count < 1;

            SortCat(parent);
            SortCat(grand);

            TvCat.SelectedNode = node;
        }

        /// <summary>
        /// 下降一级
        /// </summary>
        public void CatDemotion()
        {
            TreeNode node = TvCat.SelectedNode;
            if (node == null || node == _RootNode)
            {
                return;
            }
            Cat curCat = node.Tag as Cat;
            if (curCat == null)
            {
                return;
            }

            TreeNode prev = node.PrevNode;
            if (prev == null || prev == _RootNode)
            {
                return;
            }
            Cat prevCat = prev.Tag as Cat;
            if (prevCat == null)
            {
                return;
            }

            TreeNode parent = node.Parent;
            if (parent == null)
            {
                return;
            }
            node.Remove();
            prev.Nodes.Add(node);

            curCat.Parent = prevCat.Id;
            prevCat.IsLeaf = false;

            SortCat(parent);
            SortCat(prev);

            TvCat.SelectedNode = node;
        }

        public void ChangeIcon(Png png)
        {
            if (!CharUtil.IsValidateHash(png.File))
            {
                png.File = CPwd.DEF_CAT_IMG;
            }
            if (!IlCat.Images.ContainsKey(png.File))
            {
                IlCat.Images.Add(png.File, png.LargeImage);
            }
            _LastNode.ImageKey = png.File;
            _LastNode.SelectedImageKey = png.File;

            Cat cat = _LastNode.Tag as Cat;
            if (cat == null)
            {
                return;
            }

            cat.Icon = png.File;
            _DataModel.SaveVcs(cat);
        }
        #endregion

        #region 事件处理
        private void TvCat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (KeyList == null)
            {
                return;
            }

            Main.LogInfo("TvCatTree_AfterSelect");
            TreeNode node = e.Node;
            if (node == null || node == _LastNode)
            {
                return;
            }
            _LastNode = node;

            Cat cat = node.Tag as Cat;
            if (cat != null && !string.IsNullOrWhiteSpace(cat.Meta))
            {
                string meta = cat.Meta.ToLower();
                // 待提示
                if (meta == CPwd.KEY_TASK)
                {
                    KeyList.ListKeysWithGtd(DateTime.Now, 43200);
                    return;
                }
                // 已过期
                if (meta == CPwd.KEY_TASK_VAL_EXPIRED)
                {
                    KeyList.ListKeysWithGtd(Gtd.CGtd.STATUS_EXPIRED);
                    return;
                }
                // 未过期
                if (meta.StartsWith(CPwd.KEY_TASK_VAR))
                {
                    ProcessGtdMeta(meta.Substring(5));
                    return;
                }
            }

            if (KeyList != null)
            {
                KeyList.ListKeys(node.Name);
            }
        }

        #region 拖拽事件
        private void TvCat_DragDrop(object sender, DragEventArgs e)
        {
            Main.LogInfo("TvCatTree_DragDrop");
            if (_LastDnDNode != null)
            {
                _LastDnDNode.BackColor = Color.Empty;
                _LastDnDNode = null;
            }

            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                SortCat_DragDrop(e);
                return;
            }

            if (e.Data.GetDataPresent(typeof(Key)))
            {
                MoveKey_DragDrop(e);
                return;
            }
        }

        private void TvCat_DragOver(object sender, DragEventArgs e)
        {
            Main.LogInfo("TvCatTree_DragOver");
            if (e.Data.GetDataPresent(typeof(TreeNode)))
            {
                SortCat_DragOver(e);
                return;
            }

            if (e.Data.GetDataPresent(typeof(Key)))
            {
                MoveKey_DragOver(e);
                return;
            }

            e.Effect = DragDropEffects.None;
        }

        private void TvCat_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Main.LogInfo("TvCatTree_ItemDrag");
            if (e.Button == MouseButtons.Left)
            {
                TvCat.DoDragDrop(e.Item, DragDropEffects.All);
            }
        }

        private void SortCat_DragDrop(DragEventArgs e)
        {
            TreeNode srcNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (srcNode == null)
            {
                return;
            }

            Point point = TvCat.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCat.GetNodeAt(point);
            // 同级不可移动
            if (dstNode == null || dstNode == srcNode)
            {
                return;
            }
            // 上一级不可移动
            if (dstNode == srcNode.Parent)
            {
                return;
            }
            // 下级不可移动
            TreeNode tmpNode = dstNode.Parent;
            while (tmpNode != null)
            {
                if (tmpNode == srcNode)
                {
                    return;
                }
                tmpNode = tmpNode.Parent;
            }

            Cat srcCat = srcNode.Tag as Cat;
            if (srcCat == null)
            {
                return;
            }
            Cat dstCat = dstNode.Tag as Cat;
            if (dstCat == null)
            {
                return;
            }
            srcCat.Parent = dstCat.Id;
            dstCat.IsLeaf = false;

            tmpNode = srcNode.Parent;
            srcNode.Remove();
            dstNode.Nodes.Add(srcNode);

            //_DataModel.SaveVcs(dstCat);
            SortCat(tmpNode);
            SortCat(dstNode);
        }

        private void MoveKey_DragDrop(DragEventArgs e)
        {
            Key key = e.Data.GetData(typeof(Key)) as Key;
            if (key == null)
            {
                return;
            }

            Point point = TvCat.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCat.GetNodeAt(point);
            if (dstNode == null)
            {
                return;
            }
            Cat cat = dstNode.Tag as Cat;
            if (cat == null || cat.Id == key.CatId)
            {
                return;
            }

            key.CatId = cat.Id;
            //_DataModel.SaveVcs(key);

            //LastOpt();
        }

        private void SortCat_DragOver(DragEventArgs e)
        {
            if (_LastDnDNode != null)
            {
                _LastDnDNode.BackColor = Color.Empty;
            }
            TreeNode srcNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            if (srcNode == null)
            {
                return;
            }

            Point point = TvCat.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCat.GetNodeAt(point);
            if (dstNode == null || dstNode == srcNode)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            dstNode.BackColor = Color.LightBlue;
            e.Effect = DragDropEffects.Move;
            _LastDnDNode = dstNode;
        }

        private void MoveKey_DragOver(DragEventArgs e)
        {
            if (_LastDnDNode != null)
            {
                _LastDnDNode.BackColor = Color.Empty;
            }
            Key key = e.Data.GetData(typeof(Key)) as Key;
            if (key == null)
            {
                return;
            }

            Point point = TvCat.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCat.GetNodeAt(point);
            if (dstNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            dstNode.BackColor = Color.LightBlue;
            e.Effect = DragDropEffects.Move;
            _LastDnDNode = dstNode;
        }
        #endregion
        #endregion

        private void ProcessGtdMeta(string meta)
        {
            Match match = Regex.Match(meta, "^\\d+");
            if (!match.Success)
            {
                return;
            }

            meta = meta.Substring(match.Value.Length);
            int tmp = int.Parse(match.Value);
            DateTime now = DateTime.Now;
            DateTime end;
            switch (meta)
            {
                case "second":
                    end = now.AddSeconds(tmp);
                    break;
                case "minute":
                    end = now.AddMinutes(tmp);
                    break;
                case "hour":
                    end = now.AddHours(tmp);
                    break;
                case "day":
                    end = now.AddDays(tmp);
                    break;
                case "week":
                    end = now.AddDays(tmp * 7);
                    break;
                case "month":
                    end = now.AddMonths(tmp);
                    break;
                case "year":
                    end = now.AddYears(tmp);
                    break;
                default:
                    return;
            }

            KeyList.ListKeysWithGtd(now, (int)Math.Ceiling((end - now).TotalSeconds));
        }

        private void SortCat(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Cat cat;
            foreach (TreeNode node in root.Nodes)
            {
                cat = node.Tag as Cat;
                if (cat == null)
                {
                    continue;
                }
                cat.Order = node.Index;
                _DataModel.SaveVcs(cat);
            }
        }

        /// <summary>
        /// 类别视图初始化
        /// </summary>
        private void DoInitCat(TreeNode root)
        {
            foreach (Cat cat in _DataModel.ListCat(CApp.IAPP_APWD, root.Name))
            {
                TreeNode node = new TreeNode();
                node.Name = cat.Id;
                node.Text = cat.Text;
                node.ToolTipText = cat.Tips;
                node.Tag = cat;
                if (CharUtil.IsValidateHash(cat.Icon))
                {
                    IlCat.Images.Add(cat.Icon, BeanUtil.ReadImage(Path.Combine(_DataModel.CatDir, cat.Icon + ".png"), BeanUtil.NaN16));
                    node.ImageKey = cat.Icon;
                }
                else
                {
                    node.ImageKey = CPwd.DEF_CAT_IMG;
                }
                node.SelectedImageKey = node.ImageKey;

                root.Nodes.Add(node);
                if (!cat.IsLeaf)
                {
                    DoInitCat(node);
                }

                if (cat.Meta == CPwd.KEY_TASK)
                {
                    _TaskNode = node;
                    continue;
                }
                if (cat.Meta == CPwd.KEY_TASK_VAL_EXPIRED)
                {
                    _TaskExpiredNode = node;
                    continue;
                }
            }
        }
    }
}
