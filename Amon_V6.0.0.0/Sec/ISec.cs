namespace Me.Amon.Sec
{
    public interface ISec
    {
        string Name { get; set; }

        void InitView();

        void HideView();

        void LoadFav();

        void SaveFav();

        void DoCrypto();
    }
}
