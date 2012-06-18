using System.Data;

namespace Me.Amon.Sql.C
{
    public class SQLiteEngine : IEngine
    {
        public IDbConnection GetConnection(string uri, string user, string pass)
        {
            return null;
        }

        public IDbCommand GetCommand()
        {
            return null;
        }

        public IDbDataAdapter GetAdapter()
        {
            return null;
        }

        public bool DropTable(string table)
        {
            return true;
        }

        public void Close()
        {
        }
    }
}
