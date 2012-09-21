using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Kms.Robot.img
{
    public partial class ImgDefault : UserControl, IHuman<Image>
    {
        public ImgDefault()
            : this(null)
        {
        }

        public ImgDefault(KmsHuman human)
        {
            InitializeComponent();
        }

        #region ImgHuman 成员

        public UserControl Control
        {
            get { return this; }
        }

        public bool HideWindow()
        {
            return false;
        }

        public void Init(string key)
        {
        }

        public Image Deal()
        {
            return null;
        }

        #endregion
    }
}
