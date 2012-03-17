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
            CbError.Items.Add(new Item { K = "l", V = "L" });
            CbError.Items.Add(new Item { K = "m", V = "M" });
            CbError.Items.Add(new Item { K = "q", V = "Q" });
            CbError.Items.Add(new Item { K = "h", V = "H" });
            CbError.SelectedIndex = 0;

            Item item;
            foreach (EncodingInfo encoding in Encoding.GetEncodings())
            {
                item = new Item { K = encoding.Name, V = encoding.DisplayName };
                CbCoding.Items.Add(item);
                if (item.K.ToLower() == "utf-8")
                {
                    CbCoding.SelectedItem = item;
                }
            }
        }

        public void LoadUserSet(BarcodeEncoder encoder)
        {
            Item item = CbError.SelectedItem as Item;
            if (item != null)
            {
                switch (item.K)
                {
                    case "l":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.L;
                        break;
                    case "m":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.M;
                        break;
                    case "q":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.Q;
                        break;
                    case "h":
                        encoder.ErrorCorrectionLevel = ErrorCorrectionLevel.H;
                        break;
                }
            }

            item = CbCoding.SelectedItem as Item;
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
