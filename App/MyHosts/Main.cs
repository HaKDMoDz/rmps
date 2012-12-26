using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Hosts.Properties;

namespace Me.Amon.Hosts
{
    public partial class Main : Form
    {
        #region 全局常量
        public const string HOSTS_FILE = "hosts_{0}";
        public const string BAK_DIR = "bak";
        public const string DAT_DIR = "dat";
        /// <summary>
        /// 注释模板
        /// </summary>
        private const string COMMENT = "#{0}";
        #endregion

        #region 全局变量
        private bool _Modified;
        private string _HostsDir;
        private string _HostsFile;
        private string _Comment;

        private Group _Group;
        private List<Group> _Groups;
        private Solution _Solution;
        private List<Solution> _Solutions;

        private Color _EnabledBackColor;
        private Color _EnabledForeColor;
        private Color _DisabledBackColor;
        private Color _DisabledForeColor;
        private Color _DefaultColor;
        private Color _ChangedColor;
        private ListViewItem _SelectedItem;
        #endregion

        #region 构造函数
        public Main()
        {
            InitializeComponent();

            NiTray.Icon = Me.Amon.Hosts.Properties.Resources.Icon;
            TiHide.Checked = Settings.Default.HideMain;

            LvItem.BackColor = Color.White;
            _EnabledBackColor = LvItem.BackColor;
            _EnabledForeColor = LvItem.ForeColor;
            _DisabledBackColor = Color.FromArgb(238, 238, 238);
            _DisabledForeColor = Color.LightGray;
            _DefaultColor = LvItem.ForeColor;
            _ChangedColor = Color.Green;

            _Group = new Group { Key = "", Text = "默认" };
            _Groups = new List<Group>();
            _Groups.Add(_Group);

            _HostsDir = FindHostsDir();
            _HostsFile = Path.Combine(_HostsDir, "hosts");

            _Solution = new Solution();
            _Solutions = new List<Solution>();

            KeyPreview = true;

            Reload();
            ListSolution();
        }
        #endregion

