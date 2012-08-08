using System.Windows.Controls;
using Me.Amon.Lot.M;

namespace Me.Amon.Lot.V
{
    public partial class Uc1 : UserControl
    {
        private Item _Item;

        public Uc1()
        {
            InitializeComponent();
        }

        public Item Item
        {
            get
            {
                return _Item;
            }
            set
            {
                _Item = value;
                TbValue.Text = _Item.Value;
            }
        }
    }
}
