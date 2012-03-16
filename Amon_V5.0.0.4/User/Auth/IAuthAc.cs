using System.Windows.Forms;

namespace Me.Amon.User.Auth
{
    public interface IAuthAc
    {
        string Name { get; }

        Control Control { get; }

        void DoAuthAc();

        void DoCancel();

        void ShowMenu(Control control, int x, int y);
    }
}
