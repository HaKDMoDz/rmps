
namespace Msec.Uc.UkUi
{
    public class Scrypto : AUk
    {
        public Scrypto(Main main, Uk uk)
            : base(main, uk)
        {
        }

        public override void InitOpt()
        {
        }

        public override void InitKey(string key)
        {
            _Uk.Enabled = true;

            _Uk.TbPass.Enabled = true;
            _Uk.TbSalt.Enabled = true;
        }

        public override void MorePass()
        {
            _Main.ShowPass("");
        }

        public override void MoreSalt()
        {
            _Main.ShowPass("");
        }

        public override bool Check()
        {
            if (string.IsNullOrEmpty(_Uk.TbPass.Text))
            {
                _Main.ShowAlert("请输入用户！");
                _Uk.TbPass.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(_Uk.TbSalt.Text))
            {
                _Main.ShowAlert("请输入口令！");
                _Uk.TbSalt.Focus();
                return false;
            }
            return true;
        }
    }
}