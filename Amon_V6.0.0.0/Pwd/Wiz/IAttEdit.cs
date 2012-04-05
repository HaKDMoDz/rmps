using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;

namespace Me.Amon.Pwd.Wiz
{
    public interface IAttEdit
    {
        void InitOnce(TableLayoutPanel grid, ViewModel viewModel);

        int InitView(int row);

        bool ShowData(DataModel dataModel, Att att);

        void Copy();

        bool Save();

        int Height { get; }
    }
}
