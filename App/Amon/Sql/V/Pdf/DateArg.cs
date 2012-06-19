using System.Text;
using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdf
{
    public partial class DateArg : UserControl, IInput
    {
        private Param _Param;
        private StringBuilder _Buffer = new StringBuilder();

        public DateArg()
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
            if (_Param == null)
            {
                _Buffer.Append(txt);
                return true;
            }

            _Buffer.Append('\'').Append(txt).Append('\'');
            return true;
        }

        public Param Param
        {
            get
            {
                //_Param.Input = DtParam.Value;
                _Param.Value = _Buffer.ToString();
                return _Param;
            }
            set
            {
                _Param = value;
                DtParam.CustomFormat = _Param.Format;
                //DtParam.Value = _Param.Value;
            }
        }
        #endregion
    }
}
