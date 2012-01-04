using System.Windows.Controls;

namespace Me.Amon.Apwd.Views.Mpwd.Mwiz
{
    public interface ICardCtl
    {
        void InitView(Grid grid);

        void HideView(Grid grid);

        void ShowData();

        bool SaveData();

        void CopyData();
    }
}
