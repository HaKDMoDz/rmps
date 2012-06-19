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
            if (CbParam.SelectedItem == null)
            {
                Main.ShowAlert(_Param.Error);
                CbParam.Focus();
                return false;
            }
            return true;
        }

        public Param Param
        {
            get
            {
                _Param.Input = CbParam.SelectedItem.ToString();
                _Param.Value = _Param.Input;
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
                CbParam.SelectedItem = _Param.Input;
            }
        }
        #endregion
    }
}
