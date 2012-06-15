using System.Windows.Forms;

namespace Me.Amon.Sec.V.Pro.Uw
{
    public class Save : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            Main.SaveFileDialog.Filter = EApp.FILE_OPEN_ALL;
            Main.SaveFileDialog.FileName = data;
            if (DialogResult.OK != Main.SaveFileDialog.ShowDialog(asec))
            {
                return;
            }
            if (CallBack != null)
            {
                CallBack.Invoke(Main.SaveFileDialog.FileName);
            }
        }
    }
}
