using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    interface IDate
    {
        Control Control { get; }

        MGtd MGtd { get; set; }

        void ShowData();

        bool SaveData();
    }
}
