using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Api.Enums;
using Me.Amon.Api.User32;
using Me.Amon.Auth;
using Me.Amon.C;
using Me.Amon.Gtd;
using Me.Amon.M;
using Me.Amon.Properties;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
using Me.Amon.Pwd._Lib;
using Me.Amon.Pwd._Log;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V.Pad;
using Me.Amon.Pwd.V.Pro;
using Me.Amon.Pwd.V.Wiz;
using Me.Amon.Uc;
using Me.Amon.Util;
using Me.Amon.Uw;
using Thought.vCards;

namespace Me.Amon.Pwd
{
    public partial class APwd : Form, IApp
    {
        #region 全局变量
        private Main _Main;
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
        private APad _PadView;
        private XmlMenu<APwd> _XmlMenu;
        #endregion

        /// <summary>
        /// 待提示节点
        /// </summary>
        private TreeNode _TaskNode;
        /// <summary>
        /// 快过期节点
        /// </summary>
        private TreeNode _TaskExpiredNode;
        /// <summary>
        /// 消息等待时间
        /// </summary>
        private int _EchoDelay;

        private bool _Exit;

        #region 构造函数
        public APwd()
        {
            InitializeComponent();
        }

        public APwd(Main main, AUserModel userModel)
        {
            _Main = main;
            _UserModel = userModel as UserModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        private void APwd_Load(object sender, EventArgs e)
        {
            #region 数据模型
            _SafeModel = new SafeModel(_UserModel);
            _SafeModel.Init();
            _DataModel = new DataModel(_UserModel);
            _DataModel.Init();
            _ViewModel = new ViewModel(_UserModel);
            _ViewModel.LoadLayout();
            UdcModel udcModel = new UdcModel();
            udcModel.Init(_UserModel);
            _DataModel.UdcModel = udcModel;
            #endregion

            #region 系统选单
            _XmlMenu = new XmlMenu<APwd>(this, _ViewModel);
            if (_XmlMenu.Load(Path.Combine(_UserModel.DatHome, CPwd.XML_MENU)))
            {
                _XmlMenu.GetMenuBar("APwd", MbMenu);
                _XmlMenu.GetToolBar("APwd", TbTool);
                _XmlMenu.GetPopMenu("ACat", CmCat);
                _XmlMenu.GetPopMenu("AKey", CmKey);
                //_XmlMenu.GetPopMenu("AAtt", CmAtt);
                _XmlMenu.GetStrokes("APwd", this);
            }
            #endregion

            LoadLayout();

            InitCat();
            InitKey();
            FbFind.APwd = this;

            // 当前时间
            UcTimer.Start();

            // 视图模式
            switch (_ViewModel.Pattern)
            {
                case CPwd.PATTERN_PRO:
                    ShowAPro();
                    break;
                case CPwd.PATTERN_WIZ:
                    ShowAWiz();
                    break;
                case CPwd.PATTERN_PAD:
                    ShowAPad();
                    break;
                default:
                    break;
            }

            _UserModel.AppendHandler(new AmonHandler<string>(ShowEcho));

            User32.RegisterHotKey(this.Handle, this.Handle.ToInt32(), 0, (int)VirtualKey.F2);
        }
        #endregion

        #region 接口实现
        public int AppId { get; set; }

        public Form Form
        {
            get { return this; }
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            if (_EchoDelay < 1)
            {
                if (SsEcho.InvokeRequired)
                {
                    SsEcho.Invoke(new MethodInvoker(() => TssEcho.Text = message));
                }
                else
                {
                    TssEcho.Text = message;
                }
                //TssEcho.Text = message;
            }
        }

        public void ShowEcho(string message, int delay)
        {
            TssEcho.Text = message;
            _EchoDelay = delay;
        }

        public new bool Focus()
        {
            return FbFind.Focus();
        }

        public bool CanExit()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes != Main.ShowConfirm("您有数据尚未保存，确认要退出窗口吗？"))
                {
                    return false;
                }
            }

            User32.UnregisterHotKey(this.Handle, this.Handle.ToInt32());

            SaveLayout();
            _Exit = true;

