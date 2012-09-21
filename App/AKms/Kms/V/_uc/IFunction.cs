using System.Windows.Forms;
using Me.Amon.Kms.M;

namespace Me.Amon._uc
{
    public interface IFunction
    {
        MFunction UserFunction { get; set; }

        bool SaveFunction();

        UserControl UserControl { get; }
    }
}
