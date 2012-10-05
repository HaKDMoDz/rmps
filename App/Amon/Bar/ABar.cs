using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Me.Amon.Bar.Opt;
using Me.Amon.M;
using Me.Amon.Uc;
using MessagingToolkit.Barcode;

namespace Me.Amon.Bar
{
    public partial class ABar : Form, IApp
    {
        private BarcodeEncoder _Encoder;
        private BarcodeDecoder _Decoder;
        private IOpt _IOpt;
        private Text _OptText;
        private Note _OptNote;
        private Vcard _OptCard;
        private Email _OptMail;
        private Sms _OptSms;
        private Tel _OptTel;
        private Url _OptUri;
        private Wifi _OptWifi;

        #region 构造函数
        public ABar()
        {
            InitializeComponent();
        }

        public ABar(AUserModel userModel)
        {
            InitializeComponent();

            this.Icon = Me.Amon.Properties.Resources.Icon;
        }
        #endregion

        #region 接口实现
        public int AppId
        {
            get;
            set;
        }

        public Form Form
        {
            get { return this; }
        }

        public void ShowTips(Control control, string caption)
        {
            TpTips.SetToolTip(control, caption);
        }

        public void ShowEcho(string message)
        {
            LbEcho.Text = message;
        }

        public void ShowEcho(string message, int delay)
        {
            LbEcho.Text = message;
        }

        public bool CanExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void ABar_Load(object sender, EventArgs e)
        {
            CbOpt.Items.Add(new Items { K = "", V = "请选择" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_TEXT, V = "文本" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_NOTE, V = "记事" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_VCARD, V = "名片" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_EMAIL, V = "邮件" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_SMS, V = "短信" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_TEL, V = "电话号码" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_URL, V = "网址收藏" });
            CbOpt.Items.Add(new Items { K = EBar.OPT_WIFI, V = "WiFi网络" });
            CbOpt.SelectedIndex = 0;

            PbIcon.BackColor = Color.White;
        }

        private void CbOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Items item = CbOpt.SelectedItem as Items;
            if (item == null)
            {
                return;
            }

            ShowOpt(item.K);
        }

        private void BtEnc_Click(object sender, EventArgs e)
        {
            if (!_IOpt.Check())
            {
                return;
            }

            string text = _IOpt.Encode();
            if (string.IsNullOrEmpty(text))
            {
                return;
            }

            if (_Encoder == null)
            {
                _Encoder = new BarcodeEncoder();
            }

            UcUserSet.EncodeUserSet(_Encoder);

            try
            {
                PbIcon.BackColor = _Encoder.BackColor;
                PbIcon.Image = _Encoder.Encode(BarcodeFormat.QRCode, text);
            }
            catch (Exception exp)
            {
                LbEcho.Text = exp.Message;
            }
        }

        private void PbMenu_Click(object sender, EventArgs e)
        {
            MiSave.Enabled = PbIcon.Image != null;
            CmMenu.Show(PbMenu, 0, PbMenu.Height);
        }

        private void MiSave_Click(object sender, EventArgs e)
        {
            if (PbIcon.Image == null)
            {
                return;
            }

            if (DialogResult.OK != Main.ShowSaveFileDialog(this, CApp.FILE_SAVE_PNG, ""))
            {
                return;
            }

            PbIcon.Image.Save(Main.SaveFileDialog.FileName);
        }

        private void MiDecUrl_Click(object sender, EventArgs e)
        {
            string url = Main.ShowInput("请输入一个有效的QR图片地址：", "");

            if (!Regex.IsMatch(url, "^[a-zA-z]{2,}:/{2,3}[^\\s]+"))
            {
                return;
            }

            Image img = null;
            try
            {
                Stream stream = WebRequest.Create(url).GetRequestStream();
                img = Image.FromStream(stream);
                stream.Close();
            }
            catch (Exception exp)
            {
                Main.LogInfo(exp.Message);
                return;
            }

            Decode(img);
        }

