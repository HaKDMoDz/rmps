using System;
using Me.Amon.Bean;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Uc.DoUi
{
    public class Sstream : ADo
    {
        private Sstream _Cur;
        private SstreamDef _Def;
        private SstreamEnc _Enc;
        private SstreamDec _Dec;

        public Sstream(ASec asec, Do od)
            : base(asec, od)
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
            _Do.CbMask.Items.Add(new Item { K = "11", V = "2进制", D = "01" });
            _Do.CbMask.Items.Add(new Item { K = "12", V = "4进制", D = "0123" });
            _Do.CbMask.Items.Add(new Item { K = "13", V = "8进制", D = "01234567" });
            _Do.CbMask.Items.Add(new Item { K = "14", V = "16进制", D = "0123456789ABCDEF" });
            _Do.CbMask.Items.Add(new Item { K = "15", V = "32进制", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Do.CbMask.Items.Add(new Item { K = "16", V = "64进制", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz*." });
            _Do.CbMask.Items.Add(new Item { K = "21", V = "仅数字", D = "0123456789" });
            _Do.CbMask.Items.Add(new Item { K = "22", V = "大写字母", D = "ABCDEFGHIJKLMNOPQRSTUVWXYZ" });
            _Do.CbMask.Items.Add(new Item { K = "23", V = "小写字母", D = "abcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Item { K = "24", V = "大小写字母", D = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Item { K = "25", V = "数字及字母", D = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz" });
            _Do.CbMask.Items.Add(new Item { K = "26", V = "可输入英文符号", D = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~" });
            _Do.CbMask.Items.Add(new Item { K = USER_CHARSET, V = "自定义字符集", D = "" });

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
            BeanUtil.Clear(_Do.CbType);

            switch (key)
            {
                case IData.DIR_ENC:
                    if (_Enc == null)
                    {
                        _Enc = new SstreamEnc(_Asec, _Do);
                    }
                    _Cur = _Enc;
                    break;
                case IData.DIR_DEC:
                    if (_Dec == null)
                    {
                        _Dec = new SstreamDec(_Asec, _Do);
                    }
                    _Cur = _Dec;
                    break;
                default:
                    if (_Def == null)
                    {
                        _Def = new SstreamDef(_Asec, _Do);
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
                    _Asec.ShowSave(_Do.TbData.Text, new CallBackHandler<string>(SaveCallBack));
                    break;
                case OUTPUT_TEXT:
                    _Asec.ShowText(_Do.UserData.ToString(), new CallBackHandler<string>(EditCallBack));
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
            _Asec.ShowMask(_Udc);
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
            if (!_Do.CbMask.Visible)
            {
                _Stream.Write(buffer, offset, count);
                return;
            }

            int len;
            // BASE64 编码
            if (_Udc.Id == "0")
            {
                len = Convert.ToBase64CharArray(buffer, offset, count, _CharBuf, 0);
                _Writer.WriteLine(_CharBuf, 0, len);
                return;
            }

            // 掩码算法
            len = _Wrapper.Encode(buffer, offset, count, _CharBuf, 0);
            _Writer.Write(_CharBuf, 0, len);
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
