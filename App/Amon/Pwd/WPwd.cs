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
using Me.Amon.M;
using Me.Amon.Open;
using Me.Amon.Open.V1;
using Me.Amon.Open.V1.App.Pcs;
using Me.Amon.Pcs.V.Dlg;
using Me.Amon.Pwd._Att;
using Me.Amon.Pwd._Cat;
using Me.Amon.Pwd._Key;
using Me.Amon.Pwd._Lib;
using Me.Amon.Pwd._Log;
using Me.Amon.Pwd.M;
using Me.Amon.Pwd.V;
using Me.Amon.Pwd.V.Pad;
using Me.Amon.Pwd.V.Pro;
using Me.Amon.Pwd.V.Wiz;
using Me.Amon.Uc;
using Me.Amon.Util;
using Me.Amon.Uw;
using Thought.vCards;

namespace Me.Amon.Pwd
{
    public partial class WPwd : Form, IApp
    {
        private ICatTree _CatTree;
        private IKeyList _KeyList;
        #region 全局变量
        private Main _Main;
        private UserModel _UserModel;
        private SafeModel _SafeModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private IPwd _PwdView;
        private WPro _ProView;
        private WWiz _WizView;
        private APad _PadView;
        private KeyInfo _KeyInfo;
        private XmlMenu<WPwd> _XmlMenu;
        #endregion

        /// <summary>
        /// 消息等待时间
        /// </summary>
        private int _EchoDelay;

        private bool _Exit;

        #region 构造函数
        public WPwd()
        {
            InitializeComponent();
        }

