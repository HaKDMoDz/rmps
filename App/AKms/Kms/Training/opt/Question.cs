using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Training.Opt
{
    public partial class Question : UserControl, IOptions
    {
        private Training _target;

        #region 构造函数
        public Question()
        {
            InitializeComponent();
        }

        public Question(Training target)
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
        private void BtOk_Click(object sender, System.EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowNotice("请输入您的回答：");
        }

        private void BtNo_Click(object sender, System.EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.Default, "输入一个问题，看$robot_name$回答的怎么样：");
        }
        #endregion
    }
}
