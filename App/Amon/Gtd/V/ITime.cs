using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public interface ITime
    {
        Control Control { get; }

        void ShowData(MGtd mgtd);

        bool SaveData(MGtd mgtd);
    }
}
