namespace Me.Amon.Pwd._Att
{
    public class AutoAtt : Att
    {
        public AutoAtt()
            : base(TYPE_AUTO, "", "")
        {
            Order = "填充";
        }

        public override void SetDefault()
        {
        }
    }
}
