namespace Me.Amon.Bean.Atts
{
    public class MetaAtt : Att
    {
        public MetaAtt()
            : base(TYPE_META, "", "")
        {
            Order = "搜索";
        }

        public override void SetDefault()
        {
        }
    }
}
