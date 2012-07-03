using System;
using System.Windows.Forms;

namespace Me.Amon.Ren.E.Rule
{
    public class ExportAction : ARenAction
    {
        public override void EventHandler(object sender, EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowSaveFileDialog(IApp.Form, "重命名模板文件|*.arxml", ""))
            {
                return;
            }
            IApp.ExportRule(Main.SaveFileDialog.FileName);
        }
    }
}
