using System;
using System.IO;
using System.Text;
using Me.Amon.Bean;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Pro.Uc.DiUi
{
    public class Wrapper : ADi
    {
        public Wrapper(ASec asec, Di di)
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
            _Di.CbMask.Items.Add(new Item { K = "11", V = "2进制", D = "01" });
            _Di.CbMask.Items.Add(new Item { K = "12", V = "4进制", D = "0123" });
            _Di.CbMask.Items.Add(new Item { K = "13", V = "8进制", D = "01234567" });
            _Di.CbMask.Items.Add(new Item { K = "14", V = "16进制", D = "0123456789ABCDEF" });
            _Di.CbMask.Items.Add(new Item { K = "15", V = "32进制", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Di.CbMask.Items.Add(new Item { K = "16", V = "64进制", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz*." });
            _Di.CbMask.Items.Add(new Item { K = "21", V = "仅数字", D = "0123456789" });
            _Di.CbMask.Items.Add(new Item { K = "22", V = "大写字母", D = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Di.CbMask.Items.Add(new Item { K = "23", V = "小写字母", D = "abcdefghijklmnopqrstuvwxyz" });
            _Di.CbMask.Items.Add(new Item { K = "24", V = "大小写字母", D = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Di.CbMask.Items.Add(new Item { K = "25", V = "数字及字母", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Di.CbMask.Items.Add(new Item { K = "26", V = "可输入英文符号", D = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            _Di.CbMask.Items.Add(new Item { K = USER_CHARSET, V = "自定义字符集", D = "" });

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
            if (_Di.CbMask.Visible)
            {
                if (_Udc == null)
                {
                    Main.ShowAlert("请选择掩码！");
                    _Di.CbMask.Focus();
                    return false;
                }
                if (_Udc.Id == USER_CHARSET && string.IsNullOrEmpty(_Udc.Data))
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
            // 解密
            if (_Di.CbMask.Visible)
            {
                switch (_Type.K)
                {
                    case INPUT_FILE:
                        _Reader = new StreamReader(_Di.TbData.Text);
                        break;
                    case INPUT_TEXT:
                        _Reader = new StringReader(_Di.TbData.Text);
                        break;
                    default:
                        break;
                }

                if (_Udc.Id.Length > 1)
                {
                    _Wrapper.Init(false, _Udc.Data.ToCharArray());
                }
            }
            // 加密
            else
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
                        break;
                }
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            // 不做处理
            if (_Stream != null)
            {
                return _Stream.Read(buffer, offset, count);
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
            if (l3 > 0)
            {
                l3 = _Wrapper.Decode(_CharBuf, 0, l3, buffer, offset);
            }
            else
            {
                l3 = _Wrapper.DoFinal(buffer, offset);
            }
            return l3;
        }

        public override void End()
        {
            if (_Stream != null)
            {
                _Stream.Close();
                _Stream = null;
                return;
            }

            if (_Reader != null)
            {
                _Reader.Close();
                _Reader = null;
                return;
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