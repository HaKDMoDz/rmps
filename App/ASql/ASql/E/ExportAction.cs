using System.Windows.Forms;

namespace Me.Amon.Sql.E
{
    public class ExportAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            Main.SaveFileDialog.Filter = "CSV文件|*.csv";
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.ExportCsv(Main.SaveFileDialog.FileName, new C.CsvConfig());
        }
    }
}