            return true;
        }

        public bool SaveData()
        {
            if (Directory.Exists(_UserModel.BakHome))
            {
                string[] files = Directory.GetFiles(_UserModel.BakHome, _UserModel.Code + "*.apbak", SearchOption.TopDirectoryOnly);
                if (files.Length >= _UserModel.BackFileCount)
                {
                    Array.Sort(files);
                    for (int i = files.Length - _UserModel.BackFileCount; i >= 0; i -= 1)
                    {
                        File.Delete(files[i]);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(_UserModel.BakHome);
            }

            string file = _UserModel.Code + '-' + DateTime.Now.ToString("yyyyMMddHHmmss") + ".apbak";
            _UserModel.Suspend();
            BeanUtil.DoZip(Path.Combine(_UserModel.BakHome, file), _UserModel.DatHome);
            _UserModel.Resume();
            return true;
        }
        #endregion

        #region 事件处理
        private void APwd_Resize(object sender, EventArgs e)
        {
            if (!Visible)
            {
                return;
            }
            if (Width < 360 || Height < 360)
            {
                ShowAPad();
            }
            //if (WindowState == FormWindowState.Minimized)
            //{
            //    Visible = false;
            //}
        }

        private void APwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_Exit)
            {
                e.Cancel = true;
                HideForm();
            }
        }

        /// <summary>
        /// 是否处于模态
        /// </summary>
        public bool Modaled { get; set; }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == (int)WindowMessage.WM_HOTKEY)
            {
                if (Visible && !Modaled)
                {
                    int t = m.WParam.ToInt32();
                    if (t == this.Handle.ToInt32())
                    {
                        FillData();
                    }
                }
            }
            base.WndProc(ref m);
        }

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
            _LastNode = node;

            Cat cat = node.Tag as Cat;
            if (cat != null && !string.IsNullOrWhiteSpace(cat.Meta))
            {
                string meta = cat.Meta.ToLower();
                // 待提示
                if (meta == CPwd.KEY_TASK)
                {
                    ListGtd(DateTime.Now, 43200);
                    return;
                }
                // 已过期
                if (meta == CPwd.KEY_TASK_VAL_EXPIRED)
                {
                    ListGtdExpired();
                    return;
                }
                // 未过期
                if (meta.StartsWith(CPwd.KEY_TASK_VAR))
                {
                    ListGtd(meta.Substring(5));
                    return;
                }
            }

            ListKey(node.Name);
            return;
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
            Key key = LbKeyList.Items[e.Index] as Key;
            if (key == null)
            {
                return;
            }

            e.Graphics.DrawImage(key.Icon, e.Bounds.X + 3, e.Bounds.Y + 3, 24, 24);

            //最后把要显示的文字画在背景图片上
            int y = e.Bounds.Y + 2;
            e.Graphics.DrawString(key.Title, LbKeyList.Font, Brushes.Black, e.Bounds.X + 30, y);

            y = e.Bounds.Y + e.Bounds.Height;
            e.Graphics.DrawString(key.AccessTime, LbKeyList.Font, Brushes.Gray, e.Bounds.X + 30, y - 14);

            int x = e.Bounds.X + e.Bounds.Width;
            y -= 16;
            if (key.GtdIcon != null)
            {
                e.Graphics.DrawImage(key.GtdIcon, x - 48, y);
            }
            if (key.LabelIcon != null)
            {
                e.Graphics.DrawImage(key.LabelIcon, x - 32, y);
            }
            if (key.MajorIcon != null)
            {
                e.Graphics.DrawImage(key.MajorIcon, x - 16, y);
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
            DateTime now = DateTime.Now;
            TssTime.Text = now.ToString(CApp.DATEIME_FORMAT);
            if (_EchoDelay > 0)
            {
                _EchoDelay -= 1;
            }
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
            BeanUtil.CenterToParent(seeker, this);
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

            ItemGroup group = _XmlMenu.GetGroup(CPwd.KEY_LABEL);
            if (group != null)
            {
                group.Checked(key.Label.ToString());
            }
            group = _XmlMenu.GetGroup(CPwd.KEY_MAJOR);
            if (group != null)
            {
                group.Checked(key.Major.ToString());
            }
        }

        public void FillData()
        {
            IntPtr hWnd = User32.GetForegroundWindow();
            if (hWnd == IntPtr.Zero || hWnd == this.Handle)
            {
                return;
            }

            if (_SafeModel.Key == null || string.IsNullOrEmpty(_SafeModel.Key.Script))
            {
                return;
            }

            int i1 = 0;
            int i2;
            string s1;
            string s2;
            string t;
            string script = _SafeModel.Key.Script;
            Match match = Regex.Match(script, "{[^}]*}");
            while (match.Success)
            {
                i2 = match.Index;
                s1 = match.Value;
                s2 = s1.ToUpper();

                match = match.NextMatch();
                if (s2 == "{TAB}"
                    || s2 == "{BACKSPACE}"
                    || s2 == "{BKSP}"
                    || s2 == "{BS}"
                    || s2 == "{ENTER}")
                {
                    if (i2 > i1)
                    {
                        t = script.Substring(i1, i2 - i1);
                        SendKeys.SendWait(t);//已有字符
                    }
                    i1 = i2 + s1.Length;
                    SendKeys.SendWait(s2);// 功能键
                    Thread.Sleep(200);// 执行等待
                    continue;
                }

                if (i2 > i1)
                {
                    s2 = script.Substring(i1, i2 - i1) + TrimFillData(s1);
                }
                else
                {
                    s2 = TrimFillData(s1);
                }
                i1 = i2 + s1.Length;
                SendKeys.SendWait(s2);
            }
        }

        /// <summary>
        /// 特殊字符处理
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private string TrimFillData(string data)
        {
            Att item;
            data = data.Substring(1, data.Length - 2);
            for (int i = Att.HEAD_SIZE, j = _SafeModel.Count; i < j; i += 1)
            {
                item = _SafeModel.GetAtt(i);
                if (item.Text != data)
                {
                    continue;
                }
                data = item.Data;
                data = data.Replace('{', '\b').Replace('}', '\f');
                data = data.Replace("\b", "{{}");
                data = data.Replace("\f", "{}}");
                data = data.Replace("[", "{[}");
                data = data.Replace("]", "{]}");
                data = data.Replace("(", "{(}");
                data = data.Replace(")", "{)}");
                data = data.Replace("+", "{+}");
                data = data.Replace("^", "{^}");
                data = data.Replace("%", "{%}");
                data = data.Replace("~", "{~}");
                return data;
            }
            return "{{}" + data + "{}}";
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
            cat.AppId = CApp.IAPP_APWD;
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

            if (cur.Id == CPwd.DEF_CAT_ID)
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

            if (cat.Id == CPwd.DEF_CAT_ID)
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
            if (currCat == null || currCat.Id == CPwd.DEF_CAT_ID)
            {
                return;
            }

            TreeNode prevNode = _LastNode.PrevNode;
            if (prevNode == null)
            {
                return;
            }

            Cat prevCat = prevNode.Tag as Cat;
            if (prevCat == null || prevCat.Id == CPwd.DEF_CAT_ID)
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
            if (currCat == null || currCat.Id == CPwd.DEF_CAT_ID)
            {
                return;
            }

            TreeNode nextNode = _LastNode.NextNode;
            if (nextNode == null)
            {
                return;
            }

            Cat nextCat = nextNode.Tag as Cat;
            if (nextCat == null || nextCat.Id == CPwd.DEF_CAT_ID)
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
            BeanUtil.CenterToParent(editor, this);
            editor.ShowDialog(this);
        }

        public void ChangeCatIcon(Png png)
        {
            if (!CharUtil.IsValidateHash(png.File))
            {
                png.File = CPwd.DEF_CAT_IMG;
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
                    _SafeModel.Key.CatId = CPwd.DEF_CAT_ID;
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
            _SafeModel.Key.AccessTime = DateTime.Now.ToString(CApp.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
            if (_SafeModel.Key.Gtd != null)
            {
                _SafeModel.Key.Gtd.RefId = _SafeModel.Key.Id;
                _UserModel.DBA.SaveVcs(_SafeModel.Key.Gtd);
            }
            _SafeModel.Modified = false;

            _PwdView.ShowInfo();

            if (_SafeModel.IsUpdate)
            {
                Key key = LbKeyList.SelectedItem as Key;
                if (key != null && _SafeModel.Key == key)
                {
                    LbKeyList.Items[LbKeyList.SelectedIndex] = _SafeModel.Key;
                }
                LbKeyList.Refresh();
            }
            else
            {
                LastOpt();
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

        public void ListGtdExpired()
        {
            IList<Gtd.M.MGtd> gtds = _UserModel.DBA.FindKeyByGtdExpired();
            List<Key> keys = new List<Key>();
            foreach (Gtd.M.MGtd gtd in gtds)
            {
                keys.Add(_UserModel.DBA.ReadKey(gtd.RefId));
            }
            DoInitKey(keys);
        }

        public void ListGtd(DateTime time, int seconds)
        {
            IList<Gtd.M.MGtd> gtds = _UserModel.DBA.ListGtdWithRef();
            List<Key> keys = new List<Key>();
            foreach (Gtd.M.MGtd gtd in gtds)
            {
                gtd.Test(time, seconds);
                if (gtd.Status == CGtd.STATUS_ONTIME)
                {
                    keys.Add(_UserModel.DBA.ReadKey(gtd.RefId));
                }
            }
            DoInitKey(keys);
        }

        public void ListGtd(string meta)
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

            ListGtd(now, (int)Math.Ceiling((end - now).TotalSeconds));
        }

        public void ListKey(string catId)
        {
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = CPwd.DEF_CAT_ID;
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
                catId = CPwd.DEF_CAT_ID;
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
            _SafeModel.Key.LabelIcon = _ViewModel.GetImage(CPwd.KEY_LABEL + label);
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
            _SafeModel.Key.MajorIcon = _ViewModel.GetImage(CPwd.KEY_MAJOR + (major + 2));
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LbKeyList.Refresh();
        }

        public void KeyMoveto()
        {
            CatTree view = new CatTree(_UserModel);
            view.Init(IlCatTree);
            view.CallBack = new AmonHandler<string>(ChangeKeyCat);
            BeanUtil.CenterToParent(view, this);
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
            BeanUtil.CenterToParent(edit, this);
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
            new AuthLs(_UserModel, this).ShowDialog(this);
        }

        public void HideForm()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes != Main.ShowConfirm("您有数据尚未保存，确认要隐藏窗口吗？"))
                {
                    return;
                }
            }

            SaveLayout();
            Visible = false;
        }

        public void ExitForm()
        {
            _Main.ExitSystem();
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
                _ProView.Name = CPwd.PATTERN_PRO;
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

            ItemGroup group = _XmlMenu.GetGroup("att-edit");
            if (group != null)
            {
                group.Visible(true);
            }
        }

        /// <summary>
        /// 向导模式
        /// </summary>
        public void ShowAWiz()
        {
            if (_WizView == null)
            {
                _WizView = new AWiz();
                _WizView.Name = CPwd.PATTERN_WIZ;
                _WizView.Init(this, _UserModel, _SafeModel, _DataModel, _ViewModel);
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

            ItemGroup group = _XmlMenu.GetGroup("att-edit");
            if (group != null)
            {
                group.Visible(false);
            }
        }

        /// <summary>
        /// 记事模式
        /// </summary>
        public void ShowAPad()
        {
            if (_PadView == null)
            {
                _PadView = new APad();
                _PadView.Name = CPwd.PATTERN_PAD;
                _PadView.Init(this, _SafeModel, _DataModel);
                _PadView.Dock = System.Windows.Forms.DockStyle.Fill;
            }

            if (_PwdView != null)
            {
                if (_PwdView.Name == _PadView.Name)
                {
                    return;
                }
                MbMenu.Visible = false;
                TbTool.Visible = false;
                TcTool.Visible = false;
            }

            PlMain.Controls.Remove(TcTool);
            PlMain.Controls.Add(_PadView);
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
            _UserModel.Suspend();
            BeanUtil.DoZip(Main.SaveFileDialog.FileName, _UserModel.DatHome);
            _UserModel.Resume();
        }

        /// <summary>
        /// 本地恢复
        /// </summary>
        public void NativeResume()
        {
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            _UserModel.Suspend();
            SaveData();

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, "密码箱备份文件|*.apbak", "", false))
            {
                return;
            }

            BeanUtil.UnZip(Main.OpenFileDialog.FileName, _UserModel.DatHome);
            Main.ShowAlert("数据恢复成功，请重新启动软件！");
            _Main.ExitSystem();
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

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, CApp.FILE_OPEN_ALL, "", false))
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
            LibEditer edit = new LibEditer(_UserModel);
            edit.Init(_DataModel);
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }

        public void ShowUdcEdit()
        {
            UdcEditor edit = new UdcEditor(_UserModel);
            edit.Init(_DataModel.UdcModel, new Udc());
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }

        public void ShowIcoEdit()
        {
            KeyIcon edit = new KeyIcon(_UserModel, _DataModel.KeyDir);
            edit.IcoSize = CApp.IMG_KEY_LIST_DIM;
            BeanUtil.CenterToParent(edit, this);
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

            HotKeys keys = new HotKeys(Me.Amon.Properties.Resources.Icon, dt);
            BeanUtil.CenterToParent(keys, this);
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
            IlCatTree.Images.Add(CPwd.DEF_CAT_IMG, BeanUtil.NaN16);

            Cat cat = new Cat { Id = CPwd.DEF_CAT_ID, Text = "默认类别", Tips = "默认类别", Icon = "Amon" };
            IlCatTree.Images.Add(cat.Icon, Resources.Logo);
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Icon, SelectedImageKey = cat.Icon };
            _RootNode.Tag = cat;
            TvCatTree.Nodes.Add(_RootNode);
            DoInitCat(_RootNode);
            _RootNode.Expand();
        }

        private void DoInitCat(TreeNode root)
        {
            foreach (Cat cat in _UserModel.DBA.ListCat(CApp.IAPP_APWD, root.Name))
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
        }

        private void DoInitKey(IList<Key> keys)
        {
            LbKeyList.Items.Clear();

            foreach (Key key in keys)
            {
                LbKeyList.Items.Add(key);

                if (CharUtil.IsValidateHash(key.IcoName))
                {
                    if (CharUtil.IsValidateHash(key.IcoPath))
                    {
                        key.Icon = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoPath, key.IcoName + CApp.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                    else
                    {
                        key.Icon = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoName + CApp.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                }
                else
                {
                    key.Icon = BeanUtil.NaN24;
                }

                key.LabelIcon = _ViewModel.GetImage(CPwd.KEY_LABEL + key.Label);
                key.MajorIcon = _ViewModel.GetImage(CPwd.KEY_MAJOR + (key.Major + 2));
                key.GtdIcon = CharUtil.IsValidateHash(key.GtdId) ? Resources.Hint : BeanUtil.NaN16;
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

            _SafeModel.Key.AccessTime = DateTime.Now.ToString(CApp.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
        }

        /// <summary>
        /// 布局加载
        /// </summary>
        public void LoadLayout()
        {
            if (_ViewModel.WindowState == CPwd.WINDOW_STATE_MAXIMIZED)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (_ViewModel.WindowState == CPwd.WINDOW_STATE_MINIMIZED)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                ClientSize = new Size(_ViewModel.WindowDimW, _ViewModel.WindowDimH);
                Location = new Point(_ViewModel.WindowLocX, _ViewModel.WindowLocY);
            }

            MbMenu.Visible = _ViewModel.MenuBarVisible;
            TbTool.Visible = _ViewModel.ToolBarVisible;
            SsEcho.Visible = _ViewModel.EchoBarVisible;
            FbFind.Visible = _ViewModel.FindBarVisible;

            HSplit.SplitterDistance = _ViewModel.HSplitDistance;
            HSplit.Panel1Collapsed = !_ViewModel.NavPaneVisible;

            VSplit.SplitterDistance = _ViewModel.VSplitDistance;
        }

        /// <summary>
        /// 布局保存
        /// </summary>
        public void SaveLayout()
        {
            if (!Visible)
            {
                return;
            }

            if (WindowState == FormWindowState.Maximized)
            {
                _ViewModel.WindowState = CPwd.WINDOW_STATE_MAXIMIZED;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                _ViewModel.WindowState = CPwd.WINDOW_STATE_MINIMIZED;
            }
            else
            {
                _ViewModel.WindowState = CPwd.WINDOW_STATE_NORMAL;

                _ViewModel.WindowLocX = Location.X;
                _ViewModel.WindowLocY = Location.Y;
                _ViewModel.WindowDimW = ClientSize.Width;
                _ViewModel.WindowDimH = ClientSize.Height;
            }

            _ViewModel.MenuBarVisible = MbMenu.Visible;
            _ViewModel.ToolBarVisible = TbTool.Visible;
            _ViewModel.EchoBarVisible = SsEcho.Visible;
            _ViewModel.FindBarVisible = FbFind.Visible;

            _ViewModel.HSplitDistance = HSplit.SplitterDistance;
            _ViewModel.NavPaneVisible = !HSplit.Panel1Collapsed;

            _ViewModel.VSplitDistance = VSplit.SplitterDistance;
            _ViewModel.CatTreeVisible = !VSplit.Panel1Collapsed;
            _ViewModel.KeyListVisible = !VSplit.Panel2Collapsed;

            _ViewModel.SaveLayout();
        }
        #endregion

        private void BgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void TssEcho_DoubleClick(object sender, EventArgs e)
        {
            if (_TaskNode != null)
            {
                TvCatTree.SelectedNode = _TaskNode;
            }
        }
    }
}
