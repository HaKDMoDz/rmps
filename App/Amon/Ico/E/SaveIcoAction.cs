using System.Windows.Forms;

namespace Me.Amon.Ico.E
{
    public class SaveIcoAction : WIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowSaveFileDialog(IApp.Form, CApp.FILE_SAVE_ICO, ""))
            {
                return;
            }
            IApp.SaveIco(Main.SaveFileDialog.FileName);
        }
    }
}
