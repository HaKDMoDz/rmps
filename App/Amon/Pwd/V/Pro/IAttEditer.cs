using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Pro
{
    interface IAttEditer
    {
        void InitOnce(DataModel dataModel, ViewModel viewModel);

        Control Control { get; }

        string Title { get; }

        bool ShowData(Att att);

        bool Focus();

        void Cut();

        void Copy();

        void Paste();

        void Clear();

        bool Save();
    }
}
