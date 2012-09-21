using System.Windows.Forms;

namespace Me.Amon.Kms.Robot
{
    public interface IHuman<T>
    {
        UserControl Control { get; }

        bool HideWindow();

        void Init(string catId);

        T Deal();
    }
}
