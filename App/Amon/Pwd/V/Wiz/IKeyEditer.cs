namespace Me.Amon.Pwd.V.Wiz
{
    public interface IKeyEditer
    {
        string Name { get; set; }

        void InitView(System.Windows.Forms.Panel panel);

        void HideView(System.Windows.Forms.Panel panel);

        bool Focus();

        void ShowData();

        bool SaveData();

        void CutData();

        void CopyData();

        void PasteData();

        void ClearData();
    }
}
