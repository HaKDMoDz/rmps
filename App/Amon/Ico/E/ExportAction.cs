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
            Main.SaveFileDialog.Filter = EApp.FILE_SAVE_PNG;
            if (DialogResult.OK != Main.SaveFileDialog.ShowDialog())
            {
                return;
            }
            IApp.Export(Main.SaveFileDialog.FileName);
        }
    }
}
