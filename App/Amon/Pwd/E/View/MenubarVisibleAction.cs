using System.Windows.Forms;

namespace Me.Amon.Pwd.E.View
{
    public class MenubarVisibleAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (sender is ToolStripMenuItem)
            {
                ToolStripMenuItem item = sender as ToolStripMenuItem;
                IApp.MenuBarVisible = item.Checked;
                return;
            }

            if (sender is ToolStripButton)
            {
                ToolStripButton item = sender as ToolStripButton;
                IApp.MenuBarVisible = item.Checked;
                return;
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
