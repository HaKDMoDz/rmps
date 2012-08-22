using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class GtdEditor : Form
    {
        private IDate _IDate;
        private UtDates _UtDates;
        private UtEvent _UtEvent;
        private UtMaths _UtMaths;

        #region 构造函数
        public GtdEditor()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        public MGtd MGtd
        {
            get;
            set;
        }

        #region 事件处理
        private void GtdEditor_Load(object sender, EventArgs e)
        {
            if (MGtd == null)
            {
                MGtd = new MGtd();
            }

            TbTitle.Text = MGtd.Title;
            switch (MGtd.Type)
            {
                case CGtd.TYPE_MAJOR_EVENT:
                    RbEvent.Checked = true;
                    break;
                case CGtd.TYPE_MAJOR_MATHS:
                    RbMaths.Checked = true;
                    break;
                default:
                    RbDates.Checked = true;
                    break;
            }

            UcStop.ShowData(MGtd);
        }

        private void RbDates_CheckedChanged(object sender, EventArgs e)
        {
            MGtd.Type = CGtd.TYPE_MAJOR_DATES;
            ShowDate(CGtd.TYPE_MAJOR_DATES);
        }

        private void RbEvent_CheckedChanged(object sender, EventArgs e)
        {
            MGtd.Type = CGtd.TYPE_MAJOR_EVENT;
            ShowDate(CGtd.TYPE_MAJOR_EVENT);
        }

        private void RbMaths_CheckedChanged(object sender, EventArgs e)
        {
            MGtd.Type = CGtd.TYPE_MAJOR_MATHS;
            ShowDate(CGtd.TYPE_MAJOR_MATHS);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            string text = TbTitle.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
            {
                Main.ShowAlert("请输入提醒标题！");
                TbTitle.Focus();
                return;
            }
            MGtd.Title = text;

            if (MGtd.Type == 0)
            {
                Main.ShowAlert("请选择提醒方案！");
                return;
            }

            if (_IDate == null || !_IDate.SaveData())
            {
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

        #region 私有函数
        private void ShowDate(int type)
        {
            if (_IDate != null)
            {
                GpDate.Controls.Remove(_IDate.Control);
            }

            switch (type)
            {
                case CGtd.TYPE_MAJOR_DATES:
                    if (_UtDates == null)
                    {
                        _UtDates = new UtDates();
                        _UtDates.Dock = DockStyle.Fill;
                    }
                    GpDate.Text = "时间";
                    _IDate = _UtDates;
                    break;
                case CGtd.TYPE_MAJOR_EVENT:
                    if (_UtEvent == null)
                    {
                        _UtEvent = new UtEvent();
                        _UtEvent.Dock = DockStyle.Fill;
                    }
                    GpDate.Text = "事件";
                    _IDate = _UtEvent;
                    break;
                case CGtd.TYPE_MAJOR_MATHS:
                    if (_UtMaths == null)
                    {
                        _UtMaths = new UtMaths();
                        _UtMaths.Dock = DockStyle.Fill;
                    }
                    GpDate.Text = "公式";
                    _IDate = _UtMaths;
                    break;
                default:
                    return;
            }

            GpDate.Controls.Add(_IDate.Control);
            _IDate.MGtd = MGtd;
            _IDate.ShowData();
        }
        #endregion
    }
}
