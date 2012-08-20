using System;
using System.Windows.Forms;
using Me.Amon.Gtd.V.Uc;
using Me.Amon.Uc;

namespace Me.Amon.Gtd.V
{
    public partial class UtDates : UserControl, IDate
    {
        private MGtdDates _Dates;
        private ITime _ITime;

        public UtDates()
        {
            InitializeComponent();

            DtStart.CustomFormat = EApp.DATEIME_FORMAT;

            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_NONE, V = "无" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_SECOND, V = "秒" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_MINUTE, V = "分" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_HOUR, V = "时" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_DAY, V = "日" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_WEEK, V = "周" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_MONTH, V = "月" });
            CbRedoUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_YEAR, V = "年" });
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
                return;
            }

            _Dates = MGtd.Dates;
            if (_Dates == null)
            {
                _Dates = new MGtdDates();
            }
            if (_Dates.Start > DtStart.MinDate && _Dates.Start < DtStart.MaxDate)
            {
                DtStart.Value = _Dates.Start;
            }
            CbRedoUnit.SelectedItem = new Itemi { K = _Dates.RedoUnit };
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

            _Dates.Start = DtStart.Value;
            if (_Dates.Start.Kind == DateTimeKind.Unspecified)
            {
                DateTime.SpecifyKind(_Dates.Start, DateTimeKind.Local);
            }
            _Dates.RedoUnit = item.K;

            if (!_ITime.SaveData(_Dates))
            {
                return false;
            }
            MGtd.Dates = _Dates;
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
                case CGtd.UNIT_MAJOR_NONE:
                    if (_UcNone == null)
                    {
                        _UcNone = new UcNone();
                        InitView(_UcNone);
                    }
                    _ITime = _UcNone;
                    break;
                case CGtd.UNIT_MAJOR_SECOND:
                    if (_UcSecond == null)
                    {
                        _UcSecond = new UcSecond();
                        InitView(_UcSecond);
                    }
                    _ITime = _UcSecond;
                    break;
                case CGtd.UNIT_MAJOR_MINUTE:
                    if (_UcMinute == null)
                    {
                        _UcMinute = new UcMinute();
                        InitView(_UcMinute);
                    }
                    _ITime = _UcMinute;
                    break;
                case CGtd.UNIT_MAJOR_HOUR:
                    if (_UcHour == null)
                    {
                        _UcHour = new UcHour();
                        InitView(_UcHour);
                    }
                    _ITime = _UcHour;
                    break;
                case CGtd.UNIT_MAJOR_DAY:
                    if (_UcDay == null)
                    {
                        _UcDay = new UcDay();
                        InitView(_UcDay);
                    }
                    _ITime = _UcDay;
                    break;
                case CGtd.UNIT_MAJOR_WEEK:
                    if (_UcWeek == null)
                    {
                        _UcWeek = new UcWeek();
                        InitView(_UcWeek);
                    }
                    _ITime = _UcWeek;
                    break;
                case CGtd.UNIT_MAJOR_MONTH:
                    if (_UcMonth == null)
                    {
                        _UcMonth = new UcMonth();
                        InitView(_UcMonth);
                    }
                    _ITime = _UcMonth;
                    break;
                case CGtd.UNIT_MAJOR_YEAR:
                    if (_UcYear == null)
                    {
                        _UcYear = new UcYear();
                        InitView(_UcYear);
                    }
                    _ITime = _UcYear;
                    break;
                default:
                    return;
            }

            Controls.Add(_ITime.Control);
            _ITime.ShowData(_Dates);
        }

        private void InitView(Control control)
        {
            control.Location = new System.Drawing.Point(3, 55);
            control.Size = new System.Drawing.Size(200, 100);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        #endregion
    }
}
