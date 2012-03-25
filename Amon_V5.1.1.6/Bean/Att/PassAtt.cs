namespace Me.Amon.Bean.Att
{
    public class PassAtt : AAtt
    {
        public const int SPEC_PWDS_KEY = 0;// 字符空间索引
        public const int SPEC_PWDS_LEN = 1;// 生成口令长度
        public const int SPEC_PWDS_REP = 2;// 是否允许重复

        public PassAtt()
            : base(TYPE_PASS, "", "")
        {
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[3];
            }

            for (int i = 0; i < _Spec.Length; i += 1)
            {
                _Spec[i] = SPEC_VALUE_NONE;
            }
        }
    }
}
