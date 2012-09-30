using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.V.Uc
{
    public partial class ThreadWait : UserControl, IFunction
    {
        private MFunction _function;

        public ThreadWait()
        {
            InitializeComponent();
        }

        #region IFunction 成员

        public MFunction UserFunction
        {
            get
            {
                return _function;
            }
            set
            {
                _function = value;
                string text = (_function.Param ?? "100").Trim();
                TbTime.Text = text;
                CbTime.Checked = Regex.IsMatch(text, "^\\{\\d+,\\d+\\}$");
            }
        }

        public bool SaveFunction()
        {
            if (_function == null)
            {
                return false;
            }
            string param = (TbTime.Text ?? "").Trim();
            if (string.IsNullOrEmpty(param))
            {
                MessageBox.Show(this, "请输入等待时间！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbTime.Focus();
                return false;
            }
            if (!Regex.IsMatch(param, "^\\d+$"))
            {
                MessageBox.Show(this, "请输入一个自然数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                TbTime.Focus();
                return false;
            }
            _function.Action = EAction.ThreadWait;
            _function.Param = param;
            return true;
        }

        public UserControl UserControl
        {
            get
            {
                return this;
            }
        }

        #endregion

        private void CbTime_CheckedChanged(object sender, System.EventArgs e)
        {
            TbTime.Text = CbTime.Checked ? "{1,1000}" : "100";
        }
    }
}
