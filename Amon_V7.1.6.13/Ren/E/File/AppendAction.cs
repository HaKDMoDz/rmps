using System;
using System.Windows.Forms;

namespace Me.Amon.Ren.E.File
{
    public class AppendAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(IApp.Form, EApp.FILE_OPEN_ALL, "", true))
            {
                return;
            }
            IApp.AppendFile(Main.OpenFileDialog.FileNames);
        }
    }
}
