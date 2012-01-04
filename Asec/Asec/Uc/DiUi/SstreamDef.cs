namespace Msec.Uc.DiUi
{
    class SstreamDef : Sstream
    {
        public SstreamDef(Main main, Di di)
            : base(main, di)
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
