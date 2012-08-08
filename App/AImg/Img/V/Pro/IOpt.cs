using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon.Img.V.Pro
{
    public interface IOpt
    {
        void Init();

        Control Control { get; }

        Image Deal(Image image);

        void Reset();
    }
}
