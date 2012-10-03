using System.Windows.Forms;

namespace Me.Amon.Pwd.V.Cfg
{
    public partial class UcGeneral : UserControl
    {
        public UcGeneral()
        {
            InitializeComponent();
        }

        #region 接口实现
        public ACfg ACfg { private get; set; }

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
