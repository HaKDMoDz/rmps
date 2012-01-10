using Me.Amon.Uc;

namespace Me.Amon.Sec.Uc.DoUi
{
    public class Default : ADo
    {
        public Default(ASec asec, Do od)
            : base(asec, od)
        {
        }

        #region 接口实现
        #region 用户交互
        public override void InitOpt()
        {
            _Do.Enabled = false;

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
        }

        public override void MoreData()
        {
        }

        public override void ChangedMask(Item mask)
        {
            _Mask = mask;
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