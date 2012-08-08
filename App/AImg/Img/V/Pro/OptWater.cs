using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public partial class OptWater : UserControl,IOpt
    {
        public OptWater()
        {
            InitializeComponent();
        }

        #region 接口实现
        public void Init()
        {
        }

        public Control Control
        {
            get { return this; }
        }

        public Image Deal(Image image)
        {
            return image;
        }

        public void Reset()
        {
        }
        #endregion
    }
}
