using System.Windows.Forms;

namespace Me.Amon.Bar
{
    public interface IOpt
    {
        string Name { get; set; }

        void InitView(GroupBox gBox);

        void HideView(GroupBox gBox);

        bool Check();

        string Encode();
    }
}
