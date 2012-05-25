using System.Windows.Forms;
namespace Me.Amon.Img.E
{
    public class SaveAction : AImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "PNG图像|*.png";
            if (DialogResult.OK != fd.ShowDialog(IApp))
            {
                return;
            }
        }
    }
}
