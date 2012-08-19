using Me.Amon.Gtd;

namespace Me.Amon.Pwd._Att
{
    public class HintAtt : Att
    {
        public MGtd Gtd { get; set; }

        public HintAtt()
            : base(TYPE_HINT, "", "")
        {
            Order = "提醒";
        }

        public override void SetDefault()
        {
        }
    }
}
