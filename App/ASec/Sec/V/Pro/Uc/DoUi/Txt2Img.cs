using Me.Amon.M;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc.DoUi
{
    public class Txt2Img : ADo
    {
        public Txt2Img(APro apro, Do od)
            : base(apro, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = true;

            _Do.LbMask.Visible = false;
            _Do.CbMask.Visible = false;
            _Do.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangedType(Items type)
        {
            _Type = type;

            _Do.TbData.Text = "";
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
            _APro.ShowMask(_Udc);
        }
        #endregion

        #region 数据处理
        public override bool Check()
        {
            //if (_Type.K == OUTPUT_FILE_TXT || _Type.K == OUTPUT_FILE_BIN)
            //{
            //    if (string.IsNullOrWhiteSpace(_Do.TbData.Text))
            //    {
            //        _Main.ShowAlert("请选择输出路径！");
            //        _Do.TbData.Focus();
            //        return false;
            //    }
            //    return true;
            //}
            return true;
        }

        public override void Begin()
        {
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
        }

        public override void End()
        {
        }
        #endregion
        #endregion
    }
}