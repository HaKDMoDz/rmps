 namespace Me.Amon.Pwd.E.View
{
    public class ProPattenAction : APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp != null)
            {
                IApp.ShowAPro();
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
            else if (sender is KeyStroke)
            {
                KeyStroke stroke = sender as KeyStroke;
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

                ItemGroup group = IApp.GetGroup(arr[0]);
                if (group == null)
                {
                    continue;
                }
                group.Checked(arr[1]);
            }
        }
    }
}
