using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.V.Wiz
{
    public interface IAttEdit
    {
        void InitOnce(TableLayoutPanel grid, ViewModel viewModel);

        int InitView(int row);

        bool ShowData(DataModel dataModel, Att att);

        void Cut();

        void Copy();

        void Paste();

        void Clear();

        bool Save();

        int Height { get; }
    }
}
