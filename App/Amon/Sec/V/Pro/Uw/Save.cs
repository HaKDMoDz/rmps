using System.Windows.Forms;

namespace Me.Amon.Sec.V.Pro.Uw
{
    public class Save : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            SaveFileDialog fd = new SaveFileDialog();
            fd.Filter = "所有文档(*.*)|*.*";
            fd.FileName = data;
            if (DialogResult.OK != fd.ShowDialog(asec))
            {
                return;
            }
            if (CallBack != null)
            {
                CallBack.Invoke(fd.FileName);
            }
        }
    }
}
