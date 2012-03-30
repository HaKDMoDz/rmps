namespace Me.Amon.Pwd._Att
{
    public class LogoAtt : Att
    {
        private string path;

        public LogoAtt()
            : base(TYPE_LOGO, "", "")
        {
            Order = "徽标";
        }

        public override void SetDefault()
        {
        }

        public override string ToString()
        {
            return Data;
        }

        public string Path
        {
            get
            {
                return path;
            }
            set
            {
                path = value;
            }
        }
    }
}
