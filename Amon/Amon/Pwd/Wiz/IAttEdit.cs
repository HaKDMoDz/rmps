using System.Drawing;
using Me.Amon.Model;

namespace Me.Amon.Pwd.Wiz
{
    public interface IAttEdit
    {
        void InitView(int row);

        bool ShowData(AAtt att);

        void Copy();

        bool Save();
    }
}
