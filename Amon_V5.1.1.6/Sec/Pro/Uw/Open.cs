using System.Windows.Forms;

namespace Me.Amon.Sec.Pro.Uw
{
    public class Open : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(ASec asec, string data)
        {
            OpenFileDialog fd = new OpenFileDialog();
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
