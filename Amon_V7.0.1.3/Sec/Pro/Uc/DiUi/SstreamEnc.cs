using System.IO;
using System.Text;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Pro.Uc.DiUi
{
    class SstreamEnc : Sstream
    {
        public SstreamEnc(APro apro, Di di)
            : base(apro, di)
        {
        }

        public override void InitKey(string key)
        {
            _Di.CbType.Items.Add(new Item { K = INPUT_FILE, V = "文件" });
            _Di.CbType.Items.Add(new Item { K = INPUT_TEXT, V = "文本" });

            _Di.CbType.SelectedIndex = 0;

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void ChangedType(Item type)
        {
            switch (_Type.K)
            {
                case INPUT_FILE:
                    _Di.TbData.Enabled = true;

                    _Di.BtData.Enabled = true;
                    _Di.BtData.Focus();
                    break;
                case INPUT_TEXT:
                    _Di.TbData.Enabled = true;

                    _Di.BtData.Enabled = true;
                    _Di.BtData.Focus();
                    break;
            }
        }
        public override bool Check()
        {
            if (_Type.K == INPUT_FILE)
            {
                if (string.IsNullOrWhiteSpace(_Di.TbData.Text))
                {
                    Main.ShowAlert("请选择输入文件！");
                    _Di.TbData.Focus();
                    return false;
                }
                if (!System.IO.File.Exists(_Di.TbData.Text))
                {
                    Main.ShowAlert("您选择的输入文件不存在！");
                    _Di.TbData.Focus();
                    return false;
                }
                return true;
            }

            if (_Type.K == INPUT_TEXT)
            {
                if (string.IsNullOrEmpty(_Di.TbData.Text))
                {
                    Main.ShowAlert("请录入输入文本！");
                    _Di.TbData.Focus();
                    return false;
                }
                return true;
            }
            return true;
        }

        public override void Begin()
        {
            switch (_Type.K)
            {
                case INPUT_FILE:
                    _Stream = File.OpenRead(_Di.TbData.Text);
                    break;
                case INPUT_TEXT:
                    _Stream = new MemoryStream(Encoding.Default.GetBytes(_Di.UserData.ToString()));
                    break;
                default:
                    _Stream = null;
                    _Reader = null;
                    break;
            }
        }
    }
}
