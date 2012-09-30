using System;
using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Open.V2.App.Client;

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
            OAuthConsumer consumer = new OAuthConsumer { consumer_key = "2850502466", consumer_secret = "f7daa45a43572bd2a68022c1208f67ab" };
            WeiboClient client = new WeiboClient(consumer);
            client.Verify();
        }
    }
}
