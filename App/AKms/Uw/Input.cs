﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Uw
{
    public partial class Input : Form
    {
        public Input()
        {
            InitializeComponent();
        }

        public Input(Icon icon)
        {
            InitializeComponent();

            this.Icon = icon;
        }

        public void Show(IWin32Window owner, string message, string deftext)
        {
            LbTips.Text = message;
            TbText.Text = deftext;
            ShowDialog(owner);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TbText.Text))
            {
                TbText.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Visible = false;
        }

        private void BtCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Visible = false;
        }

        public string Message
        {
            get
            {
                return TbText.Text;
            }
        }
    }
}
