namespace Me.Amon.Bean.Atts
{
    public class DataAtt : Att
    {
        public const int SPEC_OPT = 0;//可选输入
        public const int SPEC_SET = 1;//数据集
        public const int SPEC_DOT_INT = 2;//整数位
        public const int SPEC_DOT_DEC = 3;//小数位
        public const int SPEC_CHAR = 4;//特殊符号
        public const int SPEC_CHAR_OPT = 5;//是否可选
        public const int SPEC_CHAR_POS = 6;//符号位置
        public const int SPEC_EXP = 7;//表达式

        public DataAtt()
            : base(TYPE_DATA, "", "")
        {
        }

        public override void SetDefault()
        {
            if (_Spec == null)
            {
                _Spec = new string[8];
            }

            _Spec[0] = SPEC_VALUE_TRUE;
            _Spec[1] = "+0-";
            _Spec[2] = "0";
            _Spec[3] = "8";
            _Spec[4] = SPEC_VALUE_NONE;
            _Spec[5] = SPEC_VALUE_TRUE;
            _Spec[6] = "^";
            _Spec[7] = SPEC_VALUE_FAIL;
        }
    }
}
