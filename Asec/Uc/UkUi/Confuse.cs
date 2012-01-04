namespace Msec.Uc.UkUi
{
    public class Confuse : AUk
    {
        public Confuse(Main main, Uk uk)
            : base(main, uk)
        {
        }

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
    }
}