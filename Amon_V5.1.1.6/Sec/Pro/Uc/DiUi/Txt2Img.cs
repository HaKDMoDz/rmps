using Me.Amon.Bean;
using Me.Amon.Uc;

namespace Me.Amon.Sec.Pro.Uc.DiUi
{
    public class Txt2Img : ADi
    {
        public Txt2Img(APro apro, Di di)
            : base(apro, di)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Di.Enabled = true;

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangedType(Item type)
        {
            _Type = type;
        }

        public override void MoreData()
        {
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
            //if (_Type.K == INPUT_FILE_BIN || _Type.K == INPUT_FILE_TXT)
            //{
            //    if (string.IsNullOrWhiteSpace(_Di.TbData.Text))
            //    {
            //        _Main.ShowAlert("请选择输入文件！");
            //        _Di.TbData.Focus();
            //        return false;
            //    }
            //    if (!System.IO.File.Exists(_Di.TbData.Text))
            //    {
            //        _Main.ShowAlert("您选择的输入文件不存在！");
            //        _Di.TbData.Focus();
            //        return false;
            //    }
            //    return true;
            //}
            //if (_Type.K == INPUT_TEXT)
            //{
            //    if (string.IsNullOrEmpty(_Di.TbData.Text))
            //    {
            //        _Main.ShowAlert("请录入输入文本！");
            //        _Di.TbData.Focus();
            //        return false;
            //    }
            //    return true;
            //}
            return true;
        }

        public override void Begin()
        {
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }

        public override void End()
        {
        }
        #endregion
        #endregion
    }
}