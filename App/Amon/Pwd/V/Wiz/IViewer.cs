namespace Me.Amon.Pwd.V.Wiz
{
    public interface IViewer
    {
        string Name { get; set; }

        bool Focus();

        void ShowData();

        void CopyData();
    }
}
