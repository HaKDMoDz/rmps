
namespace Msec.Uc.UkUi
{
    public class Acrypto : AUk
    {
        public Acrypto(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
        }

        public override void InitKey(string key)
        {
            _Uk.Enabled = false;
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