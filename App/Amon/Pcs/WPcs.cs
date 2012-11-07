using System.IO;
using System.Windows.Forms;
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
        private IViewModel _ViewModel;
        private XmlMenu<WPcs> _XmlMenu;
        private PcsView _CurView;

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

        public void NewKuaipan()
        {
            OAuthConsumer consumer = new OAuthConsumer();
            consumer.consumer_key = "xcWPaz75PSRDOWBM";
            consumer.consumer_secret = "DU5ZYaCK0cRlsMTj";
            KuaipanClient client = new KuaipanClient(consumer);
            client.Verify();

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

        public void AddFav()
        {
            if (_CurView != null)
            {
                _CurView.AddFav();
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
