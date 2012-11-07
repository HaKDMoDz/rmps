using System.Windows.Forms;
using Me.Amon.Util;
namespace Me.Amon.Ico.E
{
    public class AppendImgAction : AIcoAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string cmd = item.Tag as string;
            int dim = 0;
            if (CharUtil.IsValidateLong(cmd))
            {
                dim = int.Parse(cmd);
                if (dim > 256)
                {
                    dim = 256;
                }
            }
            else
            {
            }

            IApp.AppendImg(dim);
        }
    }
}
