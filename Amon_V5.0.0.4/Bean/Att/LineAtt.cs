namespace Me.Amon.Bean.Att
{
    public class LineAtt : AAtt
    {
        public const int SPEC_LINE_TYPE = 0;//控制类型
        public const int SPEC_LINE_TPLT = 1;//显示模板

        public LineAtt()
            : base(TYPE_LINE, "", "")
        {
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[2];
            }

            _Spec[0] = "def";
            _Spec[1] = "P30F7E02";
        }
    }
}
