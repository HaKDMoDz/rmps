namespace Me.Amon.Sql.Editor
{
    public interface IEditor
    {
        bool Check();

        string GetSQL();
    }
}