        private void MiDecLoc_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != Main.ShowOpenFileDialog(this, CApp.FILE_OPEN_IMG, "", false))
            {
                return;
            }

            if (!File.Exists(Main.OpenFileDialog.FileName))
            {
                return;
            }

            Decode(Image.FromFile(Main.OpenFileDialog.FileName));
        }
        #endregion

        private void Decode(Image img)
        {
            if (img == null)
            {
                return;
            }

            Bitmap bmp;
            if (img is Bitmap)
            {
                bmp = img as Bitmap;
            }
            else
            {
                bmp = new Bitmap(img.Width, img.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.DrawImage(img, 0, 0, img.Width, img.Height);
                g.Flush();
                g.Save();
                g.Dispose();
            }

            if (_Decoder == null)
            {
                _Decoder = new BarcodeDecoder();
            }

            try
            {
                Dictionary<DecodeOptions, object> opt = new Dictionary<DecodeOptions, object>();
                List<BarcodeFormat> format = new List<BarcodeFormat>(10);
                format.Add(BarcodeFormat.QRCode);
                //opt.Add(DecodeOptions.PureBarcode, "");
                opt.Add(DecodeOptions.TryHarder, true);
                //opt.Add(DecodeOptions.PossibleFormats, format);

                Result result = _Decoder.Decode(bmp, opt);
                if (result == null)
                {
                    return;
                }

                CbOpt.SelectedIndex = 0;
                PbIcon.Image = bmp;
                UcUserSet.DecodeUserSet(result);
                string text = result.Text;

                string key;
                if (!Regex.IsMatch(text, "^[a-zA-z]{2,}:[^\\s]+"))
                {
                    key = EBar.OPT_TEXT;
                }
                else
                {
                    int idx = text.IndexOf(':');
                    key = text.Substring(0, idx);
                    text = text.Substring(idx + 1);
                }

                ShowOpt(key);
                if (_IOpt != null)
                {
                    _IOpt.Decode(text);
                }
            }
            catch (BarcodeDecoderException exp)
            {
                LbEcho.Text = exp.Message;
            }
        }

        private void ShowOpt(string key)
        {
            key = key.ToUpper();

            if (_IOpt != null)
            {
                if (_IOpt.Name == key)
                {
                    return;
                }

                _IOpt.HideView(GbOpt);
            }

            _IOpt = GetOpt(key);
            if (_IOpt == null)
            {
                return;
            }

            _IOpt.Name = key;
            _IOpt.InitView(GbOpt);
            GbOpt.Text = _IOpt.Text;
            UcUserSet.Enabled = !string.IsNullOrEmpty(key);
        }

        private IOpt GetOpt(string key)
        {
            switch (key)
            {
                case EBar.OPT_TEXT:
                    if (_OptText == null)
                    {
                        _OptText = new Text();
                    }
                    return _OptText;
                case EBar.OPT_NOTE:
                    if (_OptNote == null)
                    {
                        _OptNote = new Note();
                    }
                    return _OptNote;
                case EBar.OPT_VCARD:
                    if (_OptCard == null)
                    {
                        _OptCard = new Vcard();
                    }
                    return _OptCard;
                case EBar.OPT_EMAIL:
                    if (_OptMail == null)
                    {
                        _OptMail = new Email();
                    }
                    return _OptMail;
                case EBar.OPT_SMS:
                    if (_OptSms == null)
                    {
                        _OptSms = new Sms();
                    }
                    return _OptSms;
                case EBar.OPT_TEL:
                    if (_OptTel == null)
                    {
                        _OptTel = new Tel();
                    }
                    return _OptTel;
                case EBar.OPT_URL:
                    if (_OptUri == null)
                    {
                        _OptUri = new Url();
                    }
                    return _OptUri;
                case EBar.OPT_WIFI:
                    if (_OptWifi == null)
                    {
                        _OptWifi = new Wifi();
                    }
                    return _OptWifi;
                default:
                    return null;
            }
        }
    }
}
