namespace Me.Amon.Pwd.V.Wiz
{
    public interface IViewer
    {
        string Name { get; set; }

        void InitView();

        void HideView();

        bool Focus();

        void ShowData();

        void CopyData();
    }
}
