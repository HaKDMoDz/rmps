using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Auth;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Properties;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
using Me.Amon.Pwd._Lib;
using Me.Amon.Pwd._Log;
using Me.Amon.Pwd.V.Pro;
using Me.Amon.Pwd.V.Wiz;
using Me.Amon.Uc;
using Me.Amon.Util;
using Me.Amon.Uw;
using Thought.vCards;

namespace Me.Amon.Pwd
{
    public partial class APwd : UserControl, IApp, IAmon
    {
        #region 全局变量
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private TreeNode _RootNode;
        private TreeNode _LastNode;
        private string _LastHash;
        private string _LastMeta;
        private bool _IsSearch;
        private IPwd _PwdView;
        private APro _ProView;
        private AWiz _WizView;
        //private APad _PadView;
        private Dictionary<string, Image> _KeyIcon;
        private Dictionary<string, Image> _KeyHint;
        private XmlMenu<APwd> _XmlMenu;
        #endregion
        private Main _Main;

        #region 构造函数
        public APwd()
        {
            InitializeComponent();
        }

        public APwd(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }

        public void Init(Main main)
        {
            _Main = main;

            #region 数据模型
            _SafeModel = new SafeModel(_UserModel);
            _SafeModel.Init();
            _DataModel = new DataModel(_UserModel);
            _DataModel.Init();
            _ViewModel = new ViewModel(_UserModel);
            _ViewModel.Load();
            UdcModel udcModel = new UdcModel();
            udcModel.Init(_UserModel);
            _DataModel.UdcModel = udcModel;
            #endregion

            #region 系统选单
            _XmlMenu = new XmlMenu<APwd>(this, _ViewModel);
            if (_XmlMenu.Load(Path.Combine(_UserModel.Home, EPwd.XML_MENU)))
            {
                _XmlMenu.GetStrokes("APwd");
                _XmlMenu.GetMenuBar("APwd", MbMenu);
                _XmlMenu.GetToolBar("APwd", TbTool);
                _XmlMenu.GetPopMenu("ACat", CmCat);
                _XmlMenu.GetPopMenu("AKey", CmKey);
                //_XmlMenu.GetPopMenu("AAtt", CmAtt);
            }
            #endregion

            InitCat();
            InitKey();
            FbFind.APwd = this;

            // 当前时间
            UcTime.Start();

            // 视图模式
            switch (_ViewModel.Pattern)
            {
                case EPwd.PATTERN_PRO:
                    ShowAPro();
                    break;
                case EPwd.PATTERN_WIZ:
                    ShowAWiz();
                    break;
                case EPwd.PATTERN_PAD:
                    ShowAPad();
                    break;
                default:
                    break;
            }

            _Main.FormBorderStyle = FormBorderStyle.Sizable;
            _Main.KeyPreview = true;
            _Main.MainMenuStrip = this.MbMenu;
            _Main.MaximizeBox = true;

            LoadLayout();
        }
        #endregion

        #region 接口实现
        public int AppId { get; set; }


        public Form Form
        {
            get { return _Main; }
        }

        public Icon Icon { get; set; }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            TssEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            TssEcho.Text = message;
        }

        public bool WillExit()
        {
            if (_SafeModel.Modified)
            {
                return DialogResult.Yes == Main.ShowConfirm("您有数据尚未保存，确认要退出窗口吗？");
            }
            return true;
        }

