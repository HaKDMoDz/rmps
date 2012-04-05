using System;
using System.Drawing;
using System.Windows.Forms;
using Me.Amon.Bar.Opt;
using Me.Amon.Model;
using Me.Amon.Uc;
using Me.Amon.Util;
using MessagingToolkit.Barcode;
using System.Collections.Generic;

namespace Me.Amon.Bar
{
    public partial class ABar : Form, IApp
    {
        private BarcodeEncoder _Encoder;
        private BarcodeDecoder _Decoder;
        private IOpt _IOpt;

        #region 构造函数
        public ABar()
        {
            InitializeComponent();
        }

        public ABar(UserModel userModel)
        {
            InitializeComponent();
        }
        #endregion

        #region 接口实现
        public void InitOnce()
        {
            CbOpt.Items.Add(new Item { K = "text", V = "文本" });
            CbOpt.Items.Add(new Item { K = "note", V = "记事" });
            CbOpt.Items.Add(new Item { K = "vcard", V = "名片" });
            CbOpt.Items.Add(new Item { K = "email", V = "邮件" });
            CbOpt.Items.Add(new Item { K = "sms", V = "短信" });
            CbOpt.Items.Add(new Item { K = "tel", V = "电话号码" });
            CbOpt.Items.Add(new Item { K = "url", V = "网址收藏" });
            CbOpt.Items.Add(new Item { K = "wifi", V = "WiFi网络" });
            CbOpt.SelectedIndex = 0;

            PbIcon.BackColor = Color.White;
        }

        public int AppId
        {
            get;
            set;
        }

        public Form Form
        {
            get { return this; }
        }

        public bool WillExit()
        {
            return true;
        }

        public bool SaveData()
        {
            return true;
        }
        #endregion

        #region 事件处理
        private void CbOpt_SelectedIndexChanged(object sender, EventArgs e)
        {
            Item item = CbOpt.SelectedItem as Item;
            if (item == null)
            {
                return;
            }

            if (_IOpt != null)
            {
                if (_IOpt.Name == item.K)
                {
                    return;
                }

                _IOpt.HideView(GbOpt);
            }

            switch (item.K)
            {
                case "text":
                    _IOpt = new Text();
                    break;
                case "note":
                    _IOpt = new Note();
                    break;
                case "vcard":
                    _IOpt = new Vcard();
                    break;
                case "email":
                    _IOpt = new Email();
                    break;
                case "sms":
                    _IOpt = new Sms();
                    break;
                case "tel":
                    _IOpt = new Tel();
                    break;
                case "url":
                    _IOpt = new Url();
                    break;
                case "wifi":
                    _IOpt = new Wifi();
                    break;
                default:
                    return;
            }

            _IOpt.Name = item.K;
            _IOpt.InitView(GbOpt);
            GbOpt.Text = item.V;
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

            UcUserSet.LoadUserSet(_Encoder);

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

        private void BtDec_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "PNG文件|*.png";
            if (DialogResult.OK != fd.ShowDialog(this))
            {
                return;
            }

            Bitmap bmp = (Bitmap)BeanUtil.ReadImage(fd.FileName, null);
            if (bmp == null)
            {
                return;
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

                Result decodedResult = _Decoder.Decode(bmp, opt);
                if (decodedResult == null)
                {
                    return;
                }

                CbOpt.SelectedIndex = 0;
                PbIcon.Image = bmp;
                //txtBarcodeContent.Text = decodedResult.Text;
                //txtBarcodeType.Text = decodedResult.BarcodeFormat.ToString();
            }
            catch (BarcodeDecoderException exp)
            {
                LbEcho.Text = exp.Message;
            }
        }
        #endregion
    }
}
