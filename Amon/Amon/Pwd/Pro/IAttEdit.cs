using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public interface IAttEdit
    {
        Control Control { get; }

        string Title { get; }

        bool ShowData(DataModel dataModel, AAtt att);

        void Copy();

        void Save();
    }
}
