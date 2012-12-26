using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Hosts
{
    public partial class BackupViewer : Form
    {
        public BackupViewer()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Hosts.Properties.Resources.Icon;

            if (Directory.Exists(Main.BAK_DIR))
            {
                string name;
                StringBuilder text = new StringBuilder();
                foreach (string file in Directory.GetFiles(Main.BAK_DIR, string.Format(Main.HOSTS_FILE, "*")))
                {
                    name = Path.GetFileName(file);
                    name = name.Substring(6);
                    if (name.Length != 14)
                    {
                        continue;
                    }

                    text.Append(name);
                    text.Insert(12, ':').Insert(10, ':');
                    text.Insert(8, ' ');
                    text.Insert(6, '-').Insert(4, '-');
                    LbBak.Items.Add(new KVItem { K = name, V = text.ToString() });
                    text.Clear();
                }
            }
        }

        #region 事件处理
        private void LbSln_SelectedIndexChanged(object sender, EventArgs e)
        {
            TbBak.Text = "";

            KVItem item = LbBak.SelectedItem as KVItem;
            if (item == null)
            {
                return;
            }

            TbBak.Text = File.ReadAllText(Path.Combine(Main.BAK_DIR, string.Format(Main.HOSTS_FILE, item.K)));
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            File.WriteAllText(Main.HOSTS_FILE, TbBak.Text);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
