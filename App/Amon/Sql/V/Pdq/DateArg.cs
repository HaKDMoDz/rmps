using System.Text;
using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdq
{
    public partial class Date : UserControl, IInput
    {
        private Param _Param;
        private StringBuilder _Buffer = new StringBuilder();

        public Date()
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
            _Buffer.Clear();
            string txt = DtParam.Text;

            // 无要求
            if (Param == null)
            {
                _Buffer.Append(txt);
                return true;
            }

            _Buffer.Append('\'').Append(txt).Append('\'');
            return true;
        }

        public string Value
        {
            get
            {
                return _Buffer.ToString();
            }
            set
            {
                DtParam.Text = value;
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
                DtParam.CustomFormat = _Param.Format;
            }
        }
        #endregion
    }
}
