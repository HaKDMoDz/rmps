using System;
using System.Text;
using System.Windows.Forms;
using Me.Amon.Uc;
using MessagingToolkit.Barcode;
using MessagingToolkit.Barcode.QRCode.Decoder;

namespace Me.Amon.Bar
{
    public partial class UserSet : UserControl
    {
        public UserSet()
        {
            InitializeComponent();

            InitOnce();
        }

        public void InitOnce()
        {
            CbError.Items.Add(new Items { K = "L", V = "L" });
            CbError.Items.Add(new Items { K = "M", V = "M" });
            CbError.Items.Add(new Items { K = "Q", V = "Q" });
            CbError.Items.Add(new Items { K = "H", V = "H" });
            CbError.SelectedIndex = 0;

            Items item;
            foreach (EncodingInfo encoding in Encoding.GetEncodings())
            {
                item = new Items { K = encoding.Name, V = encoding.DisplayName };
                CbCoding.Items.Add(item);
                if (item.K.ToLower() == "utf-8")
                {
                    CbCoding.SelectedItem = item;
                }
            }
        }

        public void EncodeUserSet(BarcodeEncoder encoder)
        {
            Items item = CbError.SelectedItem as Items;
            if (item != null)
            {
                switch (item.K)
                {
                    case "L":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.L;
                        break;
                    case "M":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.M;
                        break;
                    case "Q":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.Q;
                        break;
                    case "H":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.H;
                        break;
                }
            }

            item = CbCoding.SelectedItem as Items;
            if (item != null)
            {
                encoder.CharacterSet = item.K;
            }
            encoder.ForeColor = BtForeColor.BackColor;
            encoder.BackColor = BtBackColor.BackColor;
            encoder.QuietZone = 1;
            encoder.Width = (int)SpDimW.Value;
            encoder.Height = (int)SpDimH.Value;
        }

        public void DecodeUserSet(Result result)
        {
            ErrorCorrectionLevel level = result.ResultMetadata[ResultMetadataType.ErrorCorrectionLevel] as ErrorCorrectionLevel;
            if (level != null)
            {
                CbError.SelectedItem = new Items { K = level.Name };
            }
        }

        private void BtForeColor_Click(object sender, EventArgs e)
        {
            CdDialog.Color = BtForeColor.BackColor;
            if (DialogResult.OK != CdDialog.ShowDialog())
            {
                return;
            }
            BtForeColor.BackColor = CdDialog.Color;
        }

        private void BtBackColor_Click(object sender, EventArgs e)
        {
            CdDialog.Color = BtBackColor.BackColor;
            if (DialogResult.OK != CdDialog.ShowDialog())
            {
                return;
            }
            BtBackColor.BackColor = CdDialog.Color;
        }
    }
}
