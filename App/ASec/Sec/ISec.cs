namespace Me.Amon.Sec
{
    /// <summary>
    /// 模块接口
    /// </summary>
    public interface ISec
    {
        string Name { get; set; }

        void LoadFav();

        void SaveFav();

        void DoCrypto();
    }
}
