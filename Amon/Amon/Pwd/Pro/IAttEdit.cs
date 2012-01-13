using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public interface IAttEdit
    {
        Control Control { get; }

        bool ShowData(AAtt att);

        void Copy();

        void Save();
    }
}
