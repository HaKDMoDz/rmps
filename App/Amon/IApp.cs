using System.Drawing;
using System.Windows.Forms;

namespace Me.Amon
{
    public interface IApp
    {
        int AppId { get; set; }

        Form Form { get; }

        Icon Icon { get; set; }

        void Show();

        void ShowTips(Control control, string caption);

        void ShowEcho(string message);

        void ShowEcho(string message, int delay);

        bool Visible { get; set; }

        bool IsDisposed { get; }

        void Dispose();

        void BringToFront();

        bool WillExit();

        bool SaveData();
    }
}
