using System.Windows.Forms;

namespace Me.Amon.Sec.V.Pro.Uw
{
    public class Open : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            Main.OpenFileDialog.Filter = EApp.FILE_OPEN_ALL;
            Main.OpenFileDialog.FileName = data;
            Main.OpenFileDialog.Multiselect = false;
            if (DialogResult.OK != Main.OpenFileDialog.ShowDialog(asec))
            {
                return;
            }

            if (CallBack != null)
            {
                CallBack.Invoke(Main.OpenFileDialog.FileName);
            }
        }
    }
}
