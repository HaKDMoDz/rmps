using System;
using Me.Amon.Bean;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Pro.Uc.DiUi
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

        public override void ChangedMask(Udc udc)
        {
            _Udc = udc;
        }

        public override void MoreMask()
        {
            _ASec.ShowMask(_Udc);
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
            if (_Udc.Id == "0")
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