using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pwd;
using Me.Amon.Pwd._Att;
using Me.Amon.Model;
using Me.Amon.Model.Pwd;
using Me.Amon.Util;

namespace Me.Amon.Pwd.Wiz
{
    public partial class BeanDate : UserControl, IAttEdit
    {
        private BeanBody _Body;
        private TableLayoutPanel _Grid;
        private RowStyle _Style;
        private Label _Label;
        private Att _Att;
        private ToolStripMenuItem _LastMenu;
        private Dictionary<string, ToolStripMenuItem> _MenuList;

        #region 构造函数
        public BeanDate()
        {
            InitializeComponent();
        }

        public BeanDate(BeanBody body)
        {
            _Body = body;

            InitializeComponent();
        }

        public void InitOnce(TableLayoutPanel grid, ViewModel viewModel)
        {
            _Grid = grid;

            _Label = new Label();
            _Label.TextAlign = ContentAlignment.MiddleRight;
            _Label.Dock = DockStyle.Fill;

            _Style = new RowStyle(SizeType.Absolute, 27F);
            Dock = DockStyle.Fill;

            _MenuList = new Dictionary<string, ToolStripMenuItem>(15);
            InitMenu("yyyyMMdd", "yyyyMMdd", MuDate);
            InitMenu("yyyy-MM-dd", "yyyy-MM-dd", MuDate);
            InitMenu("yyyy/MM/dd", "yyyy/MM/dd", MuDate);
            InitMenu("yyyy.MM.dd", "yyyy.MM.dd", MuDate);
            InitMenu("yyyy年MM月dd日", "yyyy年MM月dd日", MuDate);

            InitMenu("HHmmss", "HHmmss", MuTime);
            InitMenu("HH:mm:ss", "HH:mm:ss", MuTime);
            InitMenu("HH时mm分ss秒", "HH时mm分ss秒", MuTime);
            InitMenu("H:m:s", "H:m:s", MuTime);
            InitMenu("H时m分s秒", "H时m分s秒", MuTime);
            InitMenu("h:m:s", "h:m:s", MuTime);
            InitMenu("h时m分s秒", "h时m分s秒", MuTime);

            InitMenu("yyyyMMdd HHmmss", "yyyyMMdd HHmmss", MuDateTime);
            InitMenu("yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm:ss", MuDateTime);
            InitMenu("yyyy/MM/dd HH:mm:ss", "yyyy/MM/dd HH:mm:ss", MuDateTime);
            InitMenu("yyyy年MM月dd日 HH时mm分ss秒", "yyyy年MM月dd日 HH时mm分ss秒", MuDateTime);

            _LastMenu = MiDateDef;
            _LastMenu.Checked = true;

            DtData.GotFocus += new EventHandler(DtData_GotFocus);

            BtNow.Image = viewModel.GetImage("att-date-now");
            BtOpt.Image = viewModel.GetImage("att-date-options");
        }

        private void InitMenu(string tag, string text, ToolStripMenuItem root)
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Size = new System.Drawing.Size(170, 22);
            item.Text = text;
            item.Tag = tag;
            item.Click += new EventHandler(this.MiDatePre_Click);
            root.DropDownItems.Add(item);
            _MenuList[tag] = item;
        }
        #endregion

        #region 接口实现
        public int InitView(int row)
        {
            TabIndex = row;

            _Grid.RowStyles.Add(_Style);

            _Grid.Controls.Add(_Label, 0, row);
            _Grid.Controls.Add(this, 1, row);

            return 27;
        }

        public bool ShowData(DataModel dataModel, Att att)
        {
            _Att = att;
            if (_Att == null)
            {
                return false;
            }

            _Label.Text = _Att.Name;
            if (CharUtil.IsValidateLong(_Att.Data))
            {
                DtData.Value = DateTime.FromFileTimeUtc(long.Parse(_Att.Data));
            }
            return true;
        }

        public void Copy()
        {
            if (!string.IsNullOrEmpty(DtData.Text))
            {
                Clipboard.SetText(DtData.Text);
            }
        }

        public bool Save()
        {
            if (_Att == null)
            {
                return false;
            }

            string date = DtData.Value.ToFileTimeUtc().ToString();
            if (date != _Att.Data)
            {
                _Att.Data = date;
                _Att.Modified = true;
            }
            return true;
        }
        #endregion

        #region 事件处理
        private void DtData_GotFocus(object sender, EventArgs e)
        {
            _Body.EditCtl = this;
        }

        #region 按钮事件
        private void BtNow_Click(object sender, EventArgs e)
        {
            DtData.Value = DateTime.Now;
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {
            _LastMenu.Checked = false;

            string spec = _Att.GetSpec(DateAtt.SPEC_FORMAT);
            if (string.IsNullOrEmpty(spec))
            {
                _LastMenu = MiDateDef;
            }
            else if (_MenuList.ContainsKey(spec))
            {
                _LastMenu = _MenuList[spec];
            }
            else
            {
                MiDateTimeDiy.Tag = spec;
                _LastMenu = MiDateTimeDiy;
            }

            _LastMenu.Checked = true;

            CmMenu.Show(BtNow, 0, BtNow.Height);
        }
        #endregion

        #region 菜单事件
        private void MiDateDef_Click(object sender, EventArgs e)
        {
            _Att.SetSpec(DateAtt.SPEC_FORMAT, DataAtt.SPEC_VALUE_NONE);
            DtData.Format = DateTimePickerFormat.Long;
        }

        private void MiDatePre_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }
            string cmd = item.Tag as string;
            if (string.IsNullOrEmpty(cmd))
            {
                return;
            }
            _Att.SetSpec(DateAtt.SPEC_FORMAT, cmd);
            DtData.Format = DateTimePickerFormat.Custom;
            DtData.CustomFormat = cmd;
        }

        private void MiDateDiy_Click(object sender, EventArgs e)
        {
        }
        #endregion
        #endregion
    }
}
