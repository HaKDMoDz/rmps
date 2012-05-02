using System.Windows.Forms;

namespace Me.Amon.Pwd.E.View
{
    public class MenubarVisibleAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            if (IApp != null)
            {
                IApp.MenuBarVisible = item.Checked;
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
                    (item as ToolStripMenuItem).Checked = IApp.MenuBarVisible;
                    continue;
                }
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).Checked = IApp.MenuBarVisible;
                }
            }
        }
    }
}
