using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Kms.Robot.img
{
    public partial class ImgScreen : UserControl, IHuman<Image>
    {
        private KmsHuman _KmsHuman;

        public ImgScreen()
            : this(null)
        {
        }

        public ImgScreen(KmsHuman human)
        {
            InitializeComponent();
            _KmsHuman = human;
        }

        #region ICapture 成员

        public UserControl Control
        {
            get { return this; }
        }

        public bool HideWindow()
        {
            return CkHide.Checked;
        }

        public void Init(string key)
        {
        }

        public Image Deal()
        {
            Thread.Sleep(decimal.ToInt32(SpWait.Value) * 1000);

            return BeanUtil.CaptureScreen();
        }

        #endregion
    }
}
