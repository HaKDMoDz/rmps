using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Me.Amon.Open;
using Me.Amon.Open.PC;
using Me.Amon.Open.V1.App.Pcs;
using Me.Amon.Pcs.M;
using Me.Amon.Pcs.V.Cfg;

namespace Me.Amon.Pcs.V
{
    public partial class PcsList : UserControl
    {
        private WPcs _WPcs;
        private MPcs _MPcs;
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
            var pcs = LbItem.SelectedItem as MPcs;
            if (pcs == null)
            {
                return;
            }
            if (pcs.Account != null)
            {
                return;
            }

            if (BwWorker.IsBusy)
            {
                BwWorker.CancelAsync();
            }
            _MPcs = pcs;
            BwWorker.RunWorkerAsync();
            BtUpdate.Enabled = false;
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

        public PcsClient GetClient(MPcs pcs)
        {
            switch (pcs.ServerType)
            {
                case "native":
                    return NewNative(pcs);
                case "kuaipan":
                    return NewKuaipan(pcs);
                default:
                    return null;
            }
        }

        private PcsClient NewNative(MPcs mPcs)
        {
            return new NativeClient();
        }

        private PcsClient NewKuaipan(MPcs pcs)
        {
            var token = new Me.Amon.Open.V1.OAuthTokenV1();
            token.oauth_token = pcs.Token;
            token.oauth_token_secret = pcs.TokenSecret;
            token.UserId = pcs.UserId;
            KuaipanClient client = new KuaipanClient(OAuthConsumer.KuaipanConsumer(), token, false);
            if (token.oauth_token.Length != 24 && token.oauth_token_secret.Length != 32)
            {
                client.Verify();
            }
            return client;
        }

        private void BwWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var client = GetClient(_MPcs);
            if (client == null)
            {
                return;
            }

            var account = client.Account();
            if (account == null)
            {
                return;
            }

            _MPcs.UserId = account.Id;
            _MPcs.UserName = account.Name;
            TbMemo.Text = "总空间：" + GetSize(account.Size) + Environment.NewLine;
            TbMemo.Text += "已使用：" + GetSize(account.Used) + Environment.NewLine;

            BtUpdate.Enabled = true;
            _DataModel.SavePcs(_MPcs);
        }

        private string GetSize(long size)
        {
            // 1024
            if (size < 1024)
            {
                return string.Format("{0} B", size);
            }
            // 1024* 1024
            if (size < 1048576)
            {
                return (size / 1024d).ToString("f2") + " KB";
            }
            // 1024 * 1024 * 1024
            if (size < 1073741824)
            {
                return (size / 1048576d).ToString("f2") + " MB";
            }
            // 1024 * 1024 * 1024 * 1024
            if (size < 1099511627776)
            {
                return (size / 1073741824d).ToString("f2") + " GB";
            }
            // 1099511627776 1G
            return (size / 1099511627776d).ToString("f2") + " TB";
        }

        private void BtUpdate_Click(object sender, EventArgs e)
        {
            if (BwWorker.IsBusy)
            {
                BwWorker.CancelAsync();
            }
            BwWorker.RunWorkerAsync();
            BtUpdate.Enabled = false;
        }
    }
}
