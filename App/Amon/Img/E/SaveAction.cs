using System.Windows.Forms;

namespace Me.Amon.Img.E
{
    public class SaveAction : AImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (DialogResult.OK != Main.ShowSaveFileDialog(IApp.Form, EApp.FILE_SAVE_PNG, ""))
            {
                return;
            }
        }
    }
}
