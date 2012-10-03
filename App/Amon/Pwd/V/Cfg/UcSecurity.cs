using System.Text;
using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Cfg
{
    public partial class UcSecurity : UserControl
    {
        private UserModel _UserModel;

        public UcSecurity()
        {
            InitializeComponent();
        }

        #region 接口实现
        public ACfg ACfg { private get; set; }

        public void InitView(UserModel userModel)
        {
            _UserModel = userModel;

            SpClear.Value = userModel.ResidenceDuration;
            TbFillKey.Text = userModel.AutoFillKey;
        }

        public bool CheckInput()
        {
            return true;
        }
        #endregion

        private void TbFillKey_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
            e.SuppressKeyPress = true;

            StringBuilder builder = new StringBuilder();
            if (e.Control)
            {
                builder.Append("Control ");
            }
            if (e.Shift)
            {
                builder.Append("Shift ");
            }
            if (e.Alt)
            {
                builder.Append("Alt ");
            }
            Keys key = e.KeyCode;
            if (key >= Keys.Space && key <= Keys.F24)
            {
                builder.Append(e.KeyCode);

                TbFillKey.Text = builder.ToString();
            }
        }
    }
}
