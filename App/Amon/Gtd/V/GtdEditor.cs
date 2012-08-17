using System;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Gtd.V
{
    public partial class GtdEditor : Form
    {
        private IDate _IDate;
        private UtDates _UtDates;
        private UtEvent _UtEvent;
        private UtMaths _UtMaths;
        private IHint _IHint;
        private UhAlert _UhAlert;
        private UhApps _UhApps;
        private UhEmail _UhEmail;

        #region 构造函数
        public GtdEditor()
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        public MGtd MGtd { get; set; }

        #region 事件处理
        private void GtdEditor_Load(object sender, EventArgs e)
        {
            if (MGtd == null)
            {
                MGtd = new MGtd();
            }

            CbType.Items.Add(new Itemi { K = 0, V = "请选择" });
            CbType.Items.Add(new Itemi { K = CGtd.TYPE_MAJOR_TIME, V = "时间" });
            CbType.Items.Add(new Itemi { K = CGtd.TYPE_MAJOR_EVENT, V = "事件" });
            CbType.Items.Add(new Itemi { K = CGtd.TYPE_MAJOR_FORMULA, V = "公式" });
        }

        private void CbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Itemi item = CbType.SelectedItem as Itemi;
            if (item == null || item.K <= 0)
            {
                return;
            }

            ShowDate(item.K);
        }

        private void BtOk_Click(object sender, EventArgs e)
        {
            IDate edit = null;
            if (edit == null)
            {
                return;
            }

            if (edit.SaveData(MGtd))
            {
                Close();
            }
        }

        private void BtNo_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 私有函数
        private void ShowDate(int type)
        {
            IDate iDate;
            switch (type)
            {
                case CGtd.TYPE_MAJOR_TIME:
                    if (_UtDates == null)
                    {
                        _UtDates = new UtDates();
                        _UtDates.Dock = DockStyle.Fill;
                    }
                    iDate = _UtDates;
                    break;
                case CGtd.TYPE_MAJOR_EVENT:
                    if (_UtEvent == null)
                    {
                        _UtEvent = new UtEvent();
                        _UtEvent.Dock = DockStyle.Fill;
                    }
                    iDate = _UtEvent;
                    break;
                case CGtd.TYPE_MAJOR_FORMULA:
                    if (_UtMaths == null)
                    {
                        _UtMaths = new UtMaths();
                        _UtMaths.Dock = DockStyle.Fill;
                    }
                    iDate = _UtMaths;
                    break;
                default:
                    return;
            }

            if (_IDate != null)
            {
                GpTime.Controls.Remove(_IDate.Control);
            }
            _IDate = iDate;
            GpTime.Controls.Add(_IDate.Control);
        }

        private void ShowHint(int type)
        {
            IHint iHint;
            switch (type)
            {
                case CGtd.TYPE_MAJOR_TIME:
                    if (_UhAlert == null)
                    {
                        _UhAlert = new UhAlert();
                        _UhAlert.Dock = DockStyle.Fill;
                    }
                    iHint = _UhAlert;
                    break;
                case CGtd.TYPE_MAJOR_EVENT:
                    if (_UhApps == null)
                    {
                        _UhApps = new UhApps();
                        _UhApps.Dock = DockStyle.Fill;
                    }
                    iHint = _UhApps;
                    break;
                case CGtd.TYPE_MAJOR_FORMULA:
                    if (_UhEmail == null)
                    {
                        _UhEmail = new UhEmail();
                        _UhEmail.Dock = DockStyle.Fill;
                    }
                    iHint = _UhEmail;
                    break;
                default:
                    return;
            }

            if (_IHint != null)
            {
                NpHint.Controls.Remove(_IHint.Control);
            }
            _IHint = iHint;
            NpHint.Controls.Add(_IHint.Control);
        }
        #endregion
    }
}
