using System.Windows.Forms;

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

            IApp.SaveFileDialog.Filter = "";
            if (DialogResult.OK != IApp.SaveFileDialog.ShowDialog())
            {
                return;
            }
            IApp.SaveIco(IApp.SaveFileDialog.FileName);
        }
    }
}
