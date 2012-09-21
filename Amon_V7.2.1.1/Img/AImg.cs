using System.Windows.Forms;
using Me.Amon.Img.V;
using Me.Amon.M;

namespace Me.Amon.Img
{
    /// <summary>
    /// 图片文件查看
    /// </summary>
    public partial class AImg : Form, IApp
    {
        #region 全局变量
        private IImg _IImg;
        private UserModel _UserModel;
        //private ViewModel _ViewModel;
        #endregion

        #region 构造函数
        public AImg()
        {
            InitializeComponent();
        }

        public AImg(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get;
            set;
        }

        public Form Form
        {
            get { return this; }
        }

        public void ShowTips(Control control, string caption)
        {
            //TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            //LbEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            //LbEcho.Text = message;
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
        public void OpenFile(string file)
        {
            _IImg.OpenFile(file);
        }
        #endregion

        #region 事件处理
        private void AImg_Load(object sender, System.EventArgs e)
        {
            ShowLarge();
        }

        private void AImg_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                TopMost = !TopMost;
            }
        }
        #endregion

        #region 私有函数
        private void ShowLarge()
        {
            if (_IImg != null)
            {
                Controls.Remove(_IImg.Control);
            }

            if (_ALarge == null)
            {
                _ALarge = new ALarge();
                _ALarge.InitOnce();
            }

            _ALarge.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _ALarge.Location = new System.Drawing.Point(12, 12);
            _ALarge.Size = new System.Drawing.Size(360, 238);
            _ALarge.TabIndex = 0;
            Controls.Add(_ALarge);

            _IImg = _ALarge;
        }
        private ALarge _ALarge;

        private void ShowSmall()
        {
            if (_IImg != null)
            {
                Controls.Remove(_IImg.Control);
            }

            if (_ASmall == null)
            {
                _ASmall = new ASmall();
                _ASmall.InitOnce();
            }

            _ASmall.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            _ASmall.Location = new System.Drawing.Point(12, 12);
            _ASmall.Size = new System.Drawing.Size(360, 238);
            _ASmall.TabIndex = 0;
            Controls.Add(_ASmall);

            _IImg = _ALarge;
        }
        private ASmall _ASmall;
        #endregion
    }
}
