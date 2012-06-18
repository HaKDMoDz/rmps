using System.Windows.Forms;

namespace Me.Amon.Img.E
{
    public class OpenAction : AImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(IApp.Form, "EXE图像|*.exe", "", false))
            {
                return;
            }
        }
    }
}
