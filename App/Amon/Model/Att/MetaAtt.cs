namespace Me.Amon.Model.Att
{
    public class MetaAtt : AAtt
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
