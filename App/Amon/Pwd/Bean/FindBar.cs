﻿using System;
using System.Windows.Forms;

namespace Me.Amon.Pwd.Bean
{
    public partial class FindBar : UserControl
    {
        private APwd _APwd;

        public FindBar()
        {
            InitializeComponent();
        }

        public FindBar(APwd apwd)
        {
            _APwd = apwd;

            InitializeComponent();
        }

        private void TbFind_TextChanged(object sender, EventArgs e)
        {
            _APwd.FindKey(TbFind.Text);
        }

        private void BtFind_Click(object sender, EventArgs e)
        {
            _APwd.FindKey(TbFind.Text);
        }
    }
}