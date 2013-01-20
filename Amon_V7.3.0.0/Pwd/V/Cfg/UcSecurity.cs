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
            SpPassLength.Value = userModel.PasswordLength;
            CbPassCharset.SelectedItem = userModel.PasswordUdc;
        }

        public bool CheckInput()
        {
            return true;
        }
        #endregion
    }
}
