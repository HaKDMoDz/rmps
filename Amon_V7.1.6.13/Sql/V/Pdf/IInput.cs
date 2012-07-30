using System.Windows.Forms;
using Me.Amon.Sql.Model;

namespace Me.Amon.Sql.V.Pdf
{
    public interface IInput
    {
        Control Control { get; }

        bool Check();

        Param Param { get; set; }
    }
}
