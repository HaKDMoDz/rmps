using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Input
{
    public partial class Text : UserControl, IInput
    {
        private const char COMMA = '\'';
        private const char LIKE = '%';

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
            if (Param == null)
            {
                _Buffer.Append(COMMA).Append(txt).Append(COMMA);
                return true;
            }

            // 消除空白
            if (!string.IsNullOrEmpty(Param.Trim))
            {
                txt = txt.Trim(Param.Trim.ToCharArray());
            }

            // 为空判断
            if (string.IsNullOrEmpty(txt))
            {
                if (string.IsNullOrEmpty(Param.Empty))
                {
                    _Buffer.Append(COMMA).Append(txt).Append(COMMA);
                    return true;
                }
                MessageBox.Show(Param.Empty);
                return false;
            }

            // 模糊查找
            if (!string.IsNullOrEmpty(Param.Escape))
            {
                txt = txt.Replace(Param.Escape, "" + LIKE);
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

            bool isMatch = !string.IsNullOrWhiteSpace(Param.Format);

            // 无分隔符
            if (string.IsNullOrEmpty(Param.Separator))
            {
                if (isMatch && !Regex.IsMatch(txt, Param.Format))
                {
                    MessageBox.Show(string.Format(Param.Error, txt));
                    return false;
                }
                _Buffer.Append(COMMA).Append(txt).Append(COMMA);
                return true;
            }

            // 有分隔符
            foreach (string tmp in txt.Split(Param.Separator.ToCharArray()))
            {
                if (isMatch && !Regex.IsMatch(tmp, Param.Format))
                {
                    MessageBox.Show(string.Format(Param.Error, tmp));
                    return false;
                }
                _Buffer.Append(COMMA).Append(tmp).Append(COMMA).Append(',');
                continue;
            }
            _Buffer.Remove(_Buffer.Length - 1, 1);
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
                TbParam.Text = value;
            }
        }

        public Param Param { get; set; }
        #endregion
    }
}
