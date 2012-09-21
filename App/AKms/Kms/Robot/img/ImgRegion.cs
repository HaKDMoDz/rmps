using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Kms.Robot.img
{
    public partial class ImgRegion : UserControl, IHuman<Image>
    {
        public ImgRegion()
            : this(null)
        {
        }

        public ImgRegion(KmsHuman human)
        {
            InitializeComponent();
        }

        #region ICapture 成员

        public UserControl Control
        {
            get { return this; }
        }

        public bool HideWindow()
        {
            return true;
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
