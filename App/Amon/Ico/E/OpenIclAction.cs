using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class OpenIclAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            IApp.OpenFileDialog.Filter = "";
            if (DialogResult.OK != IApp.OpenFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.OpenIcl(IApp.OpenFileDialog.FileName);
        }
    }
}
