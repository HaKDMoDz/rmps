namespace Me.Amon.Ico
{
    public interface IIco
    {
        void InitOnce();

        void AppendImg();

        void RemoveImg();

        void SaveIco(string file);

        void Import(string file);

        void Export(string file);
    }
}