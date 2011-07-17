using System;
using System.IO;
using System.Text;
using System.Web;
using rmp.util;

namespace rmp.wrp.srch
{
    /// <summary>
    /// Summary description for Srch
    /// </summary>
    public class Srch
    {
        private static String TPLT_CODE;

        private Srch()
        {
        }

        /// <summary>
        /// 读取Script模板代码
        /// </summary>
        public static String TpltCode
        {
            get
            {
                if (TPLT_CODE == null)
                {
                    LoadData(true);
                }
                // 开发时使用，用于按原格式显示脚本内容。
                if (cons.EnvCons.NET_DEV)
                {
                    LoadData(false);
                }
                return TPLT_CODE;
            }
        }

        /// <summary>
        /// 读取文档数据
        /// </summary>
        /// <param name="trim">是否去除注释及空白字符</param>
        public static void LoadData(bool trim)
        {
            TPLT_CODE = "";
            if (trim)
            {
                StreamReader sr = File.OpenText(HttpContext.Current.Server.MapPath("~/srch/c/iSearcher.js"));
                TPLT_CODE = WrpUtil.TrimCode(sr);
                sr.Close();
            }
            else
            {
                TPLT_CODE = File.ReadAllText(HttpContext.Current.Server.MapPath("~/srch/c/iSearcher.js"), Encoding.UTF8);
            }
        }
    }
}