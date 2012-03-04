using System;
using System.Text;
using Me.Amon.Bean;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Uc.DiUi
{
    public class Confuse : ADi
    {
        public Confuse(ASec asec, Di di)
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
            _Di.CbType.Enabled = true;

            _Di.TbData.Enabled = false;
            _Di.BtData.Enabled = false;

            BeanUtil.Clear(_Di.CbMask);
            _Di.CbMask.Items.Add(new Udc { Id = "11", Name = "2进制", Data = "01" });
            _Di.CbMask.Items.Add(new Udc { Id = "12", Name = "4进制", Data = "0123" });
            _Di.CbMask.Items.Add(new Udc { Id = "13", Name = "8进制", Data = "01234567" });
            _Di.CbMask.Items.Add(new Udc { Id = "14", Name = "16进制", Data = "0123456789ABCDEF" });
            _Di.CbMask.Items.Add(new Udc { Id = "15", Name = "32进制", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Di.CbMask.Items.Add(new Udc { Id = "16", Name = "64进制", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz*." });
            _Di.CbMask.Items.Add(new Udc { Id = "21", Name = "仅数字", Data = "0123456789" });
            _Di.CbMask.Items.Add(new Udc { Id = "22", Name = "大写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Di.CbMask.Items.Add(new Udc { Id = "23", Name = "小写字母", Data = "abcdefghijklmnopqrstuvwxyz" });
            _Di.CbMask.Items.Add(new Udc { Id = "24", Name = "大小写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Di.CbMask.Items.Add(new Udc { Id = "25", Name = "数字及字母", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Di.CbMask.Items.Add(new Udc { Id = "26", Name = "可输入英文符号", Data = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            _Di.CbMask.Items.Add(new Udc { Id = USER_CHARSET, Name = "自定义字符集", Data = "" });

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
            bool b = key == IData.DIR_DEC;
            _Di.LbMask.Visible = b;
            _Di.CbMask.Visible = b;
            _Di.BtMask.Visible = b;
            _Di.CbMask.SelectedIndex = 0;
        }

        public override void ChangedType(Item type)
        {
            _Type = type;

            switch (_Type.K)
            {
                case INPUT_FILE:
                    _Di.TbData.Enabled = true;
                    _Di.BtData.Enabled = true;
                    break;
                case INPUT_TEXT:
                    _Di.TbData.Enabled = true;
                    _Di.BtData.Enabled = true;
                    break;
                default:
                    _Di.TbData.Enabled = false;

                    _Di.BtData.Enabled = false;
                    break;
            }
        }

        public override void MoreData()
        {
            switch (_Type.K)
            {
                case INPUT_FILE:
                    _ASec.ShowOpen(_Di.TbData.Text, new CallBackHandler<string>(OpenCallBack));
                    break;
                case INPUT_TEXT:
                    _ASec.ShowEdit(_Di.UserData.ToString(), new CallBackHandler<string>(EditCallBack));
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
                    _Di.CbMask.Focus();
                    return false;
                }
            }
            return true;
        }

        public override void Begin()
        {
            switch (_Type.K)
            {
                case INPUT_FILE:
                    _Reader = new System.IO.StreamReader(_Di.TbData.Text);
                    break;
                case INPUT_TEXT:
                    _Reader = new System.IO.StringReader(_Di.TbData.Text);
                    break;
                default:
                    break;
            }

            if (_Udc.Id.Length > 1)
            {
                _Wrapper.Init(false, _Udc.Data.ToCharArray());
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // 不做处理
            if (!_Di.CbMask.Visible)
            {
                int l1 = _Reader.Read(_CharBuf, offset, count >> 1);
                byte[] bi = Encoding.Default.GetBytes(_CharBuf, 0, l1);
                Array.Copy(bi, 0, buffer, offset, bi.Length);
                return bi.Length;
            }

            // BASE 64编码
            if (_Udc.Id == "0")
            {
                int l2 = _Reader.Read(_CharBuf, offset, count);
                if (l2 < 1)
                {
                    return 0;
                }
                byte[] bi = Convert.FromBase64CharArray(_CharBuf, 0, l2);
                Array.Copy(bi, buffer, bi.Length);
                return bi.Length;
            }

            // 掩码算法
            int l3 = _Reader.Read(_CharBuf, offset, count);
            return _Wrapper.Decode(_CharBuf, 0, l3, buffer, offset);
        }

        public override void End()
        {
            _Reader.Close();
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