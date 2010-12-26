using System;
using System.Text.RegularExpressions;

namespace rmp.wrp.code
{
    public class CodeCss
    {
        public const int STYLE_NORMAL = 0;
        public const int STYLE_BOLD = 1;
        public const int STYLE_ITALIC = 2;
        public const int STYLE_UNDER_LINE = 4;
        public const int STYLE_STROKE = 8;
        public const int STYLE_OVER_LINE = 16;

        /// <summary>
        /// 显示排序
        /// </summary>
        public String W2050201;
        /// <summary>
        /// 风格索引
        /// </summary>
        public String W2050202;
        /// <summary>
        /// 语言索引
        /// </summary>
        public String W2050203;
        /// <summary>
        /// 所属语言
        /// </summary>
        public CodeCat codeCat;
        /// <summary>
        /// 风格名称
        /// </summary>
        public String W2050204;
        /// <summary>
        /// 样式名称
        /// </summary>
        public String W2050205;
        /// <summary>
        /// 背景颜色
        /// </summary>
        public String W2050206;
        /// <summary>
        /// 前景颜色
        /// </summary>
        public String W2050207;
        /// <summary>
        /// 字体名称
        /// </summary>
        public String W2050208;
        /// <summary>
        /// 字体大小
        /// </summary>
        public String W2050209;
        /// <summary>
        /// 字体风格（正常、粗体、斜体、下划线、删除线）
        /// </summary>
        public int W205020A;
        /// <summary>
        /// 备注信息
        /// </summary>
        public String W205020B;

        public CodeCss()
        {
            SetDefault();
        }

        public void SetDefault()
        {
            W2050206 = null;
            W2050207 = "#0000C0";
            W2050208 = null;
            W2050209 = "12px";
            W205020A = STYLE_NORMAL;
        }

        public CodeCat CodeCat
        {
            get { return codeCat; }
            set { codeCat = value; }
        }

        public bool IsValidateBgColor()
        {
            return W2050206 != null && Regex.IsMatch(W2050206, "^[#][0-9a-zA-Z]{6}$");
        }

        public bool IsValidateFgColor()
        {
            return W2050207 != null && Regex.IsMatch(W2050207, "^[#][0-9a-zA-Z]{6}$");
        }
    }
}
