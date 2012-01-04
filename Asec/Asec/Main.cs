using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Msec.Uc;
using Msec.Uw;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Paddings;

namespace Msec
{
    public partial class Main : Form
    {
        #region 全局变量
        private Cm _UcCm;
        private Uk _UcUk;
        private Di _UcDi;
        private Do _UcDo;

        private Edit _Edit;
        private Mask _Mask;
        private Open _Open;
        private Pass _Pass;
        private Save _Save;
        private Text _Text;
        #endregion

        public Main()
        {
            InitializeComponent();
        }

        public void Init()
        {
            // 
            // UcCm
            // 
            _UcCm = new Msec.Uc.Cm(this);
            _UcCm.Init();
            _UcCm.Location = new System.Drawing.Point(12, 39);
            _UcCm.Name = "UcCm";
            _UcCm.Size = new System.Drawing.Size(240, 110);
            _UcCm.TabIndex = 3;
            Controls.Add(_UcCm);

            // 
            // UcUk
            // 
            _UcUk = new Msec.Uc.Uk(this);
            _UcUk.Init();
            _UcUk.Location = new System.Drawing.Point(258, 39);
            _UcUk.Name = "UcUk";
            _UcUk.Size = new System.Drawing.Size(240, 110);
            _UcUk.TabIndex = 4;
            Controls.Add(_UcUk);

            // 
            // UcDi
            // 
            _UcDi = new Msec.Uc.Di(this);
            _UcDi.Init();
            _UcDi.Location = new System.Drawing.Point(12, 155);
            _UcDi.Name = "UcDi";
            _UcDi.Size = new System.Drawing.Size(240, 110);
            _UcDi.TabIndex = 5;
            Controls.Add(_UcDi);

            // 
            // UcDo
            // 
            _UcDo = new Msec.Uc.Do(this);
            _UcDo.Init();
            _UcDo.Location = new System.Drawing.Point(258, 155);
            _UcDo.Name = "UcDo";
            _UcDo.Size = new System.Drawing.Size(240, 110);
            _UcDo.TabIndex = 6;
            Controls.Add(_UcDo);

            // 
            // CbOpt
            // 
            CbOpt.Items.Add(new Item { K = "0", V = "请选择" });
            CbOpt.Items.Add(new Item { K = IData.OPT_DIGEST, V = "散列算法" });
            CbOpt.Items.Add(new Item { K = IData.OPT_RANDKEY, V = "随机口令" });
            CbOpt.Items.Add(new Item { K = IData.OPT_WRAPPER, V = "混淆算法" });
            CbOpt.Items.Add(new Item { K = IData.OPT_SCRYPTO, V = "块对称算法" });
            CbOpt.Items.Add(new Item { K = IData.OPT_SSTREAM, V = "流对称算法" });
            //CbOpt.Items.Add(new Item { K = IData.OPT_ACRYPTO, V = "非对称算法" });
            //CbOpt.Items.Add(new Item { K = IData.OPT_TXT2IMG, V = "图文转换" });
            CbOpt.SelectedIndex = 0;

            // 
            // CbKey
            // 
            CbKey.Items.Add(new Item { K = "0", V = "请选择" });
            CbKey.Items.Add(new Item { K = IData.DIR_ENC, V = "加密" });
            CbKey.Items.Add(new Item { K = IData.DIR_DEC, V = "解密" });
            CbOpt.SelectedIndex = 0;
            CbKey.Visible = false;

            // 
            // CbDir
            // 
            //CbDir.Items.Add(new Item { K = "0", V = "请选择" });
            //CbDir.Visible = false;

            //BtDo.Text = "执行(&R)";
        }

        #region 事件处理
        private void CbOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbOpt.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _UcCm.InitOpt(item.K);
            _UcUk.InitOpt(item.K);
            _UcDi.InitOpt(item.K);
            _UcDo.InitOpt(item.K);

            switch (item.K)
            {
                case IData.OPT_DIGEST:
                    CbKey.Visible = false;
                    break;
                case IData.OPT_WRAPPER:
                    CbKey.SelectedIndex = 0;
                    CbKey.Visible = true;
                    CbKey.Focus();
                    break;
                case IData.OPT_SCRYPTO:
                    CbKey.SelectedIndex = 0;
                    CbKey.Visible = true;
                    CbKey.Focus();
                    break;
                case IData.OPT_SSTREAM:
                    CbKey.SelectedIndex = 0;
                    CbKey.Visible = true;
                    CbKey.Focus();
                    break;
                case IData.OPT_ACRYPTO:
                    CbKey.Visible = false;
                    break;
                case IData.OPT_TXT2IMG:
                    CbKey.Visible = false;
                    break;
                default:
                    CbKey.Visible = false;
                    _UcCm.FocusIn();
                    break;
            }
        }

