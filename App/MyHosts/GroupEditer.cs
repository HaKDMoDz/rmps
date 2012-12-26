using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Me.Amon.Hosts
{
    public partial class GroupEditer : Form
    {
        private List<ListViewGroup> _Groups;

        public GroupEditer()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;
        }

        public GroupEditer(List<ListViewGroup> groups, string group)
        {
            _Groups = groups;
            Group = group;

            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;

            TbGroup.Text = group;
        }

        public string Group { get; private set; }

        private void BtOk_Click(object sender, EventArgs e)
        {
            Group = TbGroup.Text.Trim();
            if (string.IsNullOrEmpty(Group))
            {
                LlGroup.Text = "请输入一个有效的分组名称：";
                TbGroup.Focus();
                return;
            }
            if (_Groups != null)
            {
                foreach (var group in _Groups)
                {
                    if (Group == group.Header)
                    {
                        LlGroup.Text = "您输入的分组名称已存在，请重新输入：";
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
