namespace Me.Amon.Pwd._Att
{
    public class CallAtt : Att
    {
        public const int SPEC_CALL_CAT1 = 0;//控制类型
        public const int SPEC_CALL_CAT2 = 1;//显示模板

        public CallAtt()
            : base(TYPE_CALL, "", "")
        {
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[2];
            }
        }
    }
}
