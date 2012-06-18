using System.Windows.Forms;
using Me.Amon.Sql.Model;
using Me.Amon.Uc;

namespace Me.Amon.Sql.V.Pdq
{
    public partial class List : UserControl, IInput
    {
        private Param _Param;

        public List()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public bool Check()
        {
            return true;
        }

        public string Value
        {
            get
            {
                return CbParam.SelectedItem.ToString();
            }
            set
            {
                CbParam.SelectedItem = value;
            }
        }

        public Param Param
        {
            get
            {
                return _Param;
            }
            set
            {
                _Param = value;
                CbParam.Items.Clear();
                foreach (Item item in _Param.Items)
                {
                    CbParam.Items.Add(item);
                }
            }
        }
        #endregion
    }
}
