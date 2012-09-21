using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class UhTips : UserControl, IHint
    {
        public UhTips()
        {
            InitializeComponent();
        }

        #region 接口实现
        public Control Control { get { return this; } }

        public void ShowData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return;
            }
            TbTips.Text = mgtd.Command;
        }

        public bool SaveData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return false;
            }
            string tips = TbTips.Text;
            if (string.IsNullOrWhiteSpace(tips))
            {
                Main.ShowAlert("请输入提示信息！");
                TbTips.Focus();
                return false;
            }
            mgtd.Command = tips;
            return true;
        }
        #endregion
    }
}
