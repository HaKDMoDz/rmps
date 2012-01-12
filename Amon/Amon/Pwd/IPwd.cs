using System.Windows.Forms;
using Me.Amon.Model;

namespace Me.Amon.Pwd
{
    public interface IPwd
    {
        void InitView(TableLayoutPanel grid);

        void HideView(TableLayoutPanel grid);

        void ShowData();

        void ShowData(Key key);

        void AppendKey();

        bool UpdateKey();

        void DeleteKey();

        void CopyAtt();

        void SaveAtt();

        void DropAtt();
    }
}
