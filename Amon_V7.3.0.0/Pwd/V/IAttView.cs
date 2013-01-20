using System.Windows.Forms;

namespace Me.Amon.Pwd.V
{
    public interface IAttView
    {
        Control Control { get; }

        void ShowData();
    }
}
