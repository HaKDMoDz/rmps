using System;
using System.Text;

namespace Msec.Uc.DoUi
{
    public class Confuse : ADo
    {
        public Confuse(Main main, Do od)
            : base(main, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = true;

            Util.Clear(_Do.CbType);
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE, V = "文件" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_TEXT, V = "文本" });
            _Do.CbType.Enabled = true;

            _Do.TbData.Enabled = false;
            _Do.BtData.Enabled = false;

            Util.Clear(_Do.CbMask);
            _Do.CbMask.Items.Add(new Item { K = "11", V = "2进制", D = "01" });
            _Do.CbMask.Items.Add(new Item { K = "12", V = "4进制", D = "0123" });
            _Do.CbMask.Items.Add(new Item { K = "13", V = "8进制", D = "01234567" });
            _Do.CbMask.Items.Add(new Item { K = "14", V = "16进制", D = "0123456789ABCDEF" });
            _Do.CbMask.Items.Add(new Item { K = "15", V = "32进制", D = "0123456789ABCDEF" });
            _Do.CbMask.Items.Add(new Item { K = "16", V = "64进制", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz*." });
            _Do.CbMask.Items.Add(new Item { K = "21", V = "仅数字", D = "0123456789" });
            _Do.CbMask.Items.Add(new Item { K = "22", V = "大写字母", D = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Do.CbMask.Items.Add(new Item { K = "23", V = "小写字母", D = "abcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Item { K = "24", V = "大小写字母", D = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Item { K = "25", V = "数字及字母", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Item { K = USER_CHARSET, V = "自定义字符集", D = "" });

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
            bool b = key == IData.KEY_ENC;
            _Do.LbMask.Visible = b;
            _Do.CbMask.Visible = b;
            _Do.BtMask.Visible = b;
            _Do.CbMask.SelectedIndex = 0;
        }

        public override void ChangedType(Item type)
        {
            _Type = type;

            _Do.TbData.Text = "";
            switch (_Type.K)
            {
                case OUTPUT_FILE:
                    _Do.TbData.Enabled = false;

                    _Do.BtData.Enabled = true;
                    break;
                case OUTPUT_TEXT:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;
                    break;
                default:
                    _Do.TbData.Enabled = false;

                    _Do.BtData.Enabled = false;
                    break;
            }
        }

        public override void MoreData()
        {
            switch (_Type.K)
            {
                case OUTPUT_FILE:
                    _Main.ShowSave(_Do.TbData.Text, new CallBackHandler<string>(SaveCallBack));
                    break;
                case OUTPUT_TEXT:
                    _Main.ShowText(_Do.UserData.ToString(), new CallBackHandler<string>(EditCallBack));
                    break;
                default:
                    _Do.TbData.Enabled = false;
                    _Do.BtData.Enabled = false;

                    _Do.CbMask.Enabled = false;
                    break;
            }
        }

        public override void ChangedMask(Item mask)
        {
            _Mask = mask;
        }

        public override void MoreMask()
        {
            _Main.ShowMask(_Mask);
        }
        #endregion

        #region 数据处理
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

            if (_Mask == null)
            {
                _Main.ShowAlert("请选择掩码！");
                _Do.CbMask.Focus();
                return false;
            }
            if (_Mask.K == USER_CHARSET)
            {
                if (string.IsNullOrEmpty(_Mask.D))
                {
                    _Main.ShowAlert("掩码字符不能为空！");
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
                case OUTPUT_FILE:
                    _Writer = new System.IO.StreamWriter(_Do.TbData.Text);
                    break;
                case OUTPUT_TEXT:
                    _Writer = new System.IO.StringWriter(_Do.UserData.Clear());
                    break;
                default:
                    break;
            }

            if (_Mask.K.Length > 1)
            {
                _Wrapper.Init(true, _Mask.D.ToCharArray());
            }
        }

        public override void Write(byte[] byteBuf, int offset, int length)
        {
            int len;
            // 不处理
            if (!_Do.CbMask.Visible)
            {
                len = Encoding.Default.GetChars(byteBuf, offset, length, _CharBuf, 0);
            }
            // BASE64 编码
            else if (_Mask.K == "0")
            {
                len = Convert.ToBase64CharArray(byteBuf, offset, length, _CharBuf, 0);
            }
            // 掩码算法
            else
            {
                len = _Wrapper.Encode(byteBuf, offset, length, _CharBuf, 0);
            }
            _Writer.Write(_CharBuf, 0, len);
        }

        public override void End()
        {
            if (_Type.K == OUTPUT_TEXT)
            {
                _Writer.Flush();
                _Do.ShowData();
            }
            _Writer.Close();
        }
        #endregion
        #endregion

        private void SaveCallBack(string file)
        {
            _Do.TbData.Text = file;
        }

        private void EditCallBack(string data)
        {
        }
    }
}