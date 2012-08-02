using System.Collections.Generic;
using System.Data;

namespace Me.Amon.Sql.C.Engine
{
    public class MSSQLEngine : IEngine
    {
        public void Begin()
        {
        }

        public void Close()
        {
        }

        public List<string> TableList
        {
            get { return null; }
        }

        public List<string> ViewList
        {
            get { return null; }
        }

        public List<string> ProcedureList
        {
            get { return null; }
        }

        public List<string> FunctionList
        {
            get { return null; }
        }

        public bool DropTable(string table)
        {
            return true;
        }

        public DataSet DoSelect(string sql)
        {
            return null;
        }

        public int DoExecute(string sql)
        {
            return 0;
        }

        public int ImportSql(string sqlFile, SqlConfig sqlCfg)
        {
            return 0;
        }

        public int ImportCsv(string csvFile, CsvConfig csvCfg)
        {
            return 0;
        }

        public int ImportXml(string xmlFile, XmlConfig xmlCfg)
        {
            return 0;
        }

        public int ExportSql(string sqlFile, SqlConfig sqlCfg)
        {
            return 0;
        }

        public int ExportCsv(string csvFile, CsvConfig csvCfg)
        {
            return 0;
        }

        public int ExportXml(string xmlFile, XmlConfig xmlCfg)
        {
            return 0;
        }
    }
}
