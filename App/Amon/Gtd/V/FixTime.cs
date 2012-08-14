using System;
using System.Windows.Forms;

namespace Me.Amon.Gtd.V
{
    public partial class FixTime : UserControl, IEdit
    {
        public FixTime()
        {
            InitializeComponent();
        }

        #region 接口实现
        public MGtd MGtd { get; set; }

        public void ShowData()
        {
            if (MGtd == null)
            {
                return;
            }
            if (MGtd.Type != EGtd.GTD_TYPE_FIXTIME || MGtd.Details.Count != 1)
            {
                return;
            }

            DtData.Value = DateTime.FromFileTimeUtc(MGtd.Details[0].Time);
        }

        public bool SaveData()
        {
            if (MGtd == null)
            {
                return false;
            }
            if (MGtd.Type != EGtd.GTD_TYPE_FIXTIME)
            {
                MGtd.Type = EGtd.GTD_TYPE_FIXTIME;
                if (MGtd.Details.Count > 1)
                {
                    MGtd.Details.RemoveRange(1, MGtd.Details.Count - 1);
                }
                else
                {
                    MGtd.Details.Add(new MGtdDetail());
                }
            }

            MGtd.Details[0].Time = DtData.Value.ToFileTimeUtc();
            return true;
        }
        #endregion
    }
}
