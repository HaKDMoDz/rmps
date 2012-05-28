using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class ExportAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }
            IApp.SaveFileDialog.Filter = EApp.FILE_SAVE_PNG;
            if (DialogResult.OK != IApp.SaveFileDialog.ShowDialog())
            {
                return;
            }
            IApp.Export(IApp.SaveFileDialog.FileName);
        }
    }
}
