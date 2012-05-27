using System.IO;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc.DiUi
{
    class ScryptoDec : Scrypto
    {
        public ScryptoDec(APro apro, Di di)
            : base(apro, di)
        {
        }

        public override void InitKey(string key)
        {
            _Di.CbType.Items.Add(new Item { K = INPUT_FILE_BIN, V = "字节文件" });
            _Di.CbType.Items.Add(new Item { K = INPUT_FILE_TXT, V = "字符文件" });
            _Di.CbType.Items.Add(new Item { K = INPUT_TEXT, V = "文本" });

            _Di.CbType.SelectedIndex = 0;

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void ChangedType(Item type)
        {
            switch (type.K)
            {
                case INPUT_FILE_BIN:
                    _Di.TbData.Enabled = true;

                    _Di.BtData.Enabled = true;
                    _Di.BtData.Focus();

                    _Di.LbMask.Visible = false;
                    _Di.CbMask.Visible = false;
                    _Di.BtMask.Visible = false;
                    break;
                case INPUT_FILE_TXT:
                case INPUT_TEXT:
                    _Di.TbData.Enabled = true;

                    _Di.BtData.Enabled = true;
                    _Di.BtData.Focus();

                    _Di.LbMask.Visible = true;
                    _Di.CbMask.Visible = true;
                    _Di.BtMask.Visible = true;
                    break;
                default:
                    _Di.LbMask.Visible = false;
                    _Di.CbMask.Visible = false;
                    _Di.BtMask.Visible = false;
                    break;
            }
        }

        public override bool Check()
        {
            if (_Type.K == INPUT_FILE_BIN || _Type.K == INPUT_FILE_TXT)
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

            if (_Udc == null)
            {
                Main.ShowAlert("请选择掩码！");
                _Di.CbMask.Focus();
                return false;
            }
            if (_Udc.Id == USER_CHARSET)
            {
                if (string.IsNullOrEmpty(_Udc.Data))
                {
                    Main.ShowAlert("掩码字符不能为空！");
                    _Di.TbData.Focus();
                    return false;
                }
            }
            return true;
        }

        public override void Begin()
        {
            switch (_Type.K)
            {
                case INPUT_FILE_BIN:
                    _Stream = File.OpenRead(_Di.TbData.Text);
                    break;
                case INPUT_FILE_TXT:
                    _Reader = new StreamReader(_Di.TbData.Text);
                    break;
                case INPUT_TEXT:
                    _Reader = new StringReader(_Di.UserData.ToString());
                    break;
                default:
                    _Stream = null;
                    _Reader = null;
                    break;
            }

            if (_Udc.Id.Length > 1)
            {
                _Wrapper.Init(false, _Udc.Data.ToCharArray());
            }
        }
    }
}
