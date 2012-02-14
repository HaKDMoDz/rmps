namespace Me.Amon.Model.Att
{
    public class GuidAtt : AAtt
    {
        public bool IsAppend { get; set; }

        public GuidAtt()
            : base(TYPE_GUID, "", "")
        {
            Order = "向导";
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[2];
            }

            _Spec[0] = SPEC_VALUE_FAIL;
            _Spec[1] = SPEC_VALUE_NONE;
        }

        public const int SPEC_GUID_TPLT = 0;// 口令模板索引
    }
}
