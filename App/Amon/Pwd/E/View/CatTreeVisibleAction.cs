using System.Windows.Forms;

namespace Me.Amon.Pwd.E.View
{
    public class CatTreeVisibleAction : APwdAction
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

        public override void ReInit()
        {
            if (_Items == null || ViewModel == null)
            {
                return;
            }

            foreach (ToolStripItem item in _Items)
            {
                if (item is ToolStripMenuItem)
                {
                    (item as ToolStripMenuItem).Checked = ViewModel.CatTreeVisible;
                    continue;
                }
                if (item is ToolStripButton)
                {
                    (item as ToolStripButton).Checked = ViewModel.CatTreeVisible;
                }
            }
        }
    }
}
