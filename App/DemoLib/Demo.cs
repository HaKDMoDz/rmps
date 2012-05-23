using System.Windows.Forms;

namespace DemoLib
{
    public class Demo : Me.Amon.Pwd.E.APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            string cmd = "";
            if (sender is ToolStripItem)
            {
                ToolStripItem item = sender as ToolStripItem;
                cmd = item.Tag as string;
            }
            if (string.IsNullOrEmpty(cmd))
            {
                cmd = "这是一个演示！^_^";
            }
            MessageBox.Show(cmd, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
