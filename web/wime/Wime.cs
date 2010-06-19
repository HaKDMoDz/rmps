using System;
using System.IO;
using System.Text;
using System.Web;
using cons;

namespace rmp.wrp.wime
{
    /// <summary>
    /// Summary description for Wime
    /// </summary>
    public class Wime
    {
        private static String TPLT_WIME;
        private static string DICT_WB86;
        private static string DICT_WB89;
        private static string DICT_ZNPY;

        private Wime()
        {
        }

        public static String TpltWime
        {
            get
            {
                if (TPLT_WIME == null)
                {
                    LoadData(true);
                }
                // 开发时使用，用于按原格式显示脚本内容。
                if (EnvCons.NET_DEV)
                {
                    LoadData(false);
                }
                return TPLT_WIME;
            }
        }

        /// <summary>
        /// 五笔86
        /// </summary>
        /// <param name="load"></param>
        /// <returns></returns>
        public static String DictWb86(bool load)
        {
            if (load || String.IsNullOrEmpty(DICT_WB86))
            {
                DICT_WB86 = File.ReadAllText(HttpContext.Current.Server.MapPath("~/wime/c/wb86.js"));
            }
            return DICT_WB86;
        }

        /// <summary>
        /// 五笔89
        /// </summary>
        /// <param name="load"></param>
        /// <returns></returns>
        public static String DictWb89(bool load)
        {
            if (load || String.IsNullOrEmpty(DICT_WB89))
            {
                DICT_WB89 = File.ReadAllText(HttpContext.Current.Server.MapPath("~/wime/c/wb89.js"));
            }
            return DICT_WB89;
        }

        /// <summary>
        /// 智能拼音
        /// </summary>
        /// <param name="load"></param>
        /// <returns></returns>
        public static String DictZnpy(bool load)
        {
            if (load || String.IsNullOrEmpty(DICT_ZNPY))
            {
                DICT_ZNPY = File.ReadAllText(HttpContext.Current.Server.MapPath("~/wime/c/znpy.js"));
            }
            return DICT_ZNPY;
        }

        /// <summary>
        /// 读取文档数据
        /// </summary>
        /// <param name="trim">是否去除注释及空白字符</param>
        public static void LoadData(bool trim)
        {
            String path = HttpContext.Current.Server.MapPath("~/wime/c/wime.js");
            if (trim)
            {
                StreamReader sr = File.OpenText(path);
                StringBuilder sb = new StringBuilder();
                String line;
                bool inComment = false;
                bool copyRight = false;
                while (true)
                {
                    line = sr.ReadLine();

                    // 文档结束
                    if (line == null)
                    {
                        break;
                    }

                    // 文档注释开始
                    if (line.StartsWith("/***"))
                    {
                        copyRight = true;
                    }

                    // 多行注释中
                    if (copyRight)
                    {
                        // 多行注释结束
                        if (line.EndsWith("***/"))
                        {
                            copyRight = false;
                        }
                        sb.Append(line).Append("\n");
                        continue;
                    }

                    // 空行
                    line = line.Trim();
                    if (line == "")
                    {
                        continue;
                    }

                    // 单行注释
                    if (line.StartsWith("//"))
                    {
                        continue;
                    }

                    // 多行注释开始
                    if (line.StartsWith("/*"))
                    {
                        inComment = true;
                    }

                    // 多行注释中
                    if (inComment)
                    {
                        // 多行注释结束
                        if (line.EndsWith("*/"))
                        {
                            inComment = false;
                        }
                        continue;
                    }

                    sb.Append(line);
                }
                sr.Close();
                TPLT_WIME = sb.ToString();
            }
            else
            {
                TPLT_WIME = File.ReadAllText(path, Encoding.UTF8);
            }
        }
    }
}