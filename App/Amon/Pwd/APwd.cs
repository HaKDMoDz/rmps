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
using Me.Amon.Pwd.Pro;
using Me.Amon.Pwd.Wiz;
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
        private FindBar FbFind;
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
        private Dictionary<string, Image> _RecIcon;
        private Dictionary<string, Image> _RecHint;
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
            _SafeModel = new SafeModel(_UserModel);
            _SafeModel.Init();
            _DataModel = new DataModel(_UserModel);
            _DataModel.Init();
            _ViewModel = new ViewModel(_UserModel);
            _ViewModel.Load();
            UdcModel udcModel = new UdcModel();
            udcModel.Init(_UserModel);
            _DataModel.UdcModel = udcModel;

            _RecIcon = new Dictionary<string, Image>();
            _RecHint = new Dictionary<string, Image>();

            #region 类别
            Cat cat = new Cat { Id = "winshineapwd0000", Text = "阿木密码箱", Tips = "阿木密码箱", Icon = "Amon" };
            IlCatTree.Images.Add("winshineapwd0000", BeanUtil.NaN16);
            IlCatTree.Images.Add(cat.Icon, Resources.Logo);
            _RootNode = new TreeNode { Name = cat.Id, Text = cat.Text, ToolTipText = cat.Tips, ImageKey = cat.Icon, SelectedImageKey = cat.Icon };
            _RootNode.Tag = cat;
            TvCatTree.Nodes.Add(_RootNode);
            InitCat(_RootNode);
            _RootNode.Expand();
            #endregion

            #region 查找
            FbFind = new FindBar(this);
            FbFind.Dock = DockStyle.Fill;
            FbFind.Location = new Point(3, 3);
            FbFind.Name = "FbFind";
            FbFind.Size = new Size(390, 26);
            FbFind.TabIndex = 0;
            TpGrid.Controls.Add(FbFind, 0, 0);
            #endregion

            #region 视图
            HSplit.SplitterDistance = _ViewModel.HSplitDistance;
            HSplit.Panel1Collapsed = !_ViewModel.NavPaneVisible;
            TmiNavPane.Checked = _ViewModel.NavPaneVisible;

            VSplit.SplitterDistance = _ViewModel.VSplitDistance;
            VSplit.Panel1Collapsed = !_ViewModel.CatTreeVisible;
            TmiCatView.Checked = _ViewModel.CatTreeVisible;

            VSplit.Panel2Collapsed = !_ViewModel.KeyListVisible;
            TmiKeyList.Checked = _ViewModel.KeyListVisible;

            TmMenu.Visible = _ViewModel.MenuBarVisible;
            TmiMenuBar.Checked = _ViewModel.MenuBarVisible;
            TsbMenuBar.Checked = _ViewModel.MenuBarVisible;

            TsTool.Visible = _ViewModel.ToolBarVisible;
            TmiToolBar.Checked = _ViewModel.ToolBarVisible;
            TsbToolBar.Checked = _ViewModel.ToolBarVisible;

            FbFind.Visible = _ViewModel.FindBarVisible;
            TmiFindBar.Checked = _ViewModel.FindBarVisible;

            SsEcho.Visible = _ViewModel.EchoBarVisible;
            TmiEchoBar.Checked = _ViewModel.EchoBarVisible;
            TsbEchoBar.Checked = _ViewModel.EchoBarVisible;

            Location = new Point(_ViewModel.WindowLocX, _ViewModel.WindowLocY);
            #endregion

            ShowAWiz();

            UcTime.Start();

            #region 图标
            TsbAppend.Image = _ViewModel.GetImage("menu-key-append");
            TsbUpdate.Image = _ViewModel.GetImage("menu-key-update");
            TsbDelete.Image = _ViewModel.GetImage("menu-key-delete");

            TsbMenuBar.Image = _ViewModel.GetImage("menu-view-menubar");
            TsbToolBar.Image = _ViewModel.GetImage("menu-view-toolbar");
            TsbEchoBar.Image = _ViewModel.GetImage("menu-view-echobar");

            TsbSync.Image = _ViewModel.GetImage("menu-data-sync");

            TsbKeys.Image = _ViewModel.GetImage("menu-help-hotkeys");
            TsbInfo.Image = _ViewModel.GetImage("menu-help-topic");
            #endregion

            #region 使用状态
            _CmiLabels = new ToolStripMenuItem[] { CmiLabel0, CmiLabel1, CmiLabel2, CmiLabel3, CmiLabel4, CmiLabel5, CmiLabel6, CmiLabel7, CmiLabel8, CmiLabel9 };
            _LastLabel = CmiLabel0;
            _ImgLabels = new Image[_CmiLabels.Length];
            for (int i = 0; i < _CmiLabels.Length; i += 1)
            {
                _ImgLabels[i] = _ViewModel.GetImage("key-label" + i);
                _CmiLabels[i].Image = _ImgLabels[i];
            }
            #endregion

            #region 紧要程度
            _CmiMajors = new ToolStripMenuItem[] { CmiMajorN2, CmiMajorN1, CmiMajor0, CmiMajorP1, CmiMajorP2, };
            _ImgMajors = new Image[_CmiMajors.Length];
            for (int i = 0; i < _CmiMajors.Length; i += 1)
            {
                _ImgMajors[i] = _ViewModel.GetImage("key-major" + i);
                _CmiMajors[i].Image = _ImgMajors[i];
            }
            _LastMajor = CmiMajor0;
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

        private void InitCat(TreeNode root)
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
                    node.ImageKey = "0";
                }
                node.SelectedImageKey = node.ImageKey;

                root.Nodes.Add(node);
                if (!cat.IsLeaf)
                {
                    InitCat(node);
                }
            }
        }
        #endregion

        #region 事件处理
        #region 界面事件
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

        private void InitKey(IList<Key> keys)
        {
            LbKeyList.Items.Clear();
            _RecIcon.Clear();
            _RecHint.Clear();

            foreach (Key key in keys)
            {
                LbKeyList.Items.Add(key);

                if (CharUtil.IsValidateHash(key.IcoName))
                {
                    if (CharUtil.IsValidateHash(key.IcoPath))
                    {
                        _RecIcon[key.IcoName] = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoPath, key.IcoName + IEnv.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                    else
                    {
                        _RecIcon[key.IcoName] = BeanUtil.ReadImage(Path.Combine(_DataModel.KeyDir, key.IcoName + IEnv.IMG_KEY_LIST_EXT), BeanUtil.NaN24);
                    }
                }
                else
                {
                    _RecIcon[key.IcoName] = BeanUtil.NaN24;
                }

                _RecHint[key.GtdId] = CharUtil.IsValidateHash(key.GtdId) ? Resources.Hint : BeanUtil.NaN16;
            }
        }

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

            Image img = _RecIcon.ContainsKey(rec.IcoName) ? _RecIcon[rec.IcoName] : BeanUtil.NaN24;
            e.Graphics.DrawImage(img, e.Bounds.X + 3, e.Bounds.Y + 3, img.Width, img.Height);

            //最后把要显示的文字画在背景图片上
            e.Graphics.DrawString(rec.Title, this.Font, Brushes.Black, e.Bounds.X + 36, e.Bounds.Y);

            int y = e.Bounds.Y + e.Bounds.Height;
            e.Graphics.DrawString(rec.AccessTime, this.Font, Brushes.Gray, e.Bounds.X + 36, y - 14);

            int x = e.Bounds.X + e.Bounds.Width;
            y -= 16;
            img = _RecHint.ContainsKey(rec.GtdId) ? _RecHint[rec.GtdId] : BeanUtil.NaN16;
            e.Graphics.DrawImage(img, x - 48, y);
            e.Graphics.DrawImage(_ImgLabels[rec.Label], x - 32, y);
            e.Graphics.DrawImage(_ImgMajors[rec.Major + 2], x - 16, y);
        }

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

            ShowRec(key);
        }

        private void APwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                // 添加记录
                if (e.KeyCode == Keys.N)
                {
                    AppendKey();
                    return;
                }
                // 保存记录
                if (e.KeyCode == Keys.S)
                {
                    UpdateKey();
                    return;
                }
                // 删除记录
                if (e.KeyCode == Keys.R)
                {
                    _PwdView.DeleteKey();
                    return;
                }
                // 查找
                if (e.KeyCode == Keys.F)
                {
                    FbFind.Focus();
                    return;
                }
                // 锁定窗口
                if (e.KeyCode == Keys.L)
                {
                    LockForm();
                    return;
                }
                // 隐藏窗口
                if (e.KeyCode == Keys.H || e.KeyCode == Keys.Enter)
                {
                    HideForm();
                    return;
                }
                // 退出窗口
                if (e.KeyCode == Keys.Q)
                {
                    ExitForm();
                    return;
                }
                // 向上选择
                if (e.KeyCode == Keys.U || e.KeyCode == Keys.Up)
                {
                    return;
                }
                // 向下选择
                if (e.KeyCode == Keys.U || e.KeyCode == Keys.Down)
                {
                    return;
                }
                // 向上移动
                if (e.Shift && (e.KeyCode == Keys.U || e.KeyCode == Keys.Up))
                {
                    return;
                }
                // 向下移动
                if (e.Shift && (e.KeyCode == Keys.D || e.KeyCode == Keys.Down))
                {
                    return;
                }

                #region 切换视图
                if (e.KeyCode == Keys.F1)
                {
                    ShowAPro();
                    return;
                }
                if (e.KeyCode == Keys.F2)
                {
                    ShowAWiz();
                    return;
                }
                if (e.KeyCode == Keys.F3)
                {
                    ShowAPad();
                    return;
                }
                #endregion

                #region 添加属性
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    _PwdView.AppendAtt(Att.TYPE_TEXT);
                    return;
                }
                if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    _PwdView.AppendAtt(Att.TYPE_PASS);
                    return;
                }
                if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    _PwdView.AppendAtt(Att.TYPE_LINK);
                    return;
                }
                if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    _PwdView.AppendAtt(Att.TYPE_MAIL);
                    return;
                }
                if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    _PwdView.AppendAtt(Att.TYPE_DATE);
                    return;
                }
                if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    _PwdView.AppendAtt(Att.TYPE_DATA);
                    return;
                }
                if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    _PwdView.AppendAtt(Att.TYPE_LIST);
                    return;
                }
                if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    _PwdView.AppendAtt(Att.TYPE_MEMO);
                    return;
                }
                if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    _PwdView.AppendAtt(Att.TYPE_FILE);
                    return;
                }
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    _PwdView.AppendAtt(Att.TYPE_LINE);
                    return;
                }
                #endregion

                #region 类别管理
                // 添加类别
                if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                {
                    AppendCat();
                    return;
                }
                // 更新类别
                if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
                {
                    UpdateCat();
                    return;
                }
                // 删除类别
                if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                {
                    DeleteCat();
                    return;
                }
                #endregion

                // 菜单栏隐现
                if (e.KeyCode == Keys.M)
                {
                    SetMenuBarVisible(!TmMenu.Visible);
                    return;
                }
                // 工具栏隐现
                if (e.KeyCode == Keys.T)
                {
                    SetToolBarVisible(!TsTool.Visible);
                    return;
                }
                // 状态栏隐现
                if (e.KeyCode == Keys.E)
                {
                    SetEchoBarVisible(!SsEcho.Visible);
                    return;
                }
                // 查找隐现
                if (e.KeyCode == Keys.G)
                {
                    SetFindBarVisible(!FbFind.Visible);
                    return;
                }
                // 目录隐现
                if (e.KeyCode == Keys.K)
                {
                    SetCatTreeVisible(VSplit.Panel1Collapsed);
                    return;
                }
                // 列表隐现
                if (e.KeyCode == Keys.P)
                {
                    SetKeyListVisible(VSplit.Panel2Collapsed);
                    return;
                }
                // 列表隐现
                if (e.KeyCode == Keys.J)
                {
                    SetNavPaneVisible(HSplit.Panel1Collapsed);
                    return;
                }
                // 属性隐现
                if (e.KeyCode == Keys.A)
                {
                    //SetKeyListVisible(VSplit.Panel2Collapsed);
                    return;
                }
                return;
            }
            if (e.Alt)
            {
                // 复制属性
                if (e.KeyCode == Keys.C)
                {
                    _PwdView.CopyAtt();
                    return;
                }
                // 更新属性
                if (e.KeyCode == Keys.U)
                {
                    _PwdView.SaveAtt();
                    return;
                }
                // 删除属性
                if (e.KeyCode == Keys.R)
                {
                    _PwdView.DropAtt();
                    return;
                }
                #region 修改属性
                if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
                {
                    _PwdView.UpdateAtt(Att.TYPE_TEXT);
                    return;
                }
                if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
                {
                    _PwdView.UpdateAtt(Att.TYPE_PASS);
                    return;
                }
                if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
                {
                    _PwdView.UpdateAtt(Att.TYPE_LINK);
                    return;
                }
                if (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4)
                {
                    _PwdView.UpdateAtt(Att.TYPE_MAIL);
                    return;
                }
                if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
                {
                    _PwdView.UpdateAtt(Att.TYPE_DATE);
                    return;
                }
                if (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6)
                {
                    _PwdView.UpdateAtt(Att.TYPE_DATA);
                    return;
                }
                if (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7)
                {
                    _PwdView.UpdateAtt(Att.TYPE_LIST);
                    return;
                }
                if (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8)
                {
                    _PwdView.UpdateAtt(Att.TYPE_MEMO);
                    return;
                }
                if (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9)
                {
                    _PwdView.UpdateAtt(Att.TYPE_FILE);
                    return;
                }
                if (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0)
                {
                    _PwdView.UpdateAtt(Att.TYPE_LINE);
                    return;
                }
                #endregion
                return;
            }
            // 帮助
            if (e.KeyCode == Keys.F1)
            {
                ShowHelp();
                return;
            }
            // 快捷键
            if (e.KeyCode == Keys.F5)
            {
                ShowKeys();
                return;
            }
        }

        private void APwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            HideForm();
        }

        private void UcTime_Tick(object sender, EventArgs e)
        {
            TssTime.Text = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
        }
        #endregion

        #region 菜单栏事件区域
        #region 系统菜单
        private void TmiHideWin_Click(object sender, EventArgs e)
        {
            HideForm();
        }

        private void TmiLockWin_Click(object sender, EventArgs e)
        {
            LockForm();
        }

        private void TmiExitApp_Click(object sender, EventArgs e)
        {
            ExitForm();
        }
        #endregion

        #region 编辑菜单
        #region 类别编辑
        private void TmiAppendCat_Click(object sender, EventArgs e)
        {
            AppendCat();
        }

        private void TmiUpdateCat_Click(object sender, EventArgs e)
        {
            UpdateCat();
        }

        private void TmiDeleteCat_Click(object sender, EventArgs e)
        {
            DeleteCat();
        }
        #endregion

        #region 记录编辑
        private void TmiAppendKey_Click(object sender, EventArgs e)
        {
            AppendKey();
        }

        private void TmiUpdateKey_Click(object sender, EventArgs e)
        {
            UpdateKey();
        }

        private void TmiDeleteKey_Click(object sender, EventArgs e)
        {
            DeleteKey();
        }
        #endregion

        #region 属性编辑
        #region 添加属性
        private void TmiAppendAttText_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_TEXT);
        }

        private void TmiAppendAttPass_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_PASS);
        }

        private void TmiAppendAttLink_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_LINK);
        }

        private void TmiAppendAttMail_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_MAIL);
        }

        private void TmiAppendAttDate_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_DATE);
        }

        private void TmiAppendAttData_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_DATA);
        }

        private void TmiUpdateAttCall_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_CALL);
        }

        private void TmiAppendAttList_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_LIST);
        }

        private void TmiAppendAttMemo_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_MEMO);
        }

        private void TmiAppendAttFile_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_FILE);
        }

        private void TmiAppendAttLine_Click(object sender, EventArgs e)
        {
            _PwdView.AppendAtt(Att.TYPE_LINE);
        }
        #endregion

        #region 转换属性
        private void TmiUpdateAttText_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_TEXT);
        }

        private void TmiUpdateAttPass_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_PASS);
        }

        private void TmiUpdateAttLink_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_LINK);
        }

        private void TmiUpdateAttMail_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_MAIL);
        }

        private void TmiUpdateAttDate_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_DATE);
        }

        private void TmiUpdateAttData_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_DATA);
        }

        private void TmiAppendAttCall_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_CALL);
        }

        private void TmiUpdateAttList_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_LIST);
        }

        private void TmiUpdateAttMemo_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_MEMO);
        }

        private void TmiUpdateAttFile_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_FILE);
        }

        private void TmiUpdateAttLine_Click(object sender, EventArgs e)
        {
            _PwdView.UpdateAtt(Att.TYPE_LINE);
        }
        #endregion

        private void TmiDeleteAtt_Click(object sender, EventArgs e)
        {
            _PwdView.DropAtt();
        }
        #endregion
        #endregion

        #region 视图菜单
        private void TmiViewPro_Click(object sender, EventArgs e)
        {
            ShowAPro();
        }

        private void TmiViewWiz_Click(object sender, EventArgs e)
        {
            ShowAWiz();
        }

        private void TmiViewPad_Click(object sender, EventArgs e)
        {
            ShowAPad();
        }

        private void TmiMenuBar_Click(object sender, EventArgs e)
        {
            SetMenuBarVisible(false);
        }

        private void TmiToolBar_Click(object sender, EventArgs e)
        {
            SetToolBarVisible(!TsTool.Visible);
        }

        private void TmiEchoBar_Click(object sender, EventArgs e)
        {
            SetEchoBarVisible(!SsEcho.Visible);
        }

        private void TmiKeyGuid_Click(object sender, EventArgs e)
        {
            SetNavPaneVisible(HSplit.Panel1Collapsed);
        }

        private void TmiCatView_Click(object sender, EventArgs e)
        {
            SetCatTreeVisible(VSplit.Panel1Collapsed);
        }

        private void TmiKeyList_Click(object sender, EventArgs e)
        {
            SetKeyListVisible(VSplit.Panel2Collapsed);
        }

        private void TmiFindBar_Click(object sender, EventArgs e)
        {
            SetFindBarVisible(!FbFind.Visible);
        }
        #endregion

        #region 数据菜单
        private void TmiSync_Click(object sender, EventArgs e)
        {
            DoSync();
        }

        private void TmiLocaleBackup_Click(object sender, EventArgs e)
        {
            LocaleBackup();
        }

        private void TmiLocaleResuma_Click(object sender, EventArgs e)
        {
            LocaleResuma();
        }

        private void TmiRemoteBackup_Click(object sender, EventArgs e)
        {
            RemoteBackup();
        }

        private void TmiRemoteResuma_Click(object sender, EventArgs e)
        {
            RemoteResume();
        }

        #region 数据导出
        private void TmiExportTxt_Click(object sender, EventArgs e)
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
                writer.WriteLine("APwd-1");
                StringBuilder buffer = new StringBuilder();
                _SafeModel.ExportAsTxt(buffer);
                writer.WriteLine(buffer.ToString());

                writer.Close();
            }
        }

        private void TmiExportXml_Click(object sender, EventArgs e)
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
                    writer.WriteElementString("Ver", "1");
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
        private void TmiImportTxt_Click(object sender, EventArgs e)
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
                if ("APwd-1" != ver)
                {
                    Main.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }

                string line = reader.ReadLine();
                while (line != null)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        if (_SafeModel.ImportByTxt(line))
                        {
                            _SafeModel.Key.CatId = cat.Id;
                            ImportKey();
                        }
                    }
                    line = reader.ReadLine();
                }
            }

            DoListKey(cat.Id);
        }

        private void TmiImportXml_Click(object sender, EventArgs e)
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
                if (reader.Name != "Ver" && !reader.ReadToFollowing("Ver") || reader.ReadElementContentAsString() != "1")
                {
                    Main.ShowAlert("未知的文件版本，无法进行导入处理！");
                    return;
                }
                while (reader.ReadToFollowing("Key"))
                {
                    if (_SafeModel.ImportByXml(reader))
                    {
                        _SafeModel.Key.CatId = cat.Id;
                        ImportKey();
                    }
                }
            }

            DoListKey(cat.Id);
        }

        private void TmiImportVcf_Click(object sender, EventArgs e)
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

            ImportKey();
            DoListKey(cat.Id);
        }
        #endregion

        private void TmiImportOld_Click(object sender, EventArgs e)
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
                        _SafeModel.ImportByTxt(line);
                        UpdateKey();
                    }
                    line = reader.ReadLine();
                }
            }
        }

        #endregion

        #region 用户菜单
        #region 记录安全
        private void TmiPkey_Click(object sender, EventArgs e)
        {
            AuthAc authAc = new AuthAc(_UserModel);
            authAc.InitOnce();
            authAc.ShowView(EAuthAc.AuthPc);
            authAc.ShowDialog(this);
        }

        private void TmiLkey_Click(object sender, EventArgs e)
        {
            AuthAc authAc = new AuthAc(_UserModel);
            authAc.InitOnce();
            authAc.ShowView(EAuthAc.AuthLk);
            authAc.ShowDialog(this);
        }

        private void TmiSkey_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 系统管理
        private void TmiLib_Click(object sender, EventArgs e)
        {
            LibEdit edit = new LibEdit(_UserModel);
            edit.Init(_DataModel);
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }

        private void TmiUcs_Click(object sender, EventArgs e)
        {
            UdcEditor edit = new UdcEditor(_UserModel);
            edit.Init(null, new Udc());
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }

        private void TmiIco_Click(object sender, EventArgs e)
        {
            IcoSeeker edit = new IcoSeeker(_UserModel, _DataModel.KeyDir);
            edit.InitOnce(IEnv.IMG_KEY_LIST_DIM);
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }
        #endregion
        #endregion

        #region 皮肤菜单
        #endregion

        #region 帮助菜单
        private void TmiHelp_Click(object sender, EventArgs e)
        {
            ShowHelp();
        }

        private void TmiKeys_Click(object sender, EventArgs e)
        {
            ShowKeys();
        }

        private void TmiInfo_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }
        #endregion
        #endregion

        #region 工具栏事件区域
        private void TsTool_EndDrag(object sender, EventArgs e)
        {

        }

        private void TsbAppend_Click(object sender, EventArgs e)
        {
            AppendKey();
        }

        private void TsbUpdate_Click(object sender, EventArgs e)
        {
            UpdateKey();
        }

        private void TsbDelete_Click(object sender, EventArgs e)
        {
            DeleteKey();
        }

        private void TsbCopy_Click(object sender, EventArgs e)
        {

        }

        private void TsbPaste_Click(object sender, EventArgs e)
        {

        }

        private void TsbClear_Click(object sender, EventArgs e)
        {
        }

        private void TsbMenu_Click(object sender, EventArgs e)
        {
            SetMenuBarVisible(!TmMenu.Visible);
        }

        private void TsbTool_Click(object sender, EventArgs e)
        {
            SetToolBarVisible(false);
        }

        private void TsbEcho_Click(object sender, EventArgs e)
        {
            SetEchoBarVisible(!SsEcho.Visible);
        }

        private void TsbSync_Click(object sender, EventArgs e)
        {
            DoSync();
        }

        private void TsbKeys_Click(object sender, EventArgs e)
        {
            ShowKeys();
        }

        private void TsbInfo_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }
        #endregion

        #region 弹出菜单事件区域
        #region 类别弹出菜单
        private void CmiSortU_Click(object sender, EventArgs e)
        {
            TreeNode currNode = TvCatTree.SelectedNode;
            if (currNode == null)
            {
                return;
            }

            Cat currCat = currNode.Tag as Cat;
            if (currCat == null || currCat.Id == "0")
            {
                return;
            }

            TreeNode prevNode = currNode.PrevNode;
            if (prevNode == null)
            {
                return;
            }

            Cat prevCat = prevNode.Tag as Cat;
            if (prevCat == null || prevCat.Id == "0")
            {
                return;
            }

            TreeNode parent = currNode.Parent;
            if (parent == null)
            {
                return;
            }

            _UserModel.DBA.SaveVcs(prevCat);
            _UserModel.DBA.SaveVcs(currCat);

            TvCatTree.SelectedNode = null;
            parent.Nodes.Remove(currNode);
            parent.Nodes.Insert(prevNode.Index, currNode);
            TvCatTree.SelectedNode = currNode;
        }

        private void CmiSortD_Click(object sender, EventArgs e)
        {
            TreeNode currNode = TvCatTree.SelectedNode;
            if (currNode == null)
            {
                return;
            }

            Cat currCat = currNode.Tag as Cat;
            if (currCat == null || currCat.Id == "0")
            {
                return;
            }

            TreeNode nextNode = currNode.NextNode;
            if (nextNode == null)
            {
                return;
            }

            Cat nextCat = nextNode.Tag as Cat;
            if (nextCat == null || nextCat.Id == "0")
            {
                return;
            }

            TreeNode parent = currNode.Parent;
            if (parent == null)
            {
                return;
            }

            _UserModel.DBA.SaveVcs(currCat);
            _UserModel.DBA.SaveVcs(nextCat);

            TvCatTree.SelectedNode = null;
            parent.Nodes.Remove(currNode);
            parent.Nodes.Insert(nextNode.Index + 1, currNode);
            TvCatTree.SelectedNode = currNode;
        }

        private void CmiAppendCat_Click(object sender, EventArgs e)
        {
            AppendCat();
        }

        private void CmiUpdateCat_Click(object sender, EventArgs e)
        {
            UpdateCat();
        }

        private void CmiDeleteCat_Click(object sender, EventArgs e)
        {
            DeleteCat();
        }

        private void CmiEditIcon_Click(object sender, EventArgs e)
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null || cat.Id == "winshineapwd0000")
            {
                return;
            }

            PngSeeker editor = new PngSeeker(_UserModel, _DataModel.CatDir);
            editor.InitOnce(16);
            editor.CallBackHandler = new AmonHandler<Pwd.Png>(ChangeImgByCat);
            BeanUtil.CenterToParent(editor, this);
            editor.ShowDialog(this);
        }
        #endregion

        #region 记录弹出菜单
        private void CmiAppendKey_Click(object sender, EventArgs e)
        {
            AppendKey();
        }

        private void CmiDeleteKey_Click(object sender, EventArgs e)
        {
            DeleteKey();
        }

        #region 使用状态
        private ToolStripMenuItem _LastLabel;
        private ToolStripMenuItem[] _CmiLabels;
        private Image[] _ImgLabels;
        private void CmiLabel0_Click(object sender, EventArgs e)
        {
            ChangeLabel(0);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel0;
            _LastLabel.Checked = true;
        }

        private void CmiLabel1_Click(object sender, EventArgs e)
        {
            ChangeLabel(1);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel1;
            _LastLabel.Checked = true;
        }

        private void CmiLabel2_Click(object sender, EventArgs e)
        {
            ChangeLabel(2);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel2;
            _LastLabel.Checked = true;
        }

        private void CmiLabel3_Click(object sender, EventArgs e)
        {
            ChangeLabel(3);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel3;
            _LastLabel.Checked = true;
        }

        private void CmiLabel4_Click(object sender, EventArgs e)
        {
            ChangeLabel(4);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel4;
            _LastLabel.Checked = true;
        }

        private void CmiLabel5_Click(object sender, EventArgs e)
        {
            ChangeLabel(5);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel5;
            _LastLabel.Checked = true;
        }

        private void CmiLabel6_Click(object sender, EventArgs e)
        {
            ChangeLabel(6);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel6;
            _LastLabel.Checked = true;
        }

        private void CmiLabel7_Click(object sender, EventArgs e)
        {
            ChangeLabel(7);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel7;
            _LastLabel.Checked = true;
        }

        private void CmiLabel8_Click(object sender, EventArgs e)
        {
            ChangeLabel(8);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel8;
            _LastLabel.Checked = true;
        }

        private void CmiLabel9_Click(object sender, EventArgs e)
        {
            ChangeLabel(9);
            _LastLabel.Checked = false;
            _LastLabel = CmiLabel9;
            _LastLabel.Checked = true;
        }
        #endregion

        #region 优先级
        private ToolStripMenuItem _LastMajor;
        private ToolStripMenuItem[] _CmiMajors;
        private Image[] _ImgMajors;
        private void CmiMajorP2_Click(object sender, EventArgs e)
        {
            ChangeMajor(2);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorP2;
            _LastMajor.Checked = true;
        }

        private void CmiMajorP1_Click(object sender, EventArgs e)
        {
            ChangeMajor(1);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorP1;
            _LastMajor.Checked = true;
        }

        private void CmiMajor0_Click(object sender, EventArgs e)
        {
            ChangeMajor(0);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajor0;
            _LastMajor.Checked = true;
        }

        private void CmiMajorN1_Click(object sender, EventArgs e)
        {
            ChangeMajor(-1);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorN1;
            _LastMajor.Checked = true;
        }

        private void CmiMajorN2_Click(object sender, EventArgs e)
        {
            ChangeMajor(-2);
            _LastMajor.Checked = false;
            _LastMajor = CmiMajorN2;
            _LastMajor.Checked = true;
        }
        #endregion

        private void CmiMoveto_Click(object sender, EventArgs e)
        {
            CatView view = new CatView(_UserModel);
            view.Init(IlCatTree);
            view.CallBack = new AmonHandler<string>(ChangeCatByKey);
            BeanUtil.CenterToParent(view, this);
            view.ShowDialog(this);
        }

        private void CmiHistory_Click(object sender, EventArgs e)
        {
            LogEdit edit = new LogEdit(this);
            edit.Init(_UserModel, _SafeModel);
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }
        #endregion
        #endregion
        #endregion

        #region 公共方法
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

        public void ShowRec(Key rec)
        {
            _PwdView.ShowData();

            _LastLabel.Checked = false;
            _LastLabel = _CmiLabels[rec.Label];
            _LastLabel.Checked = true;

            _LastMajor.Checked = false;
            _LastMajor = _CmiMajors[rec.Major + 2];
            _LastMajor.Checked = true;
        }
        #endregion

        #region 私有方法
        #region 模式切换
        private void ShowAPro()
        {
            if (_ProView == null)
            {
                _ProView = new APro();
                _ProView.Name = "Pro";
                _ProView.Init(this, _SafeModel, _DataModel, _ViewModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Name == _ProView.Name)
                {
                    return;
                }
                _PwdView.HideView(TpGrid);
            }

            _PwdView = _ProView;
            _PwdView.InitView(TpGrid);

            TmiViewPro.Checked = true;
            TmiViewWiz.Checked = false;
            TmiViewPad.Checked = false;
        }

        private void ShowAWiz()
        {
            if (_WizView == null)
            {
                _WizView = new AWiz();
                _WizView.Name = "Wiz";
                _WizView.Init(this, _SafeModel, _DataModel, _ViewModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Name == _WizView.Name)
                {
                    return;
                }
                _PwdView.HideView(TpGrid);
            }

            _PwdView = _WizView;
            _PwdView.InitView(TpGrid);

            TmiViewPro.Checked = false;
            TmiViewWiz.Checked = true;
            TmiViewPad.Checked = false;
        }

        private void ShowAPad()
        {
            //if (_PadView == null)
            //{
            //    _PadView = new APad();
            //    _PadView.Name = "Pad";
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

        #region 视图调整
        private void SetMenuBarVisible(bool visible)
        {
            TmMenu.Visible = visible;
            TmiMenuBar.Checked = visible;
            TsbMenuBar.Checked = visible;

            _ViewModel.MenuBarVisible = visible;
        }

        private void SetToolBarVisible(bool visible)
        {
            TsTool.Visible = visible;
            TmiToolBar.Checked = visible;
            TsbToolBar.Checked = visible;

            _ViewModel.ToolBarVisible = visible;
        }

        private void SetEchoBarVisible(bool visible)
        {
            SsEcho.Visible = visible;
            TmiEchoBar.Checked = visible;
            TsbEchoBar.Checked = visible;

            _ViewModel.EchoBarVisible = visible;
        }

        private void SetCatTreeVisible(bool visible)
        {
            if (!visible && VSplit.Panel2Collapsed)
            {
                SetNavPaneVisible(false);
            }
            else
            {
                VSplit.Panel1Collapsed = !visible;
                TmiCatView.Checked = visible;

                _ViewModel.CatTreeVisible = visible;
            }
        }

        private void SetKeyListVisible(bool visible)
        {
            if (!visible && VSplit.Panel1Collapsed)
            {
                SetNavPaneVisible(false);
            }
            else
            {
                VSplit.Panel2Collapsed = !visible;
                TmiKeyList.Checked = visible;

                _ViewModel.KeyListVisible = visible;
            }
        }

        private void SetNavPaneVisible(bool visible)
        {
            HSplit.Panel1Collapsed = !visible;
            TmiNavPane.Checked = visible;

            _ViewModel.NavPaneVisible = visible;
        }

        private void SetFindBarVisible(bool visible)
        {
            TpGrid.RowStyles[0].Height = visible ? 32 : 0;
            FbFind.Visible = visible;
            TmiFindBar.Checked = visible;

            _ViewModel.FindBarVisible = visible;
        }
        #endregion

        #region 类别处理
        private void AppendCat()
        {
            CatEdit catEdit = new CatEdit();
            catEdit.CallBackHandler = new AmonHandler<Cat>(AppendCatHandler);
            catEdit.Show(this, new Cat());
        }

        private void AppendCatHandler(Cat cat)
        {
            if (_LastNode == null)
            {
                return;
            }

            cat.Parent = _LastNode.Name;
            _UserModel.DBA.SaveVcs(cat);

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

        private void UpdateCat()
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                Main.ShowAlert("请选择您要更新的类别！");
                TvCatTree.Focus();
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null || cat.Id == "winshineapwd0000")
            {
                return;
            }

            CatEdit catEdit = new CatEdit();
            catEdit.CallBackHandler = new AmonHandler<Cat>(UpdateCatHandler);
            catEdit.Show(this, cat);
        }

        private void UpdateCatHandler(Cat cat)
        {
            TreeNode node = TvCatTree.SelectedNode;

            _UserModel.DBA.SaveVcs(cat);

            node.Text = cat.Text;
            node.ToolTipText = cat.Tips;
            node.ImageKey = cat.Icon;
        }

        private void DeleteCat()
        {
            TreeNode node = TvCatTree.SelectedNode;
            if (node == null)
            {
                Main.ShowAlert("请选择您要删除的类别！");
                TvCatTree.Focus();
                return;
            }

            Cat cat = node.Tag as Cat;
            if (cat == null || cat.Id == "winshineapwd0000")
            {
                return;
            }

            if (node.Nodes.Count > 0)
            {
                Main.ShowAlert("下级类别不为空，不能删除！");
                return;
            }

            if (DialogResult.Yes != Main.ShowConfirm("确认要删除选中的类别吗，此操作将不可恢复？"))
            {
                return;
            }

            IList<Key> recs = _UserModel.DBA.ListKey(cat.Id);
            if (recs.Count > 0)
            {
                Main.ShowAlert("类别数据不为空，不能删除！");
                return;
            }

            _UserModel.DBA.DeleteVcs(cat);

            TreeNode root = node.Parent;
            if (root != null)
            {
                root.Nodes.Remove(node);
            }
        }

        private void ChangeImgByCat(Pwd.Png png)
        {
            if (!CharUtil.IsValidateHash(png.File))
            {
                png.File = "0";
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

            _UserModel.DBA.SaveVcs(cat);
        }
        #endregion

        #region 记录处理
        private void AppendKey()
        {
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            _PwdView.AppendKey();
        }

        private void UpdateKey()
        {
            if (_SafeModel.Key == null || _SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }

            if (!_SafeModel.IsUpdate)
            {
                TreeNode node = TvCatTree.SelectedNode;
                if (node == null)
                {
                    Main.ShowAlert("请选择类别！");
                    TvCatTree.Focus();
                    return;
                }

                Cat cat = node.Tag as Cat;
                if (cat == null)
                {
                    Main.ShowAlert("系统异常，请稍后重试！");
                    return;
                }

                _SafeModel.Key.CatId = cat.Id;
            }

            if (!_PwdView.UpdateKey())
            {
                return;
            }

            if (_SafeModel.IsUpdate && _SafeModel.Key.Backup)
            {
                KeyLog recLog = _SafeModel.Key.ToLog();
                _UserModel.DBA.SaveLog(recLog);
            }
            _SafeModel.Encode();
            _SafeModel.Key.AccessTime = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
            _SafeModel.Modified = false;

            LastOpt();
            _PwdView.ShowInfo();
        }

        private void DeleteKey()
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

        private void ImportKey()
        {
            _SafeModel.Encode();

            _SafeModel.Key.AccessTime = DateTime.Now.ToString(IEnv.DATEIME_FORMAT);
            _UserModel.DBA.SaveVcs(_SafeModel.Key);
        }

        public void ListKey(string catId)
        {
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = "0";
            }

            DoListKey(catId);

            _IsSearch = false;
            _LastHash = catId;
        }

        public void DoListKey(string catId)
        {
            IList<Key> recs = _UserModel.DBA.ListKey(catId);
            InitKey(recs);
        }

        public void FindKey(string meta)
        {
            meta = meta.Trim();
            if (string.IsNullOrEmpty(meta))
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

        private void DoFindKey(string meta)
        {
            IList<Key> recs = _UserModel.DBA.FindKey(meta);
            InitKey(recs);
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

        private void ChangeCatByKey(string catId)
        {
            if (string.IsNullOrEmpty(catId))
            {
                catId = "0";
            }
            if (catId == _SafeModel.Key.CatId)
            {
                return;
            }

            _SafeModel.Key.CatId = catId;
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LastOpt();
        }

        public void ChangeLabel(int label)
        {
            if (label < 0 || label > 9)
            {
                return;
            }

            _SafeModel.Key.Label = label;
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LbKeyList.Refresh();
        }

        public void ChangeMajor(int major)
        {
            if (major < -2 || major > 2)
            {
                return;
            }

            _SafeModel.Key.Major = major;
            _UserModel.DBA.SaveVcs(_SafeModel.Key);

            LbKeyList.Refresh();
        }
        #endregion

        #region 数据同步
        private void DoSync()
        {
            MessageBox.Show("同步功能尚在完善中，敬请期待！");
        }

        private void DoBackup(string file)
        {
            _UserModel.DBA.CloseConnect();
            BeanUtil.DoZip(file, _UserModel.Home);
        }

        private void DoResuma(string file)
        {
        }

        private void LocaleBackup()
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

        private void RemoteBackup()
        {
            MessageBox.Show("远程备份功能尚在完善中，敬请期待！");
        }

        private void LocaleResuma()
        {
            MessageBox.Show("本地恢复功能尚在完善中，敬请期待！");
        }

        private void RemoteResume()
        {
            MessageBox.Show("远程恢复功能尚在完善中，敬请期待！");
        }
        #endregion

        private void ShowHelp()
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

        private void ShowKeys()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MajorKey");
            dt.Columns.Add("Memo");
            dt.Columns.Add("MinorKey");
            dt.Rows.Add("Control N", "添加记录", "");
            dt.Rows.Add("Control S", "保存记录", "");
            dt.Rows.Add("Control R", "删除记录", "");
            dt.Rows.Add("Control F", "快速查找", "");
            dt.Rows.Add("Control L", "锁定窗口", "");
            dt.Rows.Add("Control H", "隐藏窗口", "Control Enter");
            dt.Rows.Add("Control Q", "退出", "");
            dt.Rows.Add("Control U", "选择上一个属性", "Control Up");
            dt.Rows.Add("Control D", "选择下一个属性", "Control Down");
            dt.Rows.Add("Control Shift U", "向上移动属性", "Control Shift Up");
            dt.Rows.Add("Control Shift D", "向下移动属性", "Control Shift Down");
            dt.Rows.Add("Control F1", "切换到专业模式", "");
            dt.Rows.Add("Control F2", "切换到向导模式", "");
            dt.Rows.Add("Control F3", "切换到记事模式", "");
            dt.Rows.Add("Control +", "添加类别", "");
            dt.Rows.Add("Control .", "更新类别", "");
            dt.Rows.Add("Control -", "删除类别", "");
            dt.Rows.Add("Control M", "切换菜单栏显示状态", "");
            dt.Rows.Add("Control T", "切换工具栏显示状态", "");
            dt.Rows.Add("Control E", "切换状态栏显示状态", "");
            dt.Rows.Add("Control G", "切换查找栏显示状态", "");
            dt.Rows.Add("Control K", "切换类别目录显示状态", "");
            dt.Rows.Add("Control P", "切换记录列表显示状态", "");
            dt.Rows.Add("Control J", "切换导航面板显示状态", "");
            dt.Rows.Add("Control A", "切换属性编辑显示状态", "");
            dt.Rows.Add("Control P", "显示或隐藏导航面板", "");
            dt.Rows.Add("Alt C", "复制属性数据到剪贴板", "");
            dt.Rows.Add("Alt U", "应用当前属性变更", "");
            dt.Rows.Add("Alt D", "移除当前属性", "");

            HotKeys keys = new HotKeys();
            keys.KeyList = dt;
            BeanUtil.CenterToParent(keys, this);
            keys.Show(this);
        }

        private void ShowInfo()
        {
            new Info().ShowDialog(this);
        }

        private void LockForm()
        {
            new AuthRc(_UserModel, this).ShowDialog(this);
        }

        private void HideForm()
        {
            if (_SafeModel.Modified)
            {
                if (DialogResult.Yes != Main.ShowConfirm("您有数据尚未保存，确认要隐藏窗口吗？"))
                {
                    return;
                }
            }
            Visible = false;

            _ViewModel.WindowLocX = Location.X;
            _ViewModel.WindowLocY = Location.Y;
            _ViewModel.WindowDimW = Width;
            _ViewModel.WindowDimH = Height;
            _ViewModel.Save();
        }

        private void ExitForm()
        {
            _ViewModel.WindowLocX = Location.X;
            _ViewModel.WindowLocY = Location.Y;
            _ViewModel.WindowDimW = Width;
            _ViewModel.WindowDimH = Height;
            _ViewModel.Save();

            Close();
        }
        #endregion
    }
}
