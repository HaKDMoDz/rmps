using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Pcs.M;
using Me.Amon.Pcs.V.Mgr;

namespace Me.Amon.Pcs.V
{
    public partial class PcsList : UserControl
    {
        private WPcs _WPcs;
        private UserModel _UserModel;
        private DataModel _DataModel;

        #region 构造函数
        public PcsList()
        {
            InitializeComponent();
        }

        public PcsList(WPcs wPcs, UserModel userModel, DataModel dataModel)
        {
            _WPcs = wPcs;
            _UserModel = userModel;
            _DataModel = dataModel;

            InitializeComponent();
        }
        #endregion

        public void Init()
        {
            string path = Path.Combine(_UserModel.SysHome, "Pcs");
            string file = Path.Combine(path, "native24.png");
            MPcs mPcs = new MPcs();
            mPcs.ServerType = CPcs.PCS_TYPE_NATIVE;
            mPcs.ServerName = "本地演示";
            mPcs.UserId = "0";
            mPcs.UserName = Environment.UserName;
            if (File.Exists(file))
            {
                mPcs.Logo = Image.FromFile(file);
            }
            LbItem.Items.Add(mPcs);

            foreach (var pcs in _DataModel.ListPcs())
            {
                pcs.Init();
                file = Path.Combine(path, pcs.ServerType + "24.png");
                if (File.Exists(file))
                {
                    pcs.Logo = Image.FromFile(file);
                }
                LbItem.Items.Add(pcs);
            }
        }

        #region 公共函数
        public void CreatePcs()
        {
            var pcsMgr = new PcsCreate();
            pcsMgr.Init();
            if (DialogResult.OK != pcsMgr.ShowDialog(_WPcs))
            {
                return;
            }
            var pcs = pcsMgr.MPcs;
            _DataModel.SavePcs(pcs);
            LbItem.Items.Add(pcs);
            _WPcs.OpenPcs(pcs);
        }

        public void VerifyPcs()
        {
        }

        public void DeletePcs()
        {
            var pcs = LbItem.SelectedItem as MPcs;
            if (pcs == null)
            {
                Main.ShowAlert("请选择您要移除的账户！");
                LbItem.Focus();
                return;
            }
            _DataModel.DeletePcs(pcs);
            LbItem.Items.Remove(pcs);
        }
        #endregion

        #region 事件处理
        private void LbItem_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            if (e.Index <= -1 || e.Index >= LbItem.Items.Count)
            {
                return;
            }

            MPcs pcs = LbItem.Items[e.Index] as MPcs;
            if (pcs == null)
            {
                return;
            }

            if (pcs.Logo != null)
            {
                e.Graphics.DrawImage(pcs.Logo, e.Bounds.X + 3, e.Bounds.Y + 3, 24, 24);
            }

            //最后把要显示的文字画在背景图片上
            int y = e.Bounds.Y + 2;
            e.Graphics.DrawString(pcs.ServerName, LbItem.Font, new SolidBrush(e.ForeColor), e.Bounds.X + 30, y);

            y = e.Bounds.Y + e.Bounds.Height;
            e.Graphics.DrawString(pcs.UserName, LbItem.Font, Brushes.Gray, e.Bounds.X + 30, y - 14);
        }

        private void LbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            PbLogo.Image = null;
            TbMemo.Text = "本地文件管理系统";
        }

        private void LbItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                CmMenu.Show(LbItem, e.Location);
            }
        }

        private void LbItem_DoubleClick(object sender, EventArgs e)
        {
            OpenItem();
        }

        private void BnOpen_Click(object sender, EventArgs e)
        {
            OpenItem();
        }

        private void MiCreate_Click(object sender, EventArgs e)
        {
            CreatePcs();
        }

        private void MiVerify_Click(object sender, EventArgs e)
        {
            VerifyPcs();
        }

        private void MiDelete_Click(object sender, EventArgs e)
        {
            DeletePcs();
        }
        #endregion

        #region 私有函数
        private void OpenItem()
        {
            MPcs mPcs = LbItem.SelectedItem as MPcs;
            if (mPcs == null)
            {
                return;
            }
            _WPcs.OpenPcs(mPcs);
        }
        #endregion
    }
}
