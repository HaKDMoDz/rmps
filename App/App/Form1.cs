using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            TextBox tb = new TextBox();
            tb.Multiline = true;
            tb.Size = new Size(350, 200);
            panel1.Controls.Add(tb);
        }
    }
}
