using System;
using System.Windows.Forms;
using Me.Amon.Kms.Enums;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Training.Opt
{
    public partial class RateInfo : UserControl, IOptions
    {
        private Training _target;
        private MSentence _Question;
        private MSentence _Response;

        #region 构造函数
        public RateInfo()
        {
            InitializeComponent();
        }

        public RateInfo(Training target)
        {
            InitializeComponent();

            _target = target;
        }
        #endregion

        #region IOptions 成员

        public void Init()
        {
            CbVote.Items.Add("请选择");
            CbVote.Items.Add("很好");
            CbVote.Items.Add("好");
            CbVote.Items.Add("一般");
            CbVote.Items.Add("差");
            CbVote.Items.Add("很差");
        }

        public void ReInit(MSentence question, MSentence response)
        {
            _Question = question;
            _Response = response;

            InitToolBar();
        }

        private delegate void ComboBoxHandler();
        private void InitToolBar()
        {
            if (TsToolBar.InvokeRequired)
            {
                TsToolBar.Invoke(new ComboBoxHandler(InitToolBar), null);
            }
            else
            {
                CbVote.SelectedIndex = 0;
                CbVote.Enabled = true;
            }
        }

        public UserControl GetControl()
        {
            return this;
        }

        #endregion

        #region 用户事件
        private void BtVote_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }

            int idx = CbVote.SelectedIndex;
            if (idx < 1)
            {
                _target.ShowNotice("不好意思，你要选择投票信息呀！");
                return;
            }

            _target.UpdateResponse(3 - idx);
            _target.ShowNotice("谢谢您的投票，$robot_name$会做得更好！");
            //BtVote.Enabled = false;
        }

        private void BtPrev_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.PrevResponse();
        }

        private void BtNext_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.NextResponse();
        }

        private void BtExit_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.Default, "输入一个问，看$robot_name$回答的怎么样：");
        }
        #endregion

        private void MiTags_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.UpdateCategory, "请输入新的标签！");
        }

        private void MiAppendR_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.AppendResponse, "请输入新的回答！");
        }

        private void MiUpdateR_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.UpdateResponse, "请输入新的回答！");
        }

        private void MiRemoveR_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            if (DialogResult.Yes != _target.ShowConfirm("确认要删除此回答吗？"))
            {
                return;
            }
            _target.RemoveResponse();
        }

        private void MiUpdateQ_Click(object sender, EventArgs e)
        {
            if (_target == null)
            {
                return;
            }
            _target.ShowOptions(EOptions.UpdateQuestion, "现在您可以更新提问了！");
        }
    }
}
