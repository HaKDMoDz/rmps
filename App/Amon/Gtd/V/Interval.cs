using System;
using System.Windows.Forms;
using Me.Amon.Uc;

namespace Me.Amon.Gtd.V
{
    public partial class Interval : UserControl, IEdit
    {
        public Interval()
        {
            InitializeComponent();
        }

        public void Init()
        {
            CbUnit.Items.Add(new Item { K = "", V = "请选择" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_SECOND, V = "秒" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_MINUTE, V = "分" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_HOUR, V = "时" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_DAY, V = "天" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_WEEK, V = "周" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_MONTH, V = "月" });
            CbUnit.Items.Add(new Item { K = CGtd.GTD_UNIT_YEAR, V = "年" });
        }
        #region 接口实现
        public MGtd MGtd { get; set; }

        public void ShowData(MGtd mgtd)
        {
        }

        public void ShowData()
        {
            if (MGtd == null)
            {
                return;
            }
            if (MGtd.Type != CGtd.GTD_TYPE_INTERVAL || MGtd.Details.Count != 1)
            {
                return;
            }

            MGtdDetail detail = MGtd.Details[0];
            DtDate.Value = DateTime.FromBinary(detail.Time);
            SpData.Value = detail.MajorTime;
            CbUnit.SelectedItem = new Item { K = detail.MajorUnit };
        }

        public bool SaveData()
        {
            Item item = CbUnit.SelectedItem as Item;
            if (item == null || string.IsNullOrWhiteSpace(item.K))
            {
                Main.ShowAlert("请选择时间单位！");
                CbUnit.Focus();
                return false;
            }

            if (MGtd == null)
            {
                return false;
            }
            if (MGtd.Type != CGtd.GTD_TYPE_INTERVAL)
            {
                MGtd.Type = CGtd.GTD_TYPE_INTERVAL;
                if (MGtd.Details.Count > 1)
                {
                    MGtd.Details.RemoveRange(1, MGtd.Details.Count - 1);
                }
                else
                {
                    MGtd.Details.Add(new MGtdDetail());
                }
            }

            MGtdDetail detail = MGtd.Details[0];
            detail.Time = DtDate.Value.ToFileTimeUtc();
            detail.MajorTime = decimal.ToInt32(SpData.Value);
            detail.MajorUnit = item.K;
            return true;
        }
        #endregion
    }
}
