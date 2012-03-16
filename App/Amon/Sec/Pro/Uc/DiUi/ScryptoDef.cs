using Me.Amon.Uc;

namespace Me.Amon.Sec.Pro.Uc.DiUi
{
    class ScryptoDef : Scrypto
    {
        public ScryptoDef(ASec asec, Di di)
            : base(asec, di)
        {
        }

        public override void InitKey(string key)
        {
            _Di.CbType.SelectedIndex = 0;

            _Di.LbMask.Visible = false;
            _Di.CbMask.Visible = false;
            _Di.BtMask.Visible = false;
        }

        public override void ChangedType(Item type)
        {
            _Di.BtData.Enabled = false;
        }

        public override bool Check()
        {
            return true;
        }

        public override void Begin()
        {
        }
    }
}
