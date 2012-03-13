using System.Windows.Forms;

namespace Me.Amon
{
    public interface IApp
    {
        void InitOnce();

        int AppId { get; set; }

        Form Form { get; }

        void Show();

        bool Visible { get; set; }

        bool IsDisposed { get; }

        void BringToFront();

        bool WillExit();

        bool SaveData();
    }
}
