namespace Me.Amon.Sec.Uc.CmUi
{
    public class RandKey : ACm
    {
        public RandKey(ASec asec, Cm cm)
            : base(asec, cm)
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
