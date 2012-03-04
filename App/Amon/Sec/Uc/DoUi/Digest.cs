using System;
using System.IO;
using Me.Amon.Bean;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Uc.DoUi
{
    public class Digest : ADo
    {
        public Digest(ASec asec, Do od)
            : base(asec, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = true;

            BeanUtil.Clear(_Do.CbType);
            _Do.CbType.Items.Add(new Item { K = OUTPUT_TEXT, V = "文本" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE_TXT, V = "字符文件" });
            _Do.CbType.Items.Add(new Item { K = OUTPUT_FILE_BIN, V = "字节文件" });

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
        }

        public override void ChangedType(Item type)
        {
            _Type = type;

            _Do.TbData.Text = "";
            switch (_Type.K)
            {
                case OUTPUT_TEXT:
                case OUTPUT_FILE_TXT:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;

                    _Do.LbMask.Visible = true;
                    _Do.CbMask.Visible = true;
                    _Do.BtMask.Visible = true;
                    break;
                case OUTPUT_FILE_BIN:
                    _Do.TbData.Enabled = true;

                    _Do.BtData.Enabled = true;

                    _Do.LbMask.Visible = false;
                    _Do.CbMask.Visible = false;
                    _Do.BtMask.Visible = false;
                    break;
                default:
                    _Do.TbData.Enabled = false;

                    _Do.BtData.Enabled = false;

                    _Do.LbMask.Visible = false;
                    _Do.CbMask.Visible = false;
                    _Do.BtMask.Visible = false;
                    break;
            }
            _Do.CbMask.SelectedIndex = 0;
        }

        public override void MoreData()
        {
            switch (_Type.K)
            {
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
            if (_Type.K == OUTPUT_FILE_TXT || _Type.K == OUTPUT_FILE_BIN)
            {
                if (string.IsNullOrWhiteSpace(_Do.TbData.Text))
                {
                    Main.ShowAlert("请选择输出路径！");
                    _Do.TbData.Focus();
                    return false;
                }
                return true;
            }

            if (_Udc == null)
            {
                Main.ShowAlert("请选择掩码！");
                _Do.CbMask.Focus();
                return false;
            }
            if (_Udc.Id == USER_CHARSET)
            {
                if (string.IsNullOrEmpty(_Udc.Data))
                {
                    Main.ShowAlert("掩码字符不能为空！");
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
                case OUTPUT_TEXT:
                    _Writer = new StringWriter(_Do.UserData.Clear());
                    break;
                case OUTPUT_FILE_TXT:
                    _Writer = new StreamWriter(_Do.TbData.Text);
                    break;
                case OUTPUT_FILE_BIN:
                    _Stream = new FileStream(_Do.TbData.Text, FileMode.Create);
                    break;
                default:
                    _Writer = null;
                    _Stream = null;
                    break;
            }

            if (_Udc.Id.Length > 1)
            {
                _Wrapper.Init(true, _Udc.Data.ToCharArray());
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
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
                len = _Wrapper.Encode(buffer, offset, count, _CharBuf, 0);
            }
            _Writer.Write(_CharBuf, 0, len);
        }

        public override void End()
        {
            if (_Stream != null)
            {
                _Stream.Flush();
                _Stream.Close();
                _Stream = null;
                return;
            }

            if (_Writer != null)
            {
                _Writer.Flush();

                if (_Type.K == OUTPUT_TEXT)
                {
                    _Do.ShowData();
                }

                _Writer.Close();
                _Writer = null;
            }
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