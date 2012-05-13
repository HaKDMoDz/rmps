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
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Properties;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Lib;
using Me.Amon.Pwd._Log;
using Me.Amon.Pwd.V.Pro;
using Me.Amon.Pwd.V.Wiz;
using Me.Amon.Uc;
using Me.Amon.User;
using Me.Amon.User.Auth;
using Me.Amon.Util;
using Me.Amon.Uw;
using Thought.vCards;

namespace Me.Amon.Pwd
{
    public partial class APwd : Form, IApp
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
        #endregion

        #region 接口实现
        public void InitOnce()
        {
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

            #region 系统菜单
            _XmlMenu = new XmlMenu<APwd>(this, _ViewModel);
            _XmlMenu.Load(Path.Combine(_UserModel.Home, "Pwd.xml"));
            _XmlMenu.GetStrokes("APwd");
            _XmlMenu.GetMenuBar("APwd", MbMenu);
            _XmlMenu.GetToolBar("APwd", TbTool);
            _XmlMenu.GetPopMenu("ACat", CmCat);
            _XmlMenu.GetPopMenu("AKey", CmKey);
            //_XmlMenu.GetPopMenu("AAtt", CmAtt);
            #endregion
        }

        public int AppId { get; set; }

        public Form Form { get { return this; } }

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
            string path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), IEnv.DIR_BACK);
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APwd_Load(object sender, EventArgs e)
        {
            InitCat();
            InitKey();
            FbFind.APwd = this;

            // 布局加载
            LoadLayout();

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
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TvCatTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = e.Node;
            if (node == null || node == _LastNode)
            {
                return;
            }

            ListKey(node.Name);
            _LastNode = node;
        }

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LbKeyList_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Key key = LbKeyList.SelectedItem as Key;
            if (key == null)
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
                return;
            }

            _SafeModel.Key = key;
            _SafeModel.Decode();

            ShowKey(key);
        }

        /// <summary>
        /// 时钟信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcTime_Tick(object sender, EventArgs e)
        {
            TssTime.Text = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
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

                e.Handled = true;
                stroke.Action.EventHandler(stroke, null);
                break;
            }
        }

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

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowIcoSeeker(string rootDir, AmonHandler<Pwd.Ico> handler)
        {
            IcoSeeker seeker = new IcoSeeker(_UserModel, rootDir);
            seeker.InitOnce(24);
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
            _LastNode.ImageKey = cat.Icon;
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
            TreeNode parent = node.Parent;
            if (parent == null || parent == _RootNode)
            {
                return;
            }
            TreeNode grand = parent.Parent;
            if (grand == null)
            {
                return;
            }
            parent.Nodes.Remove(node);
            grand.Nodes.Add(node);

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
            TreeNode prev = node.PrevNode;
            if (prev == null || prev == _RootNode)
            {
                return;
            }
            TreeNode parent = node.Parent;
            if (parent == null)
            {
                return;
            }
            parent.Nodes.Remove(node);
            prev.Nodes.Add(node);

            TvCatTree.SelectedNode = node;
        }

        public void ChangeCatIcon()
        {
            PngSeeker editor = new PngSeeker(_UserModel, _DataModel.CatDir);
            editor.InitOnce(16);
            editor.CallBackHandler = new AmonHandler<Png>(ChangeCatIcon);
            BeanUtil.CenterToParent(editor, this);
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
                IlCatTree.Images.Add(png.File, png.Image);
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
            _SafeModel.Key.AccessTime = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
            _SafeModel.Modified = false;

            LastOpt();
            _PwdView.ShowInfo();
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

            _UserModel.DBA.RemoveVcs(_SafeModel.Key);

            LbKeyList.Items.RemoveAt(LbKeyList.SelectedIndex);
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

            LastOpt();
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
            CatView view = new CatView(_UserModel);
            view.Init(IlCatTree);
            view.CallBack = new AmonHandler<string>(ChangeKeyCat);
            BeanUtil.CenterToParent(view, this);
            view.ShowDialog(this);
        }

        public void KeyHistory()
        {
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

        #region 文件菜单
        public void LockForm()
        {
            new AuthRc(_UserModel, this).ShowDialog(this);
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
            SaveLayout();

            Close();
        }
        #endregion

        #region 编辑菜单
        #endregion

        #region 视图菜单
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
        /// 菜单栏是否可见
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

        #region 数据菜单
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
        public void LocaleBackup()
        {
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            _LastNode = null;
            TvCatTree.SelectedNode = null;
            LbKeyList.Items.Clear();

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "密码箱备份文件|*.apbak";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            DoBackup(fd.FileName);
        }

        /// <summary>
        /// 远程备份
        /// </summary>
        public void RemoteBackup()
        {
            MessageBox.Show("远程备份功能尚在完善中，敬请期待！");
        }

        /// <summary>
        /// 本地恢复
        /// </summary>
        public void LocaleResuma()
        {
            MessageBox.Show("本地恢复功能尚在完善中，敬请期待！");
        }

        /// <summary>
        /// 远程恢复
        /// </summary>
        public void RemoteResume()
        {
            MessageBox.Show("远程恢复功能尚在完善中，敬请期待！");
        }

        #region 数据导出
        /// <summary>
        /// 导出为TXT
        /// </summary>
        public void ExportTxt()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
                {
                    return;
                }
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "文件|*.aptxt";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (StreamWriter writer = new StreamWriter(file, false))
            {
                writer.WriteLine("APwd-2");
                StringBuilder buffer = new StringBuilder();
                _SafeModel.ExportAsTxt(buffer);
                writer.WriteLine(buffer.ToString());

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

            IList<Key> recs = _UserModel.DBA.ListKey(cat.Id);
            if (recs.Count < 1)
            {
                Main.ShowAlert("当前类别下没有记录！");
                TvCatTree.Focus();
                return;
            }

            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "文件|*.apxml";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file))
            {
                return;
            }

            using (StreamWriter sw = new StreamWriter(file, false))
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    writer.WriteStartElement("Amon");
                    writer.WriteElementString("App", "APwd");
                    writer.WriteElementString("Ver", "2");
                    writer.WriteStartElement("Keys");
                    foreach (Key rec in recs)
                    {
                        _SafeModel.Key = rec;
                        _SafeModel.Decode();
                        _SafeModel.ExportAsXml(writer);
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();

                    writer.Flush();
                }

                sw.Close();
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

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文件|*.aptxt";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

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
                        if (_SafeModel.ImportByTxt(line, ver.Substring(5)))
                        {
                            _SafeModel.Key.CatId = cat.Id;
                            DoImportKey();
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            DoListKey(cat.Id);
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

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文件|*.apxml";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            using (XmlReader reader = XmlReader.Create(File.OpenText(file)))
            {
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
                while (reader.ReadToFollowing("Key"))
                {
                    if (_SafeModel.ImportByXml(reader, ver))
                    {
                        _SafeModel.Key.CatId = cat.Id;
                        DoImportKey();
                    }
                }
            }

            DoListKey(cat.Id);
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

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "文件|*.vcf";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
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

            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "所有文件|*.*";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }
            string file = fd.FileName;
            if (string.IsNullOrEmpty(file) || !File.Exists(file))
            {
                return;
            }

            using (StreamReader reader = File.OpenText(file))
            {
                // 版本判断
                string ver = reader.ReadLine();
                if ("2" != ver)
                {
                    Main.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        //_SafeModel.ImportByTxt(line);
                        SaveKey();
                    }
                    line = reader.ReadLine();
                }
            }
        }
        #endregion
        #endregion

        #region 用户菜单
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
            IcoSeeker edit = new IcoSeeker(_UserModel, _DataModel.KeyDir);
            edit.InitOnce(IEnv.IMG_KEY_LIST_DIM);
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }
        #endregion
        #endregion

        #region 帮助菜单
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
            BeanUtil.CenterToParent(keys, this);
            keys.Show(this);
        }

        /// <summary>
        /// 关于
        /// </summary>
        public void ShowAbout()
        {
            new About().ShowDialog(this);
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
                        _KeyIcon[key.IcoName] = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoPath, key.IcoName + IEnv.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                    else
                    {
                        _KeyIcon[key.IcoName] = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoName + IEnv.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
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
            _SafeModel.Encode();

            _SafeModel.Key.AccessTime = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
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

        private void LoadLayout()
        {
            if (_ViewModel.WindowState == EPwd.WINDOW_STATE_MAXIMIZED)
            {
                WindowState = FormWindowState.Maximized;
            }
            else if (_ViewModel.WindowState == EPwd.WINDOW_STATE_MINIMIZED)
            {
                WindowState = FormWindowState.Minimized;
            }
            else
            {
                ClientSize = new Size(_ViewModel.WindowDimW, _ViewModel.WindowDimH);
                Location = new Point(_ViewModel.WindowLocX, _ViewModel.WindowLocY);
            }

            HSplit.SplitterDistance = _ViewModel.HSplitDistance;
            HSplit.Panel1Collapsed = !_ViewModel.NavPaneVisible;

            VSplit.SplitterDistance = _ViewModel.VSplitDistance;

            MbMenu.Visible = _ViewModel.MenuBarVisible;
            TbTool.Visible = _ViewModel.ToolBarVisible;
            SsEcho.Visible = _ViewModel.EchoBarVisible;
            FbFind.Visible = _ViewModel.FindBarVisible;
        }

        private void SaveLayout()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                _ViewModel.WindowState = EPwd.WINDOW_STATE_MAXIMIZED;
            }
            else if (WindowState == FormWindowState.Minimized)
            {
                _ViewModel.WindowState = EPwd.WINDOW_STATE_MINIMIZED;
            }
            else
            {
                _ViewModel.WindowState = EPwd.WINDOW_STATE_NORMAL;

                _ViewModel.WindowLocX = Location.X;
                _ViewModel.WindowLocY = Location.Y;
                _ViewModel.WindowDimW = ClientSize.Width;
                _ViewModel.WindowDimH = ClientSize.Height;
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
