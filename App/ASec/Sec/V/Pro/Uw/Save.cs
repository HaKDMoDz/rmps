using System.Windows.Forms;

namespace Me.Amon.Sec.V.Pro.Uw
{
    public class Save : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            if (DialogResult.OK != Main.ShowSaveFileDialog(asec, CApp.FILE_SAVE_ALL, data))
            {
                return;
            }
            if (CallBack != null)
            {
                CallBack(Main.SaveFileDialog.FileName);
            }
        }
    }
}
