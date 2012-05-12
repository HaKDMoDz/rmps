using System.Windows.Forms;

namespace DemoLib
{
    public class Demo : Me.Amon.Pwd.E.APwdAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            MessageBox.Show("这是一个演示！^_^", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
