
namespace Me.Amon
{
    public interface IViewModel
    {
        System.Drawing.Image GetImage(string path);

        System.Drawing.Image GetImage(string id, string path);
    }
}
