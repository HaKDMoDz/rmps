using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Me.Amon.Model;
using Me.Amon.Util;

namespace Me.Amon.Da
{
    /// <summary>
    /// 数据库
    /// </summary>
    public class DBAccess
    {
        private string _DbPath;
        private SqlConnection _Connection;
        /// <summary>
        /// 当前要操作的字段名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _ColumList;

        /// <summary>
        /// 数据库查寻时的排序依据（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _OrderList;

        /// <summary>
        /// 数据KEY-VALUE对持有变量
        /// </summary>
        private readonly List<string> _ParamList;

        /// <summary>
        /// 符号持有变量
        /// </summary>
        private readonly List<string> _SignList;

        /// <summary>
        /// 当前要操作的表格名称（列表（以逗号“,”分隔符区分））
        /// </summary>
        private readonly StringBuilder _TableList;

        /// <summary>
        /// 数据插入时数据列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly List<string> _ValueList;

        /// <summary>
        /// 数据库操作时的关联条件列表（以逗号“,”分隔符区分）
        /// </summary>
        private readonly StringBuilder _WhereList;
        private readonly List<string> _BatchList;

        private int _MinLimit;
        private int _MaxLimit;

        DBAccess()
        {
            // 参数列表
            _ParamList = new List<string>();
            // 关联符号
            _SignList = new List<string>();
            // 数据列表
            _ValueList = new List<string>();
            // 字段缓冲
            _ColumList = new StringBuilder();
            // 表格缓冲
            _TableList = new StringBuilder();
            // 关联每件缓冲
            _WhereList = new StringBuilder();
            // 排序依据缓冲
            _OrderList = new StringBuilder();
            _BatchList = new List<string>();
        }

        public void Init(UserModel userModel)
        {
            _DbPath = Path.Combine(userModel.Home, IEnv.FILE_DB);

            if (!File.Exists(_DbPath))
            {
                DbInit();
            }
        }

        public void CloseConnect()
        {
            if (_Connection != null)
            {
                _Connection.Close();
                _Connection = null;
            }
        }

