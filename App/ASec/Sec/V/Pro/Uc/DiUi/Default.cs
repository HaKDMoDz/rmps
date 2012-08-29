using Me.Amon.M;
using Me.Amon.Uc;

namespace Me.Amon.Sec.V.Pro.Uc.DiUi
{
    public class Default : ADi
    {
        public Default(APro apro, Di di)
            : base(apro, di)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Di.Enabled = false;

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangedType(Items type)
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