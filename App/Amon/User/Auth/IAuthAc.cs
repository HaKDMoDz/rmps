using System.Windows.Forms;

namespace Me.Amon.User.Auth
{
    public interface IAuthAc
    {
        string Name { get; }

        Control Control { get; }

        void DoAuthAc();

        void DoCancel();
    }
}
