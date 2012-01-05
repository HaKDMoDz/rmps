using System.Windows.Forms;

namespace Msec.Uw
{
    public class Save : IForm<string>
    {
        public CallBackHandler<string> CallBack { get; set; }

        public void Show(Main main, string data)
        {
            SaveFileDialog fd = new SaveFileDialog();
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
