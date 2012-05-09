using System.Windows.Forms;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Pwd.E._Key
{
    public class ChangeMajorAction : APwdAction
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
                if (arr.Length != 2)
                {
                    continue;
                }
                ItemGroup group = IApp.GetItemGroup(arr[0]);
                if (group == null)
                {
                    continue;
                }
                if (CharUtil.IsValidateLong(arr[1]))
                {
                    group.Checked(arr[1]);
                    IApp.ChangeKeyMajor(int.Parse(arr[1]));
                }
            }
        }
    }
}
