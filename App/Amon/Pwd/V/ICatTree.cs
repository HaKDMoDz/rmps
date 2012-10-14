using System.Windows.Forms;
using Me.Amon.M;

namespace Me.Amon.Pwd.V
{
    public interface ICatTree
    {
        Control Control { get; }

        ContextMenuStrip PopupMenu { get; set; }

        Cat SelectedCat { get; set; }

        bool Focus();

        void ChangeIcon(Png png);
    }
}
