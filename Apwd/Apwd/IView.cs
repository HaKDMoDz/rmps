namespace Me.Amon.Apwd
{
    public interface IView
    {
        string ViewName { get; }

        bool InitView(MainPage main);

        void InitData();
    }
}
