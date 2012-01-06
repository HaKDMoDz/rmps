using System.Windows.Controls;

namespace Me.Amon.Apwd.Views.Mpwd
{
    public interface IAttEdit
    {
        void InitView(Grid grid);

        void HideView(Grid grid);

        void ShowData(Key key);

        void Append();

        void Update();

        void Delete();

        void CopyAtt();

        void SaveAtt();

        void DropAtt();
    }
}
