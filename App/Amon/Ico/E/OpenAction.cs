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

            IApp.OpenFileDialog.Filter = EApp.FILE_OPEN_RES;
            if (DialogResult.OK != IApp.OpenFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.Open(IApp.OpenFileDialog.FileName);
        }
    }
}
