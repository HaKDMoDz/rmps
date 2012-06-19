using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdf
{
    public partial class NoneArg : UserControl, IInput
    {
        public NoneArg()
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