        private void CbKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbKey.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            _UcCm.InitKey(item.K);
            _UcUk.InitKey(item.K);
            _UcDi.InitKey(item.K);
            _UcDo.InitKey(item.K);
        }

        private void BtDo_Click(object sender, EventArgs e)
        {
            //if (!Worker.IsBusy)
            //{
            //    Worker.RunWorkerAsync();
            //    BtDo.Text = "取消(&R)";
            //    return;
            //}

            //if (DialogResult.Yes == MessageBox.Show(this, "确认要取消操作吗？", "友情提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            //{
            //    Worker.CancelAsync();
            //    return;
            //}
            DoWork(null, null);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            Item opt = CbOpt.SelectedItem as Item;
            if (opt == null || opt.K == "0")
            {
                ShowAlert("请选择您要执行的操作！");
                CbOpt.Focus();
                return;
            }

            Item key = CbKey.SelectedItem as Item;

            ShowInfo("处理中，请稍候……");

            if (!_UcCm.Check())
            {
                return;
            }
            if (!_UcUk.Check())
            {
                return;
            }
            if (!_UcDi.Check())
            {
                return;
            }
            if (!_UcDo.Check())
            {
                return;
            }

            switch (opt.K)
            {
                case IData.OPT_DIGEST:
                    Digest();
                    break;
                case IData.OPT_RANDKEY:
                    Randkey();
                    break;
                case IData.OPT_WRAPPER:
                    if (key == null || key.K == "0")
                    {
                        ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Wrapper();
                    break;
                case IData.OPT_SCRYPTO:
                    if (key == null || key.K == "0")
                    {
                        ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Scrypto(key.K != IData.KEY_DEC);
                    break;
                case IData.OPT_SSTREAM:
                    if (key == null || key.K == "0")
                    {
                        ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Sstream(key.K != IData.KEY_DEC);
                    break;
                case IData.OPT_ACRYPTO:
                    if (key == null || key.K == "0")
                    {
                        ShowAlert("请选择您要执行的操作！");
                        CbKey.Focus();
                        return;
                    }
                    Acrypto(key.K != IData.KEY_DEC);
                    break;
                case IData.OPT_TXT2IMG:
                    Txt2Img();
                    break;
                default:
                    break;
            }
        }

        private void DoWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                ShowInfo("用户已取消！");
            }
        }
        #endregion

        #region 公有方法
        public void ShowInfo(string info)
        {
            LbInfo.Text = info;
            TpTips.SetToolTip(LbInfo, info);
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowAlert(string message)
        {
            MessageBox.Show(this, message, "提醒", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowEdit(string data, CallBackHandler<string> handler)
        {
            if (_Edit != null && _Edit.Visible)
            {
                return;
            }
            _Edit = new Edit();
            _Edit.CallBack = handler;
            _Edit.Location = new Point(Location.X + (Width - _Edit.Width) / 2, Location.Y + (Height - _Edit.Height) / 2);
            _Edit.Show(this, data);
        }

        public void ShowMask(Item mask)
        {
            if (_Mask != null && _Mask.Visible)
            {
                return;
            }
            _Mask = new Mask();
            //_Mask.Item = mask;
            _Mask.Show(this);
        }

        public void ShowOpen(string file, CallBackHandler<string> handler)
        {
            if (_Open == null)
            {
                _Open = new Open();
            }
            _Open.CallBack = handler;
            _Open.Show(this, file);
        }

        public void ShowPass(string pass)
        {
            if (_Pass != null && _Pass.Visible)
            {
                return;
            }
            _Pass = new Pass();
            _Pass.Show(this);
        }

        public void ShowSave(string file, CallBackHandler<string> handler)
        {
            if (_Save == null)
            {
                _Save = new Save();
            }
            _Save.CallBack = handler;
            _Save.Show(this, file);
        }

        public void ShowText(string data, CallBackHandler<string> handler)
        {
            if (_Text != null && _Text.Visible)
            {
                return;
            }
            _Text = new Text();
            _Text.CallBack = handler;
            _Text.Location = new Point(Location.X + (Width - _Text.Width) / 2, Location.Y + (Height - _Text.Height) / 2);
            _Text.Show(this, data);
        }
        #endregion

        #region 私有方法
        private void Digest()
        {
            IDigest digest = _UcCm.Digest;

            _UcDi.Begin();
            _UcDo.Begin();

            try
            {
                byte[] buf = new byte[IData.BUF_SIZE];
                int len = _UcDi.Read(buf, 0, buf.Length);
                while (len > 0)
                {
                    digest.BlockUpdate(buf, 0, len);
                    len = _UcDi.Read(buf, 0, buf.Length);
                }
                len = digest.DoFinal(buf, 0);
                _UcDo.Write(buf, 0, len);

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Randkey()
        {
        }

        private void Wrapper()
        {
            _UcDi.Begin();
            _UcDo.Begin();

            try
            {
                byte[] buf = new byte[IData.BUF_SIZE];
                int len = _UcDi.Read(buf, 0, buf.Length);
                while (len > 0)
                {
                    _UcDo.Write(buf, 0, len);
                    len = _UcDi.Read(buf, 0, buf.Length);
                }

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Scrypto(bool encrypt)
        {
            BufferedCipherBase cipher = _UcCm.SBlock;
            cipher.Init(encrypt, _UcUk.GenParam(_UcCm.KeySize, _UcCm.IVSize));

            _UcDi.Begin();
            _UcDo.Begin();

            try
            {
                byte[] bi = new byte[IData.BUF_SIZE];
                byte[] bo = new byte[IData.BUF_SIZE];
                int li = _UcDi.Read(bi, 0, bi.Length);
                int lo;
                while (li > 0)
                {
                    lo = cipher.ProcessBytes(bi, 0, li, bo, 0);
                    _UcDo.Write(bo, 0, lo);
                    li = _UcDi.Read(bi, 0, bi.Length);
                }
                if (cipher is PaddedBufferedBlockCipher)
                {
                    lo = cipher.DoFinal(bo, 0);
                    _UcDo.Write(bo, 0, lo);
                }

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Sstream(bool encrypt)
        {
            BufferedStreamCipher cipher = _UcCm.Stream;
            cipher.Init(encrypt, _UcUk.GenParam(_UcCm.KeySize, _UcCm.IVSize));

            _UcDi.Begin();
            _UcDo.Begin();

            try
            {
                byte[] bi = new byte[IData.BUF_SIZE];
                byte[] bo = new byte[IData.BUF_SIZE];
                int li = _UcDi.Read(bi, 0, bi.Length);
                int lo;
                while (li > 0)
                {
                    lo = cipher.ProcessBytes(bi, 0, li, bo, 0);
                    _UcDo.Write(bo, 0, lo);
                    li = _UcDi.Read(bi, 0, bi.Length);
                }
                lo = cipher.DoFinal(bo, 0);
                _UcDo.Write(bo, 0, lo);

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Acrypto(bool encrypt)
        {
            BufferedBlockCipher cipher = _UcCm.SBlock;
            cipher.Init(encrypt, _UcUk.GenParam(_UcCm.KeySize, _UcCm.IVSize));

            _UcDi.Begin();
            _UcDo.Begin();

            try
            {
                byte[] bi = new byte[IData.BUF_SIZE];
                byte[] bo = new byte[IData.BUF_SIZE];
                int li = _UcDi.Read(bi, 0, bi.Length);
                int lo;
                while (li > 0)
                {
                    lo = cipher.ProcessBytes(bi, 0, li, bo, 0);
                    _UcDo.Write(bo, 0, lo);
                    li = _UcDi.Read(bi, 0, bi.Length);
                }
                if (cipher is PaddedBufferedBlockCipher)
                {
                    lo = cipher.DoFinal(bo, 0);
                    _UcDo.Write(bo, 0, lo);
                }

                ShowInfo("处理已完成！");
            }
            catch (Exception exp)
            {
                ShowInfo("错误：" + exp.Message);
            }
            finally
            {
                _UcDo.End();
                _UcDi.End();
            }
        }

        private void Txt2Img()
        {
        }
        #endregion

        private void MiExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MiInfo_Click(object sender, EventArgs e)
        {
            new Info().ShowDialog(this);
        }

        private void MiSave_Click(object sender, EventArgs e)
        {

        }
    }
}