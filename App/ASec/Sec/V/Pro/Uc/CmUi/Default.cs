﻿namespace Me.Amon.Sec.V.Pro.Uc.CmUi
{
    public class Default : ACm
    {
        public Default(APro apro, Cm cm)
            : base(apro, cm)
        {
        }

        public override void InitOpt()
        {
            _Cm.Enabled = false;

            _Cm.LbMode.Visible = false;
            _Cm.CbMode.Enabled = false;
            _Cm.CbMode.Visible = false;

            _Cm.LbPads.Visible = false;
            _Cm.CbPads.Enabled = false;
            _Cm.CbPads.Visible = false;
        }

        public override void InitKey(string key)
        {
        }

        public override void ChangeName(string name)
        {
        }

        public override void ChangeMode(string mode)
        {
        }

        public override void ChangePads(string pads)
        {
        }
    }
}