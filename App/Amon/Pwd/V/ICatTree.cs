using System.Windows.Forms;
using Me.Amon.M;

namespace Me.Amon.Pwd.V
{
    public interface ICatTree
    {
        bool Focus();

        Control Control { get; }

        Cat SelectedCat { get; set; }
    }
}
