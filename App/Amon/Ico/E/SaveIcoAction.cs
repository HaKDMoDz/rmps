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

            if (DialogResult.OK != Main.ShowSaveFileDialog(IApp.Form, EApp.FILE_SAVE_ICO, ""))
            {
                return;
            }
            IApp.SaveIco(Main.SaveFileDialog.FileName);
        }
    }
}
