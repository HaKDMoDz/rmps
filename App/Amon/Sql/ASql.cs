using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Sql.Editor;
using Me.Amon.Sql.M;
using Me.Amon.Sql.Model;
using Me.Amon.Util;

namespace Me.Amon.Sql
{
    public partial class ASql : Form, IApp
    {
        #region 全局变量
        private Rdbms _Dbms;
        private IEditor _Param;
        private IDbConnection _Connect;
        private IDbCommand _Command;
        private IDbDataAdapter _Adapter;
        private Dictionary<string, Assembly> _Assemblys;
        #endregion

        #region 构造函数
        public ASql()
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public Form Form
        {
            get { return this; }
        }

        public bool WillExit()
        {
            CloseConnection();
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 私有函数
        private void InitDB(string file, char sep)
        {
            string name = Path.GetFileNameWithoutExtension(file);
            IDbConnection con = GetConnection();
            IDbCommand cmd = GetCommand();
            cmd.Connection = con;
            cmd.CommandText = string.Format("drop table if exists {0}", name);
            cmd.ExecuteNonQuery();

            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line))
                {
                    return;
                }
                string[] header = line.Split(sep);
                StringBuilder builder = new StringBuilder();
                builder.Append(string.Format("CREATE TABLE {0} (", name));
                for (int i = 0; i < header.Length; i += 1)
                {
                    line = (header[i] ?? "").Trim();
                    if (!Regex.IsMatch(line, "^[\\w]+$"))
                    {
                        return;
                    }
                    builder.Append(string.Format("{0} VARCHAR(8),", line));
                }
                builder.Remove(builder.Length - 1, 1).Append(')');
                cmd.CommandText = builder.ToString();
                cmd.ExecuteNonQuery();
                builder.Clear();

                IDbTransaction trans = con.BeginTransaction();
                line = reader.ReadLine();
                string[] detail;
                int idx;
                int max;
                int cnt = 0;
                while (line != null)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        line = reader.ReadLine();
                        continue;
                    }
                    idx = 0;

                    detail = line.Split(sep);
                    builder.Append(string.Format("INSERT INTO {0} VALUES (", name));
                    max = detail.Length <= header.Length ? detail.Length : header.Length;
                    while (idx < max)
                    {
                        builder.Append(string.Format("'{0}',", detail[idx]));
                        idx += 1;
                    }
                    while (idx < header.Length)
                    {
                        builder.Append("null,");
                        idx += 1;
                    }
                    builder.Remove(builder.Length - 1, 1).Append(')');
                    cmd.CommandText = builder.ToString();
                    cmd.ExecuteNonQuery();
                    builder.Clear();
                    cnt += 1;

                    line = reader.ReadLine();
                }
                trans.Commit();

                ShowEcho(string.Format("成功导入 {0} 条记录！", cnt));
            }
            cmd.Dispose();
        }

        private void DoExecute()
        {
            if (!_Param.Check())
            {
                return;
            }

            string sql = _Param.GetSQL().Trim();
            IDbCommand command = GetCommand();
            command.CommandText = sql;
            if (!sql.ToLower().StartsWith("select"))
            {
                //GvDataList.Rows.Clear();
                int row = command.ExecuteNonQuery();
                ShowEcho(string.Format("共影响 {0} 条数据", row));
                return;
            }

            DataSet dataSet = new DataSet();
            IDbDataAdapter adapter = GetAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(dataSet);
            if (dataSet.Tables.Count > 0)
            {
                //GvDataList.DataSource = dataSet.Tables[0];

                ShowEcho(string.Format("查询结果共 {0} 条", dataSet.Tables[0].Rows.Count));
            }
        }

        private void ShowEcho(string echo)
        {
            LblEcho.Text = echo;
        }

        private bool LoadLib(XmlDocument doc)
        {
            _Assemblys = new Dictionary<string, Assembly>();
            _Assemblys[""] = Assembly.GetExecutingAssembly();

            XmlNodeList list = doc.SelectNodes("/Amon/Libs/Lib");
            if (list == null || list.Count < 1)
            {
                return true;
            }

            try
            {
                string path = Application.StartupPath;
                foreach (XmlNode node in list)
                {
                    string file = Dml.Attribute(node, "Path", "");
                    if (!CharUtil.IsValidate(file))
                    {
                        continue;
                    }
                    if (!Path.IsPathRooted(file))
                    {
                        file = Path.Combine(path, file);
                    }
                    if (!File.Exists(file))
                    {
                        return false;
                    }
                    //动态加载程序集
                    Assembly assembly = Assembly.LoadFrom(file);
                    string id = Dml.Attribute(node, "Id", null);
                    if (CharUtil.IsValidate(id))
                    {
                        _Assemblys[id] = assembly;
                    }
                }
                return true;
            }
            catch (Exception exp)
            {
                return false;
            }
        }
        #endregion

        #region 事件处理
        private void ASql_Load(object sender, EventArgs e)
        {
            _Param = UcUdf;

            StreamReader reader = File.OpenText("Rdbms.xml");
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            LoadLib(doc);

            foreach (XmlNode node in doc.SelectNodes("/Amon/RDBMS"))
            {
                Rdbms dbms = new Rdbms();
                dbms.FromXml(node);
                _Dbms = dbms;
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                DoExecute();
            }
        }

        private void TcParams_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TcParams.SelectedIndex)
            {
                case 0:
                    _Param = UcUdf;
                    break;
                case 1:
                    _Param = UcSql;
                    break;
                default:
                    return;
            }
        }

        private void BtSelect_Click(object sender, EventArgs e)
        {
            DoExecute();
        }

        private void BtImport_Click(object sender, EventArgs e)
        {
            //if (DialogResult.OK != FdOpen.ShowDialog())
            //{
            //    return;
            //}
            //InitDB(FdOpen.FileName, ',');
        }
        #endregion

        #region 数据库操作
        private IDbConnection GetConnection()
        {
            if (_Connect != null)
            {
                return _Connect;
            }

            Assembly assembly = _Assemblys[_Dbms.LibId];
            _Connect = assembly.CreateInstance(_Dbms.ConnectionClass) as IDbConnection;
            if (_Connect != null)
            {
                _Connect.ConnectionString = string.Format(_Dbms.Uri, _Dbms.User, _Dbms.Password);
                _Connect.Open();
            }
            return _Connect;
        }

        private IDbCommand GetCommand()
        {
            if (_Command != null)
            {
                return _Command;
            }

            Assembly assembly = _Assemblys[_Dbms.LibId];
            _Command = assembly.CreateInstance(_Dbms.CommandClass) as IDbCommand;
            if (_Command != null)
            {
                _Command.Connection = GetConnection();
                _Command.CommandType = CommandType.Text;
            }
            return _Command;
        }

        private IDbDataAdapter GetAdapter()
        {
            if (_Adapter != null)
            {
                return _Adapter;
            }

            Assembly assembly = _Assemblys[_Dbms.LibId];
            _Adapter = assembly.CreateInstance(_Dbms.AdapterClass) as IDbDataAdapter;
            return _Adapter;
        }

        private void CloseConnection()
        {
            if (_Command != null)
            {
                _Command.Dispose();
            }
            if (_Connect != null)
            {
                _Connect.Close();
            }
        }
        #endregion

        private void PbMenu_Click(object sender, EventArgs e)
        {

        }
    }
}
