using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Uc;

namespace Me.Amon.Img
{
    public partial class AImg : Form, IApp
    {
        private IImg _IImg;
        private UserModel _UserModel;
        private ViewModel _ViewModel;
        private XmlMenu<AImg> _Menu;

        #region 构造函数
        public AImg()
        {
            InitializeComponent();
        }

        public AImg(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public Form Form
        {
            get { return this; }
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 公共函数
        public XmlMenu<AImg> XmlMenu
        {
            get
            {
                return _Menu;
            }
        }

        public void OpenIcl(string file)
        {
            _IImg.OpenFile(file);
        }

        public void OpenPng(string file)
        {
        }
        #endregion

        #region 事件处理
        private void PbMenu_Click(object sender, System.EventArgs e)
        {
            if (_IImg.PopMenu != null)
            {
                _IImg.PopMenu.Show(PbMenu, 0, PbMenu.Height);
            }
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
        }
        #endregion

        #region 私有函数

        private void ShowPng()
        {
            //if (_IImg != null)
            //{
            //    Controls.Remove(_IImg.Control);
            //}

            //if (_APng == null)
            //{
            //    _APng = new AIco();
            //    _APng.InitOnce();
            //}

            //_APng.Location = new System.Drawing.Point(12, 12);
            //_APng.Size = new System.Drawing.Size(449, 322);
            //_APng.TabIndex = 0;
            //Controls.Add(_APng);

            //_IImg = _AIco;
        }
        //private AIco _APng;
        #endregion

        private void AImg_Load(object sender, System.EventArgs e)
        {
            //if (_UserModel == null)
            //{
            //    return;
            //}

            //_ViewModel = new ViewModel(_UserModel);
            //_ViewModel.Load();

            _Menu = new XmlMenu<AImg>(this, _ViewModel);
            _Menu.Load("Img.xml");

            //ShowIco();
        }
    }
}
