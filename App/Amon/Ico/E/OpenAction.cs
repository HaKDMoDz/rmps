using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class OpenAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(IApp.Form, EApp.FILE_OPEN_RES, "", false))
            {
                return;
            }
            IApp.Open(Main.OpenFileDialog.FileName);
        }
    }
}
