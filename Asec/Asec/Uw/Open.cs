using System.Windows.Forms;

namespace Msec.Uw
{
    public class Open : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(Main main, string data)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "所有文档(*.*)|*.*";
            fd.FileName = data;
            if (DialogResult.OK != fd.ShowDialog(main))
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
