using System.Windows.Forms;

namespace Me.Amon.Img
{
    public interface IImg
    {
        void InitOnce();

        Control Control { get; }

        void OpenFile(string file);
    }
}
