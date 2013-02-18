namespace Me.Amon
{
    public interface IView
    {
        string ViewName { get; }

        bool InitView(MainPage main);

        void InitData();
    }
}
