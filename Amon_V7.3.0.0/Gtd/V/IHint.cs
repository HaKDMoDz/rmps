using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    interface IHint
    {
        Control Control { get; }

        void ShowData(MGtd mgtd);

        bool SaveData(MGtd mgtd);
    }
}
