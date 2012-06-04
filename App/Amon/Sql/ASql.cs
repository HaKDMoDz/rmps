using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Event;
using Me.Amon.Sql.Editor;
using Me.Amon.Sql.M;
using Me.Amon.Sql.Model;
using Me.Amon.Sql.V;
using Me.Amon.Uc;
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
        private List<Rdbms> _Drives;
        private DbResult _DataGrid;
        private XmlMenu<ASql> _XmlMenu;
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

        #region 公共函数
        public void ChangeDdl()
        {
            DbConfig config = new DbConfig();
            config.DriverList = _Drives;
            config.AmonHandler = new AmonHandler<Rdbms>(ChangeDdl);
            config.ShowDialog(this);
        }

        public void ChangeDdl(Rdbms ddl)
        {
            CloseConnection();

            _Dbms = ddl;
            GetConnection();
            GetCommand();
        }
        #endregion

        #region 事件处理
        private void ASql_Load(object sender, EventArgs e)
        {
            _Param = UcUdf;

            _XmlMenu = new XmlMenu<ASql>(this, null);
            if (File.Exists("ASql.xml"))
            {
                _XmlMenu.Load("ASql.xml");
                _XmlMenu.GetStrokes("ASql");
            }

            if (!File.Exists(ESql.DBMS_FILE))
            {
                return;
            }

            StreamReader reader = File.OpenText(ESql.DBMS_FILE);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            reader.Close();

            LoadLib(doc);

            _Drives = new List<Rdbms>();
            foreach (XmlNode node in doc.SelectNodes("/Amon/RDBMS"))
            {
                Rdbms dbms = new Rdbms();
                dbms.FromXml(node);
                _Drives.Add(dbms);
            }
        }

        private void ASql_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (KeyStroke<ASql> stroke in _XmlMenu.KeyStrokes)
            {
                if (stroke.Action == null ||
                    e.Control ^ stroke.Control ||
                    e.Shift ^ stroke.Shift ||
                    e.Alt ^ stroke.Alt ||
                    e.KeyCode != stroke.Code)
                {
                    continue;
                }

                e.Handled = true;
                stroke.Action.EventHandler(stroke, null);
                break;
            }
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
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

        private void TcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage page = TcResult.SelectedTab;
            _DataGrid = page.Controls[0] as DbResult;
        }

        private void TcResult_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = TcResult.TabCount < 2;
        }

        private void BnExecute_Click(object sender, EventArgs e)
        {
            DoExecute();
        }
        #endregion

        #region 私有函数
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
                _DataGrid.DataSource = null;
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
                _DataGrid.DataSource = dataSet.Tables[0];
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
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 数据库操作
        public IDbConnection GetConnection()
        {
            if (_Connect != null)
            {
                return _Connect;
            }

            if ("System.Data.OleDb.OleDbConnection" == _Dbms.ConnectionClass)
            {
                _Connect = new System.Data.OleDb.OleDbConnection();
            }
            else
            {
                Assembly assembly = _Assemblys[_Dbms.LibId];
                _Connect = assembly.CreateInstance(_Dbms.ConnectionClass) as IDbConnection;
            }
            if (_Connect != null)
            {
                _Connect.ConnectionString = string.Format(_Dbms.ConnectionString, _Dbms.Uri, _Dbms.User, _Dbms.Password);
                _Connect.Open();
            }
            return _Connect;
        }

        public IDbCommand GetCommand()
        {
            if (_Command != null)
            {
                return _Command;
            }

            if ("System.Data.OleDb.OleDbCommand" == _Dbms.CommandClass)
            {
                _Command = new System.Data.OleDb.OleDbCommand();
            }
            else
            {
                Assembly assembly = _Assemblys[_Dbms.LibId];
                _Command = assembly.CreateInstance(_Dbms.CommandClass) as IDbCommand;
            }
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

            if ("System.Data.OleDb.OleDbDataAdapter" == _Dbms.AdapterClass)
            {
                _Adapter = new System.Data.OleDb.OleDbDataAdapter();
            }
            else
            {
                Assembly assembly = _Assemblys[_Dbms.LibId];
                _Adapter = assembly.CreateInstance(_Dbms.AdapterClass) as IDbDataAdapter;
            }
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
            _Adapter = null;
        }
        #endregion
    }
}
