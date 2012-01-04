namespace Msec.Uc.UkUi
{
    public class Wrapper : AUk
    {
        public Wrapper(Main main, Uk uk)
            : base(main, uk)
        {
        }

        #region 接口实现
        public override void InitOpt()
        {
            _Uk.Enabled = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void MorePass()
        {
        }

        public override void MoreSalt()
        {
        }

        public override bool Check()
        {
            return true;
        }
        #endregion
    }
}