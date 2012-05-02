using System.Windows.Forms;

namespace Me.Amon.Pwd.E.View
{
    public class TopMostAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.TopMost = !IApp.TopMost;
            }
        }

        public override void ReInit()
        {
            if (_Items == null)
            {
                return;
            }

            foreach (ToolStripItem item in _Items)
            {
                if (item is ToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).Checked = IApp.TopMost;
                    continue;
                }
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).Checked = IApp.TopMost;
                }
            }
        }
    }
}
