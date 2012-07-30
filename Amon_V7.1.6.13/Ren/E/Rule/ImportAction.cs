using System;
using System.Windows.Forms;

namespace Me.Amon.Ren.E.Rule
{
    public class ImportAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowOpenFileDialog(IApp.Form, "重命名模板文件|*.arxml", "", false))
            {
                return;
            }
            IApp.ImportRule(Main.OpenFileDialog.FileName);
        }
    }
}
