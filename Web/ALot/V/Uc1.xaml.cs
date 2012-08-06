using System.Windows.Controls;

namespace Me.Amon.Lot.V
{
    public partial class Uc1 : UserControl
    {
        public Uc1()
        {
            InitializeComponent();
        }

        public string Text
        {
            get
            {
                return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
            }
        }
    }
}
