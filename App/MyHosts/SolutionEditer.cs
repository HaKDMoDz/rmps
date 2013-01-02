using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Me.Amon.Hosts
{
    public partial class SolutionEditer : Form
    {
        private List<Solution> _Solutions;

        #region 构造函数
        public SolutionEditer()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;
        }

        public SolutionEditer(List<Solution> solutions)
        {
            _Solutions = solutions;

            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;
        }
        #endregion

        public string Solution { get; private set; }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Solution = TbGroup.Text.Trim();
            if (string.IsNullOrEmpty(Solution))
            {
                LlGroup.Text = "请输入一个有效的方案名称：";
                TbGroup.Focus();
                return;
            }
            if (_Solutions != null)
            {
                foreach (var solution in _Solutions)
                {
                    if (Solution == solution.Text)
                    {
                        LlGroup.Text = "您输入的方案名称已存在，请重新输入：";
                        TbGroup.Focus();
                        return;
                    }
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
