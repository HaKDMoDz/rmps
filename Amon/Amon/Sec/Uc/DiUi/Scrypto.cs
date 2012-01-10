using System;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Uc.DiUi
{
    public class Scrypto : ADi
    {
        private Scrypto _Cur;
        private ScryptoDef _Def;
        private ScryptoEnc _Enc;
        private ScryptoDec _Dec;

        public Scrypto(ASec asec, Di di)
            : base(asec, di)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Di.Enabled = true;

            BeanUtil.Clear(_Di.CbType);
            _Di.CbType.Enabled = true;
            _Di.CbType.SelectedIndex = 0;

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
            _Key = key;

            BeanUtil.Clear(_Di.CbType);
            switch (_Key)
            {
                case IData.DIR_ENC:
                    if (_Enc == null)
                    {
                        _Enc = new ScryptoEnc(_ASec, _Di);
                    }
                    _Cur = _Enc;
                    break;
                case IData.DIR_DEC:
                    if (_Dec == null)
                    {
                        _Dec = new ScryptoDec(_ASec, _Di);
                    }
                    _Cur = _Dec;
                    break;
                default:
                    if (_Def == null)
                    {
                        _Def = new ScryptoDef(_ASec, _Di);
                    }
                    _Cur = _Def;
                    break;
            }

            _Cur.InitKey(key);
        }

        public override void ChangedType(Item type)
        {
            _Type = type;

            if (_Cur != null)
            {
                _Cur.ChangedType(type);
            }
        }

        public override void MoreData()
        {
            switch (_Type.K)
            {
                case INPUT_FILE:
                case INPUT_FILE_TXT:
                case INPUT_FILE_BIN:
                    _ASec.ShowOpen(_Di.TbData.Text, new CallBackHandler<string>(OpenCallBack));
                    break;
                case INPUT_TEXT:
                    _ASec.ShowEdit(_Di.UserData.ToString(), new CallBackHandler<string>(EditCallBack));
                    break;
                default:
                    break;
            }
        }

        public override void ChangedMask(Item mask)
        {
            _Mask = mask;
        }

        public override void MoreMask()
        {
            _ASec.ShowMask(_Mask);
        }
        #endregion

        #region 数据处理
        public override bool Check()
        {
            return _Cur.Check();
        }

        public override void Begin()
        {
            _Cur.Begin();
        }

        public override int Read(byte[] buffer, int offset, int length)
        {
            // 不做处理
            if (_Stream != null)
            {
                return _Stream.Read(buffer, offset, length);
            }

            string tmp = _Reader.ReadLine();
            if (tmp == null)
            {
                return 0;
            }

            // BASE 64编码
            if (_Mask.K == "0")
            {
                byte[] bi = Convert.FromBase64String(tmp);
                Array.Copy(bi, buffer, bi.Length);
                return bi.Length;
            }

            // 掩码算法
            char[] ci = tmp.ToCharArray();
            return _Wrapper.DoFinal(ci, 0, ci.Length, buffer, offset);
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