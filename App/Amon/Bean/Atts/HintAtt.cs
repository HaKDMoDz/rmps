namespace Me.Amon.Bean.Atts
{
    public class HintAtt : Att
    {
        public Gtd GtdHeader { get; set; }

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
