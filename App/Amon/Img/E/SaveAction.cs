using System.Windows.Forms;
namespace Me.Amon.Img.E
{
    public class SaveAction : AImgAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            Main.SaveFileDialog.Filter = "PNG图像|*.png";
            if (DialogResult.OK != Main.SaveFileDialog.ShowDialog(IApp))
            {
                return;
            }
        }
    }
}
