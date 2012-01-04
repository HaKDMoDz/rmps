
namespace Msec.Uc.UkUi
{
    public class Sstream : AUk
    {
        public Sstream(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = true;
        }

        public override void InitKey(string key)
        {
            bool b = key != "0";
            _Uk.TbPass.Enabled = b;
            _Uk.BtPass.Enabled = b;

            _Uk.TbSalt.Enabled = b;
            _Uk.BtSalt.Enabled = b;
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
