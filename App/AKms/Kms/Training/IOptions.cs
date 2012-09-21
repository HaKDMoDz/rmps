using System.Windows.Forms;
using Me.Amon.Kms.M;

namespace Me.Amon.Kms.Training
{
    public interface IOptions
    {
        void Init();

        void ReInit(MSentence question, MSentence response);

        UserControl GetControl();
    }
}
