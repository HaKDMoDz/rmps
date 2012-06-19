using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Model;
using Me.Amon.Sql.C;
using Me.Amon.Sql.Model;
using Me.Amon.Sql.V.Pdq;

namespace Me.Amon.Sql.V
{
    public partial class PdfEditor : UserControl, IEditor
    {
        #region 全局变量
        private Dml _Sql;
        private RowStyle _DefStyle;
        private List<IInput> _UcList;
        private UserModel _UserModel;
        #endregion

        #region 构造函数
        public PdfEditor()
        {
            InitializeComponent();
        }

        public PdfEditor(UserModel userModel)
        {
            _UserModel = userModel;

            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void Init(IEngine engine)
        {
            _DefStyle = new RowStyle(SizeType.Percent, 100F);
            _UcList = new List<IInput>();

            string file = Path.Combine(_UserModel.Home, "ASql-Pdf.xml");
            if (!File.Exists(file))
            {
                return;
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            Dml sql;
            foreach (XmlNode node in doc.SelectNodes("/Amon/Sqls/Sql"))
            {
                sql = new Dml();
                sql.Load(node);
                CbSqlList.Items.Add(sql);
            }
        }

        public bool Check()
        {
            if (_Sql == null || string.IsNullOrWhiteSpace(_Sql.Text))
            {
                return false;
            }
            foreach (IInput input in _UcList)
            {
                if (!input.Check())
                {
                    return false;
                }
            }
            return true;
        }

        public string GetSQL()
        {
            string sql = _Sql.Text;
            Param param;
            foreach (IInput input in _UcList)
            {
                param = input.Param;
                sql = sql.Replace('#' + param.Key + '#', param.Value);
            }
            return sql;
        }
        #endregion

        #region 事件处理
        private void CbSqlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Sql = CbSqlList.SelectedItem as Dml;
            if (_Sql == null)
            {
                return;
            }

            TbSql.Text = _Sql.Text;
            TpInput.Controls.Clear();
            TpInput.RowStyles.Clear();
            _UcList.Clear();

            foreach (string key in _ArgInput.Keys)
            {
                _ArgIndex[key] = 0;
            }

            int i = 0;
            int h = 6;
            Label label;
            IInput input;
            foreach (Param param in _Sql.Params)
            {
                TpInput.RowStyles.Add(GetStyle(i));

                label = GetLabel(i);
                TpInput.Controls.Add(label, 0, i);
                label.Text = param.Text;

                input = GetInput(param.Type);
                TpInput.Controls.Add(input.Control, 1, i);
                input.Param = param;
                h += 27;

                _UcList.Add(input);
                i += 1;
            }

            TpInput.RowStyles.Add(_DefStyle);
            TpInput.Height = h;
        }
        #endregion

        #region 私有函数
        #region 动态组件
        private Label GetLabel(int idx)
        {
            Label label;
            if (idx >= _LlList.Count)
            {
                label = new Label();
                label.TextAlign = ContentAlignment.MiddleRight;
                label.Dock = DockStyle.Fill;
                _LlList.Add(label);
            }
            else
            {
                label = _LlList[idx];
            }
            return label;
        }
        private List<Label> _LlList = new List<Label>();

        private IInput GetInput(string type)
        {
            List<IInput> list;
            int idx;
            if (_ArgInput.ContainsKey(type))
            {
                list = _ArgInput[type];
                idx = _ArgIndex[type];
            }
            else
            {
                list = new List<IInput>();
                _ArgInput[type] = list;
                idx = 0;
                _ArgIndex[type] = idx;
            }

            IInput input;
            if (idx < list.Count)
            {
                input = list[idx];
            }
            else
            {
                switch (type)
                {
                    case "text":
                        input = new Text();
                        break;
                    case "date":
                        input = new Date();
                        break;
                    case "data":
                        input = new Data();
                        break;
                    case "list":
                        input = new List();
                        break;
                    default:
                        input = new None();
                        break;
                }
                list.Add(input);
            }
            _ArgIndex[type] += 1;

            input.Control.Dock = DockStyle.Fill;
            return input;
        }
        private Dictionary<string, List<IInput>> _ArgInput = new Dictionary<string, List<IInput>>();
        private Dictionary<string, int> _ArgIndex = new Dictionary<string, int>();

        private RowStyle GetStyle(int idx)
        {
            RowStyle style;
            if (idx >= _RsList.Count)
            {
                style = new RowStyle(SizeType.Absolute, 26F);
                _RsList.Add(style);
            }
            else
            {
                style = _RsList[idx];
            }
            return style;
        }
        private List<RowStyle> _RsList = new List<RowStyle>();
        #endregion
        #endregion
    }
}
