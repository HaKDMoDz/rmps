using System.Windows.Forms;

namespace Me.Amon.Pwd.V.Cfg
{
    public partial class UcStorage : UserControl
    {
        public UcStorage()
        {
            InitializeComponent();
        }

        #region 接口实现
        public ACfg ACfg { private get; set; }

        public bool CheckInput()
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void CbType_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void PbPass_Click(object sender, System.EventArgs e)
        {
            if (TbPass.UseSystemPasswordChar)
            {
                TbPass.UseSystemPasswordChar = false;
                ACfg.ShowTips(PbPass, "隐藏口令");
            }
            else
            {
                TbPass.UseSystemPasswordChar = true;
                ACfg.ShowTips(PbPass, "显示口令");
            }
        }
        #endregion
    }
}
