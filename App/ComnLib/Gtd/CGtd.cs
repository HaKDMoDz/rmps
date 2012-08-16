
namespace Me.Amon.Gtd
{
    public class CGtd
    {
        public const int GTD_TYPE_FIXTIME = 1;
        public const int GTD_TYPE_INTERVAL = 2;
        public const int GTD_TYPE_CYCLIST = 3;
        public const int GTD_TYPE_REPEAT = 4;
        public const int GTD_TYPE_FORMULA = 5;
        public const int GTD_TYPE_OTHER = 6;

        public const string GTD_UNIT_SECOND = "1";
        public const string GTD_UNIT_MINUTE = "2";
        public const string GTD_UNIT_HOUR = "3";
        public const string GTD_UNIT_DAY = "4";
        public const string GTD_UNIT_WEEK = "5";
        public const string GTD_UNIT_MONTH = "6";
        public const string GTD_UNIT_YEAR = "7";

        /// <summary>
        /// -2:异常、-1:过期、0满足、1未到
        /// </summary>
        public const int GTD_STAT_NORMAL = 1;
        public const int GTD_STAT_EXPIRED = 0;
        public const int GTD_STAT_OVERDUE = -1;
        public const int GTD_STAT_ERROR = -2;
    }
}
