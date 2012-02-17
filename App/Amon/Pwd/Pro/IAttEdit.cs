using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Pro
{
    public interface IAttEdit
    {
        Control Control { get; }

        string Title { get; }

        void InitOnce(DataModel dataModel, ViewModel viewModel);

        bool ShowData(AAtt att);

        void Copy();

        void Save();
    }
}
