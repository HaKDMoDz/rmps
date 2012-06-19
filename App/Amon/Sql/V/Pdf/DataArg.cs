using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdf
{
    public partial class DataArg : UserControl, IInput
    {
        private const char LIKE = '%';
        private Param _Param;
        private StringBuilder _Buffer = new StringBuilder();

        public DataArg()
        {
            InitializeComponent();
        }

        public Control Control
        {
            get { return this; }
        }

        public bool Check()
        {
            _Buffer.Clear();
            string txt = TbParam.Text;

            // 无要求
            if (_Param == null)
            {
                _Buffer.Append(txt);
                return true;
            }

            // 为空判断
            if (string.IsNullOrEmpty(txt))
            {
                if (string.IsNullOrEmpty(_Param.Empty))
                {
                    return true;
                }
                MessageBox.Show(_Param.Empty);
                return false;
            }

            bool isMatch = !string.IsNullOrWhiteSpace(_Param.Format);

            // 无分隔符
            if (string.IsNullOrEmpty(_Param.Separator))
            {
                if (isMatch && !Regex.IsMatch(txt, _Param.Format))
                {
                    MessageBox.Show(string.Format(_Param.Error, txt));
                    return false;
                }
                _Buffer.Append(txt);
                return true;
            }

            // 有分隔符
            foreach (string tmp in txt.Split(_Param.Separator.ToCharArray()))
            {
                if (isMatch && !Regex.IsMatch(tmp, _Param.Format))
                {
                    MessageBox.Show(string.Format(_Param.Error, tmp));
                    return false;
                }
                _Buffer.Append(tmp).Append(',');
                continue;
            }
            _Buffer.Remove(_Buffer.Length - 1, 1);
            return true;
        }

        public Param Param
        {
            get
            {
                _Param.Input = TbParam.Text;
                _Param.Value = _Buffer.ToString();
                return _Param;
            }
            set
            {
                _Param = value;
                TbParam.Text = _Param.Input;
            }
        }
    }
}
