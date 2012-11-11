using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Pcs.M;

namespace Me.Amon.Pcs.V
{
    public partial class PcsList : UserControl
    {
        private WPcs _WPcs;
        private DataModel _DataModel;

        #region 构造函数
        public PcsList()
        {
            InitializeComponent();
        }

        public PcsList(WPcs wPcs, DataModel dataModel)
        {
            _WPcs = wPcs;
            _DataModel = dataModel;

            InitializeComponent();
        }
        #endregion

        public void Init()
        {
            MPcs mPcs = new MPcs();
            mPcs.ServerType = CPcs.PCS_TYPE_NATIVE;
            mPcs.ServerName = "本地演示";
            mPcs.UserId = "0";
            mPcs.UserName = Environment.UserName;
            LbItem.Items.Add(mPcs);

            mPcs = new MPcs();
            mPcs.ServerType = CPcs.PCS_TYPE_KUAIPAN;
            mPcs.ServerName = "金山快盘";
            mPcs.Token = "00ecf6192d45e0ec90af333a";
            mPcs.TokenSecret = "01f300a7cfa64ae090f8ea6054705148";
            mPcs.LocalRoot = @"D:\kp";
            mPcs.UserId = "15529497";
            mPcs.UserName = "Demosss";
            LbItem.Items.Add(mPcs);
        }

        #region 事件处理
        private void LbItem_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index <= -1 || e.Index >= LbItem.Items.Count)
            {
                return;
            }

            MPcs key = LbItem.Items[e.Index] as MPcs;
            if (key == null)
            {
                return;
            }

            //e.Graphics.DrawImage(key.Icon, e.Bounds.X + 3, e.Bounds.Y + 3, 24, 24);

            //最后把要显示的文字画在背景图片上
            int y = e.Bounds.Y + 2;
            e.Graphics.DrawString(key.ServerName, LbItem.Font, new SolidBrush(e.ForeColor), e.Bounds.X + 30, y);

            y = e.Bounds.Y + e.Bounds.Height;
            e.Graphics.DrawString(key.UserName, LbItem.Font, Brushes.Gray, e.Bounds.X + 30, y - 14);
        }

        private void LbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            PbLogo.Image = null;
            TbMemo.Text = "本地文件管理系统";
        }

        private void LbItem_DoubleClick(object sender, EventArgs e)
        {
            OpenItem();
        }

        private void BnOpen_Click(object sender, EventArgs e)
        {
            OpenItem();
        }
        #endregion

        private void OpenItem()
        {
            MPcs mPcs = LbItem.SelectedItem as MPcs;
            if (mPcs == null)
            {
                return;
            }
            _WPcs.OpenPcs(mPcs);
        }
    }
}
