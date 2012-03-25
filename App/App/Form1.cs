using System;
using System.Drawing.IconLib;
using System.Windows.Forms;
using Db4objects.Db4o;
using System.Drawing;

namespace App
{
    public partial class Form1 : Form
    {
        private IObjectContainer _Container;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_Container == null)
            {
                _Container = Db4oEmbedded.OpenFile("a.dbo");
            }

            Demo demo = new Demo();
            demo.A = "A";
            demo.C = 2;
            demo.Icon = Image.FromFile(@"F:\1.png");

            _Container.Store(demo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_Container == null)
            {
                _Container = Db4oEmbedded.OpenFile("a.dbo");
            }

            Demo demo = new Demo { A = "A" };
            IObjectSet b = _Container.QueryByExample(demo);
            Demo c = (Demo)b.Next();
            demo.A = "B";
        }
    }
}
