using System.IO;
using System.Text;
using Me.Amon.Pwd;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Pro.Uc.DiUi
{
    public class Digest : ADi
    {
        public Digest(APro asec, Di di)
            : base(asec, di)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Di.Enabled = true;

            BeanUtil.Clear(_Di.CbType);
            _Di.CbType.Items.Add(new Item { K = INPUT_FILE, V = "文件" });
            _Di.CbType.Items.Add(new Item { K = INPUT_TEXT, V = "文本" });

            _Di.TbData.Enabled = false;
            _Di.BtData.Enabled = false;

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangedType(Item type)
        {
            _Type = type;

            switch (_Type.K)
            {
                case INPUT_TEXT:
                    _Di.TbData.Enabled = true;
                    _Di.TbData.Focus();

                    _Di.BtData.Enabled = true;

                    _Di.CbMask.Enabled = true;
                    break;
                case INPUT_FILE:
                    _Di.TbData.Enabled = true;

                    _Di.BtData.Enabled = true;
                    _Di.BtData.Focus();

                    _Di.CbMask.Enabled = true;
                    break;
                default:
                    _Di.BtData.Enabled = false;

                    _Di.CbMask.Enabled = false;
                    break;
            }
        }

        public override void MoreData()
        {
            switch (_Type.K)
            {
                case INPUT_FILE:
                    _APro.ShowOpen(_Di.TbData.Text, new CallBackHandler<string>(OpenCallBack));
                    break;
                case INPUT_TEXT:
                    _APro.ShowEdit(_Di.UserData.ToString(), new CallBackHandler<string>(EditCallBack));
                    break;
                default:
                    break;
            }
        }

        public override void ChangedMask(Udc udc)
        {
            _Udc = udc;
        }

        public override void MoreMask()
        {
        }
        #endregion

        #region 数据处理
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
                    break;
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return _Stream.Read(buffer, offset, count);
        }

        public override void End()
        {
            if (_Stream != null)
            {
                _Stream.Close();
                _Stream = null;
            }
        }
        #endregion
        #endregion

        private void OpenCallBack(string file)
        {
            _Di.TbData.Text = file;
        }

        private void EditCallBack(string data)
        {
            _Di.UserData.Clear().Append(data);
            _Di.ShowData();
        }
    }
}