using System.Windows.Forms;

namespace Me.Amon.Pwd
{
    public interface IPwd
    {
        void InitView(TableLayoutPanel grid);

        void HideView(TableLayoutPanel grid);

        void ShowInfo();

        void ShowData();

        void AppendKey();

        bool UpdateKey();

        void DeleteKey();

        void AppendAtt(int type);

        void UpdateAtt(int type);

        void CopyAtt();

        void SaveAtt();

        void DropAtt();
    }
}
