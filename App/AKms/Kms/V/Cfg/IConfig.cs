using System.Windows.Forms;

namespace Me.Amon.Kms.V.Cfg
{
    interface IConfig
    {
        void Init();

        bool Save();

        UserControl UserControl { get; }
    }
}
