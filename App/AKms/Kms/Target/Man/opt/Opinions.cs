using System;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Man
{
    public partial class Opinions : UserControl, IOptions
    {
        private ManWindow _target;

        #region 构造函数
        public Opinions()
        {
            InitializeComponent();
        }

        public Opinions(ManWindow target)
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
        private void BtOk_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.AppendQuestion, "ok");
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.Default, "ok");
        }
        #endregion
    }
}
