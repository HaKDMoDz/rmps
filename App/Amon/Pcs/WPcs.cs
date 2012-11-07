using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Auth;
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
        private AUserModel _UserModel;
        private DataModel _DataModel;
        private IViewModel _ViewModel;
        private XmlMenu<WPcs> _XmlMenu;
        private PcsView _CurView;
        private TabPage _DefPage;

        #region 构造函数
        public WPcs()
        {
            InitializeComponent();
        }

        public WPcs(Main main, AUserModel userModel)
        {
            _Main = main;
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        public void Init()
        {
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

            _DefPage = new TabPage();
            _DefPage.Text = "首页";
            //_DefPage.Location = new System.Drawing.Point(4, 23);
            //_DefPage.Padding = new System.Windows.Forms.Padding(3);
            //_DefPage.Size = new System.Drawing.Size(604, 300);
            PcsList list = new PcsList(this, _DataModel);
            list.Init();
            list.Dock = DockStyle.Fill;
            _DefPage.Controls.Add(list);
            TcMeta.TabPages.Add(_DefPage);
        }

        #region 接口实现
        public int AppId { get; set; }

        public new Form Form { get { return this; } }

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
        public CsMeta SelectedMeta { get; set; }

        public EPcs Operation { get; set; }

        public ContextMenuStrip PopupMenu { get; set; }

        public void SetPasteEnabled()
        {
            var group = _XmlMenu.GetGroup("paste-meta-enabled");
            if (group != null)
            {
                group.Enabled(SelectedMeta != null);
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

        public void OpenPcs(MPcs mPcs)
        {
            switch
                (mPcs.ServerType)
            {
                case "native":
                    NewNative();
                    break;
                case "kuaipan":
                    NewKuaipan(mPcs);
                    break;
                default:
                    break;
            }
        }

        private int NativeIndex = 0;
        public void NewNative()
        {
            var client = new NativeClient();

            TabPage ntp = new TabPage();
            ntp.Text = NativeIndex < 1 ? "本地" : string.Format("本地 ({0})", NativeIndex);
            TcMeta.TabPages.Add(ntp);

            var pcs = new PcsView(this, client);
            pcs.Init();
            pcs.MetaUri = UcUri;
            pcs.Dock = DockStyle.Fill;
            ntp.Controls.Add(pcs);

            TcMeta.SelectedTab = ntp;
            NativeIndex += 1;
        }

        private void NewKuaipan(MPcs mPcs)
        {
            OAuthConsumer consumer = new OAuthConsumer();
            consumer.consumer_key = "xcWPaz75PSRDOWBM";
            consumer.consumer_secret = "DU5ZYaCK0cRlsMTj";
            OAuthToken token = new OAuthToken();
            token.oauth_token = mPcs.Token;
            token.oauth_token_secret = mPcs.TokenSecret;
            token.UserId = mPcs.UserId;
            KuaipanClient client = new KuaipanClient(consumer);
            if (token.oauth_token.Length != 24 && token.oauth_token_secret.Length != 32)
            {
                client.Verify();
            }

            TabPage ntp = new TabPage();
            ntp.Text = "Demo";
            TcMeta.TabPages.Add(ntp);

            var pcs = new PcsView(this, client);
            pcs.Init();
            pcs.MetaUri = UcUri;
            pcs.Dock = DockStyle.Fill;
            ntp.Controls.Add(pcs);
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

        public void PasteMeta()
        {
            if (_CurView != null)
            {
                _CurView.PasteMeta();
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

        public void AddFav(string name)
        {
            if (_CurView != null)
            {
                _CurView.AddFav(name);
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

        private void TcMeta_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            bool isOk = TcMeta.SelectedIndex != 0;

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
    }
}
