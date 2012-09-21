using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.M;

namespace Me.Amon.V
{
    public partial class Reset : Form
    {
        private AUserModel _UserModel;

        #region 构造函数
        public Reset()
        {
            InitializeComponent();
        }

        public Reset(AUserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 数据导出
        public static void Export(AUserModel userModel)
        {
        }
        #endregion

        private void BtOk_Click(object sender, System.EventArgs e)
        {
            Export(_UserModel);
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
