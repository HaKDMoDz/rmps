using System.Windows.Forms;

namespace Me.Amon.Sec.V.Pro.Uw
{
    public class Open : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(asec, EApp.FILE_OPEN_ALL, data, false))
            {
                return;
            }

            if (CallBack != null)
            {
                CallBack(Main.OpenFileDialog.FileName);
            }
        }
    }
}
