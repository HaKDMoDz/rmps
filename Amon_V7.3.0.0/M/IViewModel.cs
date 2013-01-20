
namespace Me.Amon.M
{
    public interface IViewModel
    {
        System.Drawing.Image GetImage(string path);

        System.Drawing.Image GetImage(string id, string path);

        void SaveLayout();

        void LoadLayout();
    }
}
