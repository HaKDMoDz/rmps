using System.Windows.Forms;
using Me.Amon.Pcs.M;
using Me.Amon.Uc;

namespace Me.Amon.Pcs.V.Mgr
{
    public partial class Server : UserControl, IMgr
    {
        public Server()
        {
            InitializeComponent();
        }

        public void Init()
        {
            CbServer.Items.Add(new Items { K = "", V = "请选择" });
            //CbServer.Items.Add(new Items { K = CPcs.PCS_TYPE_NATIVE, V = "我的文档" });
            CbServer.Items.Add(new Items { K = CPcs.PCS_TYPE_KUAIPAN, V = "金山快盘" });
            CbServer.SelectedIndex = 0;
        }

        #region 接口实现
        public void ShowData(MPcs mPcs)
        {
            if (mPcs != null)
            {
                CbServer.SelectedItem = new Items { K = mPcs.ServerType };
            }
        }

        public bool SaveData(MPcs mPcs)
        {
            var item = CbServer.SelectedItem as Items;
            if (item == null || string.IsNullOrWhiteSpace(item.K))
            {
                MessageBox.Show("请选择服务提供商！");
                CbServer.Focus();
                return false;
            }

            mPcs.ServerType = item.K;
            return true;
        }
        #endregion
    }
}
