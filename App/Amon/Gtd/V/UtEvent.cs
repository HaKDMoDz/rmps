using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class UtEvent : UserControl, IDate
    {
        private MGtdEvent _Event;

        public UtEvent()
        {
            InitializeComponent();
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

            _Event = MGtd.Event;
            if (_Event == null)
            {
                _Event = new MGtdEvent();
            }
            foreach (int val in _Event.Events)
            {
                if (val == CGtd.EVENT_LOAD)
                {
                    CkLoad.Checked = true;
                    continue;
                }
                if (val == CGtd.EVENT_EXIT)
                {
                    CkExit.Checked = true;
                    continue;
                }
            }
        }

        public bool SaveData()
        {
            if (MGtd == null)
            {
                return false;
            }

            _Event.Events.Clear();
            if (CkLoad.Checked)
            {
                _Event.Events.Add(CGtd.EVENT_LOAD);
            }
            if (CkExit.Checked)
            {
                _Event.Events.Add(CGtd.EVENT_EXIT);
            }
            if (_Event.Events.Count < 1)
            {
                Main.ShowAlert("请至少选择一个事件！");
                return false;
            }
            MGtd.Event = _Event;
            return true;
        }
        #endregion
    }
}
