using System;
using System.Windows.Forms;
using Me.Amon.Model;
using Me.Amon.Model.Att;

namespace Me.Amon.Pwd.Pro
{
    public partial class BeanDate : UserControl, IAttEdit
    {
        private AAtt _Att;
        private TextBox _Ctl;

        #region 构造函数
        public BeanDate()
        {
            InitializeComponent();
        }

        public void InitOnce(DataModel dataModel, ViewModel viewModel)
        {
            this.TbName.GotFocus += new EventHandler(TbName_GotFocus);
            this.DtData.GotFocus += new EventHandler(DtData_GotFocus);

            BtNow.Image = viewModel.GetImage("att-date-now");
            BtOpt.Image = viewModel.GetImage("att-date-options");
        }
        #endregion

        #region 接口实现
        public Control Control { get { return this; } }

        public string Title { get { return "日期"; } }

        public bool ShowData(AAtt att)
        {
            _Att = att;

            if (_Att != null)
            {
                TbName.Text = _Att.Name;
                DtData.Text = _Att.Data;
            }
            return true;
        }

        public void Copy()
        {
            Clipboard.SetText(_Ctl.Text);
        }

        public void Save()
        {
            if (_Att == null)
            {
                return;
            }

            if (TbName.Text != _Att.Name)
            {
                _Att.Name = TbName.Text;
                _Att.Modified = true;
            }
            if (DtData.Text != _Att.Data)
            {
                _Att.Data = DtData.Text;
                _Att.Modified = true;
            }
        }
        #endregion

        #region 事件处理
        private void TbName_GotFocus(object sender, EventArgs e)
        {
            _Ctl = TbName;
            TbName.SelectAll();
        }

        private void DtData_GotFocus(object sender, EventArgs e)
        {
        }

        #region 按钮事件
        private void BtNow_Click(object sender, EventArgs e)
        {
            DtData.Value = DateTime.Now;
        }

        private void BtOpt_Click(object sender, EventArgs e)
        {

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
