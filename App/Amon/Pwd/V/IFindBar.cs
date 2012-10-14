using System.Windows.Forms;

namespace Me.Amon.Pwd.V
{
    public interface IFindBar
    {
        Control Control { get; }

        bool Visible { get; set; }
    }
}
