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

        public void Init()
        {
            #region 系统选单
            _XmlMenu = new XmlMenu<WPcs>(this, _ViewModel);
            if (_XmlMenu.Load(Path.Combine(_UserModel.DatHome, CPcs.XML_MENU)))
            {
                _XmlMenu.GetMenuBar("WPcs", MbMenu);
                _XmlMenu.GetToolBar("WPcs", TbTool);
                ContextMenuStrip CmKey = new ContextMenuStrip();
                _XmlMenu.GetPopMenu("WPcs", CmKey);
                //_KeyList.PopupMenu = CmKey;

                //_XmlMenu.GetPopMenu("WAtt", CmAtt);
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

        public void CutMeta()
        {
            //if (_UcTab.SelectedPage != null)
            //{
            //    _UcTab.SelectedPage.CutMeta();
            //}
        }

        public void CopyMeta()
        {
            //if (_UcTab.SelectedPage != null)
            //{
            //    _UcTab.SelectedPage.CopyMeta();
            //}
        }

        public void PasteMeta()
        {
            //if (_UcTab.SelectedPage != null)
            //{
            //    _UcTab.SelectedPage.PasteMeta();
            //}
        }
        #endregion

        #region 私有函数
        private void AddNative()
        {
            var client = new NativeClient();

            TabPage ntp = new TabPage();
            ntp.Text = "Demo";
            TcMeta.TabPages.Add(ntp);

            var pcs = new PcsView(this, client);
            pcs.Dock = DockStyle.Fill;
            pcs.Init();
            ntp.Controls.Add(pcs);
        }

        private void AddKuaipan()
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
            pcs.Dock = DockStyle.Fill;
            pcs.Init();
            ntp.Controls.Add(pcs);
        }
        #endregion
    }
}
