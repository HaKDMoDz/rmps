using System.Windows.Controls;

namespace Me.Amon.Win.Wiz
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
