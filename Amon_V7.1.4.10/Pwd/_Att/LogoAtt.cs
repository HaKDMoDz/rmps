namespace Me.Amon.Pwd._Att
{
    public class LogoAtt : Att
    {
        public const int SPEC_LOGO_DIR = 0;// 字符空间索引

        public LogoAtt()
            : base(TYPE_LOGO, "", "")
        {
            Order = "徽标";
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[1];
            }

            _Spec[SPEC_LOGO_DIR] = ".";
        }

        public override string ToString()
        {
            return Data;
        }
    }
}
