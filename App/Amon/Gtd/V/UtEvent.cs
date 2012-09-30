using System.Windows.Forms;
using Me.Amon.Gtd.M;

namespace Me.Amon.Gtd.V
{
    public partial class UtEvent : UserControl, IDate
    {
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

            foreach (int val in MGtd.Events)
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

            MGtd.Events.Clear();
            if (CkLoad.Checked)
            {
                MGtd.Events.Add(CGtd.EVENT_LOAD);
            }
            if (CkExit.Checked)
            {
                MGtd.Events.Add(CGtd.EVENT_EXIT);
            }
            if (MGtd.Events.Count < 1)
            {
                Main.ShowAlert("请至少选择一个事件！");
                return false;
            }
            return true;
        }
        #endregion
    }
}
