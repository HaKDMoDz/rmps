using System;

namespace Msec.Uc.DoUi
{
    public class Scrypto : ADo
    {
        private Scrypto _Cur;
        private ScryptoDef _Def;
        private ScryptoEnc _Enc;
        private ScryptoDec _Dec;

        public Scrypto(Main main, Do od)
            : base(main, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = true;

            Util.Clear(_Do.CbType);
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE_BIN, V = "字节文件" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE_TXT, V = "字符文件" });
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

            _Do.LbMask.Visible = true;
            _Do.CbMask.Visible = true;
            _Do.BtMask.Visible = true;
        }

        public override void InitKey(string key)
        {
            Util.Clear(_Do.CbType);

            switch (key)
            {
                case IData.DIR_ENC:
                    if (_Enc == null)
                    {
                        _Enc = new ScryptoEnc(_Main, _Do);
                    }
                    _Cur = _Enc;
                    break;
                case IData.DIR_DEC:
                    if (_Dec == null)
                    {
                        _Dec = new ScryptoDec(_Main, _Do);
                    }
                    _Cur = _Dec;
                    break;
                default:
                    if (_Def == null)
                    {
                        _Def = new ScryptoDef(_Main, _Do);
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
            if (_Mask.K == "0")
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