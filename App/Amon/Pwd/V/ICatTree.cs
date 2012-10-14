using System.Windows.Forms;
using Me.Amon.M;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V
{
    public interface ICatTree
    {
        Control Control { get; }

        ContextMenuStrip PopupMenu { get; set; }

        Cat SelectedCat { get; set; }

        bool Focus();

        void Init(DataModel dataModel);

        void ChangeIcon(Png png);
    }
}
