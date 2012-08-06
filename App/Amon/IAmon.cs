namespace Me.Amon
{
    public interface IAmon
    {
        void InitData();

        void LoadView();

        void SaveView();

        void DeInit();

        bool WillExit();

        void Close();
    }
}
