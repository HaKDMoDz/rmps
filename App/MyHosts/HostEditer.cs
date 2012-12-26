using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Me.Amon.Hosts
{
    public partial class HostEditer : Form
    {
        public HostEditer()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;
        }

        public HostEditer(List<Group> groups, Host host)
        {
            Host = host;

            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;

            foreach (Group group in groups)
            {
                CbGroup.Items.Add(group.Text);
            }

            if (host != null)
            {
                CbGroup.SelectedItem = host.Group;
                TbIp.Text = host.IP;
                TbDomain.Text = host.Domain;
                TbMemo.Text = host.Comment;
                CbEnabled.Checked = host.Enabled;
            }
        }

        public Host Host { get; private set; }

        #region 事件处理
        private void BtOk_Click(object sender, EventArgs e)
        {
            string group = CbGroup.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(group))
            {
                MessageBox.Show("请选择分组信息！");
                CbGroup.Focus();
                return;
            }

            string ip = TbIp.Text.Trim();
            if (string.IsNullOrWhiteSpace(ip))
            {
                MessageBox.Show("请输入一个有效的IP地址！");
                TbIp.Focus();
                return;
            }

            if (Regex.IsMatch(ip, "^\\d{1,3}(.\\d{1,3}){3}$"))
            {
                if (!IsIPv4(ip))
                {
                    MessageBox.Show("请输入一个有效的IPv4地址！");
                    TbIp.Focus();
                    return;
                }
            }
            else if (Regex.IsMatch(ip, "^[:0-9a-fA-F]+$"))
            {
                if (!IsIPv6(ip))
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("请输入一个有效的IP地址！");
                TbIp.Focus();
            }

            string domain = TbDomain.Text.Trim();
            if (!Regex.IsMatch(domain, "^[-0-1a-zA-Z]+([.][-0-1a-zA-Z]+)*$"))
            {
                MessageBox.Show("请输入一个有效的域名！");
                TbDomain.Focus();
                return;
            }

            if (Host == null)
            {
                Host = new Host();
            }
            Host.Group = group;
            Host.IP = ip;
            Host.Domain = domain;
            Host.Comment = TbMemo.Text;
            Host.Enabled = CbEnabled.Checked;

            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private bool IsIPv4(string text)
        {
            Match match = Regex.Match(text, "\\d{1,3}");
            int data;
            while (match.Success)
            {
                data = int.Parse(match.Value);
                if (data < 0 || data > 255)
                {
                    return false;
                }
                match = match.NextMatch();
            }
            return true;
        }

        private bool IsIPv6(string text)
        {
            return true;
        }
    }
}
