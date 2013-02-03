using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Me.Amon.Txt.V.Dlg
{
    public partial class TxtEditor : Form
    {
        public TxtEditor()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }

        public void ShowTxt(string file)
        {
            if (!File.Exists(file))
            {
                return;
            }
            TbTxt.Text = File.ReadAllText(file, Encoding.Default);
            CkWrap.Checked = TbTxt.WordWrap;
        }

        private void CkWrap_CheckedChanged(object sender, EventArgs e)
        {
            TbTxt.WordWrap = CkWrap.Checked;
        }
    }
}
