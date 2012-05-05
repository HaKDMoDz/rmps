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

        void UpdateAtt(int type);

        void CutAtt();

        void CopyAtt();

        void PasteAtt();

        void ClearAtt();

        void SaveAtt();

        void DropAtt();
    }
}
