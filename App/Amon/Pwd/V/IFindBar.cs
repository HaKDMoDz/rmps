using System.Windows.Forms;

namespace Me.Amon.Pwd.V
{
    public interface IFindBar
    {
        Control Control { get; }

        bool Visible { get; set; }

        bool Focus();

        IKeyList KeyList { get; set; }
    }
}
