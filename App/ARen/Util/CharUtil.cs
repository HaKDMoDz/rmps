using System.Text.RegularExpressions;

namespace Me.Amon.Util
{
    /// <summary>
    /// CharUtil 的摘要说明
    /// </summary>
    public class CharUtil
    {
        private CharUtil()
        {
        }

        #region 字符判断
        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidate(string value)
        {
            return (value != null && value.Trim().Length > 0);
        }

        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="fix"></param>
        /// <returns></returns>
        public static bool IsValidate(string value, int fix)
        {
            return (value != null && value.Trim().Length == fix);
        }

        /// <summary>
        /// 判断一个字符串是否为有效字符串
        /// </summary>
        /// <param name="value"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static bool IsValidate(string value, int min, int max)
        {
            if (value != null)
            {
                value = value.Trim();
                return value.Length >= min && value.Length <= max;
            }
            return false;
        }

        public static bool IsValidateCall(string call)
        {
            return call != null ? Regex.IsMatch(call, "^([+]?\\d{2,3}[^\\d]+)?0?((\\d{11})|(\\d{2,3}[^\\d]+)?\\d{7,8}([^\\d]+\\d{1,})?)$") : false;
        }

        /// <summary>
        /// 判断是否为合法的用户代码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsValidateCode(string code)
        {
            return code != null ? Regex.IsMatch(code, "^[0-9A-Za-z]{8}$") : false;
        }

        /// <summary>
        /// 判断是否为合法的数据主键
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool IsValidateHash(string hash)
        {
            return hash != null ? Regex.IsMatch(hash, "^[0-9A-Za-z]{16}$") : false;
        }

        /// <summary>
        /// 判断是否为合法的整形数值
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsValidateLong(string text)
        {
            return text != null ? Regex.IsMatch(text, "^[-+]?\\d+$") : false;
        }

        public static bool IsValidateMail(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "^[-.\\w]+@[-\\w]+([.][-\\w]+)+$");
        }

        public static bool IsValidateDate(string text, bool formatOnly)
        {
            if (text == null)
            {
                return false;
            }
            if (formatOnly)
            {
                return Regex.IsMatch(text, "(^[1-9][0-9]{0,3}[-\\/\\._](0[1-9]|1[012])[-\\/\\._](0[1-9]|[12][0-9]|3[01])$)");
            }
            return Regex.IsMatch(text, "((^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/\\._])(10|12|0?[13578])([-\\/\\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/\\._])(11|0?[469])([-\\/\\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\\d{2})|([2-9]\\d{3}))([-\\/\\._])(0?2)([-\\/\\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([3579][26]00)([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([1][89][0][48])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([2-9][0-9][0][48])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([1][89][2468][048])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([2-9][0-9][2468][048])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([1][89][13579][26])([-\\/\\._])(0?2)([-\\/\\._])(29)$)|(^([2-9][0-9][13579][26])([-\\/\\._])(0?2)([-\\/\\._])(29)$))");
        }

        public static bool IsValidateTime(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "(^([01][0-9]|2[0-3])[:\\.]([0-5][0-9])[:\\.]([0-5][0-9])$)");
        }

        public static bool IsValidateDateTime(string text)
        {
            if (text == null)
            {
                return false;
            }
            return Regex.IsMatch(text, "^[1-9][0-9]{0,3}[-\\/\\._](0[1-9]|1[012])[-\\/\\._](0[1-9]|[12][0-9]|3[01]) ([01][0-9]|2[0-3])[:\\.]([0-5][0-9])[:\\.]([0-5][0-9])$");
        }

        /// <summary>
        /// 判断是否为合法的用户名称
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool IsValidateName(string name)
        {
            return name != null ? Regex.IsMatch(name, "^\\w+[\\w\\d\\.]{3,31}$") : false;
        }

        public static bool IsValidateURL(string name)
        {
            return name != null ? Regex.IsMatch(name, "^[a-zA-z]{2,}:/{2,3}[^\\s]+") : false;
        }

        /// <summary>
        /// 图标路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static bool IsValidatePath(string path)
        {
            return path != null ? Regex.IsMatch(path, "^[A-Za-z]{4},([0-9]{4},[0-9A-Za-z]{16}|_[A-Z]{3})$") : false;
        }

        public static bool IsValidateNegative(string text)
        {
            return true;
        }

        public static bool IsValidatePositive(string text)
        {
            return true;
        }

        public static bool IsValidateDecimal(string text)
        {
            return true;
        }
        #endregion
    }
}
