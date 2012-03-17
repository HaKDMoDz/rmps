namespace Me.Amon.Sec.Pro.Uc.CmUi
{
    public class RandKey : ACm
    {
        public RandKey(APro apro, Cm cm)
            : base(apro, cm)
        {
        }

        #region 接口实现
        public override void InitOpt()
        {
            _Cm.Enabled = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangeName(string name)
        {
        }

        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
        #endregion
    }
}
