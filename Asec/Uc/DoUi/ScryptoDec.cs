using System.IO;
using System.Text;

namespace Msec.Uc.DoUi
{
    class ScryptoDec : Scrypto
    {
        public ScryptoDec(Main main, Do od)
            : base(main, od)
        {
        }

        public override void InitKey(string key)
        {
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE, V = "文件" });
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
                case OUTPUT_FILE:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;
                    _Do.BtData.Focus();
                    break;
                case OUTPUT_TEXT:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;
                    _Do.BtData.Focus();
                    break;
                default:
                    _Do.BtData.Enabled = false;
                    break;
            }
        }

        public override bool Check()
        {
            if (_Type.K == OUTPUT_FILE)
            {
                if (string.IsNullOrWhiteSpace(_Do.TbData.Text))
                {
                    _Main.ShowAlert("请选择输出路径！");
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
                case OUTPUT_FILE:
                    _Stream = new FileStream(_Do.TbData.Text, FileMode.Create);
                    break;
                case OUTPUT_TEXT:
                    _Stream = new MemoryStream();
                    break;
                default:
                    _Stream = null;
                    _Writer = null;
                    break;
            }
        }

        public override void End()
        {
            if (_Stream != null)
            {
                _Stream.Flush();

                if (_Type.K == OUTPUT_TEXT)
                {
                    byte[] tmp = ((MemoryStream)_Stream).ToArray();
                    _Do.UserData.Clear().Append(Encoding.Default.GetString(tmp));
                    _Do.ShowData();
                }

                _Stream.Close();
                _Stream = null;
                return;
            }
        }
    }
}
