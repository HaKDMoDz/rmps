using System.Windows.Forms;

namespace Me.Amon.Sql.E
{
    public class ImportAction : ASqlAction
    {
        public override void EventHandler(object sender, System.EventArgs e)
        {
            if (IApp == null)
            {
                return;
            }

            Main.OpenFileDialog.Filter = "CSV文件|*.csv";
            Main.OpenFileDialog.Multiselect = false;
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog(IApp.Form))
            {
                return;
            }
            IApp.ImportCsv(Main.OpenFileDialog.FileName, new C.CsvConfig { Seperator = ',' });
        }
    }
}
