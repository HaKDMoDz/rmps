using System.Windows.Controls;
using Me.Amon.Model;

namespace Me.Amon.Win.Wiz
{
    public interface IEditCtl
    {
        void InitView(Grid grid, int row);

        bool ShowData(Att att);

        void Copy();

        void Save();
    }
}
