using System.Data;

namespace Me.Amon.Sql.C
{
    public interface IEngine
    {
        IDbConnection GetConnection(string uri, string user, string pass);

        IDbCommand GetCommand();

        IDbDataAdapter GetAdapter();

        bool DropTable(string table);

        void Close();
    }
}
