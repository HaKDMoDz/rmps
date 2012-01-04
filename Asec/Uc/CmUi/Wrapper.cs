namespace Msec.Uc.CmUi
{
    public class Wrapper : ACm
    {
        public Wrapper(Main main, Cm cm)
            : base(main, cm)
        {
        }

        private Ce.Wrapper _Cipher;
        public Ce.Wrapper Cipher
        {
            get
            {
                return _Cipher;
            }
        }

        public override void InitOpt()
        {
            _Cm.Enabled = false;

            Util.Clear(_Cm.CbName);
            _Cm.CbName.Items.Add(new Item { K = "confuse", V = "混淆算法" });
            _Cm.CbName.SelectedIndex = 1;

            _Cm.LbMode.Visible = false;
            _Cm.CbMode.Visible = false;

            _Cm.LbPads.Visible = false;
            _Cm.CbPads.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangeName(string name)
        {
            _Cipher = new Ce.Wrapper();

            _Cm.CbMode.SelectedIndex = 0;

            _Cm.CbPads.SelectedIndex = 0;
        }

        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
    }
}