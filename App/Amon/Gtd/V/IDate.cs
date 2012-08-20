using System.Windows.Forms;

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
