using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Uc;

namespace Me.Amon.Pwd.E.View
{
    public class PadPatternAction : APwdAction
    {
        public override void Add(ToolStripItem item, ViewModel viewModel)
        {
            if (_Items == null)
            {
                _Items = new List<ToolStripItem>();
            }

            _Items.Add(item);
            if (viewModel == null)
            {
                return;
            }

            bool ok = viewModel.Pattern == CPwd.PATTERN_PAD;
            if (item is ToolStripMenuItem)
            {
                (item as ToolStripMenuItem).Checked = ok;
                return;
            }
            if (item is ToolStripButton)
            {
                (item as ToolStripButton).Checked = ok;
                return;
            }
        }

        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowAPad();
            }

            string cmd;
            if (sender is ToolStripItem)
            {
                ToolStripItem item = sender as ToolStripItem;
                object obj = item.Tag;
                if (obj == null || !(obj is string))
                {
                    return;
                }

                cmd = obj as string;
            }
            else if (sender is KeyStroke<APwd>)
            {
                KeyStroke<APwd> stroke = sender as KeyStroke<APwd>;
                cmd = stroke.Command;
            }
            else
            {
                return;
            }

            foreach (string tmp in cmd.Split(';'))
            {
                string[] arr = cmd.Split(':');
                if (arr.Length != 2)
                {
                    continue;
                }

                ItemGroup group = IApp.GetItemGroup(arr[0]);
                if (group == null)
                {
                    continue;
                }
                group.Checked(arr[1]);
            }
        }
    }
}
