using System;
using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    public interface ITime
    {
        void Init(DateTime time);

        Control Control { get; }

        void ShowData(MGtd mgtd);

        bool SaveData(MGtd mgtd);
    }
}
