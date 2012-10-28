using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class ExportAction : WIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowSaveFileDialog(IApp.Form, CApp.FILE_SAVE_PNG, ""))
            {
                return;
            }
            IApp.Export(Main.SaveFileDialog.FileName);
        }
    }
}
