using System.Windows.Forms;

namespace Me.Amon.Pwd.E.View
{
    public class CatAction : AAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            if (APwd != null)
            {
                APwd.SetCatTreeVisible(item.Checked);
            }
        }
    }
}
