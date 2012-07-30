using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Event;
using Me.Amon.Sql.M;

namespace Me.Amon.Sql.V
{
    public partial class DbConfig : Form
    {
        private Rdbms _DefDdl = new Rdbms { Id = "0", Text = "请选择" };

        public DbConfig()
        {
            InitializeComponent();
        }

        public List<Rdbms> DriverList
        {
            set
            {
                CbDriver.Items.Clear();
                if (value != null)
                {
                    foreach (Rdbms ddl in value)
                    {
                        CbDriver.Items.Add(ddl);
                    }
                }
            }
        }

        public AmonHandler<Rdbms> AmonHandler { get; set; }

        private void BnOk_Click(object sender, System.EventArgs e)
        {
            Rdbms ddl = CbDriver.SelectedItem as Rdbms;
            if (ddl == null || ddl == _DefDdl)
            {
                Main.ShowAlert("请选择驱动引擎！");
                CbDriver.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(TbUri.Text))
            {
                Main.ShowAlert("请输入数据路径！");
                TbUri.Focus();
                return;
            }

            Close();

            if (AmonHandler != null)
            {
                AmonHandler(ddl);
            }
        }

        private void BnNo_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void CbDriver_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            Rdbms item = CbDriver.SelectedItem as Rdbms;
            if (item == null)
            {
                return;
            }

            TbUri.Text = item.Uri;
            TbUser.Text = item.User;
            TbPass.Text = item.Password;
        }
    }
}
