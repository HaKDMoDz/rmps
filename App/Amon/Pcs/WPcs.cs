using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Me.Amon.Auth;
using Me.Amon.Http;
using Me.Amon.M;
using Me.Amon.Open;
using Me.Amon.Open.PC;
using Me.Amon.Open.V1.App.Pcs;
using Me.Amon.Pcs.M;
using Me.Amon.Pcs.V;
using Me.Amon.Uc;

namespace Me.Amon.Pcs
{
    public partial class WPcs : Form, IApp
    {
        private Main _Main;
        private UserModel _UserModel;
        private DataModel _DataModel;
        private ViewModel _ViewModel;
        private XmlMenu<WPcs> _XmlMenu;
        private PcsList _PcsList;
        private PcsView _CurView;
        private TabPage _DefPage;
        private List<TaskInfo> _Threads;
        private List<ITaskViewer> _Viewers;
        private int _MaxThreads = 1;
        private int _CurThreads = 0;

        #region 构造函数
        public WPcs()
        {
            InitializeComponent();
        }

        public WPcs(Main main, AUserModel userModel)
        {
            _Main = main;
            _UserModel = userModel as UserModel;

            _DataModel = new DataModel(userModel);
            _DataModel.Init();

            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;
            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        public void Init()
        {
            _ViewModel = new ViewModel(_UserModel);
            _ViewModel.LoadLayout();

            #region 系统选单
            _XmlMenu = new XmlMenu<WPcs>(this, _ViewModel);
            if (_XmlMenu.Load(Path.Combine(_UserModel.DatHome, CPcs.XML_MENU)))
            {
                _XmlMenu.GetMenuBar("WPcs", MbMenu);
                _XmlMenu.GetToolBar("WPcs", TbTool);
                PopupMenu = new ContextMenuStrip();
                _XmlMenu.GetPopMenu("WPcs", PopupMenu);
                _XmlMenu.GetStrokes("WPcs", this);
            }
            #endregion

            string path = Path.Combine(_UserModel.SysHome, "Pcs");
            if (Directory.Exists(path))
            {
                string key;
                foreach (string file in Directory.GetFiles(path, "*16.png"))
                {
                    key = Path.GetFileNameWithoutExtension(file);
                    key = key.Substring(0, key.Length - 2);
                    IlPcsList.Images.Add(key, Image.FromFile(file));
                }
            }

            _DefPage = new TabPage();
            _DefPage.Text = "首页";
            _DefPage.ImageKey = "main";
            //_DefPage.Location = new System.Drawing.Point(4, 23);
            //_DefPage.Padding = new System.Windows.Forms.Padding(3);
            //_DefPage.Size = new System.Drawing.Size(604, 300);
            _PcsList = new PcsList(this, _UserModel, _DataModel);
            _PcsList.Init();
            _PcsList.Dock = DockStyle.Fill;
            _DefPage.Controls.Add(_PcsList);
            TcMeta.TabPages.Add(_DefPage);

            _Threads = new List<TaskInfo>();
            _Viewers = new List<ITaskViewer>();
        }

        #region 接口实现
        public int AppId { get; set; }

        public Form Form { get { return this; } }

        public void ShowTips(Control control, string caption)
        {
            TtTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            TlEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
        }

        public bool CanExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 公共函数
        public PcsView LastView { get; set; }

        public EPcs Operation { get; set; }

        public ContextMenuStrip PopupMenu { get; set; }

        public bool TaskVisible
        {
            get
            {
                return !ScMain.Panel2Collapsed;
            }
            set
            {
                bool b = !value;
                ScMain.Panel2Collapsed = b;
                if (b)
                {
                    _Viewers.Remove(UcTaskList);
                }
                else
                {
                    _Viewers.Add(UcTaskList);
                    UcTaskList.ShowTask(_Threads);
                }
            }
        }

        public void ChangeTaskVisible()
        {
            bool b = !ScMain.Panel2Collapsed;
            ScMain.Panel2Collapsed = b;

            if (b)
            {
                _Viewers.Remove(UcTaskList);
            }
            else
            {
                _Viewers.Add(UcTaskList);
                UcTaskList.ShowTask(_Threads);
            }
        }

        public void SetPasteEnabled()
        {
            var group = _XmlMenu.GetGroup("paste-meta-enabled");
            if (group != null)
            {
                group.Enabled(Operation != EPcs.None);
            }
        }

        public void SetEnabled(string name, bool enabled)
        {
            var group = _XmlMenu.GetGroup(name);
            if (group != null)
            {
                group.Enabled(enabled);
            }
        }

        public void SetVisible(string name, bool visible)
        {
            var group = _XmlMenu.GetGroup(name);
            if (group != null)
            {
                group.Visible(visible);
            }
        }

        public void CreatePcs()
        {
            _PcsList.CreatePcs();
        }

        public void DeletePcs()
        {
            _PcsList.DeletePcs();
        }

        public void OpenPcs(MPcs mPcs)
        {
            switch (mPcs.ServerType)
            {
                case "native":
                    NewNative(mPcs);
                    break;
                case "kuaipan":
                    NewKuaipan(mPcs);
                    break;
                default:
                    break;
            }
        }

        private int NativeIndex = 0;
        private void NewNative(MPcs mPcs)
        {
            var client = new NativeClient();

            TabPage ntp = new TabPage();
            ntp.Text = NativeIndex < 1 ? "本地" : string.Format("本地 ({0})", NativeIndex);
            ntp.ImageKey = CPcs.PCS_TYPE_NATIVE;
            TcMeta.TabPages.Add(ntp);

            var pcs = new PcsView(this, mPcs, client, _UserModel, _DataModel);
            pcs.Init();
            pcs.MetaUri = UcUri;
            pcs.Dock = DockStyle.Fill;
            ntp.Controls.Add(pcs);

            TcMeta.SelectedTab = ntp;
            NativeIndex += 1;
        }

        private void NewKuaipan(MPcs mPcs)
        {
            var token = new Me.Amon.Open.V1.OAuthTokenV1();
            token.oauth_token = mPcs.Token;
            token.oauth_token_secret = mPcs.TokenSecret;
            token.UserId = mPcs.UserId;
            KuaipanClient client = new KuaipanClient(OAuthConsumer.KuaipanConsumer(), token, true);
            if (token.oauth_token.Length != 24 && token.oauth_token_secret.Length != 32)
            {
                client.Verify();
            }

            TabPage ntp = new TabPage();
            ntp.Text = mPcs.UserName;
            ntp.ImageKey = CPcs.PCS_TYPE_KUAIPAN;
            TcMeta.TabPages.Add(ntp);

            var pcs = new PcsView(this, mPcs, client, _UserModel, _DataModel);
            pcs.Init();
            pcs.MetaUri = UcUri;
            pcs.Dock = DockStyle.Fill;
            ntp.Controls.Add(pcs);

            TcMeta.SelectedTab = ntp;
        }

        public void CutMeta()
        {
            if (TcMeta.SelectedTab == null)
            {
                return;
            }
            PcsView pcs = TcMeta.SelectedTab.Controls[0] as PcsView;
            if (pcs == null)
            {
                return;
            }
            pcs.CutMeta();
        }

        public void CopyMeta()
        {
            if (_CurView != null)
            {
                _CurView.CopyMeta();
            }
        }

        public void CopyMetaRef()
        {
            if (_CurView != null)
            {
                _CurView.CopyMetaRef();
            }
        }

        public void PasteMeta()
        {
            if (_CurView != null)
            {
                _CurView.PasteMeta();
            }
        }

        public void PasteMetaAs()
        {
            if (_CurView != null)
            {
                _CurView.PasteMetaAs();
            }
        }

        public void PasteMetaRef()
        {
            if (_CurView != null)
            {
                _CurView.PasteMetaRef();
            }
        }

        public void CreateFolder()
        {
            if (_CurView != null)
            {
                _CurView.CreateFolder();
            }
        }

        public void DeleteMeta()
        {
            if (_CurView != null)
            {
                _CurView.DeleteMeta();
            }
        }

        public void RenameMeta()
        {
            if (_CurView != null)
            {
                _CurView.RenameMeta();
            }
        }

        public void DownloadMeta()
        {
            var task = _CurView.NewDownloadThread();
            if (task == null)
            {
                return;
            }

            task.Start();
            _Threads.Add(task);
            if (!ScMain.Panel2Collapsed)
            {
                UcTaskList.AppendTask(task);
            }
            StartAll();
        }

        public void UploadMeta()
        {
            var task = _CurView.NewUploadThread();
            if (task == null)
            {
                return;
            }

            task.Start();
            _Threads.Add(task);
            if (!ScMain.Panel2Collapsed)
            {
                UcTaskList.AppendTask(task);
            }
            StartAll();
        }

        /// <summary>
        /// 后退
        /// </summary>
        public void Backword()
        {
            if (_CurView != null)
            {
                _CurView.Backword();
            }
        }

        /// <summary>
        /// 前进
        /// </summary>
        public void Foreword()
        {
            if (_CurView != null)
            {
                _CurView.Foreword();
            }
        }

        /// <summary>
        /// 向上
        /// </summary>
        public void Upword()
        {
            if (_CurView != null)
            {
                _CurView.Upword();
            }
        }

        public void AddFav()
        {
            if (_CurView != null)
            {
                _CurView.AddFav();
            }
        }

        public void HideForm()
        {
            Visible = false;
        }

        public void LockForm()
        {
            new AuthLs(_UserModel, this).ShowDialog(this);
        }

        public void ExitForm()
        {
            _Main.ExitSystem();
        }

        public void StartAll()
        {
            if (!BwWork.IsBusy)
            {
                BwWork.RunWorkerAsync();
            }
        }

        public void StopAll()
        {
            if (BwWork.IsBusy)
            {
                BwWork.CancelAsync();
            }
        }

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

        /// <summary>
        /// 关于
        /// </summary>
        public void ShowAbout()
        {
            Main.ShowAbout(this);
        }

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
        #endregion

        #region 私有函数
        #endregion

        #region 事件处理
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WPcs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BwWork.IsBusy)
            {
                var msg = "您有未完成的任务，确认要退出吗？";
                if (DialogResult.OK != Main.ShowConfirm(msg))
                {
                    e.Cancel = true;
                    return;
                }
            }
        }

