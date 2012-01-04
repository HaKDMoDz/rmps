
namespace Me.Amon.Apwd.Views
{
    public interface IView
    {
        string ViewName { get; }

        bool InitView(MainPage main);

        void InitData();
    }
}
