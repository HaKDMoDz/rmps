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
            CbUnit.Items.Add(new Item { K = "1", V = "秒" });
            CbUnit.Items.Add(new Item { K = "2", V = "分" });
            CbUnit.Items.Add(new Item { K = "3", V = "时" });
            CbUnit.Items.Add(new Item { K = "4", V = "天" });
            CbUnit.Items.Add(new Item { K = "5", V = "周" });
            CbUnit.Items.Add(new Item { K = "6", V = "月" });
            CbUnit.Items.Add(new Item { K = "7", V = "年" });
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
            if (MGtd.Type != EGtd.GTD_TYPE_INTERVAL || MGtd.Details.Count != 1)
            {
                return;
            }

            MGtdDetail detail = MGtd.Details[0];
            DtDate.Value = DateTime.FromBinary(detail.Time);
            SpData.Value = detail.Interval;
            CbUnit.SelectedItem = new Item { K = detail.Unit };
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
            if (MGtd.Type != EGtd.GTD_TYPE_INTERVAL)
            {
                MGtd.Type = EGtd.GTD_TYPE_INTERVAL;
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
            detail.Interval = decimal.ToInt32(SpData.Value);
            detail.Unit = item.K;
            return true;
        }
        #endregion
    }
}
