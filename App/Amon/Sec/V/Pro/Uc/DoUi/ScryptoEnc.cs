using System.IO;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc.DoUi
{
    class ScryptoEnc : Scrypto
    {
        public ScryptoEnc(APro apro, Do od)
            : base(apro, od)
        {
        }

        public override void InitKey(string key)
        {

            _Do.CbType.Items.Add(new Items { K = OUTPUT_FILE_BIN, V = "字节文件" });
            _Do.CbType.Items.Add(new Items { K = OUTPUT_FILE_TXT, V = "字符文件" });
            _Do.CbType.Items.Add(new Items { K = OUTPUT_TEXT, V = "文本" });

            _Do.CbType.SelectedIndex = 0;

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void ChangedType(Items type)
        {
            _Do.TbData.Text = "";
            switch (_Type.K)
            {
                case OUTPUT_FILE_BIN:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;
                    _Do.BtData.Focus();

                    _Do.LbMask.Visible = false;
                    _Do.CbMask.Visible = false;
                    _Do.BtMask.Visible = false;
                    break;
                case OUTPUT_TEXT:
                case OUTPUT_FILE_TXT:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;
                    _Do.BtData.Focus();

                    _Do.LbMask.Visible = true;
                    _Do.CbMask.Visible = true;
                    _Do.BtMask.Visible = true;
                    break;
                default:
                    _Do.BtData.Enabled = false;

                    _Do.LbMask.Visible = false;
                    _Do.CbMask.Visible = false;
                    _Do.BtMask.Visible = false;
                    break;
            }
        }

        public override bool Check()
        {
            if (_Type.K == OUTPUT_FILE_TXT || _Type.K == OUTPUT_FILE_BIN)
            {
                if (string.IsNullOrWhiteSpace(_Do.TbData.Text))
                {
                    Main.ShowAlert("请选择输出路径！");
                    _Do.TbData.Focus();
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
                case OUTPUT_FILE_BIN:
                    _Stream = new FileStream(_Do.TbData.Text, FileMode.Create);
                    break;
                case OUTPUT_FILE_TXT:
                    _Writer = new StreamWriter(_Do.TbData.Text);
                    break;
                case OUTPUT_TEXT:
                    _Writer = new StringWriter(_Do.UserData.Clear());
                    break;
                default:
                    _Stream = null;
                    _Writer = null;
                    break;
            }
            
            if (_Udc.Id.Length > 1)
            {
                _Wrapper.Init(true, _Udc.Data.ToCharArray());
            }
        }

        public override void End()
        {
            if (_Stream != null)
            {
                _Stream.Close();
                _Stream = null;
                return;
            }

            if (_Writer != null)
            {
                _Writer.Close();
                _Writer = null;

                if (_Type.K == OUTPUT_TEXT)
                {
                    _Do.ShowData();
                }
                return;
            }
        }
    }
}
