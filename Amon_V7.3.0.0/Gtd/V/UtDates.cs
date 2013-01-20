using System;
using System.Windows.Forms;
using Me.Amon.Gtd.V.Uc;
using Me.Amon.Uc;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    public partial class UtDates : UserControl, IDate
    {
        private ITime _ITime;
        private GtdEditor _Editor;

        public UtDates()
        {
            InitializeComponent();
        }

        public UtDates(GtdEditor editor)
        {
            _Editor = editor;

            InitializeComponent();

            DtStart.CustomFormat = CApp.DATEIME_FORMAT;

            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_NONE, V = "无" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_SECOND, V = "秒" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MINUTE, V = "分" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_HOUR, V = "时" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_DAY, V = "日" });
            //CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_WEEK, V = "周" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MONTH, V = "月" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_YEAR, V = "年" });
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public MGtd MGtd { get; set; }

        public void ShowData()
        {
            if (MGtd == null)
            {
                CbRedoUnit.SelectedIndex = 0;
                return;
            }

            if (MGtd.StartTime > DtStart.MinDate && MGtd.StartTime < DtStart.MaxDate)
            {
                DtStart.Value = MGtd.StartTime;
            }
            if (MGtd.Dates.Count > 0)
            {
                CbRedoUnit.SelectedItem = new Itemi { K = MGtd.Dates[0].Unit };
            }
            else
            {
                CbRedoUnit.SelectedIndex = 0;
            }
        }

        public bool SaveData()
        {
            if (MGtd == null || _ITime == null)
            {
                return false;
            }

            Itemi item = CbRedoUnit.SelectedItem as Itemi;
            if (item == null)
            {
                MessageBox.Show("请选择重复周期！");
                CbRedoUnit.Focus();
                return false;
            }

            MGtd.StartTime = DtStart.Value;
            if (MGtd.StartTime.Kind == DateTimeKind.Unspecified)
            {
                DateTime.SpecifyKind(MGtd.StartTime, DateTimeKind.Local);
            }

            if (!_ITime.SaveData(MGtd))
            {
                return false;
            }
            return true;
        }
        #endregion

        #region 事件处理
        private void CbRedoUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Itemi item = CbRedoUnit.SelectedItem as Itemi;
            if (item == null)
            {
                return;
            }
            ShowTime(item.K);
        }
        #endregion

        #region 私有函数
        private UcNone _UcNone;
        private UcSecond _UcSecond;
        private UcMinute _UcMinute;
        private UcHour _UcHour;
        private UcDay _UcDay;
        private UcWeek _UcWeek;
        private UcMonth _UcMonth;
        private UcYear _UcYear;
        private void ShowTime(int unit)
        {
            if (_ITime != null)
            {
                Controls.Remove(_ITime.Control);
            }

            switch (unit)
            {
                case CGtd.UNIT_SECOND:
                    if (_UcSecond == null)
                    {
                        _UcSecond = new UcSecond();
                        _UcSecond.Init(DtStart.Value);
                        InitView(_UcSecond);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcSecond;
                    break;
                case CGtd.UNIT_MINUTE:
                    if (_UcMinute == null)
                    {
                        _UcMinute = new UcMinute();
                        _UcMinute.Init(DtStart.Value);
                        InitView(_UcMinute);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcMinute;
                    break;
                case CGtd.UNIT_HOUR:
                    if (_UcHour == null)
                    {
                        _UcHour = new UcHour();
                        _UcHour.Init(DtStart.Value);
                        InitView(_UcHour);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcHour;
                    break;
                case CGtd.UNIT_DAY:
                    if (_UcDay == null)
                    {
                        _UcDay = new UcDay();
                        _UcDay.Init(DtStart.Value);
                        InitView(_UcDay);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcDay;
                    break;
                case CGtd.UNIT_WEEK:
                    if (_UcWeek == null)
                    {
                        _UcWeek = new UcWeek();
                        _UcWeek.Init(DtStart.Value);
                        InitView(_UcWeek);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcWeek;
                    break;
                case CGtd.UNIT_MONTH:
                    if (_UcMonth == null)
                    {
                        _UcMonth = new UcMonth();
                        _UcMonth.Init(DtStart.Value);
                        InitView(_UcMonth);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcMonth;
                    break;
                case CGtd.UNIT_YEAR:
                    if (_UcYear == null)
                    {
                        _UcYear = new UcYear();
                        _UcYear.Init(DtStart.Value);
                        InitView(_UcYear);
                    }
                    _Editor.StopEnabled = true;
                    _ITime = _UcYear;
                    break;
                default:
                    if (_UcNone == null)
                    {
                        _UcNone = new UcNone();
                        _UcNone.Init(DtStart.Value);
                        InitView(_UcNone);
                    }
                    _Editor.StopEnabled = false;
                    _ITime = _UcNone;
                    return;
            }

            Controls.Add(_ITime.Control);
            _ITime.ShowData(MGtd);
        }

        private void InitView(Control control)
        {
            control.Location = new System.Drawing.Point(3, 56);
            control.Size = new System.Drawing.Size(298, 101);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        #endregion
    }
}
