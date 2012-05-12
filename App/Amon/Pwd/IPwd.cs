using System.Windows.Forms;

namespace Me.Amon.Pwd
{
    public interface IPwd
    {
        string Name { get; }

        void InitView(Panel panel);

        void HideView(Panel panel);

        void ShowInfo();

        void ShowData();

        void AppendKey();

        bool UpdateKey();

        void DeleteKey();

        void AppendAtt(int type);

        void ChangeAtt(int type);

        void SelectPrev();

        void SelectNext();

        void MoveUp();

        void MoveDown();

        void CutAtt();

        void CopyAtt();

        void PasteAtt();

        void ClearAtt();

        void SaveAtt();

        void DropAtt();
    }
}
