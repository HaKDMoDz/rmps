
namespace Msec.Uc.UkUi
{
    public class Default : AUk
    {
        public Default(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
            _Uk.Enabled = false;

            _Uk.LbSize.Text = "口令(&K)";
            _Uk.LbPass.Text = "向量(&V)";
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