using System.Windows.Forms;

namespace Me.Amon.Pwd.Wiz
{
    public interface IWizView
    {
        string Name { get; set; }

        void InitView(TableLayoutPanel grid);

        void HideView(TableLayoutPanel grid);

        void ShowData();

        bool SaveData();

        void CopyData();
    }
}
