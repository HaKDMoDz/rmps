using System;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Man
{
    public partial class Response : UserControl, IOptions
    {
        private ManWindow _target;

        #region 构造函数
        public Response()
        {
            InitializeComponent();
        }

        public Response(ManWindow target)
        {
            InitializeComponent();

            _target = target;
        }
        #endregion

        #region IOptions 成员

        public void Init()
        {
        }

        public void ReInit(MSentence question, MSentence response)
        {
        }

        public UserControl GetControl()
        {
            return this;
        }

        #endregion

        #region 用户事件

        private void BtNo_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.Default, "输入一个问，看$robot_name$回答的怎么样：");
        }
        #endregion
    }
}
