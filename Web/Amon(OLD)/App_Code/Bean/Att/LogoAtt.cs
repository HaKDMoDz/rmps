namespace Me.Amon.Bean.Att
{
    public class LogoAtt : AAtt
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
