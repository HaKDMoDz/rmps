using Me.Amon.Sql.C;

namespace Me.Amon.Sql.V
{
    public interface IEditor
    {
        void Init(IEngine engine);

        bool Check();

        string GetSQL();
    }
}
