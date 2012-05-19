using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Pro
{
    public interface IAttEdit
    {
        void InitOnce(DataModel dataModel, ViewModel viewModel);

        Control Control { get; }

        string Title { get; }

        bool ShowData(Att att);

        void Cut();

        void Copy();

        void Paste();

        void Clear();

        bool Save();
    }
}
