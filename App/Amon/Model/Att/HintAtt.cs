namespace Me.Amon.Model.Att
{
    public class HintAtt : AAtt
    {
        public GtdHeader GtdHeader { get; set; }

        public HintAtt()
            : base(TYPE_HINT, "", "")
        {
            Order = "提示";
        }

        public override void SetDefault()
        {
        }
    }
}
