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

            Main.OpenFileDialog.Filter = EApp.FILE_OPEN_RES;
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.Open(Main.OpenFileDialog.FileName);
        }
    }
}
