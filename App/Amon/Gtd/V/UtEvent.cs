using System.Windows.Forms;

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

        public void ShowData(MGtd mgtd)
        {
            if (mgtd == null)
            {
                return;
            }
            foreach (int val in mgtd.Events)
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

        public bool SaveData(MGtd mgtd)
        {
            mgtd.Events.Clear();
            if (CkLoad.Checked)
            {
                mgtd.Events.Add(CGtd.EVENT_LOAD);
            }
            if (CkExit.Checked)
            {
                mgtd.Events.Add(CGtd.EVENT_EXIT);
            }
            if (mgtd.Events.Count < 1)
            {
                Main.ShowAlert("请至少选择一个事件！");
                return false;
            }
            return true;
        }
        #endregion
    }
}