        public WPwd(Main main, AUserModel userModel)
        {
            _Main = main;
            _UserModel = userModel as UserModel;

            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        private void WPwd_Load(object sender, EventArgs e)
        {
            Init();
        }

        private bool _Inited;
        public void Init()
        {
            if (_Inited)
            {
                return;
            }
            _Inited = true;

            #region 数据模型
            _SafeModel = new SafeModel(_UserModel);
            _SafeModel.Init();
            _DataModel = new DataModel(_UserModel);
            _DataModel.Init();
            _ViewModel = new ViewModel(_UserModel);
            _ViewModel.Init();
            _ViewModel.LoadLayout();
            #endregion

            _KeyList = new KeyList(this, _DataModel, _ViewModel);
            _KeyList.Control.Dock = DockStyle.Fill;
            //_KeyList.Control.Location = new System.Drawing.Point(0, 0);
            _KeyList.Control.Name = "KeyList";
            //_KeyList.Control.Size = new System.Drawing.Size(374, 29);
            //_KeyList.Control.TabIndex = 0;
            _CatTree = new CatTree(this, _DataModel);
            _CatTree.Control.Dock = DockStyle.Fill;
            _CatTree.KeyList = _KeyList;
            UcFind.KeyList = _KeyList;

            #region 系统选单
            _XmlMenu = new XmlMenu<WPwd>(this, _ViewModel);
            if (_XmlMenu.Load(Path.Combine(_UserModel.DatHome, CPwd.XML_MENU)))
            {
                _XmlMenu.GetMenuBar("WPwd", MbMenu);
                _XmlMenu.GetToolBar("WPwd", TbTool);
                ContextMenuStrip CmCat = new ContextMenuStrip();
                _XmlMenu.GetPopMenu("WCat", CmCat);
                _CatTree.PopupMenu = CmCat;

                ContextMenuStrip CmKey = new ContextMenuStrip();
                _XmlMenu.GetPopMenu("WKey", CmKey);
                _KeyList.PopupMenu = CmKey;

                //_XmlMenu.GetPopMenu("WAtt", CmAtt);
                _XmlMenu.GetStrokes("WPwd", this);
                if (_XmlMenu.GetHotkeys("WPwd", this))
                {
                    foreach (var hotkey in _XmlMenu.Hotkeys)
                    {
                        User32.RegisterHotKey(this.Handle, hotkey.Id, (int)hotkey.Modifiers, (int)hotkey.Code);
                    }
                }
            }
            #endregion

            LoadLayout();

            ShowInfo();

            _CatTree.Init(null);

            // 当前时间
            UcTimer.Start();
            _DataModel.Start();
            _DataModel.AppendHandler(new AmonHandler<string>(ShowEcho));
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
            if (_EchoDelay > 0)
            {
                return;
            }

            if (SbEcho.InvokeRequired)
            {
                SbEcho.Invoke(new MethodInvoker(() => TlEcho.Text = message));
            }
            else
            {
                TlEcho.Text = message;
            }
            //TlEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            TlEcho.Text = message;
            _EchoDelay = delay;
        }

        public new bool Focus()
        {
            return UcFind.Focus();
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

            foreach (var hotkey in _XmlMenu.Hotkeys)
            {
                User32.UnregisterHotKey(this.Handle, hotkey.Id);
            }

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
            _DataModel.Suspend();
            BeanUtil.DoZip(Path.Combine(_UserModel.BakHome, file), _UserModel.DatHome);
            return true;
        }
        #endregion

        #region 事件处理
        private void WPwd_Resize(object sender, EventArgs e)
        {
            //if (!Visible)
            //{
            //    return;
            //}
            //if (Width < 360 || Height < 360)
            //{
            //    ShowAPad();
            //}
            //if (WindowState == FormWindowState.Minimized)
            //{
            //    Visible = false;
            //}
        }

        private void WPwd_FormClosing(object sender, FormClosingEventArgs e)
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
                    foreach (var hotkey in _XmlMenu.Hotkeys)
                    {
                        if (t == hotkey.Id)
                        {
                            IntPtr hWnd = User32.GetForegroundWindow();
                            if (hWnd != IntPtr.Zero && hWnd != this.Handle)
                            {
                                DoFillData();
                            }
                        }
                    }
                }
            }
            base.WndProc(ref m);
        }

        /// <summary>
        /// 时钟信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UcTimer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TlTime.Text = now.ToString(CApp.DATEIME_FORMAT);
            if (_EchoDelay > 0)
            {
                _EchoDelay -= 1;
            }
        }

        private VoidHandler _Handler;
        private void StartWork(VoidHandler handler)
        {
            _Handler = handler;
            if (!BgWorker.IsBusy)
            {
                BgWorker.RunWorkerAsync();
            }
        }

        private void BgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (_Handler != null)
            {
                _Handler();
            }
        }

        private void TlEcho_DoubleClick(object sender, EventArgs e)
        {
            _CatTree.TaskSelected();
        }

        /// <summary>
        /// 默认布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TlLayout0_Click(object sender, EventArgs e)
        {
            if (_ViewModel.LayoutStyle == CPwd.LAYOUT_STYLE_0)
            {
                return;
            }

            ShowLayout0();
            HideLayout(_ViewModel.LayoutStyle);
            _ViewModel.LayoutStyle = CPwd.LAYOUT_STYLE_0;
        }

        /// <summary>
        /// 紧凑布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TlLayout1_Click(object sender, EventArgs e)
        {
            if (_ViewModel.LayoutStyle == CPwd.LAYOUT_STYLE_1)
            {
                return;
            }

            ShowLayout1();
            HideLayout(_ViewModel.LayoutStyle);
            _ViewModel.LayoutStyle = CPwd.LAYOUT_STYLE_1;
        }

        /// <summary>
        /// 多列布局
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TlLayout2_Click(object sender, EventArgs e)
        {
            if (_ViewModel.LayoutStyle == CPwd.LAYOUT_STYLE_2)
            {
                return;
            }

            ShowLayout2();
            HideLayout(_ViewModel.LayoutStyle);
            _ViewModel.LayoutStyle = CPwd.LAYOUT_STYLE_2;
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

        public void ShowIcoSeeker(string rootDir, AmonHandler<Png> handler)
        {
            KeyIcon seeker = new KeyIcon(_DataModel, rootDir);
            seeker.IcoSize = 24;
            seeker.CallBackHandler = handler;
            BeanUtil.CenterToParent(seeker, this);
            seeker.ShowDialog(this);
        }

        public void ShowPngSeeker()
        {
        }

        public bool CanChange()
        {
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您当前的数据尚未保存，要丢弃吗？"))
            {
                return false;
            }
            return true;
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

        public void ShowKey()
        {
            if (_SafeModel.Key != null)
            {
                DoShowKey(_SafeModel.Key);
            }
        }

        public void ShowKey(Key key)
        {
            if (key != null)
            {
                _SafeModel.Key = key;
                _SafeModel.Decode();

                DoShowKey(key);
            }
        }

        private void DoShowKey(Key key)
        {
            if (_PwdView == _KeyInfo)
            {
                if (_ViewModel.Pattern == CPwd.PATTERN_WIZ)
                {
                    ShowAWiz();
                }
                else if (_ViewModel.Pattern == CPwd.PATTERN_PRO)
                {
                    ShowAPro();
                }
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

        /// <summary>
        /// 自动填充脚本事件
        /// </summary>
        public void FillData()
        {
            if (_SafeModel.Key == null || string.IsNullOrEmpty(_SafeModel.Key.Script))
            {
                return;
            }

            var state = WindowState;
            WindowState = FormWindowState.Minimized;
            Thread.Sleep(80);
            if (!string.IsNullOrWhiteSpace(_SafeModel.Key.Window))
            {
                IntPtr hWnd = User32.GetForegroundWindow();
                if (hWnd != IntPtr.Zero)
                {
                    string[] arr = _SafeModel.Key.Window.Split(',');
                    string clz = arr[0].Trim();
                    string ctl = arr.Length > 1 ? arr[1].Trim() : null;
                    IntPtr hCtl = User32.FindWindowEx(hWnd, IntPtr.Zero, clz, ctl);
                    if (hCtl != IntPtr.Zero)
                    {
                        User32.SetFocus(hCtl);
                        Thread.Sleep(10);
                    }
                }
            }

            DoFillData();

            WindowState = state;
            Activate();
        }

        /// <summary>
        /// 快捷键方式填充
        /// </summary>
        private void DoFillData()
        {
            if (_SafeModel.Key == null || string.IsNullOrEmpty(_SafeModel.Key.Script))
            {
                return;
            }

            string s1;//原字符
            string s2;//大写字符
            string script = _SafeModel.Key.Script;
            int i1 = 0;//结束位置
            int i2 = 0;//下一起点位置
            Match match = Regex.Match(script, "{[^}]*}");
            while (match.Success)
            {
                i2 = match.Index;
                if (i2 > i1)
                {
                    s1 = script.Substring(i1, i2 - i1);
                    Thread.Sleep(300);// 执行等待
                    SendKeys.Send(s1);//已有字符
                }

                s1 = match.Value;
                s2 = s1.ToUpper();
                if (s2 != "{TAB}"
                    && s2 != "{BACKSPACE}"
                    && s2 != "{BKSP}"
                    && s2 != "{BS}"
                    && s2 != "{ENTER}")
                {
                    s2 = TrimFillData(s1);
                }
                Thread.Sleep(300);// 执行等待
                SendKeys.SendWait(s2);
                SendKeys.Flush();

                i1 = i2 + s1.Length;
                match = match.NextMatch();
            }

            if (i1 < script.Length)
            {
                s1 = script.Substring(i1);
                Thread.Sleep(300);// 执行等待
                SendKeys.Send(s1);
            }
        }

        /// <summary>
        /// 用户手动填充事件
        /// </summary>
        /// <param name="data"></param>
        public void FillData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return;
            }

            IntPtr hWnd = User32.NextWindow(Handle);
            if (hWnd == IntPtr.Zero)
            {
                return;
            }
            User32.BringWindowToTop(hWnd);
            Thread.Sleep(100);

            SendKeys.SendWait(data);
            Thread.Sleep(100);
            Activate();
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
                return _CatTree.SelectedCat;
            }
        }

        /// <summary>
        /// 添加类别
        /// </summary>
        /// <param name="cat"></param>
        public void AppendCat(Cat cat)
        {
            _CatTree.AppendCat(cat);
        }

        /// <summary>
        /// 更新类别
        /// </summary>
        /// <param name="cat"></param>
        public void UpdateCat(Cat cat)
        {
            _CatTree.UpdateCat(cat);
        }

        public void DeleteCat()
        {
            _CatTree.DeleteCat();
        }

        public void CatMoveUp()
        {
            _CatTree.SortUp();
        }

        public void CatMoveDown()
        {
            _CatTree.SortDown();
        }

        /// <summary>
        /// 提升一级
        /// </summary>
        public void CatPromotion()
        {
            _CatTree.CatPromotion();
        }

        /// <summary>
        /// 下降一级
        /// </summary>
        public void CatDemotion()
        {
            _CatTree.CatDemotion();
        }

        public void ChangeCatIcon()
        {
            Cat cat = _CatTree.SelectedCat;
            if (cat == null || cat.Id == CPwd.DEF_CAT_ID)
            {
                return;
            }

            CatIcon editor = new CatIcon(_UserModel, _DataModel.CatDir);
            editor.InitOnce(16);
            editor.CallBackHandler = new AmonHandler<Png>(ChangeCatIcon);
            BeanUtil.CenterToParent(editor, this);
            editor.ShowDialog(this);
        }

        public void ChangeCatIcon(Png png)
        {
            _CatTree.ChangeIcon(png);
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

            if (_PwdView != _KeyInfo)
            {
                _PwdView.AppendKey();
                return;
            }

            if (_ViewModel.Pattern == CPwd.PATTERN_WIZ)
            {
                ShowAWiz();
                _WizView.AppendKey();
                return;
            }
            if (_ViewModel.Pattern == CPwd.PATTERN_PRO)
            {
                ShowAPro();
                _ProView.AppendKey();
                return;
            }
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
                if (KeyGuidVisible && CatTreeVisible)
                {
                    Cat cat = SelectedCat;
                    if (cat == null)
                    {
                        Main.ShowAlert("请选择类别！");
                        //TvCatTree.Focus();
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
                _DataModel.SaveLog(keyLog);
            }
            _SafeModel.Encode();
            _SafeModel.Key.AccessTime = DateTime.Now.ToString(CApp.DATEIME_FORMAT);
            _DataModel.SaveVcs(_SafeModel.Key);
            if (_SafeModel.Key.Gtd != null)
            {
                _SafeModel.Key.Gtd.RefId = _SafeModel.Key.Id;
                _DataModel.SaveVcs(_SafeModel.Key.Gtd);
            }
            _SafeModel.Modified = false;

            ShowInfo();

            _KeyList.LastKeys();

            _SafeModel.Key = null;
            _KeyList.SelectedKey = null;
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

            _KeyList.RemoveSelected();

            _DataModel.RemoveVcs(_SafeModel.Key);
            _SafeModel.Modified = false;
            _SafeModel.Key = null;
            ShowInfo();
        }

        public void ListGtdExpired()
        {
        }

        public void ListGtd(DateTime time, int seconds)
        {

        }

        public void ListKey(string catId)
        {
            if (!CharUtil.IsValidateHash(catId))
            {
                catId = CPwd.DEF_CAT_ID;
            }

            _KeyList.ListKeys(catId);
        }

        public void FindKey(string meta)
        {
            _KeyList.FindKeys(meta);
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
            _DataModel.SaveVcs(_SafeModel.Key);

            //Key key = LbKeyList.SelectedItem as Key;
            //if (key == null || key.Id != _SafeModel.Key.Id)
            //{
            //    return;
            //}
            //LbKeyList.Items.RemoveAt(LbKeyList.SelectedIndex);
        }

        /// <summary>
        /// 修改当前口令的标签为指定标签
        /// </summary>
        /// <param name="label"></param>
        public void ChangeKeyLabel(int label)
        {
            _KeyList.ChangeKeyLabel(label);
        }

        /// <summary>
        /// 修改当前口令的重要程度为指定级别
        /// </summary>
        /// <param name="major"></param>
        public void ChangeKeyMajor(int major)
        {
            _KeyList.ChangeKeyMajor(major);
        }

        public void KeyMoveto()
        {
            CatDialog view = new CatDialog(_DataModel);
            view.Init(_CatTree.ImageList);
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
            LogViewer edit = new LogViewer(this);
            edit.Init(_DataModel, _SafeModel);
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
                _ProView = new WPro();
                _ProView.Model = CPwd.PATTERN_PRO;
                _ProView.Init(this, _UserModel, _SafeModel, _DataModel, _ViewModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Model == _ProView.Model)
                {
                    return;
                }
                _PwdView.HideView(ScData.Panel2);
            }

            _PwdView = _ProView;
            _PwdView.InitView(ScData.Panel2);
            DoShowKey(_SafeModel.Key);
            _ViewModel.Pattern = CPwd.PATTERN_PRO;

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
                _WizView = new WWiz(this, _UserModel, _SafeModel);
                _WizView.Model = CPwd.PATTERN_WIZ;
                _WizView.Init(_DataModel, _ViewModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Model == _WizView.Model)
                {
                    return;
                }
                _PwdView.HideView(ScData.Panel2);
            }

            _PwdView = _WizView;
            _PwdView.InitView(ScData.Panel2);
            DoShowKey(_SafeModel.Key);
            _ViewModel.Pattern = CPwd.PATTERN_WIZ;

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
                _PadView.Model = CPwd.PATTERN_PAD;
                _PadView.Init(this, _SafeModel, _DataModel);
                _PadView.Dock = DockStyle.Fill;
            }

            if (_PwdView != null)
            {
                if (_PwdView.Model == _PadView.Model)
                {
                    return;
                }
                _PwdView.HideView(ScData.Panel2);
            }

            //PlMain.Controls.Remove(TcTool);
            //PlMain.Controls.Add(_PadView);
            _ViewModel.Pattern = CPwd.PATTERN_PAD;
        }

        public void ShowInfo()
        {
            if (_KeyInfo == null)
            {
                _KeyInfo = new KeyInfo(_SafeModel);
                _KeyInfo.Model = CPwd.PATTERN_INF;
                _KeyInfo.Init(_DataModel);
            }

            if (_PwdView != null)
            {
                if (_PwdView.Model == _KeyInfo.Model)
                {
                    return;
                }
                _PwdView.HideView(ScData.Panel2);
            }

            _PwdView = _KeyInfo;
            _PwdView.InitView(ScData.Panel2);
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
                return _ViewModel.MenuBarVisible;
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
                return _ViewModel.ToolBarVisible;
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
                return _ViewModel.EchoBarVisible;
            }
            set
            {
                SbEcho.Visible = value;
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
                return UcFind.Visible;
            }
            set
            {
                UcFind.Visible = value;
                _ViewModel.FindBarVisible = value;
            }
        }

        /// <summary>
        /// 导航面板是否可见
        /// </summary>
        public bool KeyGuidVisible
        {
            get
            {
                return _ViewModel.KeyGuidVisible;
            }
            set
            {
                _ViewModel.KeyGuidVisible = value;
                ScMain.Panel1Collapsed = !value;
            }
        }

        /// <summary>
        /// 类别目录是否可见
        /// </summary>
        public bool CatTreeVisible
        {
            get
            {
                return _ViewModel.CatTreeVisible;
            }
            set
            {
                _ViewModel.CatTreeVisible = value;
                switch (_ViewModel.LayoutStyle)
                {
                    case CPwd.LAYOUT_STYLE_0:
                        ScGuid.Panel1Collapsed = !value;
                        break;
                    case CPwd.LAYOUT_STYLE_1:
                        ScMain.Panel1Collapsed = !value;
                        break;
                    case CPwd.LAYOUT_STYLE_2:
                        ScMain.Panel1Collapsed = !value;
                        break;
                    default:
                        break;
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
                return _ViewModel.KeyListVisible;
            }
            set
            {
                _ViewModel.KeyListVisible = value;
                switch (_ViewModel.LayoutStyle)
                {
                    case CPwd.LAYOUT_STYLE_0:
                        ScGuid.Panel2Collapsed = !value;
                        break;
                    case CPwd.LAYOUT_STYLE_1:
                        ScData.Panel1Collapsed = !value;
                        break;
                    case CPwd.LAYOUT_STYLE_2:
                        ScData.Panel1Collapsed = !value;
                        break;
                    default:
                        break;
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
            UcFind.Visible = true;
            UcFind.Focus();
        }

        /// <summary>
        /// 同步
        /// </summary>
        public void SyncData()
        {
            MessageBox.Show("同步功能尚在完善中，敬请期待！");
        }

        private MPwd _MPwd;
        /// <summary>
        /// 本地备份
        /// </summary>
        public void NativeBackup()
        {
            // 是否保存
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }
            if (string.IsNullOrWhiteSpace(_MPwd.NsPath) && !NativeConfig())
            {
                return;
            }

            StartWork(new VoidHandler(DoNativeBackup));
            Main.ShowWaiting("数据备份中，请稍候……");
        }

        private void DoNativeBackup()
        {
            _KeyList.Clear();

            if (!Directory.Exists(_MPwd.NsPath))
            {
                Directory.CreateDirectory(_MPwd.NsPath);
            }
            string file = DateTime.Now.ToString("yyyyMMddHHmmss") + ".apbak";

            _DataModel.Suspend();
            BeanUtil.DoZip(Path.Combine(_MPwd.NsPath, file), _UserModel.DatHome);
            _DataModel.Resume();

            _KeyList.LastKeys();

            Main.HideWaiting();
        }

        /// <summary>
        /// 本地恢复
        /// </summary>
        public void NativeResume()
        {
            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }

            if (string.IsNullOrWhiteSpace(_MPwd.NsPath))
            {
                Main.ShowAlert("您尚未配置本地备份路径！");
                return;
            }

            if (!Directory.Exists(_MPwd.NsPath))
            {
                Main.ShowAlert("本地备份路径不存在，请确认配置是否正确！");
                return;
            }

            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(this, "密码箱备份文件|*.apbak", "", _MPwd.NsPath, false))
            {
                return;
            }

            StartWork(new VoidHandler(DoNativeBackup));
            Main.ShowWaiting("数据恢复中，请稍候……");
        }

        private void DoNativeResume()
        {
            SaveData();
            _DataModel.Resume();

            BeanUtil.UnZip(Main.OpenFileDialog.FileName, _UserModel.DatHome);
            Main.ShowAlert("数据恢复成功，请重新启动软件！");
            _Main.ExitSystem();
        }

        public bool NativeConfig()
        {
            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择本地备份路径：";
            dialog.SelectedPath = _MPwd.NsPath;
            if (DialogResult.OK != dialog.ShowDialog(this))
            {
                return false;
            }

            _MPwd.NsPath = dialog.SelectedPath;
            _DataModel.SaveMPwd(_MPwd);
            return true;
        }

        /// <summary>
        /// 远程备份
        /// </summary>
        public void RemoteBackup()
        {
            // 是否保存
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }
            // 远程配置
            if (string.IsNullOrWhiteSpace(_MPwd.CsAuth) && !RemoteConfig())
            {
                return;
            }

            StartWork(new VoidHandler(DoRemoteBackup));
            Main.ShowWaiting("数据备份中，请稍候……");
        }

        private void DoRemoteBackup()
        {
            string path = _MPwd.NsPath;
            if (string.IsNullOrWhiteSpace(path))
            {
                path = Path.GetTempPath();
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            var client = CreateClient();

            _KeyList.Clear();
            string file = DateTime.Now.ToString("yyyyMMddHHmmss") + ".apbak";
            path = Path.Combine(path, file);

            _DataModel.Suspend();
            BeanUtil.DoZip(path, _UserModel.DatHome);
            _DataModel.Resume();

            var task = client.NewUploadTask();
            task.FileStream = File.OpenRead(path);
            task.File = file;
            task.FileName = file;
            task.FileSize = task.FileStream.Length;
            task.Meta = '/' + file;
            task.MetaName = file;
            task.Run();

            Main.HideWaiting();
        }

        /// <summary>
        /// 远程恢复
        /// </summary>
        public void RemoteResume()
        {
            // 是否保存
            if (_SafeModel.Modified && DialogResult.Yes != Main.ShowConfirm("您的数据已修改，确认要丢弃吗？"))
            {
                return;
            }

            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }
            // 远程配置
            if (string.IsNullOrWhiteSpace(_MPwd.CsAuth) && !RemoteConfig())
            {
                return;
            }

            var client = CreateClient();
            var metas = client.ListMeta("/");
            if (metas == null || metas.Count < 1)
            {
                return;
            }

            PcsViewer viewer = new PcsViewer(metas);
            if (DialogResult.OK != viewer.ShowDialog(this))
            {
                return;
            }
            var meta = viewer.SelectedMeta;
            var file = Path.Combine(Path.GetTempPath(), meta.GetMetaName());
            var task = client.NewDownloadTask();
            task.Meta = meta.GetMeta();
            task.MetaName = meta.GetMetaName();
            task.MetaSize = meta.GetSize();
            task.File = file;
            task.FileName = task.MetaName;
            task.FileStream = new FileStream(file, FileMode.Create);
            task.Start();
        }

        public bool RemoteConfig()
        {
            var client = CreateClient();
            if (!client.Verify())
            {
                return false;
            }

            var account = client.Account();
            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }
            _MPwd.CsType = "kuaipan";
            _MPwd.CsAuth = client.Token.oauth_token;
            _MPwd.CsUser = account.Name;
            _DataModel.SaveMPwd(_MPwd);
            return true;
        }

        private KuaipanClient CreateClient()
        {
            if (_MPwd == null)
            {
                _MPwd = _DataModel.ReadMPwd();
            }
            OAuthConsumer consumer = new OAuthConsumer();
            consumer.consumer_key = "xcLegJ8HLq7ZoQ0U";
            consumer.consumer_secret = "psaBwFH0Z0r2PEPI";

            OAuthTokenV1 token = new OAuthTokenV1();
            token.oauth_token = _MPwd.CsAuth;
            KuaipanClient client = new KuaipanClient(consumer, token, false);
            return client;
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

            Cat cat = _CatTree.SelectedCat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要导出的类别！");
                _CatTree.Focus();
                return;
            }

            IList<Key> keys = _DataModel.ListKey(cat.Id);
            if (keys.Count < 1)
            {
                Main.ShowAlert("当前类别下没有记录！");
                _CatTree.Focus();
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
                writer.WriteLine("WPwd-2");
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

            Cat cat = _CatTree.SelectedCat;
            if (cat == null)
            {
                Main.ShowAlert("请选择您要导出的类别！");
                _CatTree.Focus();
                return;
            }

            IList<Key> keys = _DataModel.ListKey(cat.Id);
            if (keys.Count < 1)
            {
                Main.ShowAlert("当前类别下没有记录！");
                _CatTree.Focus();
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
                    writer.WriteElementString("App", "WPwd");
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

            var catId = CPwd.DEF_CAT_ID;
            if (KeyGuidVisible && CatTreeVisible)
            {
                Cat cat = _CatTree.SelectedCat;
                if (cat == null)
                {
                    Main.ShowAlert("请选择您要导入的类别！");
                    _CatTree.Focus();
                    return;
                }
                catId = cat.Id;
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
                if ("WPwd-1" != ver && "WPwd-2" != ver)
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

                        _SafeModel.Key.CatId = catId;
                        DoImportKey();
                        suc += 1;
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            _KeyList.ListKeys(catId);
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

            var catId = CPwd.DEF_CAT_ID;
            if (KeyGuidVisible && CatTreeVisible)
            {
                Cat cat = _CatTree.SelectedCat;
                if (cat == null)
                {
                    Main.ShowAlert("请选择您要导入的类别！");
                    _CatTree.Focus();
                    return;
                }
                catId = cat.Id;
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
            if (!reader.ReadToFollowing("App") || reader.ReadElementContentAsString() != "WPwd")
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

                _SafeModel.Key.CatId = catId;
                DoImportKey();
                suc += 1;
            }
            reader.Close();
            stream.Close();

            _KeyList.ListKeys(catId);
            _SafeModel.Key = null;

            Main.ShowAlert(string.Format("数据导入结果：{0}成功，{1}失败！", suc, err));
            //ShowEcho(string.Format("", suc, err));
        }

        /// <summary>
        /// 导入VCF数据
        /// </summary>
        public void ImportVcf()
        {
            if (_SafeModel.Modified && DialogResult.Yes == Main.ShowConfirm("当前记录已被修改，要保存吗？"))
            {
                return;
            }

            var catId = CPwd.DEF_CAT_ID;
            if (KeyGuidVisible && CatTreeVisible)
            {
                Cat cat = _CatTree.SelectedCat;
                if (cat == null)
                {
                    Main.ShowAlert("请选择您要导入的类别！");
                    _CatTree.Focus();
                    return;
                }
                catId = cat.Id;
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
            guid.Data = catId;
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
            _KeyList.ListKeys(catId);
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

            var catId = CPwd.DEF_CAT_ID;
            if (KeyGuidVisible && CatTreeVisible)
            {
                Cat cat = _CatTree.SelectedCat;
                if (cat == null)
                {
                    Main.ShowAlert("请选择您要导入的类别！");
                    _CatTree.Focus();
                    return;
                }
                catId = cat.Id;
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
                        if (!_SafeModel.ImportByOld2(line, "2"))
                        {
                            err += 1;
                            line = reader.ReadLine();
                            continue;
                        }

                        _SafeModel.Key.CatId = catId;
                        DoImportKey();
                        suc += 1;
                    }
                    line = reader.ReadLine();
                }
                reader.Close();
            }

            _KeyList.ListKeys(catId);
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
            LibEditer edit = new LibEditer(_DataModel);
            edit.Init(_DataModel);
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }

        public void ShowUdcEdit()
        {
            UdcEditor edit = new UdcEditor(_DataModel);
            edit.Init(new Udc());
            BeanUtil.CenterToParent(edit, this);
            edit.Show(this);
        }

        public void ShowIcoEdit()
        {
            KeyIcon edit = new KeyIcon(_DataModel, _DataModel.KeyDir);
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
                Process.Start("http://amon.me/");
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
            foreach (Stroke<WPwd> stroke in _XmlMenu.Strokes)
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
        private void DoImportKey()
        {
            if (_SafeModel.Count < Att.HEAD_SIZE)
            {
                return;
            }

            _SafeModel.Encode();

            _SafeModel.Key.AccessTime = DateTime.Now.ToString(CApp.DATEIME_FORMAT);
            _DataModel.SaveVcs(_SafeModel.Key);
        }
        #endregion

        #region 布局管理
        /// <summary>
        /// 布局加载
        /// </summary>
        public void LoadLayout()
        {
            this.TlLayout0.Image = _ViewModel.GetImage("view-layout0");
            this.TlLayout1.Image = _ViewModel.GetImage("view-layout1");
            this.TlLayout2.Image = _ViewModel.GetImage("view-layout2");

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
            SbEcho.Visible = _ViewModel.EchoBarVisible;

            UcFind.Visible = _ViewModel.FindBarVisible;

            ScMain.Panel1Collapsed = !_ViewModel.KeyGuidVisible;
            ScMain.SplitterDistance = _ViewModel.KeyGuidWidth;

            ScGuid.Panel1.Controls.Add(_CatTree.Control);
            ScGuid.Panel1Collapsed = !_ViewModel.CatTreeVisible;
            ScGuid.SplitterDistance = _ViewModel.CatTreeHeight;

            switch (_ViewModel.LayoutStyle)
            {
                case CPwd.LAYOUT_STYLE_0:
                    ShowLayout0();
                    break;
                case CPwd.LAYOUT_STYLE_1:
                    ShowLayout1();
                    break;
                case CPwd.LAYOUT_STYLE_2:
                    ShowLayout2();
                    break;
                default:
                    _ViewModel.LayoutStyle = CPwd.LAYOUT_STYLE_0;
                    ShowLayout0();
                    break;
            }
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
            _ViewModel.EchoBarVisible = SbEcho.Visible;

            _ViewModel.FindBarVisible = UcFind.Visible;

            _ViewModel.KeyGuidWidth = ScMain.SplitterDistance;

            _ViewModel.CatTreeHeight = ScGuid.SplitterDistance;
            switch (_ViewModel.LayoutStyle)
            {
                case CPwd.LAYOUT_STYLE_0:
                    break;
                case CPwd.LAYOUT_STYLE_1:
                    _ViewModel.KeyListHeight = ScData.SplitterDistance;
                    break;
                case CPwd.LAYOUT_STYLE_2:
                    _ViewModel.KeyListWidth = ScData.SplitterDistance;
                    break;
                default:
                    _ViewModel.LayoutStyle = CPwd.LAYOUT_STYLE_0;
                    break;
            }

            _ViewModel.SaveLayout();
        }

        private void HideLayout(int layout)
        {
            switch (layout)
            {
                case CPwd.LAYOUT_STYLE_0:
                    TlLayout0.Checked = false;
                    break;
                case CPwd.LAYOUT_STYLE_1:
                    TlLayout1.Checked = false;
                    break;
                case CPwd.LAYOUT_STYLE_2:
                    TlLayout2.Checked = false;
                    break;
            }
        }

        private void ShowLayout0()
        {
            ScGuid.Panel2.Controls.Add(_KeyList.Control);
            ScGuid.SplitterDistance = _ViewModel.CatTreeHeight;
            ScGuid.Panel2Collapsed = !_ViewModel.KeyListVisible;

            ScData.Panel1Collapsed = true;
            TlLayout0.Checked = true;
        }

        private void ShowLayout1()
        {
            ScData.Orientation = Orientation.Horizontal;

            ScData.Panel1.Controls.Add(_KeyList.Control);
            ScData.SplitterDistance = _ViewModel.KeyListHeight;
            ScData.Panel1Collapsed = !_ViewModel.KeyListVisible;

            ScGuid.Panel2Collapsed = true;
            TlLayout1.Checked = true;
        }

        private void ShowLayout2()
        {
            ScData.Orientation = Orientation.Vertical;

            ScData.Panel1.Controls.Add(_KeyList.Control);
            ScData.SplitterDistance = _ViewModel.KeyListWidth;
            ScData.Panel1Collapsed = !_ViewModel.KeyListVisible;

            ScGuid.Panel2Collapsed = true;
            TlLayout2.Checked = true;
        }
        #endregion
    }
}
