using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class APro : UserControl, IImg
    {
        private UcImg _UcImg;
        private UcOpt _UcOpt;

        public APro()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void InitOnce()
        {
            ShowOpt();
            ShowImg();
        }

        public Control Control
        {
            get { return this; }
        }

        public void OpenFile(string file)
        {
        }
        #endregion

        public Image SrcImage
        {
            get;
            set;
        }

        public Image DstImage
        {
            get
            {
                return _UcImg.Image;
            }
            set
            {
                _UcImg.Image = value;
            }
        }

        private void ShowOpt()
        {
            _UcOpt = new UcOpt(this);
            _UcOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            _UcOpt.Name = "ucOpt1";
            _UcOpt.TabIndex = 0;
            ScPanel.Panel1.Controls.Add(_UcOpt);
        }

        private void ShowImg()
        {
            _UcImg = new UcImg(this);
            _UcImg.AllowDrop = true;
            _UcImg.Dock = System.Windows.Forms.DockStyle.Fill;
            _UcImg.Name = "ucImg1";
            _UcImg.TabIndex = 0;
            ScPanel.Panel2.Controls.Add(_UcImg);
        }
    }
}
