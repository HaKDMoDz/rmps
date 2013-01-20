using System.Windows.Forms;

namespace Me.Amon.Pwd
{
    public interface IPwd
    {
        string Model { get; }

        void InitView(Panel panel);

        void HideView(Panel panel);

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

        void CopyAtt(CopyType type);

        void PasteAtt();

        void ClearAtt();

        void SaveAtt();

        void DropAtt();

        bool Focus();
    }
}
