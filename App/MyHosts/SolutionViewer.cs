using System;
using System.IO;
using System.Windows.Forms;

namespace Me.Amon.Hosts
{
    public partial class SolutionViewer : Form
    {
        private Main _Main;

        public SolutionViewer()
        {
            InitializeComponent();
        }

        public SolutionViewer(Main main)
        {
            InitializeComponent();

            _Main = main;
            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;

            if (Directory.Exists(Main.DAT_DIR))
            {
                string name;
                foreach (string file in Directory.GetFiles(Main.DAT_DIR, string.Format(Main.HOSTS_FILE, "*")))
                {
                    name = Path.GetFileName(file);
                    LbSln.Items.Add(name.Substring(6));
                }
            }
        }

        #region 事件处理
        private void LbSln_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbSln.Text = "";

            string sln = LbSln.SelectedItem as string;
            if (string.IsNullOrWhiteSpace(sln))
            {
                return;
            }

            TbSln.Text = File.ReadAllText(Path.Combine(Main.DAT_DIR, string.Format(Main.HOSTS_FILE, sln)));
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (LbSln.SelectedItem == null)
            {
                return;
            }
            _Main.Resume(TbSln.Text);
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
