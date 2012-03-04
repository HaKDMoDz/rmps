using System;
using System.IO;
using Me.Amon.Bean;
using Me.Amon.Uc;
using Me.Amon.Util;

namespace Me.Amon.Sec.Uc.DiUi
{
    public class Acrypto : ADi
    {
        public Acrypto(ASec asec, Di di)
            : base(asec, di)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Di.Enabled = true;

            BeanUtil.Clear(_Di.CbType);
            _Di.CbType.Items.Add(new Item { K = INPUT_FILE_BIN, V = "字节文件" });
            _Di.CbType.Items.Add(new Item { K = INPUT_FILE_TXT, V = "字符文件" });
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

            _Di.LbMask.Visible = true;
            _Di.CbMask.Visible = true;
            _Di.BtMask.Visible = true;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangedType(Item type)
        {
            _Type = type;

            switch (_Type.K)
            {
                case INPUT_FILE_BIN:
                case INPUT_FILE_TXT:
                    _Di.TbData.Enabled = true;
                    _Di.TbData.Focus();

                    _Di.BtData.Enabled = true;

                    _Di.CbMask.Enabled = true;
                    break;
                case INPUT_TEXT:
                    _Di.TbData.Enabled = true;

                    _Di.BtData.Enabled = true;
                    _Di.BtData.Focus();

                    _Di.CbMask.Enabled = true;
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
                case INPUT_FILE_BIN:
                case INPUT_FILE_TXT:
                    _ASec.ShowOpen(_Di.TbData.Text, new CallBackHandler<string>(SaveCallBack));
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
            if (_Type.K == INPUT_FILE_BIN || _Type.K == INPUT_FILE_TXT)
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
                case INPUT_FILE_BIN:
                case INPUT_FILE_TXT:
                    _Stream = File.OpenRead(_Di.TbData.Text);
                    break;
                case INPUT_TEXT:
                    _Stream = new MemoryStream(Convert.FromBase64String(_Di.TbData.Text));
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
            _Stream.Close();
        }
        #endregion
        #endregion

        private void SaveCallBack(string file)
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