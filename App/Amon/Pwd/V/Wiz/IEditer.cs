namespace Me.Amon.Pwd.V.Wiz
{
    public interface IEditer
    {
        string Name { get; set; }

        void InitView();

        void HideView();

        bool Focus();

        void ShowData();

        bool SaveData();

        void CutData();

        void CopyData();

        void PasteData();

        void ClearData();
    }
}
