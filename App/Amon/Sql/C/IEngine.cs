using System.Collections.Generic;
using System.Data;

namespace Me.Amon.Sql.C
{
    public interface IEngine
    {
        void Begin();

        void Close();

        List<string> TableList { get; }

        List<string> ViewList { get; }

        List<string> ProcedureList { get; }

        List<string> FunctionList { get; }

        bool DropTable(string table);

        DataSet DoSelect(string sql);

        int DoExecute(string sql);

        int ImportSql(string sqlFile, SqlConfig sqlCfg);

        int ImportCsv(string csvFile, CsvConfig csvCfg);

        int ImportXml(string xmlFile, XmlConfig xmlCfg);

        int ExportSql(string sqlFile, SqlConfig sqlCfg);

        int ExportCsv(string csvFile, CsvConfig csvCfg);

        int ExportXml(string xmlFile, XmlConfig xmlCfg);
    }
}
