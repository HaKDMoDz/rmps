using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Event;
using Me.Amon.Model;
using Me.Amon.Sql.C;
using Me.Amon.Sql.C.Engine;
using Me.Amon.Sql.M;
using Me.Amon.Sql.V;
using Me.Amon.Uc;

namespace Me.Amon.Sql
{
    public partial class ASql : Form, IApp
    {
        #region 全局变量
        private Rdbms _Dbms;
        private IEditor _DbEditor;
        private IResult _DbResult;
        private XmlMenu<ASql> _XmlMenu;
        private UserModel _UserModel;
        private IEngine _SqlEngine;
        #endregion

        #region 构造函数
        public ASql()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
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

        public void ShowTips(Control control, string caption)
        {
            //TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            LblEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            LblEcho.Text = message;
        }

        public bool WillExit()
        {
            if (_SqlEngine != null)
            {
                _SqlEngine.Close();
            }
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
            //config.DriverList = _Drives;
            config.AmonHandler = new AmonHandler<Rdbms>(ChangeDdl);
            config.ShowDialog(this);
        }

        public void ChangeDdl(Rdbms ddl)
        {
            if (_SqlEngine != null)
            {
                _SqlEngine.Close();
            }
            _SqlEngine = new SQLiteEngine();
            _SqlEngine.Begin();

            NewPdqTab(true);
            NewSqlTab(false);
            NewDbrTab(true);
        }

        public TabPage NewPdqTab(bool selected)
        {
            int cnt = TcEditor.TabPages.Count;
            TabPage page = new TabPage();
            TcEditor.TabPages.Add(page);
            //page.Location = new System.Drawing.Point(4, 23);
            page.Name = "tabPage" + cnt;
            page.Padding = new System.Windows.Forms.Padding(3);
            //page.Size = new System.Drawing.Size(664, 179);
            page.TabIndex = cnt;
            page.Text = string.Format("预置查询 ({0})", cnt);
            page.UseVisualStyleBackColor = true;

            PdfEditor editor = new PdfEditor(_UserModel);
            editor.Dock = DockStyle.Fill;
            //editor.Location = new System.Drawing.Point(3, 3);
            editor.Name = "UcSql";
            //editor.Size = new System.Drawing.Size(658, 137);
            editor.TabIndex = 0;
            page.Controls.Add(editor);

            editor.Init(_SqlEngine);

            if (selected)
            {
                TcEditor.SelectedTab = page;
                _DbEditor = editor;
            }

            return page;
        }

        public TabPage NewSqlTab(bool selected)
        {
            int cnt = TcEditor.TabPages.Count;
            TabPage page = new TabPage();
            TcEditor.TabPages.Add(page);
            //page.Location = new System.Drawing.Point(4, 23);
            page.Name = "tabPage" + cnt;
            page.Padding = new System.Windows.Forms.Padding(3);
            //page.Size = new System.Drawing.Size(664, 179);
            page.TabIndex = cnt;
            page.Text = string.Format("高级查询 ({0})", cnt);
            page.UseVisualStyleBackColor = true;

            SqlEditor editor = new SqlEditor(_UserModel);
            editor.Dock = DockStyle.Fill;
            //editor.Location = new System.Drawing.Point(3, 3);
            editor.Name = "UcSql";
            //editor.Size = new System.Drawing.Size(658, 137);
            editor.TabIndex = 0;
            page.Controls.Add(editor);

            editor.Init(_SqlEngine);

            if (selected)
            {
                TcEditor.SelectedTab = page;
                _DbEditor = editor;
            }

            return page;
        }

        public TabPage NewDbrTab(bool selected)
        {
            int cnt = TcResult.TabPages.Count;
            TabPage page = new TabPage();
            TcResult.TabPages.Add(page);
            //page.Location = new System.Drawing.Point(4, 23);
            page.Name = "tabPage" + cnt;
            page.Padding = new System.Windows.Forms.Padding(3);
            //page.Size = new System.Drawing.Size(664, 179);
            page.TabIndex = cnt;
            page.Text = string.Format("结果 ({0})", cnt);
            page.UseVisualStyleBackColor = true;

            DbResult result = new DbResult();
            page.Controls.Add(result);
            result.Dock = DockStyle.Fill;
            result.TabIndex = 0;

            if (selected)
            {
                TcResult.SelectedTab = page;
                _DbResult = result;
            }

            return page;
        }

        public void ImportCsv(string csvFile, CsvConfig csvCfg)
        {
            int cnt = _SqlEngine.ImportCsv(csvFile, csvCfg);
            if (cnt > -1)
            {
                ShowEcho(string.Format("成功导入 {0} 条记录！", cnt));
            }
        }

