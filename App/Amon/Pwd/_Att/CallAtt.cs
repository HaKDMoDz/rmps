namespace Me.Amon.Pwd._Att
{
    public class CallAtt : Att
    {
        public const int SPEC_CALL_TYPE = 0;//电话类型
        public const int SPEC_CALL_FUNC = 1;//电话用途

        /// <summary>
        /// 电话
        /// </summary>
        public const string CALL_TYPE_TEL = "VOICE";
        /// <summary>
        /// 传真
        /// </summary>
        public const string CALL_TYPE_FAX = "FAX";

        /// <summary>
        /// 工作
        /// </summary>
        public const string CALL_FUNC_WORK = "WORK";
        /// <summary>
        /// 住宅
        /// </summary>
        public const string CALL_FUNC_HOME = "HOME";
        /// <summary>
        /// 单位
        /// </summary>
        public const string CALL_FUNC_COMPANY = "COMPANY";
        /// <summary>
        /// 移动
        /// </summary>
        public const string CALL_FUNC_CELL = "CELL";
        /// <summary>
        /// 助理
        /// </summary>
        public const string CALL_FUNC_ASSISTANT = "ASSISTANT";
        /// <summary>
        /// 车载
        /// </summary>
        public const string CALL_FUNC_CAR = "CAR";
        /// <summary>
        /// 回拨
        /// </summary>
        public const string CALL_FUNC_CALLBACK = "CALLBACK";
        /// <summary>
        /// 主要
        /// </summary>
        public const string CALL_FUNC_PREF = "PREF";
        /// <summary>
        /// 其它
        /// </summary>
        public const string CALL_FUNC_OTHER = "";
        /// <summary>
        /// 无线
        /// </summary>
        public const string CALL_FUNC_RADIO = "RADIO";
        /// <summary>
        /// 寻呼
        /// </summary>
        public const string CALL_FUNC_PAGER = "PAGER";
        /// <summary>
        /// ISDN
        /// </summary>
        public const string CALL_FUNC_ISDN = "ISDN";
        /// <summary>
        /// TTY/TTD
        /// </summary>
        public const string CALL_FUNC_TTYTDD = "TTYTDD";
        /// <summary>
        /// 电话（暂不支持）
        /// </summary>
        public const string CALL_FUNC_TLX = "TLX";

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

            for (int i = 0; i < _Spec.Length; i += 1)
            {
                _Spec[i] = SPEC_VALUE_NONE;
            }
        }
    }
}
