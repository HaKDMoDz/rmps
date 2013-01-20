using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Cfg
{
    public partial class UcGeneral : UserControl
    {
        private UserModel _UserModel;

        public UcGeneral()
        {
            InitializeComponent();
        }

        #region 接口实现
        public ACfg ACfg { private get; set; }

        public void InitView(UserModel userModel)
        {
            _UserModel = userModel;

            TbDatPath.Text = userModel.DatHome;
            TbBakPath.Text = userModel.BakHome;
            SpBakCount.Value = userModel.BackFileCount;
        }

        public bool CheckInput()
        {
            string bakPath = TbBakPath.Text;
            if (string.IsNullOrEmpty(bakPath))
            {
                MessageBox.Show("请选择备份路径！");
                TbBakPath.Focus();
                return false;
            }
            return true;
        }
        #endregion
    }
}
