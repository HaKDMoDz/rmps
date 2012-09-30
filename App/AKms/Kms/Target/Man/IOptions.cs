using System.Windows.Forms;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Target.Man
{
    public interface IOptions
    {
        void Init();

        void ReInit(MSentence question, MSentence response);

        UserControl GetControl();
    }
}