        private SqlConnection BeginConnect
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SqlConnection("Data Source=" + _DbPath + ";Version=3;");
                    _Connection.Open();
                }
                if (_Connection.State == ConnectionState.Closed)
                {
                    _Connection.Open();
                }
                return _Connection;
            }
        }

        private void DbInit()
        {
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    StringBuilder sql = new StringBuilder();
                    sql.Append("CREATE TABLE ").Append(DBConst.ACAT0100).Append("(");
                    sql.Append(DBConst.ACAT0101).Append(" INT,");
                    sql.Append(DBConst.ACAT0102).Append(" VARCHAR(").Append(DBConst.ACAT0102_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0103).Append(" VARCHAR(").Append(DBConst.ACAT0103_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0104).Append(" VARCHAR(").Append(DBConst.ACAT0104_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0105).Append(" VARCHAR(").Append(DBConst.ACAT0105_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0106).Append(" VARCHAR(").Append(DBConst.ACAT0106_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0107).Append(" VARCHAR(").Append(DBConst.ACAT0107_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0108).Append(" DATETIME,");
                    sql.Append(DBConst.ACAT0109).Append(" DATETIME,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.ACAT0103).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.ACAT0200).Append("(");
                    sql.Append(DBConst.ACAT0201).Append(" INT,");
                    sql.Append(DBConst.ACAT0202).Append(" VARCHAR(").Append(DBConst.ACAT0202_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0203).Append(" VARCHAR(").Append(DBConst.ACAT0203_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0204).Append(" VARCHAR(").Append(DBConst.ACAT0204_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0205).Append(" VARCHAR(").Append(DBConst.ACAT0205_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0206).Append(" VARCHAR(").Append(DBConst.ACAT0206_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0207).Append(" VARCHAR(").Append(DBConst.ACAT0207_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0208).Append(" VARCHAR(").Append(DBConst.ACAT0208_SIZE).Append("),");
                    sql.Append(DBConst.ACAT0209).Append(" VARCHAR(").Append(DBConst.ACAT0209_SIZE).Append("),");
                    sql.Append(DBConst.ACAT020A).Append(" DATETIME,");
                    sql.Append(DBConst.ACAT020B).Append(" DATETIME,");
                    sql.Append(DBConst.ACAT020C).Append(" INT,");
                    sql.Append(DBConst.ACAT020D).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.ACAT0202).Append(",").Append(DBConst.ACAT0203).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0000).Append("(");
                    sql.Append(DBConst.APWD0001).Append(" VARCHAR(").Append(DBConst.APWD0001_SIZE).Append("),");
                    sql.Append(DBConst.APWD0002).Append(" VARCHAR(").Append(DBConst.APWD0002_SIZE).Append("),");
                    sql.Append(DBConst.APWD0003).Append(" VARCHAR(").Append(DBConst.APWD0003_SIZE).Append("),");
                    sql.Append(DBConst.APWD0004).Append(" DATETIME,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0001).Append(",").Append(DBConst.APWD0002).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0100).Append("(");
                    sql.Append(DBConst.APWD0101).Append(" INT,");
                    sql.Append(DBConst.APWD0102).Append(" INT,");
                    sql.Append(DBConst.APWD0103).Append(" INT,");
                    sql.Append(DBConst.APWD0104).Append(" VARCHAR(").Append(DBConst.APWD0104_SIZE).Append("),");
                    sql.Append(DBConst.APWD0105).Append(" VARCHAR(").Append(DBConst.APWD0105_SIZE).Append("),");
                    sql.Append(DBConst.APWD0106).Append(" VARCHAR(").Append(DBConst.APWD0106_SIZE).Append("),");
                    sql.Append(DBConst.APWD0107).Append(" VARCHAR(").Append(DBConst.APWD0107_SIZE).Append("),");
                    sql.Append(DBConst.APWD0108).Append(" VARCHAR(").Append(DBConst.APWD0108_SIZE).Append("),");
                    sql.Append(DBConst.APWD0109).Append(" VARCHAR(").Append(DBConst.APWD0109_SIZE).Append("),");
                    sql.Append(DBConst.APWD010A).Append(" VARCHAR(").Append(DBConst.APWD010A_SIZE).Append("),");
                    sql.Append(DBConst.APWD010B).Append(" VARCHAR(").Append(DBConst.APWD010B_SIZE).Append("),");
                    sql.Append(DBConst.APWD010C).Append(" VARCHAR(").Append(DBConst.APWD010C_SIZE).Append("),");
                    sql.Append(DBConst.APWD010D).Append(" VARCHAR(").Append(DBConst.APWD010D_SIZE).Append("),");
                    sql.Append(DBConst.APWD010E).Append(" VARCHAR(").Append(DBConst.APWD010E_SIZE).Append("),");
                    sql.Append(DBConst.APWD010F).Append(" VARCHAR(").Append(DBConst.APWD010F_SIZE).Append("),");
                    sql.Append(DBConst.APWD0110).Append(" VARCHAR(").Append(DBConst.APWD0110_SIZE).Append("),");
                    sql.Append(DBConst.APWD0111).Append(" VARCHAR(").Append(DBConst.APWD0111_SIZE).Append("),");
                    sql.Append(DBConst.APWD0112).Append(" CHAR(1),");
                    sql.Append(DBConst.APWD0113).Append(" INT,");
                    sql.Append(DBConst.APWD0114).Append(" INT,");
                    sql.Append(DBConst.APWD0115).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0104).Append(",").Append(DBConst.APWD0105).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0200).Append("(");
                    sql.Append(DBConst.APWD0201).Append(" INT,");
                    sql.Append(DBConst.APWD0202).Append(" VARCHAR(").Append(DBConst.APWD0202_SIZE).Append("),");
                    sql.Append(DBConst.APWD0203).Append(" VARCHAR(").Append(DBConst.APWD0203_SIZE).Append("),");
                    sql.Append(DBConst.APWD0204).Append(" VARCHAR(").Append(DBConst.APWD0204_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0201).Append(",").Append(DBConst.APWD0202).Append(",").Append(DBConst.APWD0203).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0300).Append("(");
                    sql.Append(DBConst.APWD0301).Append(" INT,");
                    sql.Append(DBConst.APWD0302).Append(" INT,");
                    sql.Append(DBConst.APWD0303).Append(" VARCHAR(").Append(DBConst.APWD0303_SIZE).Append("),");
                    sql.Append(DBConst.APWD0304).Append(" VARCHAR(").Append(DBConst.APWD0304_SIZE).Append("),");
                    sql.Append(DBConst.APWD0305).Append(" VARCHAR(").Append(DBConst.APWD0305_SIZE).Append("),");
                    sql.Append(DBConst.APWD0306).Append(" VARCHAR(").Append(DBConst.APWD0306_SIZE).Append("),");
                    sql.Append(DBConst.APWD0307).Append(" VARCHAR(").Append(DBConst.APWD0307_SIZE).Append("),");
                    sql.Append(DBConst.APWD0308).Append(" VARCHAR(").Append(DBConst.APWD0308_SIZE).Append("),");
                    sql.Append(DBConst.APWD0309).Append(" DATETIME,");
                    sql.Append(DBConst.APWD030A).Append(" DATETIME,");
                    sql.Append(DBConst.APWD030B).Append(" INT,");
                    sql.Append(DBConst.APWD030C).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0303).Append(",").Append(DBConst.APWD0304).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0400).Append("(");
                    sql.Append(DBConst.APWD0401).Append(" INT,");
                    sql.Append(DBConst.APWD0402).Append(" VARCHAR(").Append(DBConst.APWD0402_SIZE).Append("),");
                    sql.Append(DBConst.APWD0403).Append(" VARCHAR(").Append(DBConst.APWD0403_SIZE).Append("),");
                    sql.Append(DBConst.APWD0404).Append(" VARCHAR(").Append(DBConst.APWD0404_SIZE).Append("),");
                    sql.Append(DBConst.APWD0405).Append(" VARCHAR(").Append(DBConst.APWD0405_SIZE).Append("),");
                    sql.Append(DBConst.APWD0406).Append(" VARCHAR(").Append(DBConst.APWD0406_SIZE).Append("),");
                    sql.Append(DBConst.APWD0407).Append(" VARCHAR(").Append(DBConst.APWD0407_SIZE).Append("),");
                    sql.Append(DBConst.APWD0408).Append(" INT,");
                    sql.Append(DBConst.APWD0409).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0402).Append(",").Append(DBConst.APWD0403).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.AICO0100).Append("(");
                    sql.Append(DBConst.AICO0101).Append(" INT,");
                    sql.Append(DBConst.AICO0102).Append(" VARCHAR(").Append(DBConst.AICO0102_SIZE).Append("),");
                    sql.Append(DBConst.AICO0103).Append(" VARCHAR(").Append(DBConst.AICO0103_SIZE).Append("),");
                    sql.Append(DBConst.AICO0104).Append(" VARCHAR(").Append(DBConst.AICO0104_SIZE).Append("),");
                    sql.Append(DBConst.AICO0105).Append(" VARCHAR(").Append(DBConst.AICO0105_SIZE).Append("),");
                    sql.Append(DBConst.AICO0106).Append(" VARCHAR(").Append(DBConst.AICO0106_SIZE).Append("),");
                    sql.Append(DBConst.AICO0107).Append(" VARCHAR(").Append(DBConst.AICO0107_SIZE).Append("),");
                    sql.Append(DBConst.AICO0108).Append(" INT,");
                    sql.Append(DBConst.AICO0109).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.AICO0102).Append(",").Append(DBConst.AICO0103).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.AUDC0100).Append("(");
                    sql.Append(DBConst.AUDC0101).Append(" INT,");
                    sql.Append(DBConst.AUDC0102).Append(" VARCHAR(").Append(DBConst.AUDC0102_SIZE).Append("),");
                    sql.Append(DBConst.AUDC0103).Append(" VARCHAR(").Append(DBConst.AUDC0103_SIZE).Append("),");
                    sql.Append(DBConst.AUDC0104).Append(" VARCHAR(").Append(DBConst.AUDC0104_SIZE).Append("),");
                    sql.Append(DBConst.AUDC0105).Append(" VARCHAR(").Append(DBConst.AUDC0105_SIZE).Append("),");
                    sql.Append(DBConst.AUDC0106).Append(" VARCHAR(").Append(DBConst.AUDC0106_SIZE).Append("),");
                    sql.Append(DBConst.AUDC0107).Append(" VARCHAR(").Append(DBConst.AUDC0107_SIZE).Append("),");
                    sql.Append(DBConst.AUDC0108).Append(" DATETIME,");
                    sql.Append(DBConst.AUDC0109).Append(" DATETIME,");
                    sql.Append(DBConst.AUDC010A).Append(" INT,");
                    sql.Append(DBConst.AUDC010B).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.AUDC0103).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0A00).Append("(");
                    sql.Append(DBConst.APWD0A01).Append(" VARCHAR(").Append(DBConst.APWD0A01_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A02).Append(" INT,");
                    sql.Append(DBConst.APWD0A03).Append(" INT,");
                    sql.Append(DBConst.APWD0A04).Append(" VARCHAR(").Append(DBConst.APWD0A04_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A05).Append(" VARCHAR(").Append(DBConst.APWD0A05_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A06).Append(" VARCHAR(").Append(DBConst.APWD0A06_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A07).Append(" VARCHAR(").Append(DBConst.APWD0A07_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A08).Append(" VARCHAR(").Append(DBConst.APWD0A08_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A09).Append(" VARCHAR(").Append(DBConst.APWD0A09_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A0A).Append(" VARCHAR(").Append(DBConst.APWD0A0A_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A0B).Append(" VARCHAR(").Append(DBConst.APWD0A0B_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A0C).Append(" VARCHAR(").Append(DBConst.APWD0A0C_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A0D).Append(" VARCHAR(").Append(DBConst.APWD0A0D_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A0E).Append(" VARCHAR(").Append(DBConst.APWD0A0E_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A0F).Append(" VARCHAR(").Append(DBConst.APWD0A0F_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A10).Append(" VARCHAR(").Append(DBConst.APWD0A10_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A11).Append(" VARCHAR(").Append(DBConst.APWD0A11_SIZE).Append("),");
                    sql.Append(DBConst.APWD0A12).Append(" CHAR(1),");
                    sql.Append(DBConst.APWD0A13).Append(" INT,");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0A01).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("CREATE TABLE ").Append(DBConst.APWD0B00).Append("(");
                    sql.Append(DBConst.APWD0B01).Append(" INT,");
                    sql.Append(DBConst.APWD0B02).Append(" INT,");
                    sql.Append(DBConst.APWD0B03).Append(" VARCHAR(").Append(DBConst.APWD0B03_SIZE).Append("),");
                    sql.Append(DBConst.APWD0B04).Append(" VARCHAR(").Append(DBConst.APWD0B04_SIZE).Append("),");
                    sql.Append(DBConst.APWD0B05).Append(" VARCHAR(").Append(DBConst.APWD0B05_SIZE).Append("),");
                    sql.Append("PRIMARY KEY (").Append(DBConst.APWD0B01).Append(",").Append(DBConst.APWD0B02).Append(",").Append(DBConst.APWD0B03).Append(")");
                    sql.Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();

                    //sql.Clear();
                    //sql.Append("CREATE TABLE ").Append(IDat.AGTD0100).Append("(");
                    //sql.Append(IDat.AGTD0101).Append(" INT,");
                    //sql.Append(IDat.AGTD0102).Append(" INT,");
                    //sql.Append(IDat.AGTD0103).Append(" INT,");
                    //sql.Append(IDat.AGTD0104).Append(" INT,");
                    //sql.Append(IDat.AGTD0105).Append(" INT,");
                    //sql.Append(IDat.AGTD0106).Append(" INT,");
                    //sql.Append(IDat.AGTD0107).Append(" INT,");
                    //sql.Append(IDat.AGTD0108).Append(" INT,");
                    //sql.Append(IDat.AGTD0109).Append(" VARCHAR(").Append(IDat.AGTD0109_SIZE).Append("),");
                    //sql.Append(IDat.AGTD010A).Append(" VARCHAR(").Append(IDat.AGTD010A_SIZE).Append("),");
                    //sql.Append(IDat.AGTD010B).Append(" VARCHAR(").Append(IDat.AGTD010B_SIZE).Append("),");
                    //sql.Append(IDat.AGTD010C).Append(" VARCHAR(").Append(IDat.AGTD010C_SIZE).Append("),");
                    //sql.Append(IDat.AGTD010D).Append(" INT,");
                    //sql.Append(IDat.AGTD010E).Append(" INT,");
                    //sql.Append(IDat.AGTD010F).Append(" INT,");
                    //sql.Append(IDat.AGTD0110).Append(" VARCHAR(").Append(IDat.AGTD0110_SIZE).Append("),");
                    //sql.Append(IDat.AGTD0111).Append(" VARCHAR(").Append(IDat.AGTD0111_SIZE).Append("),");
                    //sql.Append(IDat.AGTD0112).Append(" INT,");
                    //sql.Append(IDat.AGTD0113).Append(" INT,");
                    //sql.Append(IDat.AGTD0114).Append(" VARCHAR(").Append(IDat.AGTD0114_SIZE).Append("),");
                    //sql.Append("PRIMARY KEY (").Append(IDat.AGTD0109).Append(")");
                    //sql.Append(")");
                    //mycommand.CommandText = sql.ToString();
                    //mycommand.ExecuteNonQuery();

                    //sql.Clear();
                    //sql.Append("CREATE TABLE ").Append(IDat.AGTD0200).Append("(");
                    //sql.Append(IDat.AGTD0201).Append(" INT,");
                    //sql.Append(IDat.AGTD0202).Append(" VARCHAR(").Append(IDat.AGTD0202_SIZE).Append("),");
                    //sql.Append(IDat.AGTD0203).Append(" INT,");
                    //sql.Append(IDat.AGTD0204).Append(" INT,");
                    //sql.Append(IDat.AGTD0205).Append(" INT,");
                    //sql.Append(IDat.AGTD0206).Append(" VARCHAR(").Append(IDat.AGTD0206_SIZE).Append("),");
                    //sql.Append("PRIMARY KEY (").Append(IDat.AGTD0201).Append(",").Append(IDat.AGTD0202).Append(")");
                    //sql.Append(")");
                    //mycommand.CommandText = sql.ToString();
                    //mycommand.ExecuteNonQuery();

                    sql.Clear();
                    sql.Append("INSERT INTO ").Append(DBConst.APWD0000).Append("(");
                    sql.Append(DBConst.APWD0001).Append(",");
                    sql.Append(DBConst.APWD0002).Append(",");
                    sql.Append(DBConst.APWD0003).Append(",");
                    sql.Append(DBConst.APWD0004).Append(") VALUES (");
                    sql.Append("'version','db','").Append(DBConst.VER_DB).Append("',").Append(DBConst.SQL_NOW).Append(")");
                    mycommand.CommandText = sql.ToString();
                    Main.LogInfo(mycommand.CommandText);
                    mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        public void AddTable(string table)
        {
            if (CharUtil.IsValidate(table))
            {
                _TableList.Append(", ").Append(table);
            }
        }

        /// <summary>
        /// 添加要使用的表格
        /// </summary>
        /// <param name="table"></param>
        /// <param name="alies"></param>
        public void AddTable(string table, string alies)
        {
            if (CharUtil.IsValidate(table))
            {
                _TableList.Append(", ").Append(table).Append(" AS ").Append(alies);
            }
        }

        /// <summary>
        /// 添加带连接的表格
        /// </summary>
        /// <param name="tableLeft"></param>
        /// <param name="tableRight"></param>
        /// <param name="joinStyle"></param>
        public void AddTable(string tableLeft, string tableRight, string joinStyle)
        {
            _TableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
        }

        /// <summary>
        /// 添加带连接的表格
        /// </summary>
        /// <param name="tableLeft"></param>
        /// <param name="tableRight"></param>
        /// <param name="joinStyle"></param>
        /// <param name="columnLeft"></param>
        /// <param name="columnRight"></param>
        public void AddTable(string tableLeft,
                             string tableRight,
                             string joinStyle,
                             string columnLeft,
                             string columnRight)
        {
            _TableList.Append(", ").Append(tableLeft).Append(' ').Append(joinStyle).Append(' ').Append(tableRight);
            _TableList.Append(" ON ").Append(columnLeft).Append(" = ").Append(columnRight);
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1, colname2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        public void AddColumn(string colname)
        {
            if (CharUtil.IsValidate(colname))
            {
                _ColumList.Append(", ").Append(colname);
            }
        }

        /// <summary>
        /// 添加查寻字段<br></br>
        /// SELECT colname1 AS col1, colname2 AS col2, ... FROM tablename
        /// </summary>
        /// <param name="colname">对于于要查寻的表格的相关字段</param>
        /// <param name="alies">字段别名</param>
        public void AddColumn(string colname, string alies)
        {
            if (CharUtil.IsValidate(colname))
            {
                _ColumList.Append(", ").Append(colname).Append(" AS ").Append(alies);
            }
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。<br>
        /// UPDATE SET key1=value1, key2=value2 ... 
        /// </summary>
        /// <param name="key">数据库字段名</param>
        /// <param name="value">对应字段的值</param>
        public void AddParam(string key, string value)
        {
            AddParam(key, value, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddParam(string key, long value)
        {
            AddParam(key, "=", value);
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// UPDATE SET key1=value1, key2=value2 ... 
        /// </summary>
        /// <param name="key">数据库字段名</param>
        /// <param name="value">对应字段的值</param>
        /// <param name="isLiteral">当前字段是否为纯文本，true为纯文本，false为其它格式。</param>
        public void AddParam(string key, string value, bool isLiteral)
        {
            AddParam(key, "=", value, isLiteral);
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// </summary>
        /// <param name="param">数据库字段名</param>
        /// <param name="sign">运算操作符</param>
        /// <param name="value">对应字段的值</param>
        /// <param name="isLiteral">当前字段是否为纯文本，true为纯文本，false为其它格式。</param>
        public void AddParam(string param, string sign, string value, bool isLiteral)
        {
            if (CharUtil.IsValidate(param))
            {
                _ParamList.Add(param);
                _SignList.Add(sign);

                // 值信息处理
                if (value == null)
                {
                    _ValueList.Add("NULL");
                }
                else if (isLiteral)
                {
                    _ValueList.Add(" '" + value + "'");
                }
                else
                {
                    _ValueList.Add(value);
                }
            }
        }

        /// <summary>
        /// 数据更新：添加数据库操作的KEY-VALUE对。
        /// </summary>
        /// <param name="param">数据库字段名</param>
        /// <param name="sign">运算操作符</param>
        /// <param name="value">对应字段的值</param>
        public void AddParam(string param, string sign, long value)
        {
            _ParamList.Add(param);
            _SignList.Add(sign);
            _ValueList.Add(value.ToString());
        }

        public void AddVcs(string vcsCol, string optCol)
        {
            _ParamList.Add(vcsCol);
            _SignList.Add("=");
            _ValueList.Add("1");

            _ParamList.Add(optCol);
            _SignList.Add("=");
            _ValueList.Add(DBConst.OPT_INSERT.ToString());
        }

        public void AddVcs(string vcsCol, string optCol, int lastOpt, int nextOpt)
        {
            if (lastOpt == DBConst.OPT_DEFAULT)
            {
                _ParamList.Add(vcsCol);
                _SignList.Add("=");
                _ValueList.Add(vcsCol + "+1");
            }

            if (lastOpt > DBConst.OPT_INSERT || nextOpt == DBConst.OPT_DELETE)
            {
                _ParamList.Add(optCol);
                _SignList.Add("=");
                _ValueList.Add(nextOpt.ToString());
            }
        }

        /// <summary>
        /// 用户自定义关联条件
        /// </summary>
        /// <param name="where"></param>
        public void AddWhere(string where)
        {
            _WhereList.Append(" AND (").Append(where).Append(") ");
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”，默认值为纯文本<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        public void AddWhere(string key, string value)
        {
            AddWhere(key, value, true);
        }

        /// <summary>
        /// 添加WHERE查寻条件，默认运算符为等号“=”<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="value">参照值</param>
        /// <param name="isLiteral">是否为纯文本字符串，true为纯文本，false为非文本</param>
        public void AddWhere(string key, string value, bool isLiteral)
        {
            AddWhere(key, "=", value, isLiteral);
        }

        /// <summary>
        /// 添加WHERE查寻条件<br>
        /// UPDATE tablename SET ... WHERE key1=value1 AND key2=value2 ...
        /// </summary>
        /// <param name="key">参照数据库表格字段名</param>
        /// <param name="sign">参照运算符，如+、-、=、!=等</param>
        /// <param name="value">参照值</param>
        /// <param name="isLiteral">是否为纯文本字符串，true为纯文本，false为非文本</param>
        public void AddWhere(string key, string sign, string value, bool isLiteral)
        {
            if (CharUtil.IsValidate(key) && value != null && CharUtil.IsValidate(sign))
            {
                _WhereList.Append(" AND ").Append(key);
                _WhereList.Append(" ").Append(sign);

                // 值信息处理
                if (isLiteral)
                {
                    _WhereList.Append(" '").Append(value).Append("'");
                }
                else
                {
                    _WhereList.Append(" ").Append(value);
                }
            }
        }

        /// <summary>
        /// 默认升序排序
        /// </summary>
        /// <param name="key"></param>
        public void AddSort(string key)
        {
            AddSort(key, true);
        }

        /// <summary>
        /// 添加排序依据<br>
        /// SELECT * FROM tablename WHERE ... ORDER BY key1 value1, key2 value2, ...
        /// </summary>
        /// <param name="key">参照数据库表格字段</param>
        /// <param name="asc">排序方法:true:ASC表示升序;false:DESC表示降序</param>
        public void AddSort(string key, bool asc)
        {
            if (CharUtil.IsValidate(key))
            {
                _OrderList.Append(", ").Append(key);
                _OrderList.Append(" ").Append(asc ? "ASC" : "DESC");
            }
        }

        public void AddLimit(int limit)
        {
            AddLimit(0, limit);
        }

        public void AddLimit(int min, int max)
        {
            if (min < 0 || max < min)
            {
                return;
            }

            _MinLimit = min;
            _MaxLimit = max;
        }

        public void ReInit()
        {
            _ParamList.Clear();
            _SignList.Clear();
            _ValueList.Clear();
            _ColumList.Clear();
            _TableList.Clear();
            _WhereList.Clear();
            _OrderList.Clear();
        }

        public void AddBatch(string sql)
        {
            _BatchList.Add(sql);
        }

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <param name="sql">查寻语句</param>
        /// <returns>查寻结果集</returns>
        public int Execute(string sql)
        {
            int n = 0;
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    mycommand.CommandText = sql;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
            return n;
        }

        public object ExecuteScalar()
        {
            return ExecuteScalar(GenSelectSQL());
        }

        public object ExecuteScalar(string sql)
        {
            using (SqlCommand mycommand = _Connection.CreateCommand())
            {
                mycommand.CommandText = sql;
                return mycommand.ExecuteScalar();
            }
        }

        public int ExecuteBatch()
        {
            int n = ExecuteBatch(_BatchList);
            _BatchList.Clear();
            return n;
        }

        public int ExecuteBatch(List<string> sqls)
        {
            int n = 0;
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    foreach (string sql in sqls)
                    {
                        mycommand.CommandText = sql;
                        n += mycommand.ExecuteNonQuery();
                    }
                }
                mytransaction.Commit();
            }
            return n;
        }

        public DataTable ExecuteSelect()
        {
            return ExecuteSelect(GenSelectSQL());
        }

        /// <summary>
        /// 数据库查寻
        /// </summary>
        /// <param name="sqlSelect">查寻语句</param>
        /// <returns>查寻结果集</returns>
        public DataTable ExecuteSelect(string sqlSelect)
        {
            DataTable dataList = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlSelect, BeginConnect))
            {
                adapter.Fill(dataList);
            }

            return dataList;
        }

        public int ExecuteUpdate()
        {
            return ExecuteUpdate(GenUpdateSQL());
        }

        /// <summary>
        /// 数据库更新
        /// </summary>
        /// <param name="sqlUpdate">更新语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteUpdate(string sqlUpdate)
        {
            int n = 0;
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    mycommand.CommandText = sqlUpdate;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }
            return n;
        }

        public void AddUpdateBatch()
        {
            _BatchList.Add(GenUpdateSQL());
        }

        public int ExecuteInsert()
        {
            return ExecuteInsert(GenInsertSQL());
        }

        /// <summary>
        /// 数据库插入
        /// </summary>
        /// <param name="sqlInsert">插入语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteInsert(string sqlInsert)
        {
            int n = 0;
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    mycommand.CommandText = sqlInsert;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        public void AddInsertBatch()
        {
            _BatchList.Add(GenInsertSQL());
        }

        public int ExecuteDelete()
        {
            return ExecuteDelete(GenDeleteSQL());
        }

        /// <summary>
        /// 数据库删除
        /// </summary>
        /// <param name="sqlDelete">删除语句</param>
        /// <returns>当前操作所影响的行数</returns>
        public int ExecuteDelete(string sqlDelete)
        {
            int n = 0;
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    mycommand.CommandText = sqlDelete;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        public void AddDeleteBatch()
        {
            _BatchList.Add(GenDeleteSQL());
        }

        public int ExecuteBackup(string t, string f)
        {
            return ExecuteBackup(GenBackupSQL(t, f));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sqlBackup"></param>
        /// <returns></returns>
        public int ExecuteBackup(string sqlBackup)
        {
            int n = 0;
            using (SqlTransaction mytransaction = BeginConnect.BeginTransaction())
            {
                using (SqlCommand mycommand = _Connection.CreateCommand())
                {
                    mycommand.CommandText = sqlBackup;
                    n = mycommand.ExecuteNonQuery();
                }
                mytransaction.Commit();
            }

            return n;
        }

        public void AddBackupBatch(string t, string f)
        {
            _BatchList.Add(GenBackupSQL(t, f));
        }

        /// <summary>
        /// 获取数据库查寻SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenSelectSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 查寻字段拼接
            sqlBuf.Append("SELECT ");
            if (_ColumList.Length > 0)
            {
                sqlBuf.Append(_ColumList.ToString().Substring(2));
            }
            else
            {
                sqlBuf.Append("*");
            }

            // 查寻表格拼接
            sqlBuf.Append(" FROM ").Append(_TableList.ToString().Substring(2));

            // 查寻关联条件拼接
            if (_WhereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(_WhereList.ToString().Substring(5));
            }

            // 排序依据拼接
            if (_OrderList.Length > 0)
            {
                sqlBuf.Append(" ORDER BY ").Append(_OrderList.ToString().Substring(2));
            }

            if (_MaxLimit > 0)
            {
                sqlBuf.Append(" LIMIT ").Append(_MinLimit).Append(',').Append(_MaxLimit);
            }

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库更新SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenUpdateSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1 || _ParamList.Count < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 更新表格拼接
            sqlBuf.Append("UPDATE ").Append(_TableList.ToString().Substring(2)).Append(" SET ");

            // 更新字段及值拼接
            int idx = 0;
            for (int j = _ParamList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(_ParamList[idx]);
                sqlBuf.Append(_SignList[idx]);
                sqlBuf.Append(_ValueList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(_ParamList[idx]);
            sqlBuf.Append(_SignList[idx]);
            sqlBuf.Append(_ValueList[idx]);

            // 参照条件拼接
            if (_WhereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(_WhereList.ToString().Substring(5));
            }
            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库插入SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenInsertSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 数据库表格拼接
            sqlBuf.Append(" INSERT INTO ").Append(_TableList.ToString().Substring(2));

            // 要插入字段拼接
            sqlBuf.Append(" (");
            int idx = 0;
            for (int j = _ParamList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(_ParamList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(_ParamList[idx]);
            sqlBuf.Append(")");

            // 插入数据拼接
            sqlBuf.Append(" VALUES (");
            idx = 0;
            for (int j = _ValueList.Count - 1; idx < j; idx += 1)
            {
                sqlBuf.Append(_ValueList[idx]);
                sqlBuf.Append(", ");
            }
            sqlBuf.Append(_ValueList[idx]);
            sqlBuf.Append(")");

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 获取数据库删除SQL语句
        /// </summary>
        /// <returns>SQL语句，若操作表格为空，则返回空语句</returns>
        private string GenDeleteSQL()
        {
            // 数据合法性判断
            if (_TableList.Length < 1)
            {
                return "";
            }

            StringBuilder sqlBuf = new StringBuilder();

            // 数据库表格拼接
            sqlBuf.Append("DELETE FROM ").Append(_TableList.ToString().Substring(2));

            // 关联条件拼接
            sqlBuf.Append(" WHERE ").Append(_WhereList.ToString().Substring(5));

            return sqlBuf.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        /// <param name="f"></param>
        /// <returns></returns>
        private string GenBackupSQL(string t, string f)
        {
            StringBuilder sqlBuf = new StringBuilder();

            // 插入目标
            sqlBuf.Append("INSERT INTO ").Append(t).Append(" (");
            int j = _ParamList.Count - 1;
            for (int i = 0; i < j; i += 1)
            {
                sqlBuf.Append(_ParamList[i]).Append(", ");
            }
            sqlBuf.Append(_ParamList[j]).Append(") ");

            // 复制来源
            sqlBuf.Append(" SELECT ");
            j = _ValueList.Count - 1;
            for (int i = 0; i < j; i += 1)
            {
                sqlBuf.Append(_ValueList[i]).Append(", ");
            }
            sqlBuf.Append(_ValueList[j]);

            sqlBuf.Append(" FROM ").Append(f);
            // 查寻关联条件拼接
            if (_WhereList.Length > 0)
            {
                sqlBuf.Append(" WHERE ").Append(_WhereList.ToString(5, _WhereList.Length - 5));
            }

            return sqlBuf.ToString();
        }
    }
}
