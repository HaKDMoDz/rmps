using System.Windows.Forms;

namespace Me.Amon.Img.E
{
    public class OpenAction : AImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            Main.OpenFileDialog.Filter = "EXE图像|*.exe";
            Main.OpenFileDialog.Multiselect = false;
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog(IApp))
            {
                return;
            }
        }
    }
}
