using System;
using System.Windows.Forms;
using Me.Amon.Pwd._Att;

namespace Me.Amon.Pwd.Bean
{
    public partial class ACall : UserControl
    {
        protected Att _Att;
        private TextBox _Box;
        private ToolStripMenuItem _LastItem;

        #region 构造函数
        public ACall()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共函数
        protected void InitSpec(TextBox box)
        {
            _Box = box;

            EventHandler handler = new EventHandler(MiTel_Click);
            char split = ';';

            MiDefault.Tag = "";
            MiDefault.Click += handler;
            MiTelWork.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_WORK;
            MiTelWork.Click += handler;
            MiTelHome.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_HOME;
            MiTelHome.Click += handler;
            MiTelCompany.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_COMPANY;
            MiTelCompany.Click += handler;
            MiTelCell.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_CELL;
            MiTelCell.Click += handler;
            MiTelAssistant.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_ASSISTANT;
            MiTelAssistant.Click += handler;
            MiTelCar.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_CAR;
            MiTelCar.Click += handler;
            MiTelCallback.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_CALLBACK;
            MiTelCallback.Click += handler;
            MiTelPref.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_PREF;
            MiTelPref.Click += handler;
            MiTelCand.Tag = CallAtt.CALL_TYPE_TEL;
            MiTelCand.Click += handler;
            MiTelRadio.Tag = CallAtt.CALL_TYPE_TEL + split + CallAtt.CALL_FUNC_RADIO;
            MiTelRadio.Click += handler;
            彩信电话ToolStripMenuItem.Click += handler;
            MiTelOther.Tag = CallAtt.CALL_TYPE_TEL;
            MiTelOther.Click += handler;

            MiFaxWork.Tag = CallAtt.CALL_TYPE_FAX + split + CallAtt.CALL_FUNC_WORK;
            MiFaxWork.Click += handler;
            MiFaxHome.Tag = CallAtt.CALL_TYPE_FAX + split + CallAtt.CALL_FUNC_HOME;
            MiFaxHome.Click += handler;
            MiFaxCompany.Tag = CallAtt.CALL_TYPE_FAX + split + CallAtt.CALL_FUNC_COMPANY;
            MiFaxCompany.Click += handler;
            MiFaxOther.Tag = CallAtt.CALL_TYPE_FAX;
            MiFaxOther.Click += handler;

            MiPager.Tag = CallAtt.CALL_FUNC_PAGER;
            MiPager.Click += handler;
            MiIsdn.Tag = CallAtt.CALL_FUNC_ISDN;
            MiIsdn.Click += handler;
            MiTtyTdd.Tag = CallAtt.CALL_FUNC_TTYTDD;
            MiTtyTdd.Click += handler;
        }

        protected void ShowSpec(Control ctl)
        {
        }
        #endregion

        #region 事件处理
        private void MiTel_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item == null)
            {
                return;
            }

            string tag = item.Tag as string;
            if (string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            string[] arr = tag.Split(';');
            if (arr.Length != 2)
            {
                return;
            }
            _Att.SetSpec(CallAtt.SPEC_CALL_TYPE, arr[0]);
            _Att.SetSpec(CallAtt.SPEC_CALL_FUNC, arr[1]);

            if (_LastItem != null)
            {
                _LastItem.Checked = false;
            }
            _LastItem = item;
            _LastItem.Checked = true;
        }
        #endregion
    }
}
