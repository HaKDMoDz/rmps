using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Me.Amon.Sql.Model;
using Me.Amon.Sql.V.Input;

namespace Me.Amon.Sql.Editor
{
    public partial class UdfEditor : UserControl, IEditor
    {
        private Dml _Sql;
        private List<Label> _LlList;
        private List<IInput> _UcList;
        private List<RowStyle> _RsList;
        private RowStyle _DefStyle;

        #region 构造函数
        public UdfEditor()
        {
            InitializeComponent();

            InitOnce();
        }
        #endregion

        public void InitOnce()
        {
            _LlList = new List<Label>();
            _UcList = new List<IInput>();
            _RsList = new List<RowStyle>();
            _DefStyle = new RowStyle(SizeType.Percent, 100F);

            string file = "sql.xml";
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

        #region 接口实现
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
            for (int i = 0; i < _Sql.Params.Count; i += 1)
            {
                sql = sql.Replace('#' + _Sql.Params[i].Key + '#', _UcList[i].Value);
            }
            return sql;
        }
        #endregion

        private void CbSqlList_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Sql = CbSqlList.SelectedItem as Dml;
            if (_Sql == null)
            {
                return;
            }

            TbSql.Text = _Sql.Text;
            TpInput.RowStyles.Clear();
            TpInput.Controls.Clear();
            _UcList.Clear();

            int idx = 0;
            int h = 6;
            Label label;
            IInput input;
            foreach (Param param in _Sql.Params)
            {
                TpInput.RowStyles.Add(GetStyle(idx));

                label = GetLabel(idx);
                TpInput.Controls.Add(label, 0, idx);
                label.Text = param.Text;

                input = GetInput(idx, param.Type);
                TpInput.Controls.Add(input.Control, 1, idx);
                input.Param = param;
                h += 27;

                _UcList.Add(input);
                idx += 1;
            }

            TpInput.RowStyles.Add(_DefStyle);
            TpInput.Height = h;
        }

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

        private IInput GetInput(int idx, string type)
        {
            IInput input;
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
            input.Control.Dock = DockStyle.Fill;
            return input;
        }

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
    }
}
