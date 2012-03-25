using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public interface IAttEdit
    {
        void InitOnce(DataModel dataModel, ViewModel viewModel);

        Control Control { get; }

        string Title { get; }

        bool ShowData(AAtt att);

        void Copy();

        bool Save();
    }
}
