using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdq
{
    public partial class None : UserControl, IInput
    {
        public None()
        {
            InitializeComponent();
        }

        public Control Control
        {
            get { return this; }
        }

        public bool Check()
        {
            return true;
        }

        public Param Param { get; set; }
    }
}
