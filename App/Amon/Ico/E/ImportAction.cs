﻿using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class ImportAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            IApp.OpenFileDialog.Filter = EApp.FILE_OPEN_IMG;
            if (DialogResult.OK != IApp.OpenFileDialog.ShowDialog())
            {
                return;
            }
            IApp.Import(IApp.OpenFileDialog.FileName);
        }
    }
}