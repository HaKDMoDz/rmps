using System.Windows.Forms;

namespace Me.Amon.Img.E
{
    public class SaveAction : WImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (DialogResult.OK != Main.ShowSaveFileDialog(IApp.Form, CApp.FILE_SAVE_PNG, ""))
            {
                return;
            }
        }
    }
}
