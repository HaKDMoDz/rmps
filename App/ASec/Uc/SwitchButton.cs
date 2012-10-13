using System.Windows.Forms;
using Me.Amon.Properties;

namespace Me.Amon.Uc
{
    public partial class SwitchButton : UserControl
    {
        private bool _On;

        public SwitchButton()
        {
            InitializeComponent();
        }

        public bool On
        {
            get
            {
                return _On;
            }
            set
            {
                _On = value;
                BackgroundImage = _On ? Resources.Encode : Resources.Decode;
            }
        }
    }
}
