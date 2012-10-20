using System.Windows.Forms;
using Me.Amon.Pwd.M;

namespace Me.Amon.Pwd.V.Wiz.Viewer
{
    public interface IAttViewer
    {
        void InitOnce(TableLayoutPanel grid, ViewModel viewModel);

        int InitView(int row);

        bool ShowData(DataModel dataModel, Att att);

        void Copy();

        int Height { get; }
    }
}
