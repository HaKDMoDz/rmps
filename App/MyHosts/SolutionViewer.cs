using System;
using System.IO;
using System.Windows.Forms;

namespace Me.Amon.Hosts
{
    public partial class SolutionViewer : Form
    {
        public SolutionViewer()
        {
            InitializeComponent();

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
            File.WriteAllText(Main.HOSTS_FILE, TbSln.Text);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
