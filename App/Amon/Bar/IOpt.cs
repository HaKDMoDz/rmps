using System.Windows.Forms;

namespace Me.Amon.Bar
{
    public interface IOpt
    {
        string Name { get; set; }

        string Text { get; set; }

        void InitView(GroupBox gBox);

        void HideView(GroupBox gBox);

        bool Check();

        string Encode();

        void Decode(string data);
    }
}
