
namespace Msec.Uc.UkUi
{
    public class RandKey : AUk
    {
        public RandKey(Main main, Uk uk)
            : base(main, uk)
        {
        }
        public override void InitOpt()
        {
            _Uk.Enabled = true;

            _Uk.LbSize.Text = "用户(&K)";
            _Uk.LbPass.Text = "网站(&V)";
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
