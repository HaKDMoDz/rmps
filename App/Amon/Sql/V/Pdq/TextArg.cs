using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdq
{
    public partial class Text : UserControl, IInput
    {
        private const char COMMA = '\'';
        private const char LIKE = '%';
        private Param _Param;
        private StringBuilder _Buffer = new StringBuilder();

        public Text()
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
            string txt = TbParam.Text;

            // 无要求
            if (_Param == null)
            {
                _Buffer.Append(COMMA).Append(txt).Append(COMMA);
                return true;
            }

            // 消除空白
            if (!string.IsNullOrEmpty(_Param.Trim))
            {
                txt = txt.Trim(_Param.Trim.ToCharArray());
            }

            // 为空判断
            if (string.IsNullOrEmpty(txt))
            {
                if (string.IsNullOrEmpty(_Param.Empty))
                {
                    _Buffer.Append(COMMA).Append(txt).Append(COMMA);
                    return true;
                }
                MessageBox.Show(_Param.Empty);
                return false;
            }

            // 大小转换
            if (_Param.ToUpper)
            {
                txt = txt.ToUpper();
            }
            if (_Param.ToLower)
            {
                txt = txt.ToLower();
            }

            // 模糊查找
            if (!string.IsNullOrEmpty(_Param.Escape))
            {
                txt = txt.Replace(_Param.Escape, "" + LIKE);
                txt = Regex.Replace(txt, LIKE + "{2,}", "" + LIKE);
                if (txt[0] != LIKE)
                {
                    txt = LIKE + txt;
                }
                if (txt[txt.Length - 1] != LIKE)
                {
                    txt = txt + LIKE;
                }
                _Buffer.Append(COMMA).Append(txt).Append(COMMA);
                return true;
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
                _Buffer.Append(COMMA).Append(txt).Append(COMMA);
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
                _Buffer.Append(COMMA).Append(tmp).Append(COMMA).Append(',');
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
        #endregion
    }
}
