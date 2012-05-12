using System.Windows.Forms;

namespace Me.Amon.Pwd.Bean
{
    public partial class AData : UserControl
    {
        protected Att _Att;
        private TextBox _Box;

        #region 构造函数
        public AData()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        protected void InitSpec(TextBox box)
        {
            _Box = box;
        }

        protected void ShowSpec(Control ctl)
        {
        }
        #endregion

        #region 事件处理
        #endregion
    }
}
