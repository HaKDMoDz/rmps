using System.Windows.Forms;

namespace Me.Amon.User.Sign
{
    public interface ISignAc
    {
        string Name { get; }

        Control Control { get; }

        bool Focus();

        void DoSignAc();

        void DoCancel();

        void ShowMenu(Control control, int x, int y);
    }
}
