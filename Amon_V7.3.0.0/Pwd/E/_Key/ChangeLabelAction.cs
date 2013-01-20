using System.Windows.Forms;
using Me.Amon.Util;

namespace Me.Amon.Pwd.E._Key
{
    public class ChangeLabelAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null || !(sender is ToolStripItem))
            {
                return;
            }
            ToolStripItem item = sender as ToolStripItem;
            object obj = item.Tag;
            if (!(obj is string))
            {
                return;
            }
            string cmd = obj as string;
            foreach (string tmp in cmd.Split(';'))
            {
                if (string.IsNullOrWhiteSpace(tmp))
                {
                    continue;
                }
                string[] arr = tmp.Split(':');
                if (arr.Length != 3)
                {
                    continue;
                }

                IApp.SetGroupChecked(arr[0], arr[1]);
                if (CharUtil.IsValidateLong(arr[2]))
                {
                    IApp.ChangeKeyLabel(int.Parse(arr[2]));
                }
            }
        }
    }
}
