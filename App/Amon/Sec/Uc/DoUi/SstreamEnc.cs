using System.IO;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Uc.DoUi
{
    class SstreamEnc : Sstream
    {
        public SstreamEnc(ASec asec, Do od)
            : base(asec, od)
        {
        }

        public override void InitKey(string key)
        {
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE_BIN, V = "字节文件" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE_TXT, V = "字符文件" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_TEXT, V = "文本" });

            _Do.CbType.SelectedIndex = 0;

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void ChangedType(Item type)
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

            if (_Udc == null)
            {
                Main.ShowAlert("请选择掩码！");
                _Do.CbMask.Focus();
                return false;
            }
            if (_Udc.Id == USER_CHARSET)
            {
                if (string.IsNullOrEmpty(_Udc.Data))
                {
                    Main.ShowAlert("掩码字符不能为空！");
                    _Do.CbMask.Focus();
                    return false;
                }
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
                _Stream.Flush();
                _Stream.Close();
                _Stream = null;
                return;
            }

            if (_Writer != null)
            {
                if (_Udc.Id != "0")
                {
                    int len = _Wrapper.DoFinal(_CharBuf, 0);
                    if (len > 0)
                    {
                        _Writer.Write(_CharBuf, 0, len);
                    }
                }

                _Writer.Flush();

                if (_Type.K == OUTPUT_TEXT)
                {
                    _Do.ShowData();
                }

                _Writer.Close();
                _Writer = null;
                return;
            }
        }
    }
}
