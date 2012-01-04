using System;
using System.Security.Cryptography;
using System.Text;

namespace rmp.comn.user
{
    /// <summary>
    /// UserInfo 的摘要说明
    /// </summary>
    public class UserInfo
    {
        #region
        /// <summary>
        /// 默认联系方式
        /// </summary>
        public const int MAJOR_00 = 0;
        /// <summary>
        /// 一般联系方式
        /// </summary>
        public const int MAJOR_01 = 1;
        /// <summary>
        /// 重要联系方式
        /// </summary>
        public const int MAJOR_02 = 2;
        /// <summary>
        /// 备选联系方式
        /// </summary>
        public const int MAJOR_03 = 3;
        /// <summary>
        /// 首选联系方式
        /// </summary>
        public const int MAJOR_04 = 4;

        /// <summary>
        /// 游客
        /// </summary>
        public const int LEVEL_00 = 0;
        /// <summary>
        /// 匿名用户
        /// </summary>
        public const int LEVEL_01 = 1;
        /// <summary>
        /// 一般用户
        /// </summary>
        public const int LEVEL_02 = 2;
        /// <summary>
        /// 高级用户
        /// </summary>
        public const int LEVEL_03 = 3;
        /// <summary>
        /// 专用用户
        /// </summary>
        public const int LEVEL_04 = 4;
        /// <summary>
        /// 客服用户
        /// </summary>
        public const int LEVEL_05 = 5;
        /// <summary>
        /// 网站管理员
        /// </summary>
        public const int LEVEL_06 = 6;
        /// <summary>
        /// 数据库管理员
        /// </summary>
        public const int LEVEL_07 = 7;
        /// <summary>
        /// 超级用户
        /// </summary>
        public const int LEVEL_08 = 8;
        /// <summary>
        /// 系统管理员
        /// </summary>
        public const int LEVEL_09 = 9;
        #endregion

        #region
        /// <summary>
        /// 系统共用用户代码
        /// </summary>
        public const string COMN_CODE = "A0000000";
        /// <summary>
        /// 系统演示用户代码
        /// </summary>
        public const string DEMO_CODE = "A0000001";
        /// <summary>
        /// 系统测试用户代码
        /// </summary>
        public const string TEST_CODE = "A0000002";
        #endregion

        private int userRank = LEVEL_00;
        private string userHash = "";
        private string userCode = "A0000000";
        private string userName = "用户";
        private string userMail = "user@amonsoft.cn";

        private UserInfo()
        {
        }

        public int UserRank
        {
            get
            {
                return userRank;
            }
        }

        public string UserHash
        {
            get
            {
                return userHash;
            }
        }

        public string UserCode
        {
            get
            {
                return userCode;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }
        }

        public string UserMail
        {
            get
            {
                return userMail;
            }
        }

        public string UserRole
        {
            get
            {
                switch (UserRank)
                {
                    case LEVEL_00:
                        return "游客";
                    case LEVEL_01:
                        return "匿名用户";
                    case LEVEL_02:
                        return "一般用户";
                    case LEVEL_03:
                        return "高级用户";
                    case LEVEL_04:
                        return "专用用户";
                    case LEVEL_05:
                        return "客服用户";
                    case LEVEL_06:
                        return "网站管理员";
                    case LEVEL_07:
                        return "数据库管理员";
                    case LEVEL_08:
                        return "超级用户";
                    case LEVEL_09:
                        return "系统管理员";
                    default:
                        return "";
                }
            }
        }
    }
}