        #region 事件处理
        #region 菜单栏事件
        #region 文件菜单
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiSaveasClick(object sender, EventArgs e)
        {
            Saveas(_HostsFile);
            Backup();
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiReloadClick(object sender, EventArgs e)
        {
            Reload();
        }

        /// <summary>
        /// 手动编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiOpenasClick(object sender, EventArgs e)
        {
            Openas();
        }

        /// <summary>
        /// 备份
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiBackupClick(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("yyyyMMddHHmmss");
            Saveas(Path.Combine(BAK_DIR, string.Format(HOSTS_FILE, time)));
        }

        /// <summary>
        /// 恢复
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiPickupClick(object sender, EventArgs e)
        {
            BackupViewer viewer = new BackupViewer();
            if (DialogResult.OK != viewer.ShowDialog(this))
            {
                return;
            }

            Reload();
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiExitClick(object sender, EventArgs e)
        {
            Exit();
        }
        #endregion

        #region 编辑菜单
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiCreateClick(object sender, EventArgs e)
        {
            DoCreate();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiUpdateClick(object sender, EventArgs e)
        {
            DoUpdate();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiRemoveClick(object sender, EventArgs e)
        {
            DoRemove();
        }

        void MiCreateGroupClick(object sender, EventArgs e)
        {
            CreateGroup();
        }
        #endregion

        #region 工具菜单
        /// <summary>
        /// 方案管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MiSaveasSlnClick(object sender, EventArgs e)
        {
            SolutionEditer editer = new SolutionEditer(_Solutions);
            if (DialogResult.OK != editer.ShowDialog(this))
            {
                return;
            }

            _Solution.Text = editer.Solution;
            Saveas(_HostsFile);
            Backup();

            if (string.IsNullOrWhiteSpace(_Solution.Text))
            {
                Text = _Solution.Text + " - MyHosts";
            }

            AppendSolution(_Solution);
        }

        private void MiCreateSln_Click(object sender, EventArgs e)
        {
            CreateSolution();
        }

        /// <summary>
        /// 方案管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiManageSlnClick(object sender, EventArgs e)
        {
            SolutionViewer viewer = new SolutionViewer();
            if (DialogResult.OK != viewer.ShowDialog(this))
            {
                return;
            }

            Reload();
        }

        /// <summary>
        /// 方案
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiSlnItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string sln = item.Text;
            if (string.IsNullOrWhiteSpace(sln))
            {
                return;
            }

            try
            {
                File.Copy(Path.Combine(DAT_DIR, string.Format(HOSTS_FILE, sln)), _HostsFile, true);
                Reload();
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 帮助菜单
        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void MiAboutClick(object sender, EventArgs e)
        {
            About();
        }
        #endregion
        #endregion

        #region 工具栏事件
        void TbSaveasClick(object sender, EventArgs e)
        {
            Saveas(_HostsFile);
            Backup();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TbUpdateClick(object sender, EventArgs e)
        {
            DoUpdate();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TbCreateClick(object sender, EventArgs e)
        {
            DoCreate();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TbRemoveClick(object sender, EventArgs e)
        {
            DoRemove();
        }

        /// <summary>
        /// 重新加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TbReloadClick(object sender, EventArgs e)
        {
            Reload();
        }

        /// <summary>
        /// 手动编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TbOpenasClick(object sender, EventArgs e)
        {
            Openas();
        }

        void TbCommentClick(object sender, EventArgs e)
        {
            Comment();
        }

        /// <summary>
        /// 关于
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void TbAboutClick(object sender, EventArgs e)
        {
            About();
        }
        #endregion

        #region 弹出菜单
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CiUpdateClick(object sender, EventArgs e)
        {
            DoUpdate();
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CiCreateClick(object sender, EventArgs e)
        {
            DoCreate();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CiRemoveClick(object sender, EventArgs e)
        {
            DoRemove();
        }

        void CiGroupClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region 托盘菜单
        void TiOpenClick(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Visible = true;
            }
            else
            {
                Activate();
            }
        }

        void TiSlnItemClick(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string sln = item.Text;
            if (string.IsNullOrWhiteSpace(sln))
            {
                return;
            }

            try
            {
                File.Copy(Path.Combine(DAT_DIR, string.Format(HOSTS_FILE, sln)), _HostsFile, true);

                if (Visible)
                {
                    Reload();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void TiExitClick(object sender, EventArgs e)
        {
            Exit();
        }
        #endregion

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    About();
                    break;
                case Keys.F5:
                    Reload();
                    break;
                case Keys.F12:
                    Openas();
                    break;
                case Keys.S:
                    if (e.Control)
                    {
                        Saveas(_HostsFile);
                    }
                    break;
                case Keys.N:
                    if (e.Control)
                    {
                        DoCreate();
                    }
                    break;
                case Keys.E:
                    if (e.Control)
                    {
                        DoUpdate();
                    }
                    break;
                case Keys.D:
                    if (e.Control)
                    {
                        DoRemove();
                    }
                    break;
            }
        }

        private void LvItem_MouseClick(object sender, MouseEventArgs e)
        {
            _SelectedItem = LvItem.GetItemAt(e.X, e.Y);
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                CiUpdate.Enabled = _SelectedItem != null;
                CmMenu.Show(LvItem, e.Location);
            }
        }

        void LvItemItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var item = e.Item;
            var host = item.Tag as Host;
            if (host == null)
            {
                return;
            }

            host.Enabled = item.Checked;
            UpdateItemEnabled(item, host);
        }
        #endregion

        #region 公共函数
        public void Reload()
        {
            if (!File.Exists(_HostsFile))
            {
                return;
            }

            StreamReader reader = File.OpenText(_HostsFile);
            if (reader == null)
            {
                return;
            }

            _Modified = false;
            _Comment = "";
            _Solution.Text = "";
            LvItem.Items.Clear();
            LvItem.Groups.Clear();
            _Groups.Clear();

            Group group = _Group;
            AppendGroup(group);

            string line;
            int row = -1;
            bool inCmt = true;
            while (true)
            {
                line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }

                row += 1;

                // 空行
                if (string.IsNullOrWhiteSpace(line))
                {
                    inCmt = false;
                    continue;
                }

                // 方案
                if (row == 0 && Solution.IsMatch(line))
                {
                    _Solution.FromString(line);
                    continue;
                }

                // 分组
                if (Group.IsMatch(line))
                {
                    var g = new Group();
                    if (g.FromString(line))
                    {
                        AppendGroup(g);
                    }
                    continue;
                }

                // 配置
                if (Host.IsMatch(line) && !inCmt)
                {
                    var h = new Host();
                    if (h.FromString(line))
                    {
                        h.Group = group.Text;

                        var item = new ListViewItem();
                        item.Text = h.IP;
                        item.Tag = h;
                        item.Group = LvItem.Groups[h.Group];
                        item.Checked = h.Enabled;
                        var sub = new ListViewItem.ListViewSubItem();
                        sub.Text = h.Domain;
                        item.SubItems.Add(sub);
                        sub = new ListViewItem.ListViewSubItem();
                        sub.Text = h.Comment;
                        item.SubItems.Add(sub);
                        LvItem.Items.Add(item);
                    }
                    continue;
                }

                // 注释
                if (Regex.IsMatch(line, "^#[^.]*"))
                {
                    if (inCmt)
                    {
                        _Comment += Environment.NewLine;
                        _Comment += line.Substring(1);
                        continue;
                    }
                }

                inCmt = false;
            }
            reader.Close();

            _Comment = _Comment.Substring(Environment.NewLine.Length);
            Text = (string.IsNullOrWhiteSpace(_Solution.Text) ? "当前" : _Solution.Text) + " - MyHosts";
        }

        public void Saveas(string file)
        {
            string dir = Path.GetDirectoryName(file);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(file);
                _Solution.Save(writer);

                foreach (var line in _Comment.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    writer.WriteLine(string.Format(COMMENT, line));
                }

                foreach (ListViewGroup group in LvItem.Groups)
                {
                    writer.WriteLine();
                    var g = group.Tag as Group;
                    if (g != null)
                    {
                        g.Save(writer);
                    }

                    foreach (ListViewItem item in group.Items)
                    {
                        var host = item.Tag as Host;
                        if (host != null)
                        {
                            host.Save(writer);
                        }
                    }
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void Openas()
        {
            try
            {
                Process.Start("notepad", Path.Combine(_HostsDir, "hosts"));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        public bool Backup()
        {
            if (!Directory.Exists(DAT_DIR))
            {
                Directory.CreateDirectory(DAT_DIR);
            }

            if (string.IsNullOrWhiteSpace(_Solution.Text))
            {
                return true;
            }

            try
            {
                File.Copy(_HostsFile, Path.Combine(DAT_DIR, string.Format(HOSTS_FILE, _Solution.Text)), true);
                return true;
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        public void Resume()
        {
        }

        public void DoUpdate()
        {
            if (_SelectedItem == null)
            {
                return;
            }

            HostEditer editer = new HostEditer(_Groups, _SelectedItem.Tag as Host);
            if (DialogResult.OK != editer.ShowDialog(this))
            {
                return;
            }

            UpdateItem(_SelectedItem, editer.Host);
            _Modified = true;
        }

        public void DoCreate()
        {
            HostEditer editer = new HostEditer(_Groups, null);
            if (DialogResult.OK != editer.ShowDialog(this))
            {
                return;
            }

            CreateItem(editer.Host);
        }

        public void DoRemove()
        {
            if (DialogResult.Yes != MessageBox.Show(this, "确认要删除此记录吗？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
            {
                return;
            }

            LvItem.Items.Remove(_SelectedItem);
            _SelectedItem = null;
        }

        public void CreateGroup()
        {
            GroupEditer editer = new GroupEditer();
            if (DialogResult.OK != editer.ShowDialog(this))
            {
                return;
            }

            var g = new Group { Text = editer.Group };
            _Groups.Add(g);

            ListViewGroup group = new ListViewGroup(g.Text, g.Text);
            LvItem.Groups.Add(group);
            group.Tag = g;
        }

        public void CreateSolution()
        {
            SolutionEditer editer = new SolutionEditer();
            if (DialogResult.OK != editer.ShowDialog(this))
            {
                return;
            }

            Backup();

            _Solution.Text = editer.Solution;
            StreamWriter writer = new StreamWriter(_HostsFile);
            _Solution.Save(writer);
            writer.WriteLine("# This is a sample HOSTS file used by Microsoft TCP/IP for Windows.");
            writer.WriteLine("#");
            writer.WriteLine("# This file contains the mappings of IP addresses to host names. Each");
            writer.WriteLine("# entry should be kept on an individual line. The IP address should");
            writer.WriteLine("# be placed in the first column followed by the corresponding host name.");
            writer.WriteLine("# The IP address and the host name should be separated by at least one");
            writer.WriteLine("# space.");
            writer.WriteLine("#");
            writer.WriteLine("# Additionally, comments (such as these) may be inserted on individual");
            writer.WriteLine("# lines or following the machine name denoted by a '#' symbol.");
            writer.WriteLine("#");
            writer.WriteLine("# For example:");
            writer.WriteLine("#");
            writer.WriteLine("#      102.54.94.97     rhino.acme.com          # source server");
            writer.WriteLine("#       38.25.63.10     x.acme.com              # x client host");
            writer.WriteLine("#");
            writer.WriteLine("# localhost name resolution is handled within DNS itself.");
            writer.WriteLine("#	127.0.0.1       localhost");
            writer.WriteLine("#	::1             localhost");
            writer.Close();

            LvItem.Groups.Clear();
            LvItem.Items.Clear();
            AppendGroup(_Group);
        }

        public void ChangeSolution(string solution)
        {
            string file = Path.Combine(DAT_DIR, string.Format(HOSTS_FILE, solution));
            if (File.Exists(file))
            {
                MessageBox.Show(this, "您选择的方案文件不存在！", "提示");
                return;
            }

            if (_Modified)
            {
                if (DialogResult.Yes == MessageBox.Show(this, "配置文件已修改，要保存吗？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    Saveas(_HostsFile);
                }
            }

            try
            {
                File.Copy(file, _HostsFile, true);
                Reload();
            }
            catch (Exception exp)
            {
                MessageBox.Show(this, exp.Message, "异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Exit()
        {
            if (_Modified)
            {
                if (DialogResult.Yes == MessageBox.Show(this, "配置文件已修改，要保存吗？", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    Saveas(_HostsFile);
                }
            }

            NiTray.Dispose();
            Close();
        }

        public void Comment()
        {
            MessageBox.Show(this, _Comment, "说明");
        }

        public void About()
        {
            StringBuilder buffer = new StringBuilder();
            buffer.Append("软件名称：MyHosts").Append(Environment.NewLine);
            buffer.Append("当前版本：V1.0.1.2").Append(Environment.NewLine);
            buffer.Append("软件作者：Amon").Append(Environment.NewLine);
            buffer.Append("作者博客：http://amon.me/").Append(Environment.NewLine);
            MessageBox.Show(this, buffer.ToString(), "关于");
        }
        #endregion

        #region 私有函数
        private string FindHostsDir()
        {
            string winDir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            return Path.Combine(winDir, "system32", "drivers", "etc");
        }

        private void ListSolution()
        {
            if (!Directory.Exists(DAT_DIR))
            {
                return;
            }

            string name;
            Solution sln;
            foreach (var file in Directory.GetFiles(DAT_DIR, string.Format(HOSTS_FILE, "*")))
            {
                name = Path.GetFileName(file);
                name = name.Substring(6);
                sln = new Solution { Text = name };
                _Solutions.Add(sln);

                AppendSolution(sln);
            }
        }

        private void UpdateItemEnabled(ListViewItem item, Host host)
        {
            if (host.Enabled)
            {
                item.BackColor = _EnabledBackColor;
                item.ForeColor = host.Modified ? _ChangedColor : _EnabledForeColor;
            }
            else
            {
                item.BackColor = _DisabledBackColor;
                item.ForeColor = host.Modified ? _ChangedColor : _DisabledForeColor;
            }
        }

        private void CreateItem(Host host)
        {
            ListViewItem item = new ListViewItem();
            item.Text = host.IP;
            item.Group = LvItem.Groups[host.Group];
            item.Tag = host;

            var sub = new ListViewItem.ListViewSubItem();
            sub.Text = host.Domain;
            item.SubItems.Add(sub);

            sub = new ListViewItem.ListViewSubItem();
            sub.Text = host.Comment;
            item.SubItems.Add(sub);

            LvItem.Items.Add(item);
            item.Selected = true;
            _SelectedItem = item;
        }

        private void UpdateItem(ListViewItem item, Host host)
        {
            item.Text = host.IP;
            item.SubItems[1].Text = host.Domain;
            item.SubItems[2].Text = host.Comment;
            item.ForeColor = host.Modified ? _ChangedColor : _DefaultColor;
        }

        private void AppendGroup(Group group)
        {
            _Groups.Add(group);

            ListViewGroup g = new ListViewGroup(group.Text, group.Text);
            g.Tag = group;
            LvItem.Groups.Add(g);

            ToolStripMenuItem i = new ToolStripMenuItem();
            i.Text = group.Text;
            i.Click += new EventHandler(CiGroupClick);
            CmGroups.DropDownItems.Add(i);
        }

        private void AppendSolution(Solution solution)
        {
            // 菜单栏
            var item = new ToolStripMenuItem();
            item.Text = solution.Text;
            item.Click += new EventHandler(MiSlnItemClick);
            MuData.DropDownItems.Add(item);

            // 状态栏
            item = new ToolStripMenuItem();
            item.Text = solution.Text;
            item.Click += new EventHandler(TiSlnItemClick);
            TuSln.DropDownItems.Add(item);
        }
        #endregion

        private void NiTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (!Visible)
            {
                Visible = true;
            }
            else
            {
                Activate();
            }
        }

        private void MiSite_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://amon.me/");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void TiHide_Click(object sender, EventArgs e)
        {
            bool hide = !TiHide.Checked;
            TiHide.Checked = hide;
            Settings settings = Settings.Default;
            settings.HideMain = hide;
            settings.Save();
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = false;
            }
        }

        const int WM_SYSCOMMAND = 0x112;
        const int SC_CLOSE = 0xF060;
        const int SC_MINIMIZE = 0xF020;
        const int SC_MAXIMIZE = 0xF030;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_SYSCOMMAND)
            {
                switch (m.WParam.ToInt32())
                {
                    case SC_MINIMIZE:
                        if (Settings.Default.HideMain)
                        {
                            this.Visible = false;
                            return;
                        }
                        break;
                    case SC_CLOSE:
                        if (Settings.Default.HideMain)
                        {
                            this.Visible = false;
                            return;
                        }
                        break;
                }
            }
            base.WndProc(ref m);
        }
    }
}
