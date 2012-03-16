namespace Me.Amon.Bean.Att
{
    public class HintAtt : AAtt
    {
        public GtdHeader GtdHeader { get; set; }

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
