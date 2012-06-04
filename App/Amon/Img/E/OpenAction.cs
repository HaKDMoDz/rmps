using System.Windows.Forms;

namespace Me.Amon.Img.E
{
    public class OpenAction : AImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "EXE图像|*.exe";
            if (DialogResult.OK != fd.ShowDialog(IApp))
            {
                return;
            }
        }
    }
}