        public bool SaveData()
        {
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), EApp.DIR_BACK);
            if (Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path, _UserModel.Code + "*.apbak", SearchOption.TopDirectoryOnly);
                if (files.Length >= 3)
                {
                    Array.Sort(files);
                    for (int i = files.Length - 3; i >= 0; i -= 1)
                    {
                        File.Delete(files[i]);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }

            string file = _UserModel.Code + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".apbak";
            DoBackup(Path.Combine(path, file));
            return true;
        }
        #endregion

        #region 事件处理
        #region CatTree拖拽事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvCatTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Main.LogInfo("TvCatTree_AfterSelect");
            TreeNode node = e.Node;
            if (node == null || node == _LastNode)
            {
                return;
            }

            ListKey(node.Name);
            _LastNode = node;
        }

        private void TvCatTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            Main.LogInfo("TvCatTree_ItemDrag");
            if (e.Button == MouseButtons.Left)
            {
                TvCatTree.DoDragDrop(e.Item, DragDropEffects.All);
            }
        }

        private void TvCatTree_DragDrop(object sender, DragEventArgs e)
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

        private void SortCat_DragDrop(DragEventArgs e)
        {
            TreeNode srcNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;
            if (srcNode == null)
            {
                return;
            }

            Point point = TvCatTree.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCatTree.GetNodeAt(point);
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

            _UserModel.DBA.SaveVcs(dstCat);
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

            Point point = TvCatTree.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCatTree.GetNodeAt(point);
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
            _UserModel.DBA.SaveVcs(key);

            LastOpt();
        }

        private void TvCatTree_DragOver(object sender, DragEventArgs e)
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

            Point point = TvCatTree.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCatTree.GetNodeAt(point);
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

            Point point = TvCatTree.PointToClient(new Point(e.X, e.Y));
            TreeNode dstNode = TvCatTree.GetNodeAt(point);
            if (dstNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            dstNode.BackColor = Color.LightBlue;
            e.Effect = DragDropEffects.Move;
            _LastDnDNode = dstNode;
        }
        private TreeNode _LastDnDNode;
        #endregion

        #region KeyList拖拽事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbKeyList_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index <= -1 || e.Index >= LbKeyList.Items.Count)
            {
                return;
            }
            Key rec = LbKeyList.Items[e.Index] as Key;
            if (rec == null)
            {
                return;
            }

            Image img = _KeyIcon.ContainsKey(rec.IcoName) ? _KeyIcon[rec.IcoName] : BeanUtil.NaN24;
            e.Graphics.DrawImage(img, e.Bounds.X + 3, e.Bounds.Y + 3, img.Width, img.Height);

            //最后把要显示的文字画在背景图片上
            int y = e.Bounds.Y + 2;
            e.Graphics.DrawString(rec.Title, this.Font, Brushes.Black, e.Bounds.X + 36, y);

            y = e.Bounds.Y + e.Bounds.Height;
            e.Graphics.DrawString(rec.AccessTime, this.Font, Brushes.Gray, e.Bounds.X + 36, y - 14);

            int x = e.Bounds.X + e.Bounds.Width;
            y -= 16;
            img = _KeyHint.ContainsKey(rec.GtdId) ? _KeyHint[rec.GtdId] : BeanUtil.NaN16;
            e.Graphics.DrawImage(img, x - 48, y);
            img = _ViewModel.GetImage(EPwd.KEY_LABEL + rec.Label);
            if (img != null)
            {
                e.Graphics.DrawImage(img, x - 32, y);
            }
            img = _ViewModel.GetImage(EPwd.KEY_MAJOR + (rec.Major + 2));
            if (img != null)
            {
                e.Graphics.DrawImage(img, x - 16, y);
            }
        }

        private void LbKeyList_MouseDown(object sender, MouseEventArgs e)
        {
            Main.LogInfo("LbKeyList_MouseDown");
            //int idx = LbKeyList.SelectedIndex;
            //if (idx < 0 || idx != LbKeyList.IndexFromPoint(e.X, e.Y))
            //{
            //    return;
            //}

            //////LbKeyList.SelectedIndex = idx;
            //Key key = LbKeyList.SelectedItem as Key;
            //if (key != null)
            //{
            //    //LbKeyList.DoDragDrop(key, DragDropEffects.All);
            //}
        }

        private void LbKeyList_DragDrop(object sender, DragEventArgs e)
        {
            Main.LogInfo("LbKeyList_DragDrop");
            //Point point = LbKeyList.PointToClient(new Point(e.X, e.Y));
            //int idx = LbKeyList.IndexFromPoint(point);
            //if (idx < 0)
            //{
            //    return;
            //}

            //LbKeyList.SelectedIndex = idx;
        }

        private void LbKeyList_DragEnter(object sender, DragEventArgs e)
        {
            Main.LogInfo("LbKeyList_DragEnter");
        }

        private void LbKeyList_DragOver(object sender, DragEventArgs e)
        {
            Main.LogInfo("LbKeyList_DragOver");
            //Type type = typeof(Key);
            //if (!e.Data.GetDataPresent(type))
            //{
            //    e.Effect = DragDropEffects.None;
            //    return;
            //}
            //Key srcObj = e.Data.GetData(type) as Key;

            //Point point = LbKeyList.PointToClient(new Point(e.X, e.Y));
            //int idx = LbKeyList.IndexFromPoint(point);
            e.Effect = DragDropEffects.Move;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbKeyList_MouseUp(object sender, MouseEventArgs e)
        {
            Main.LogInfo("LbKeyList_MouseUp");
            if (e.Button != MouseButtons.Right)
            {
                return;
            }
            int idx = LbKeyList.IndexFromPoint(e.Location);
            if (idx >= LbKeyList.Items.Count)
            {
                return;
            }
            if (LbKeyList.SelectedIndex != idx)
            {
                if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您当前的数据尚未保存，要丢弃吗？"))
                {
                    return;
                }

                _SafeModel.Modified = false;
                LbKeyList.SelectedIndex = idx;
            }
            CmKey.Show(LbKeyList, e.Location);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbKeyList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Main.LogInfo("LbKeyList_SelectedIndexChanged");
            Key key = LbKeyList.SelectedItem as Key;
            if (key == null || _SafeModel.Key == key)
            {
                return;
            }

            if (!CharUtil.IsValidateHash(key.Id))
            {
                Main.ShowAlert("系统异常，请稍后重试！");
                return;
            }

            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您当前的数据尚未保存，要丢弃吗？"))
            {
                LbKeyList.SelectedItem = _SafeModel.Key;
                return;
            }

            _SafeModel.Key = key;
            _SafeModel.Decode();

            ShowKey(key);
        }
        #endregion

        /// <summary>
        /// 时钟信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcTime_Tick(object sender, EventArgs e)
        {
            TssTime.Text = DateTime.Now.ToString(EApp.DATEIME_FORMAT);
        }

        /// <summary>
        /// 窗口快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APwd_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (KeyStroke<APwd> stroke in _XmlMenu.KeyStrokes)
            {
                if (stroke.Action == null ||
                    e.Control ^ stroke.Control ||
                    e.Shift ^ stroke.Shift ||
                    e.Alt ^ stroke.Alt ||
                    e.KeyCode != stroke.Code)
                {
                    continue;
                }

                stroke.Action.EventHandler(stroke, null);
                e.Handled = true;
                break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            HideForm();
        }
        #endregion

        #region 公共函数
        #region 公共方法
        public ToolStripMenuItem GetMenuItem(string key)
        {
            if (_XmlMenu != null)
            {
                return _XmlMenu.GetMenuItem(key);
            }
            return null;
        }

        public ToolStripButton GetToolItem(string key)
        {
            if (_XmlMenu != null)
            {
                return _XmlMenu.GetToolItem(key);
            }
            return null;
        }

        public ItemGroup GetItemGroup(string key)
        {
            if (_XmlMenu != null)
            {
                return _XmlMenu.GetGroup(key);
            }
            return null;
        }

        public void ChangeView(UserControl uc)
        {
            uc.Dock = DockStyle.Fill;
            uc.Location = new Point(3, 35);
            uc.Size = new Size(350, 296);
            uc.TabIndex = 0;

            HSplit.Panel2.Controls.Clear();
            HSplit.Panel2.Controls.Add(uc);
        }

        public void ShowIcoSeeker(string rootDir, AmonHandler<Png> handler)
        {
            KeyIcon seeker = new KeyIcon(_UserModel, rootDir);
            seeker.IcoSize = 24;
            seeker.CallBackHandler = handler;
            BeanUtil.CenterToParent(seeker, _Main);
            seeker.ShowDialog(this);
        }

        public void ShowPngSeeker()
        {
        }

        public void Backup()
        {
        }

        public void Backup(Key rec)
        {
        }

        public void Resuma()
        {
        }

        public void Resuma(KeyLog log)
        {
        }

        public void ShowKey(Key key)
        {
            if (key == null)
            {
                return;
            }
            _PwdView.ShowData();

            ItemGroup group = _XmlMenu.GetGroup(EPwd.KEY_LABEL);
            if (group != null)
            {
                group.Checked(key.Label.ToString());
            }
            group = _XmlMenu.GetGroup(EPwd.KEY_MAJOR);
            if (group != null)
            {
                group.Checked(key.Major.ToString());
            }
        }
        #endregion

        #region 类别处理
        /// <summary>
        /// 获取选择的类别
        /// </summary>
        /// <param name="cat"></param>
        public Cat SelectedCat
        {
            get
            {
                TreeNode node = TvCatTree.SelectedNode;
                return node != null ? node.Tag as Cat : null;
            }
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="cat"></param>
        public void AppendCat(Cat cat)
        {
            if (cat == null || _LastNode == null)
            {
                return;
            }
            Cat parent = SelectedCat;
            if (parent == null)
            {
                return;
            }

            cat.Parent = parent.Id;
            cat.Order = _LastNode.Nodes.Count;
            _UserModel.DBA.SaveVcs(cat);
            if (parent.IsLeaf)
            {
                parent.IsLeaf = false;
                _UserModel.DBA.SaveVcs(parent);
            }

            TreeNode node = new TreeNode();
            node.Name = cat.Id;
            node.Text = cat.Text;
            node.ToolTipText = cat.Tips;
            node.Tag = cat;
            if (CharUtil.IsValidateHash(cat.Icon))
            {
                node.ImageKey = cat.Icon;
            }
            node.SelectedImageKey = node.ImageKey;
            _LastNode.Nodes.Add(node);
            _LastNode.Expand();
        }

        /// <summary>
        /// 更新类别
        /// </summary>
        /// <param name="cat"></param>
        public void UpdateCat(Cat cat)
        {
            if (cat == null)
            {
                return;
            }

            Cat cur = SelectedCat;
            if (cur == null)
            {
                Main.ShowAlert("请选择您要更新的类别！");
                TvCatTree.Focus();
                return;
            }

            if (cur.Id == EPwd.DEF_CAT_ID)
            {
                return;
            }

            cur.Text = cat.Text;
            cur.Tips = cat.Tips;
            cur.Memo = cat.Memo;
            _UserModel.DBA.SaveVcs(cur);

            _LastNode.Text = cat.Text;
            _LastNode.ToolTipText = cat.Tips;
        }

        public void DeleteCat()
        {
            Cat cat = SelectedCat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要删除的类别！");
                TvCatTree.Focus();
                return;
            }

            if (cat.Id == EPwd.DEF_CAT_ID)
            {
                return;
            }

            if (_LastNode.Nodes.Count > 0)
            {
                Main.ShowAlert("下级类别不为空，不能删除！");
                return;
            }

            if (DialogResult.Yes != Main.ShowConfirm("确认要删除选中的类别吗，此操作将不可恢复？"))
            {
                return;
            }

            IList<Key> keys = _UserModel.DBA.ListKey(cat.Id);
            if (keys.Count > 0)
            {
                Main.ShowAlert("类别数据不为空，不能删除！");
                return;
            }

            _UserModel.DBA.DeleteVcs(cat);

            TreeNode parent = _LastNode.Parent;
            if (parent != null)
            {
                parent.Nodes.Remove(_LastNode);
            }

            cat = parent.Tag as Cat;
            if (cat != null && !cat.IsLeaf && parent.Nodes.Count == 0)
            {
                cat.IsLeaf = true;
                _UserModel.DBA.SaveVcs(cat);
            }
        }

        public void CatMoveUp()
        {
            Cat currCat = SelectedCat;
            if (currCat == null || currCat.Id == EPwd.DEF_CAT_ID)
            {
                return;
            }

            TreeNode prevNode = _LastNode.PrevNode;
            if (prevNode == null)
            {
                return;
            }

            Cat prevCat = prevNode.Tag as Cat;
            if (prevCat == null || prevCat.Id == EPwd.DEF_CAT_ID)
            {
                return;
            }

            TreeNode parent = _LastNode.Parent;
            if (parent == null)
            {
                return;
            }

            prevCat.Order += 1;
            _UserModel.DBA.SaveVcs(prevCat);
            currCat.Order -= 1;
            _UserModel.DBA.SaveVcs(currCat);

            TvCatTree.SelectedNode = null;
            parent.Nodes.Remove(_LastNode);
            parent.Nodes.Insert(prevNode.Index, _LastNode);
            TvCatTree.SelectedNode = _LastNode;
        }

        public void CatMoveDown()
        {
            Cat currCat = SelectedCat;
            if (currCat == null || currCat.Id == EPwd.DEF_CAT_ID)
            {
                return;
            }

            TreeNode nextNode = _LastNode.NextNode;
            if (nextNode == null)
            {
                return;
            }

            Cat nextCat = nextNode.Tag as Cat;
            if (nextCat == null || nextCat.Id == EPwd.DEF_CAT_ID)
            {
                return;
            }

            TreeNode parent = _LastNode.Parent;
            if (parent == null)
            {
                return;
            }

            currCat.Order += 1;
            _UserModel.DBA.SaveVcs(currCat);
            nextCat.Order -= 1;
            _UserModel.DBA.SaveVcs(nextCat);

            TvCatTree.SelectedNode = null;
            parent.Nodes.Remove(_LastNode);
            parent.Nodes.Insert(nextNode.Index + 1, _LastNode);
            TvCatTree.SelectedNode = _LastNode;
        }

        /// <summary>
        /// 提升一级
        /// </summary>
        public void CatPromotion()
        {
            TreeNode node = TvCatTree.SelectedNode;
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

            TvCatTree.SelectedNode = node;
        }

        /// <summary>
        /// 下降一级
        /// </summary>
        public void CatDemotion()
        {
            TreeNode node = TvCatTree.SelectedNode;
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

            TvCatTree.SelectedNode = node;
        }

        public void ChangeCatIcon()
        {
            CatIcon editor = new CatIcon(_UserModel, _DataModel.CatDir);
            editor.InitOnce(16);
            editor.CallBackHandler = new AmonHandler<Png>(ChangeCatIcon);
            BeanUtil.CenterToParent(editor, _Main);
            editor.ShowDialog(this);
        }

        public void ChangeCatIcon(Png png)
        {
            if (!CharUtil.IsValidateHash(png.File))
            {
                png.File = EPwd.DEF_CAT_IMG;
            }
            if (!IlCatTree.Images.ContainsKey(png.File))
            {
                IlCatTree.Images.Add(png.File, png.LargeImage);
            }
            _LastNode.ImageKey = png.File;
            _LastNode.SelectedImageKey = png.File;

            Cat cat = _LastNode.Tag as Cat;
            if (cat == null)
            {
                return;
            }

            cat.Icon = png.File;
            _UserModel.DBA.SaveVcs(cat);
        }
        #endregion

        #region 记录处理
        /// <summary>
        /// 新增记录
        /// </summary>
        public void NewKey()
        {
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            _PwdView.AppendKey();
        }

        /// <summary>
        /// 更新记录
        /// </summary>
        public void SaveKey()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }

            if (!_SafeModel.IsUpdate)
            {
                if (NavPaneVisible && CatTreeVisible)
                {
                    Cat cat = SelectedCat;
                    if (cat == null)
                    {
                        Main.ShowAlert("请选择类别！");
                        TvCatTree.Focus();
                        return;
                    }

                    _SafeModel.Key.CatId = cat.Id;
                }
                else
                {
                    _SafeModel.Key.CatId = EPwd.DEF_CAT_ID;
                }
            }

            if (!_PwdView.UpdateKey())
            {
                return;
            }

            if (_SafeModel.IsUpdate && _SafeModel.Key.Backup)
            {
                KeyLog keyLog = _SafeModel.Key.ToLog();
                _UserModel.DBA.SaveLog(keyLog);
            }
            _SafeModel.Encode();
            _SafeModel.Key.AccessTime = DateTime.Now.ToString(EApp.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
            _SafeModel.Modified = false;

            _PwdView.ShowInfo();

            if (_SafeModel.IsUpdate)
            {
                Key key = LbKeyList.SelectedItem as Key;
                if (key != null && _SafeModel.Key == key)
                {
                    LbKeyList.Items[LbKeyList.SelectedIndex] = _SafeModel.Key;
                }
            }
            else
            {
                LastOpt();
            }

            if (!_KeyIcon.ContainsKey(_SafeModel.Key.IcoName))
            {
                string path;
                if (CharUtil.IsValidateHash(_SafeModel.Key.IcoPath))
                {
                    path = Path.Combine(_DataModel.KeyDir, _SafeModel.Key.IcoPath, _SafeModel.Key.IcoName + EApp.IMG_KEY_LIST_EXT);
                }
                else
                {
                    path = Path.Combine(_DataModel.KeyDir, _SafeModel.Key.IcoName + EApp.IMG_KEY_LIST_EXT);
                }
                _KeyIcon.Add(_SafeModel.Key.IcoName, BeanUtil.ReadImage(path, BeanUtil.NaN24));
            }

            _SafeModel.Key = null;
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        public void DeleteKey()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }

            if (DialogResult.Yes != Main.ShowConfirm("确认要删除选中的记录吗，此操作将不可恢复？"))
            {
                return;
            }

            if (DialogResult.No != Main.ShowConfirm("再次确认，要返回吗？"))
            {
                return;
            }

            LbKeyList.Items.RemoveAt(LbKeyList.SelectedIndex);

            _UserModel.DBA.RemoveVcs(_SafeModel.Key);
            _SafeModel.Modified = false;
            _SafeModel.Key = null;
            _PwdView.ShowInfo();
        }

        public void ListKey(string catId)
        {
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = EPwd.DEF_CAT_ID;
            }

            DoListKey(catId);

            _IsSearch = false;
            _LastHash = catId;
        }

        public void FindKey(string meta)
        {
            if (!CharUtil.IsValidate(meta))
            {
                TvCatTree.SelectedNode = _LastNode;
                ListKey(_LastNode.Name);
                return;
            }

            meta = Regex.Replace(meta, "[+＋\\s]+", " ");
            if (string.IsNullOrEmpty(meta))
            {
                Main.ShowAlert("您输入的查询条件无效！");
                return;
            }

            TvCatTree.SelectedNode = null;

            DoFindKey(meta);

            _IsSearch = true;
            _LastMeta = meta;
        }

        public void LastOpt()
        {
            if (_IsSearch)
            {
                DoFindKey(_LastMeta);
            }
            else
            {
                DoListKey(_LastHash);
            }
        }

        /// <summary>
        /// 修改当前口令的类别为指定类别
        /// </summary>
        /// <param name="catId"></param>
        public void ChangeKeyCat(string catId)
        {
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = EPwd.DEF_CAT_ID;
            }
            if (catId == _SafeModel.Key.CatId)
            {
                return;
            }

            _SafeModel.Key.CatId = catId;
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            Key key = LbKeyList.SelectedItem as Key;
            if (key == null || key.Id != _SafeModel.Key.Id)
            {
                return;
            }
            LbKeyList.Items.RemoveAt(LbKeyList.SelectedIndex);
        }

        /// <summary>
        /// 修改当前口令的标签为指定标签
        /// </summary>
        /// <param name="label"></param>
        public void ChangeKeyLabel(int label)
        {
            if (_SafeModel.Key == null || label < 0 || label > 9)
            {
                return;
            }

            _SafeModel.Key.Label = label;
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LbKeyList.Refresh();
        }

        /// <summary>
        /// 修改当前口令的重要程度为指定级别
        /// </summary>
        /// <param name="major"></param>
        public void ChangeKeyMajor(int major)
        {
            if (_SafeModel.Key == null || major < -2 || major > 2)
            {
                return;
            }

            _SafeModel.Key.Major = major;
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LbKeyList.Refresh();
        }

        public void KeyMoveto()
        {
            CatTree view = new CatTree(_UserModel);
            view.Init(IlCatTree);
            view.CallBack = new AmonHandler<string>(ChangeKeyCat);
            BeanUtil.CenterToParent(view, _Main);
            view.ShowDialog(this);
        }

        public void KeyHistory()
        {
            if (_SafeModel.Key == null)
            {
                return;
            }
            LogEdit edit = new LogEdit(this);
            edit.Init(_UserModel, _SafeModel);
            BeanUtil.CenterToParent(edit, _Main);
            edit.Show(this);
        }
        #endregion

        #region 属性处理
        public void AppendAtt(int att)
        {
            _PwdView.AppendAtt(att);
        }

        public void ChangeAtt(int att)
        {
            _PwdView.ChangeAtt(att);
        }

        public void UpdateAtt()
        {
            _PwdView.SaveAtt();
        }

        public void DeleteAtt()
        {
            _PwdView.DropAtt();
        }

        public void AttCut()
        {
            if (_PwdView != null)
            {
                _PwdView.CutAtt();
            }
        }

        public void AttCopy()
        {
            if (_PwdView != null)
            {
                _PwdView.CopyAtt();
            }
        }

        public void AttPaste()
        {
            if (_PwdView != null)
            {
                _PwdView.PasteAtt();
            }
        }

        public void AttClear()
        {
            if (_PwdView != null)
            {
                _PwdView.ClearAtt();
            }
        }

        public void AttSelectPrev()
        {
            if (_PwdView != null)
            {
                _PwdView.SelectPrev();
            }
        }

        public void AttSelectNext()
        {
            if (_PwdView != null)
            {
                _PwdView.SelectNext();
            }
        }

        public void AttMoveUp()
        {
            if (_PwdView != null)
            {
                _PwdView.MoveUp();
            }
        }

        public void AttMoveDown()
        {
            if (_PwdView != null)
            {
                _PwdView.MoveDown();
            }
        }
        #endregion

        #region 文件选单
        public void LockForm()
        {
            new AuthLs(_UserModel, _Main).ShowDialog(this);
        }

        public bool HideForm()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes != Main.ShowConfirm("您有数据尚未保存，确认要隐藏窗口吗？"))
                {
                    return false;
                }
            }

            SaveLayout();
            return true;
        }

        public bool ExitForm()
        {
            SaveLayout();

            Settings.Default.LocX = _Main.Location.X;
            Settings.Default.LocY = _Main.Location.Y;
            Settings.Default.Save();

            return false;
        }
        #endregion

        #region 编辑选单
        #endregion

        #region 视图选单
        #region 模式切换
        /// <summary>
        /// 专业模式
        /// </summary>
        public void ShowAPro()
        {
            if (_ProView == null)
            {
                _ProView = new APro();
                _ProView.Name = EPwd.PATTERN_PRO;
                _ProView.Init(this, _SafeModel, _DataModel, _ViewModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Name == _ProView.Name)
                {
                    return;
                }
                _PwdView.HideView(PlBody);
            }

            _PwdView = _ProView;
            _PwdView.InitView(PlBody);
            ShowKey(_SafeModel.Key);
        }

        /// <summary>
        /// 向导模式
        /// </summary>
        public void ShowAWiz()
        {
            if (_WizView == null)
            {
                _WizView = new AWiz();
                _WizView.Name = EPwd.PATTERN_WIZ;
                _WizView.Init(this, _SafeModel, _DataModel, _ViewModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Name == _WizView.Name)
                {
                    return;
                }
                _PwdView.HideView(PlBody);
            }

            _PwdView = _WizView;
            _PwdView.InitView(PlBody);
            ShowKey(_SafeModel.Key);
        }

        /// <summary>
        /// 记事模式
        /// </summary>
        public void ShowAPad()
        {
            //if (_PadView == null)
            //{
            //    _PadView = new APad();
            //    _PadView.Name = EPwd.PATTERN_PAD;
            //    _PadView.Init(this, _SafeModel, _DataModel);
            //}

            //if (_PwdView != null)
            //{
            //    if (_PwdView.Name == _PadView.Name)
            //    {
            //        return;
            //    }
            //    _PwdView.HideView(TpGrid);
            //}

            //_PwdView = _PadView;
            //_PwdView.InitView(TpGrid);

            //TmiViewPro.Checked = false;
            //TmiViewWiz.Checked = false;
            //TmiViewPad.Checked = true;
        }
        #endregion

        #region 布局调整
        /// <summary>
        /// 选单栏是否可见
        /// </summary>
        public bool MenuBarVisible
        {
            get
            {
                return MbMenu.Visible;
            }
            set
            {
                MbMenu.Visible = value;
                _ViewModel.MenuBarVisible = value;
            }
        }

        /// <summary>
        /// 工具栏是否可见
        /// </summary>
        public bool ToolBarVisible
        {
            get
            {
                return TbTool.Visible;
            }
            set
            {
                TbTool.Visible = value;
                _ViewModel.ToolBarVisible = value;
            }
        }

        /// <summary>
        /// 状态栏是否可见
        /// </summary>
        public bool EchoBarVisible
        {
            get
            {
                return SsEcho.Visible;
            }
            set
            {
                SsEcho.Visible = value;
                _ViewModel.EchoBarVisible = value;
            }
        }

        /// <summary>
        /// 搜索栏是否可见
        /// </summary>
        public bool FindBarVisible
        {
            get
            {
                return FbFind.Visible;
            }
            set
            {
                FbFind.Visible = value;
                _ViewModel.FindBarVisible = value;
            }
        }

        /// <summary>
        /// 导航面板是否可见
        /// </summary>
        public bool NavPaneVisible
        {
            get
            {
                return !HSplit.Panel1Collapsed;
            }
            set
            {
                HSplit.Panel1Collapsed = !value;
                _ViewModel.NavPaneVisible = value;
            }
        }

        /// <summary>
        /// 类别目录是否可见
        /// </summary>
        public bool CatTreeVisible
        {
            get
            {
                return !VSplit.Panel1Collapsed;
            }
            set
            {
                if (!value && VSplit.Panel2Collapsed)
                {
                    NavPaneVisible = false;
                }
                else
                {
                    VSplit.Panel1Collapsed = !value;
                    _ViewModel.CatTreeVisible = value;
                }
            }
        }

        /// <summary>
        /// 口令列表是否可见
        /// </summary>
        public bool KeyListVisible
        {
            get
            {
                return !VSplit.Panel2Collapsed;
            }
            set
            {
                if (!value && VSplit.Panel1Collapsed)
                {
                    NavPaneVisible = false;
                }
                else
                {
                    VSplit.Panel2Collapsed = !value;
                    _ViewModel.KeyListVisible = value;
                }
            }
        }
        #endregion
        #endregion

        #region 数据选单
        /// <summary>
        /// 查找
        /// </summary>
        public void ShowFind()
        {
            if (!FbFind.Visible)
            {
                FbFind.Visible = true;
            }

            FbFind.Focus();
        }

        /// <summary>
        /// 同步
        /// </summary>
        public void SyncData()
        {
            MessageBox.Show("同步功能尚在完善中，敬请期待！");
        }

        /// <summary>
        /// 本地备份
        /// </summary>
        public void NativeBackup()
        {
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            _LastNode = null;
            TvCatTree.SelectedNode = null;
            LbKeyList.Items.Clear();

            if (DialogResult.OK != Main.ShowSaveFileDialog(this, "密码箱备份文件|*.apbak", ""))
            {
                return;
            }
            DoBackup(Main.SaveFileDialog.FileName);
        }

        /// <summary>
        /// 本地恢复
        /// </summary>
        public void NativeResume()
        {
            Main.ShowAlert("本地恢复功能尚在完善中，敬请期待！");
        }

        public void NativeConfig()
        {
            Main.ShowAlert("本地配置功能尚在完善中，敬请期待！");
        }

        /// <summary>
        /// 远程备份
        /// </summary>
        public void RemoteBackup()
        {
            Main.ShowAlert("远程备份功能尚在完善中，敬请期待！");
        }

        /// <summary>
        /// 远程恢复
        /// </summary>
        public void RemoteResume()
        {
            Main.ShowAlert("远程恢复功能尚在完善中，敬请期待！");
        }

        public void RemoteConfig()
        {
            Main.ShowAlert("远程配置功能尚在完善中，敬请期待！");
        }

        #region 数据导出
        /// <summary>
        /// 导出为TXT
        /// </summary>
        public void ExportTxt()
        {
            if (_SafeModel.Modified && DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
            {
                return;
            }

            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                Main.ShowAlert("请选择您要导出的类别！");
                TvCatTree.Focus();
                return;
            }
            Cat cat = node.Tag as Cat;
            if (cat == null)
            {
                return;
            }

            IList<Key> keys = _UserModel.DBA.ListKey(cat.Id);
            if (keys.Count < 1)
            {
                Main.ShowAlert("当前类别下没有记录！");
                TvCatTree.Focus();
                return;
            }

            if (DialogResult.OK != Main.ShowSaveFileDialog(this, "文件|*.aptxt", ""))
            {
                return;
            }
            string file = Main.SaveFileDialog.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(file, false))
            {
                writer.WriteLine("APwd-2");
                StringBuilder buffer = new StringBuilder();
                foreach (Key key in keys)
                {
                    _SafeModel.Key = key;
                    _SafeModel.Decode();
                    _SafeModel.ExportAsTxt(buffer);
                    buffer.Append(Environment.NewLine);
                }
                writer.Write(buffer.ToString());

                writer.Close();
            }
        }

        /// <summary>
        /// 导出为XML
        /// </summary>
        public void ExportXml()
        {
            if (_SafeModel.Modified && DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
            {
                return;
            }

            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                Main.ShowAlert("请选择您要导出的类别！");
                TvCatTree.Focus();
                return;
            }
            Cat cat = node.Tag as Cat;
            if (cat == null)
            {
                return;
            }

            IList<Key> keys = _UserModel.DBA.ListKey(cat.Id);
            if (keys.Count < 1)
            {
                Main.ShowAlert("当前类别下没有记录！");
                TvCatTree.Focus();
                return;
            }

            if (DialogResult.OK != Main.ShowSaveFileDialog(this, "文件|*.apxml", ""))
            {
                return;
            }
            string file = Main.SaveFileDialog.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (StreamWriter stream = new StreamWriter(file, false))
            {
                using (XmlWriter writer = XmlWriter.Create(stream))
                {
                    writer.WriteStartElement("Amon");
                    writer.WriteElementString("App", "APwd");
                    writer.WriteElementString("Ver", "2");
                    writer.WriteStartElement("Keys");
                    foreach (Key key in keys)
                    {
                        _SafeModel.Key = key;
                        _SafeModel.Decode();
                        _SafeModel.ExportAsXml(writer);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.Flush();
                }

                stream.Close();
            }
        }
        #endregion

        #region 数据导入
        /// <summary>
        /// 导入TXT数据
        /// </summary>
        public void ImportTxt()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            Cat cat = _LastNode.Tag as Cat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要导入的类别！");
                TvCatTree.Focus();
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, "文件|*.aptxt", "", false))
            {
                return;
            }
            string file = Main.OpenFileDialog.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            int suc = 0;
            int err = 0;
            using (StreamReader reader = File.OpenText(file))
            {
                // 版本判断
                string ver = reader.ReadLine();
                if ("APwd-1" != ver && "APwd-2" != ver)
                {
                    Main.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (!_SafeModel.ImportByTxt(line, ver.Substring(5)))
                        {
                            err += 1;
                            continue;
                        }

                        _SafeModel.Key.CatId = cat.Id;
                        DoImportKey();
                        suc += 1;
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            DoListKey(cat.Id);
            _SafeModel.Key = null;

            Main.ShowAlert(string.Format("数据导入结果：{0}成功，{1}失败！", suc, err));
        }

        /// <summary>
        /// 导入XML数据
        /// </summary>
        public void ImportXml()
        {
            if (_SafeModel.Modified && DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
            {
                return;
            }

            Cat cat = _LastNode.Tag as Cat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要导入的类别！");
                TvCatTree.Focus();
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, "文件|*.apxml", "", false))
            {
                return;
            }
            string file = Main.OpenFileDialog.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            StreamReader stream = File.OpenText(file);
            XmlReader reader = XmlReader.Create(stream, new XmlReaderSettings { IgnoreComments = true, IgnoreWhitespace = true });
            if (!reader.ReadToFollowing("App") || reader.ReadElementContentAsString() != "APwd")
            {
                Main.ShowAlert("未知的文件格式，无法进行导入处理！");
                return;
            }
            if (reader.Name != "Ver" && !reader.ReadToFollowing("Ver"))
            {
                Main.ShowAlert("未知的文件版本，无法进行导入处理！");
                return;
            }
            string ver = reader.ReadElementContentAsString();
            if (ver != "1" && ver != "2")
            {
                Main.ShowAlert("未知的文件版本，无法进行导入处理！");
                return;
            }

            int suc = 0;
            int err = 0;
            reader.ReadToFollowing("Key");
            while (reader.Name == "Key")
            {
                if (!_SafeModel.ImportByXml(reader, ver))
                {
                    err += 1;
                    continue;
                }

                _SafeModel.Key.CatId = cat.Id;
                DoImportKey();
                suc += 1;
            }
            reader.Close();
            stream.Close();

            DoListKey(cat.Id);
            _SafeModel.Key = null;

            Main.ShowAlert(string.Format("数据导入结果：{0}成功，{1}失败！", suc, err));
            //ShowEcho(string.Format("", suc, err));
        }

        /// <summary>
        /// 导出VCF数据
        /// </summary>
        public void ImportVcf()
        {
            if (_SafeModel.Modified && DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
            {
                return;
            }

            Cat cat = _LastNode.Tag as Cat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要导入的类别！");
                TvCatTree.Focus();
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, "文件|*.vcf", "", false))
            {
                return;
            }
            string file = Main.OpenFileDialog.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            StreamReader reader = new StreamReader(file, Encoding.Default);
            vCard card = new vCard(reader);
            reader.Close();

            _SafeModel.Key = new Key();
            _SafeModel.Clear();
            GuidAtt guid = _SafeModel.InitGuid();
            guid.Data = cat.Id;
            MetaAtt meta = _SafeModel.InitMeta();
            meta.Name = "演示";
            _SafeModel.InitLogo();
            _SafeModel.InitHint();

            Att att;

            if (!string.IsNullOrWhiteSpace(card.GivenName))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "名";
                att.Data = card.GivenName;
                _SafeModel.Append(att);
            }

            if (!string.IsNullOrWhiteSpace(card.FamilyName))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "姓";
                att.Data = card.FamilyName;
                _SafeModel.Append(att);
            }

            if (card.Nicknames != null)
            {
                int idx = 1;
                foreach (string nickname in card.Nicknames)
                {
                    att = Att.GetInstance(Att.TYPE_TEXT);
                    att.Name = "昵称" + (idx++);
                    att.Data = nickname;
                    _SafeModel.Append(att);
                }
            }

            if (!string.IsNullOrWhiteSpace(card.DisplayName))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "显示名称";
                att.Data = card.DisplayName;
                _SafeModel.Append(att);
            }

            if (!string.IsNullOrWhiteSpace(card.FormattedName))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "显示名称";
                att.Data = card.FormattedName;
                _SafeModel.Append(att);
            }

            if (card.Photos != null)
            {
                int idx = 1;
                foreach (vCardPhoto photo in card.Photos)
                {
                    att = Att.GetInstance(Att.TYPE_FILE);
                    att.Name = "图像" + (idx++);
                    att.Data = "";
                    _SafeModel.Append(att);
                }
            }

            if (card.BirthDate != null)
            {
                att = Att.GetInstance(Att.TYPE_DATE);
                att.Name = "生日";
                att.Data = card.BirthDate.Value.ToFileTimeUtc().ToString();
                _SafeModel.Append(att);
            }

            if (card.DeliveryAddresses != null)
            {
                foreach (vCardDeliveryAddress adr in card.DeliveryAddresses)
                {
                }
            }

            if (card.DeliveryLabels != null)
            {
            }

            if (card.Phones != null)
            {
                foreach (vCardPhone tel in card.Phones)
                {
                }
            }

            if (card.EmailAddresses != null)
            {
                foreach (vCardEmailAddress mail in card.EmailAddresses)
                {
                }
            }

            if (!string.IsNullOrWhiteSpace(card.TimeZone))
            {
                att = Att.GetInstance(Att.TYPE_DATE);
                att.Name = "时区";
                att.Data = card.TimeZone;
                _SafeModel.Append(att);
            }

            if (card.Longitude != null)
            {
                att = Att.GetInstance(Att.TYPE_DATA);
                att.Name = "经度";
                att.Data = card.Longitude.ToString();
                _SafeModel.Append(att);
            }

            if (card.Latitude != null)
            {
                att = Att.GetInstance(Att.TYPE_DATA);
                att.Name = "纬度";
                att.Data = card.Latitude.ToString();
                _SafeModel.Append(att);
            }

            if (!string.IsNullOrWhiteSpace(card.Title))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "职务";
                att.Data = card.Title;
                _SafeModel.Append(att);
            }

            if (!string.IsNullOrWhiteSpace(card.Role))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "角色";
                att.Data = card.Role;
                _SafeModel.Append(att);
            }

            if (!string.IsNullOrWhiteSpace(card.Organization))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "单位";
                att.Data = card.Organization;
                _SafeModel.Append(att);
            }

            if (card.Notes != null)
            {
                int idx = 1;
                foreach (vCardNote note in card.Notes)
                {
                    att = Att.GetInstance(Att.TYPE_TEXT);
                    att.Name = "备注" + (idx++);
                    att.Data = note.Text;
                    _SafeModel.Append(att);
                }
            }

            if (card.Websites != null)
            {
                int idx = 1;
                foreach (vCardWebsite url in card.Websites)
                {
                    att = Att.GetInstance(Att.TYPE_LINK);
                    att.Name = "网站" + (idx++);
                    att.Data = url.Url;
                    _SafeModel.Append(att);
                }
            }

            if (!string.IsNullOrWhiteSpace(card.UniqueId))
            {
                att = Att.GetInstance(Att.TYPE_TEXT);
                att.Name = "标识";
                att.Data = card.UniqueId;
                _SafeModel.Append(att);
            }

            DoImportKey();
            DoListKey(cat.Id);
            _SafeModel.Key = null;
        }

        public void ImportOld()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            Cat cat = _LastNode.Tag as Cat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要导入的类别！");
                TvCatTree.Focus();
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, EApp.FILE_OPEN_ALL, "", false))
            {
                return;
            }
            string file = Main.OpenFileDialog.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            int suc = 0;
            int err = 0;
            using (StreamReader reader = File.OpenText(file))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (!_SafeModel.ImportByOld(line, "0"))
                        {
                            err += 1;
                            continue;
                        }

                        _SafeModel.Key.CatId = cat.Id;
                        DoImportKey();
                        suc += 1;
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            DoListKey(cat.Id);
            _SafeModel.Key = null;

            Main.ShowAlert(string.Format("数据导入结果：{0}成功，{1}失败！", suc, err));
        }
        #endregion
        #endregion

        #region 用户选单
        #region 记录安全
        public void PkeyEdit()
        {
            AuthAc authAc = new AuthAc(_UserModel);
            authAc.InitOnce();
            authAc.ShowView(EAuthAc.AuthPc);
            authAc.ShowDialog(this);
        }

        public void LkeyEdit()
        {
            AuthAc authAc = new AuthAc(_UserModel);
            authAc.InitOnce();
            authAc.ShowView(EAuthAc.AuthLk);
            authAc.ShowDialog(this);
        }

        public void SkeyEdit()
        {
            MessageBox.Show("安全口令功能尚在完善中，敬请期待！");
        }
        #endregion

        #region 系统管理
        public void ShowLibEdit()
        {
            LibEdit edit = new LibEdit(_UserModel);
            edit.Init(_DataModel);
            BeanUtil.CenterToParent(edit, _Main);
            edit.Show(this);
        }

        public void ShowUdcEdit()
        {
            UdcEditor edit = new UdcEditor(_UserModel);
            edit.Init(_DataModel.UdcModel, new Udc());
            BeanUtil.CenterToParent(edit, _Main);
            edit.Show(this);
        }

        public void ShowIcoEdit()
        {
            KeyIcon edit = new KeyIcon(_UserModel, _DataModel.KeyDir);
            edit.IcoSize = EApp.IMG_KEY_LIST_DIM;
            BeanUtil.CenterToParent(edit, _Main);
            edit.Show(this);
        }
        #endregion
        #endregion

        #region 帮助选单
        /// <summary>
        /// 帮助
        /// </summary>
        public void ShowHelp()
        {
            try
            {
                Process.Start("http://amon.me/blog");
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        public void ShowShortCuts()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Key");
            dt.Columns.Add("Memo");
            foreach (KeyStroke<APwd> stroke in _XmlMenu.KeyStrokes)
            {
                dt.Rows.Add(stroke.Key, stroke.Memo);
            }

            HotKeys keys = new HotKeys(dt);
            BeanUtil.CenterToParent(keys, _Main);
            keys.Show(this);
        }

        /// <summary>
        /// 关于
        /// </summary>
        public void ShowAbout()
        {
            Main.ShowAbout(this);
        }
        #endregion
        #endregion

        #region 私有函数
        /// <summary>
        /// 类别视图初始化
        /// </summary>
        private void InitCat()
        {
            IlCatTree.Images.Add(EPwd.DEF_CAT_IMG, BeanUtil.NaN16);

            Cat cat = new Cat { Id = EPwd.DEF_CAT_ID, Text = "默认类别", Tips = "默认类别", Icon = "Amon" };
            IlCatTree.Images.Add(cat.Icon, Resources.Logo);
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Icon, SelectedImageKey = cat.Icon };
            _RootNode.Tag = cat;
            TvCatTree.Nodes.Add(_RootNode);
            DoInitCat(_RootNode);
            _RootNode.Expand();
        }

        private void DoInitCat(TreeNode root)
        {
            foreach (Cat cat in _UserModel.DBA.ListCat(root.Name))
            {
                TreeNode node = new TreeNode();
                node.Name = cat.Id;
                node.Text = cat.Text;
                node.ToolTipText = cat.Tips;
                node.Tag = cat;
                if (CharUtil.IsValidateHash(cat.Icon))
                {
                    IlCatTree.Images.Add(cat.Icon, BeanUtil.ReadImage(Path.Combine(_DataModel.CatDir, cat.Icon + ".png"), BeanUtil.NaN16));
                    node.ImageKey = cat.Icon;
                }
                else
                {
                    node.ImageKey = EPwd.DEF_CAT_IMG;
                }
                node.SelectedImageKey = node.ImageKey;

                root.Nodes.Add(node);
                if (!cat.IsLeaf)
                {
                    DoInitCat(node);
                }
            }
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
                _UserModel.DBA.SaveVcs(cat);
            }
        }

        private void InitKey()
        {
            _KeyIcon = new Dictionary<string, Image>();
            _KeyHint = new Dictionary<string, Image>();
        }

        private void DoInitKey(IList<Key> keys)
        {
            LbKeyList.Items.Clear();
            _KeyIcon.Clear();
            _KeyHint.Clear();

            foreach (Key key in keys)
            {
                LbKeyList.Items.Add(key);

                if (CharUtil.IsValidateHash(key.IcoName))
                {
                    if (CharUtil.IsValidateHash(key.IcoPath))
                    {
                        _KeyIcon[key.IcoName] = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoPath, key.IcoName + EApp.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                    else
                    {
                        _KeyIcon[key.IcoName] = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoName + EApp.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                }
                else
                {
                    _KeyIcon[key.IcoName] = BeanUtil.NaN24;
                }

                _KeyHint[key.GtdId] = CharUtil.IsValidateHash(key.GtdId) ? Resources.Hint : BeanUtil.NaN16;
            }
        }

        private void DoListKey(string catId)
        {
            IList<Key> keys = _UserModel.DBA.ListKey(catId);
            DoInitKey(keys);
        }

        private void DoFindKey(string meta)
        {
            DoInitKey(_UserModel.DBA.FindKey(meta));
        }

        private void DoImportKey()
        {
            if (_SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }

            _SafeModel.Encode();

            _SafeModel.Key.AccessTime = DateTime.Now.ToString(EApp.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="file"></param>
        private void DoBackup(string file)
        {
            _UserModel.DBA.CloseConnect();
            BeanUtil.DoZip(file, _UserModel.Home);
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="file"></param>
        private void DoResuma(string file)
        {
        }

        public void LoadLayout()
        {
            if (_ViewModel.WindowState == EPwd.WINDOW_STATE_MAXIMIZED)
            {
                _Main.WindowState = FormWindowState.Maximized;
            }
            else if (_ViewModel.WindowState == EPwd.WINDOW_STATE_MINIMIZED)
            {
                _Main.WindowState = FormWindowState.Minimized;
            }
            else
            {
                _Main.ClientSize = new Size(_ViewModel.WindowDimW, _ViewModel.WindowDimH);
                _Main.Location = new Point(_ViewModel.WindowLocX, _ViewModel.WindowLocY);
            }

            HSplit.SplitterDistance = _ViewModel.HSplitDistance;
            HSplit.Panel1Collapsed = !_ViewModel.NavPaneVisible;

            VSplit.SplitterDistance = _ViewModel.VSplitDistance;

            MbMenu.Visible = _ViewModel.MenuBarVisible;
            TbTool.Visible = _ViewModel.ToolBarVisible;
            SsEcho.Visible = _ViewModel.EchoBarVisible;
            FbFind.Visible = _ViewModel.FindBarVisible;
        }

        public void SaveLayout()
        {
            if (_Main.WindowState == FormWindowState.Maximized)
            {
                _ViewModel.WindowState = EPwd.WINDOW_STATE_MAXIMIZED;
            }
            else if (_Main.WindowState == FormWindowState.Minimized)
            {
                _ViewModel.WindowState = EPwd.WINDOW_STATE_MINIMIZED;
            }
            else
            {
                _ViewModel.WindowState = EPwd.WINDOW_STATE_NORMAL;

                _ViewModel.WindowLocX = _Main.Location.X;
                _ViewModel.WindowLocY = _Main.Location.Y;
                _ViewModel.WindowDimW = _Main.ClientSize.Width;
                _ViewModel.WindowDimH = _Main.ClientSize.Height;
            }

            _ViewModel.HSplitDistance = HSplit.SplitterDistance;
            _ViewModel.NavPaneVisible = !HSplit.Panel1Collapsed;

            _ViewModel.VSplitDistance = VSplit.SplitterDistance;
            _ViewModel.CatTreeVisible = !VSplit.Panel1Collapsed;
            _ViewModel.KeyListVisible = !VSplit.Panel2Collapsed;

            _ViewModel.MenuBarVisible = MbMenu.Visible;
            _ViewModel.ToolBarVisible = TbTool.Visible;
            _ViewModel.EchoBarVisible = SsEcho.Visible;
            _ViewModel.FindBarVisible = FbFind.Visible;

            _ViewModel.Save();
        }
        #endregion
    }
}