        public void ImportSql(string sqlFile, SqlConfig sqlCfg)
        {
            _SqlEngine.ImportSql(sqlFile, sqlCfg);
        }

        public void ImportXml(string xmlFile, XmlConfig xmlCfg)
        {
            _SqlEngine.ImportXml(xmlFile, xmlCfg);
        }

        public void ExportCsv(string csvFile, CsvConfig csvCfg)
        {
            _SqlEngine.ExportCsv(csvFile, csvCfg);
        }

        public void ExportSql(string sqlFile, SqlConfig sqlCfg)
        {
            _SqlEngine.ExportSql(sqlFile, sqlCfg);
        }

        public void ExportXml(string xmlFile, XmlConfig xmlCfg)
        {
            _SqlEngine.ExportXml(xmlFile, xmlCfg);
        }
        #endregion

        #region 事件处理
        private void ASql_Load(object sender, EventArgs e)
        {
            KeyPreview = true;

            _XmlMenu = new XmlMenu<ASql>(this, null);
            if (_XmlMenu.Load(Path.Combine(_UserModel.Home, ESql.XML_MENU)))
            {
                _XmlMenu.GetStrokes("ASql");
                _XmlMenu.GetPopMenu("ASql", CmMenu);
            }

            //string path = Path.Combine(_UserModel.Home, ESql.DDL_FILE);
            //if (!File.Exists(path))
            //{
            //    return;
            //}

            //StreamReader reader = File.OpenText(path);
            //XmlDocument doc = new XmlDocument();
            //doc.Load(reader);
            //reader.Close();

            //LoadLib(doc);

            //_Drives = new List<Rdbms>();
            //foreach (XmlNode node in doc.SelectNodes("/Amon/RDBMS"))
            //{
            //    Rdbms dbms = new Rdbms();
            //    dbms.FromXml(node);
            //    _Drives.Add(dbms);
            //}

            ChangeDdl(null);
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

        private void ASql_FormClosing(object sender, FormClosingEventArgs e)
        {
            WillExit();
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void TcEditor_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage page = TcEditor.SelectedTab;
            _DbEditor = page.Controls[0] as IEditor;
        }

        private void TcEditor_TabClosing(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = TcEditor.TabCount < 2;
        }

        private void TcResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabPage page = TcResult.SelectedTab;
            _DbResult = page.Controls[0] as DbResult;
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
        public void DoExecute()
        {
            if (!_DbEditor.Check())
            {
                ShowEcho("请输入或选择您要执行的语句！");
                return;
            }

            try
            {
                string sql = _DbEditor.GetSQL().Trim();
                if (!sql.ToLower().StartsWith("select"))
                {
                    int row = _SqlEngine.DoExecute(sql);
                    ShowEcho(string.Format("共影响 {0} 条数据", row));
                    return;
                }

                DataSet dataSet = _SqlEngine.DoSelect(sql);
                DataTable table = dataSet.Tables[0];
                _DbResult.DataSource = table;
                ShowEcho(string.Format("共查询到 {0} 条数据！", table.Rows.Count));
            }
            catch (Exception exp)
            {
                Main.ShowError(exp);
            }
        }

        private bool LoadLib(XmlDocument doc)
        {
            //_Assemblys = new Dictionary<string, Assembly>();
            //_Assemblys[""] = Assembly.GetExecutingAssembly();

            //XmlNodeList list = doc.SelectNodes("/Amon/Libs/Lib");
            //if (list == null || list.Count < 1)
            //{
            //    return true;
            //}

            //try
            //{
            //    string path = Application.StartupPath;
            //    foreach (XmlNode node in list)
            //    {
            //        string file = Dml.Attribute(node, "Path", "");
            //        if (!CharUtil.IsValidate(file))
            //        {
            //            continue;
            //        }
            //        if (!Path.IsPathRooted(file))
            //        {
            //            file = Path.Combine(path, file);
            //        }
            //        if (!File.Exists(file))
            //        {
            //            return false;
            //        }
            //        //动态加载程序集
            //        Assembly assembly = Assembly.LoadFrom(file);
            //        string id = Dml.Attribute(node, "Id", null);
            //        if (CharUtil.IsValidate(id))
            //        {
            //            _Assemblys[id] = assembly;
            //        }
            //    }
            return true;
            //}
            //catch (Exception)
            //{
            //    return false;
            //}
        }
        #endregion
    }
}
