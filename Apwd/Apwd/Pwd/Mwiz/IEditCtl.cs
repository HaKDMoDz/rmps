using System.Windows.Controls;
using Me.Amon.Apwd.Model;

namespace Me.Amon.Apwd.Views.Mpwd.Mwiz
{
    public interface IEditCtl
    {
        void InitView(Grid grid, int row);

        bool ShowData(Att att);

        void Copy();

        void Save();
    }
}
