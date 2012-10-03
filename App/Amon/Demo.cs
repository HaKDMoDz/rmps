using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Da.Db;
using Me.Amon.M;
using Me.Amon.Pwd.M;

namespace Me.Amon
{
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OAuthConsumer consumer = new OAuthConsumer { consumer_key = "2850502466", consumer_secret = "f7daa45a43572bd2a68022c1208f67ab" };
            //WeiboClient client = new WeiboClient(consumer);
            //client.Verify();
            ODBEngine odb = new ODBEngine();
            AUserModel um = new AUserModel();
            um.Init();
            odb.DbInit(um);
            //if (odb.DbVersion.Version != 2)
            {
                odb.Upgrade();
            }
            IList<Lib> libs = odb.ListLib();
            label1.Text = libs.Count.ToString();

            odb.CloseConnect();
        }
    }
}
