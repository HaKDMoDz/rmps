using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Me.Amon.Pwd._Att;

namespace Me.Amon.Pwd.Bean
{
    public partial class ADate : UserControl
    {
        protected Att _Att;
        protected DateTimePicker _Box;
        private ToolStripMenuItem _LastMenu;
        private Dictionary<string, ToolStripMenuItem> _MenuList;

        #region 构造函数
        public ADate()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        protected void InitSpec()
        {
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
        }

        protected void ShowSpec()
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
        }
        #endregion

        #region 事件处理
        private void MiDateDef_Click(object sender, EventArgs e)
        {
            _Att.SetSpec(DateAtt.SPEC_FORMAT, DataAtt.SPEC_VALUE_NONE);
            _Box.Format = DateTimePickerFormat.Long;
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
            _Box.Format = DateTimePickerFormat.Custom;
            _Box.CustomFormat = cmd;
        }

        private void MiDateDiy_Click(object sender, EventArgs e)
        {
        }
        #endregion

        #region 私有函数
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
    }
}
