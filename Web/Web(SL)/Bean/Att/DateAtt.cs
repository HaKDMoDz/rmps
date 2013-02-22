namespace Me.Amon.Bean.Att
{
    public class DateAtt : AAtt
    {
        public const int SPEC_FORMAT = 0;// 日期显示格式

        public DateAtt()
            : base(TYPE_DATE, "", "")
        {
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[1];
            }

            _Spec[0] = SPEC_VALUE_NONE;
        }
    }
}
