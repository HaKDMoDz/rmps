using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class UcHint : UserControl
    {
        private MGtd _MGtd;
        private IHint _IHint;
        private UhTips _UhAlert;
        private UhApps _UhApps;
        private UhMail _UhEmail;

        public UcHint()
        {
            InitializeComponent();
        }

        public void Init(MGtd mgtd)
        {
            _MGtd = mgtd;

            switch (_MGtd.HintType)
            {
                case CGtd.HINT_TYPE_APPS:
                    RbApps.Checked = true;
                    break;
                case CGtd.HINT_TYPE_MAIL:
                    RbMail.Checked = true;
                    break;
                default:
                    RbTips.Checked = true;
                    break;
            }
        }

        public void SaveData()
        {
            if (_IHint == null || !_IHint.SaveData(_MGtd))
            {
                return;
            }
        }

        private void RbTips_CheckedChanged(object sender, EventArgs e)
        {
            ShowHint(CGtd.HINT_TYPE_TIPS);
        }

        private void RbApps_CheckedChanged(object sender, EventArgs e)
        {
            ShowHint(CGtd.HINT_TYPE_APPS);
        }

        private void RbMail_CheckedChanged(object sender, EventArgs e)
        {
            ShowHint(CGtd.HINT_TYPE_MAIL);
        }

        private void ShowHint(int type)
        {
            IHint iHint;
            switch (type)
            {
                case CGtd.TYPE_DATES:
                    if (_UhAlert == null)
                    {
                        _UhAlert = new UhTips();
                        _UhAlert.Dock = DockStyle.Fill;
                    }
                    iHint = _UhAlert;
                    break;
                case CGtd.TYPE_EVENT:
                    if (_UhApps == null)
                    {
                        _UhApps = new UhApps();
                        _UhApps.Dock = DockStyle.Fill;
                    }
                    iHint = _UhApps;
                    break;
                case CGtd.TYPE_MATHS:
                    if (_UhEmail == null)
                    {
                        _UhEmail = new UhMail();
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
    }
}
