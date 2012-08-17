using System;
using System.Windows.Forms;
using Me.Amon.Gtd.V.Uc;
using Me.Amon.Uc;

namespace Me.Amon.Gtd.V
{
    public partial class UtDates : UserControl, IDate
    {
        private ITime _ITime;

        public UtDates()
        {
            InitializeComponent();

            CbMajorUnit.Items.Add(new Itemi { K = 0, V = "请选择" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_SECOND, V = "秒" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_MINUTE, V = "分" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_HOUR, V = "时" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_DAY, V = "日" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_WEEK, V = "周" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_MONTH, V = "月" });
            CbMajorUnit.Items.Add(new Itemi { K = CGtd.UNIT_MAJOR_YEAR, V = "年" });
        }

        #region 接口实现
        public Control Control
        {
            get { return this; }
        }

        public void ShowData(MGtd mgtd)
        {
        }

        public bool SaveData(MGtd mgtd)
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void CbMajorUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Itemi item = CbMajorUnit.SelectedItem as Itemi;
            if (item == null || item.K <= 0)
            {
                return;
            }
            ShowTime(item.K);
        }

        private UcSecond _UcSecond;
        private UcMinute _UcMinute;
        private UcHour _UcHour;
        private UcDay _UcDay;
        private UcWeek _UcWeek;
        private UcMonth _UcMonth;
        private UcYear _UcYear;
        private void ShowTime(int unit)
        {
            ITime iTime;

            switch (unit)
            {
                case CGtd.UNIT_MAJOR_SECOND:
                    if (_UcSecond == null)
                    {
                        _UcSecond = new UcSecond();
                        InitView(_UcSecond);
                    }
                    iTime = _UcSecond;
                    break;
                case CGtd.UNIT_MAJOR_MINUTE:
                    if (_UcMinute == null)
                    {
                        _UcMinute = new UcMinute();
                        InitView(_UcMinute);
                    }
                    iTime = _UcMinute;
                    break;
                case CGtd.UNIT_MAJOR_HOUR:
                    if (_UcHour == null)
                    {
                        _UcHour = new UcHour();
                        InitView(_UcHour);
                    }
                    iTime = _UcHour;
                    break;
                case CGtd.UNIT_MAJOR_DAY:
                    if (_UcDay == null)
                    {
                        _UcDay = new UcDay();
                        InitView(_UcDay);
                    }
                    iTime = _UcDay;
                    break;
                case CGtd.UNIT_MAJOR_WEEK:
                    if (_UcWeek == null)
                    {
                        _UcWeek = new UcWeek();
                        InitView(_UcWeek);
                    }
                    iTime = _UcWeek;
                    break;
                case CGtd.UNIT_MAJOR_MONTH:
                    if (_UcMonth == null)
                    {
                        _UcMonth = new UcMonth();
                        InitView(_UcMonth);
                    }
                    iTime = _UcMonth;
                    break;
                case CGtd.UNIT_MAJOR_YEAR:
                    if (_UcYear == null)
                    {
                        _UcYear = new UcYear();
                        InitView(_UcYear);
                    }
                    iTime = _UcYear;
                    break;
                default:
                    return;
            }

            if (_ITime != null)
            {
                Controls.Remove(_ITime.Control);
            }
            _ITime = iTime;
            Controls.Add(_ITime.Control);
        }

        private void InitView(Control control)
        {
            control.Location = new System.Drawing.Point(3, 29);
            control.Size = new System.Drawing.Size(200, 100);
            control.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
        }
        #endregion
    }
}
