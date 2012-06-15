﻿using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class SaveIcoAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            Main.SaveFileDialog.Filter = EApp.FILE_SAVE_ICO;
            if (DialogResult.OK != Main.SaveFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.SaveIco(Main.SaveFileDialog.FileName);
        }
    }
}
