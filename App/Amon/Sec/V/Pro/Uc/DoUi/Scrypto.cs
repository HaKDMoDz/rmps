using System;
using Me.Amon.Pwd;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.V.Pro.Uc.DoUi
{
    public class Scrypto : ADo
    {
        private Scrypto _Cur;
        private ScryptoDef _Def;
        private ScryptoEnc _Enc;
        private ScryptoDec _Dec;

        public Scrypto(APro apro, Do od)
            : base(apro, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = true;

            BeanUtil.Clear(_Do.CbType);
            _Do.CbType.Enabled = true;
            _Do.CbType.SelectedIndex = 0;

            _Do.TbData.Enabled = false;
            _Do.BtData.Enabled = false;

            BeanUtil.Clear(_Do.CbMask);
            _Do.CbMask.Items.Add(new Udc { Id = "11", Name = "2进制", Data = "01" });
            _Do.CbMask.Items.Add(new Udc { Id = "12", Name = "4进制", Data = "0123" });
            _Do.CbMask.Items.Add(new Udc { Id = "13", Name = "8进制", Data = "01234567" });
            _Do.CbMask.Items.Add(new Udc { Id = "14", Name = "16进制", Data = "0123456789ABCDEF" });
            _Do.CbMask.Items.Add(new Udc { Id = "15", Name = "32进制", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Do.CbMask.Items.Add(new Udc { Id = "16", Name = "64进制", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz*." });
            _Do.CbMask.Items.Add(new Udc { Id = "21", Name = "仅数字", Data = "0123456789" });
            _Do.CbMask.Items.Add(new Udc { Id = "22", Name = "大写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Do.CbMask.Items.Add(new Udc { Id = "23", Name = "小写字母", Data = "abcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Udc { Id = "24", Name = "大小写字母", Data = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Udc { Id = "25", Name = "数字及字母", Data = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Udc { Id = "26", Name = "可输入英文符号", Data = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            _Do.CbMask.Items.Add(new Udc { Id = USER_CHARSET, Name = "自定义字符集", Data = "" });

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
            BeanUtil.Clear(_Do.CbType);

            switch (key)
            {
                case ESec.DIR_ENC:
                    if (_Enc == null)
                    {
                        _Enc = new ScryptoEnc(_APro, _Do);
                    }
                    _Cur = _Enc;
                    break;
                case ESec.DIR_DEC:
                    if (_Dec == null)
                    {
                        _Dec = new ScryptoDec(_APro, _Do);
                    }
                    _Cur = _Dec;
                    break;
                default:
                    if (_Def == null)
                    {
                        _Def = new ScryptoDef(_APro, _Do);
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
                case OUTPUT_FILE:
                case OUTPUT_FILE_BIN:
                case OUTPUT_FILE_TXT:
                    _APro.ShowSave(_Do.TbData.Text, new CallBackHandler<string>(SaveCallBack));
                    break;
                case OUTPUT_TEXT:
                    _APro.ShowText(_Do.UserData.ToString(), new CallBackHandler<string>(EditCallBack));
                    break;
                default:
                    _Do.TbData.Enabled = false;
                    _Do.BtData.Enabled = false;

                    _Do.CbMask.Enabled = false;
                    break;
            }
        }

        public override void ChangedMask(Udc udc)
        {
            _Udc = udc;
        }

        public override void MoreMask()
        {
            _APro.ShowMask(_Udc);
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

        public override void Write(byte[] buffer, int offset, int count)
        {
            if (count < 1)
            {
                return;
            }

            // 不处理
            if (_Stream != null)
            {
                _Stream.Write(buffer, offset, count);
                return;
            }

            int len;
            // BASE64 编码
            if (_Udc.Id == "0")
            {
                len = Convert.ToBase64CharArray(buffer, offset, count, _CharBuf, 0);
            }
            // 掩码算法
            else
            {
                len = _Wrapper.DoFinal(buffer, offset, count, _CharBuf, 0);
            }
            _Writer.WriteLine(_CharBuf, 0, len);
        }

        public override void End()
        {
            _Cur.End();
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