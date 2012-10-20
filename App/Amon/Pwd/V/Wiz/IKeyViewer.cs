namespace Me.Amon.Pwd.V.Wiz
{
    public interface IKeyViewer
    {
        string Name { get; set; }

        bool Focus();

        void ShowData();

        void CopyData();
    }
}
