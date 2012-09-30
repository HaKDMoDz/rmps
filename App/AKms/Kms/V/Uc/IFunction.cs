using System.Windows.Forms;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.V.Uc
{
    public interface IFunction
    {
        MFunction UserFunction { get; set; }

        bool SaveFunction();

        UserControl UserControl { get; }
    }
}