        private void TcMeta_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int idx = TcMeta.SelectedIndex;
            if (idx < 0)
            {
                return;
            }
            bool isOk = idx != 0;

            var item = _XmlMenu.GetMenuItem("edit");
            if (item != null)
            {
                item.Visible = isOk;
            }

            if (isOk)
            {
                var tab = TcMeta.SelectedTab;
                _CurView = tab.Controls[0] as PcsView;
                _CurView.ShowInfo();
            }
            else
            {
                UcUri.Text = "首页";
                UcUri.Path = "pcs://首页";
                UcUri.Icon = null;

                _CurView = null;
            }
        }

        private void TcMeta_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == _DefPage)
            {
                e.Cancel = true;
            }
        }

        private void BwWork_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (!BwWork.CancellationPending)
            {
                _CurThreads = 0;
                int i = 0;
                while (i < _Threads.Count)
                {
                    var thread = _Threads[i];
                    // 已完成
                    if (thread.Status == TaskStatus.DONE)
                    {
                        _Threads.RemoveAt(i);
                        foreach (var moniter in _Viewers)
                        {
                            moniter.RemoveTask(thread, i);
                        }
                        continue;
                    }

                    // 进行中
                    if (thread.Status == TaskStatus.RUNNING)
                    {
                        _CurThreads += 1;
                    }
                    // 等待中
                    else if (thread.Status == TaskStatus.WAIT && _CurThreads <= _MaxThreads)
                    {
                        thread.Start();
                        _CurThreads += 1;
                    }

                    foreach (var moniter in _Viewers)
                    {
                        moniter.UpdateTask(thread, i);
                    }
                    i += 1;
                }

                if (_CurThreads < 1)
                {
                    break;
                }

                foreach (var moniter in _Viewers)
                {
                    moniter.Refresh();
                }
                Thread.Sleep(100);
            }
        }

        private void BwWork_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {

        }

        private void BwWork_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

        }
        #endregion
    }
}
