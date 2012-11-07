using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Pcs.V
{
    public partial class MetaUri : UserControl
    {
        public MetaUri()
        {
            InitializeComponent();
        }

        public MetaUri(WPcs wPcs)
        {
            InitializeComponent();
        }

        #region 公共属性
        public string Text
        {
            get
            {
                return LlUri.Text;
            }
            set
            {
                LlUri.Text = value;
            }
        }

        public string Path
        {
            get
            {
                return TbUri.Text;
            }
            set
            {
                TbUri.Text = value;
            }
        }

        public Image Icon
        {
            get
            {
                return BnUri.Image;
            }
            set
            {
                BnUri.Image = value;
            }
        }
        #endregion
    }
}
