using System.Windows.Forms;

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

            if (DialogResult.OK != Main.ShowOpenFileDialog(IApp.Form, CApp.FILE_OPEN_IMG, "", false))
            {
                return;
            }
            IApp.Import(Main.OpenFileDialog.FileName);
        }
    }
}
