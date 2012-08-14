namespace Me.Amon.Gtd.V
{
    interface IEdit
    {
        MGtd MGtd { get; set; }

        void ShowData();

        bool SaveData();
    }
}
