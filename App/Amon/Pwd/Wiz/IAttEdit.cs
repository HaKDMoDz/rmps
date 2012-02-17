using System.Windows.Forms;
using Me.Amon.Bean;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public interface IAttEdit
    {
        void InitOnce(TableLayoutPanel grid, ViewModel viewModel);

        void InitView(int row);

        bool ShowData(DataModel dataModel, AAtt att);

        void Copy();

        bool Save();
    }
}
