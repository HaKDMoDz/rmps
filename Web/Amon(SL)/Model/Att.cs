using System.Collections.Generic;
using System.Text;
using System.Xml;
using Me.Amon.Model.Atts;

namespace Me.Amon.Model
{
    public abstract class Att
    {
        #region 全局属性
        /// <summary>
        /// 显示排序
        /// </summary>
        public string Order { get; set; }

        /// <summary>
        /// 记录类别
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 记录名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 记录内容
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 专有内容
        /// </summary>
        protected List<string> ext;
        #endregion

        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        protected Att(int type)
            : this(type, "", "")
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        protected Att(int type, string name, string data)
        {
            Type = type;
            Name = name;
            Data = data;
            SetDefault();
        }
        #endregion

        #region 工厂方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Att GetInstance(int type)
        {
            switch (type)
            {
                case TYPE_TEXT:
                    return new TextAtt();
                case TYPE_PASS:
                    return new PassAtt();
                case TYPE_LINK:
                    return new LinkAtt();
                case TYPE_MAIL:
                    return new MailAtt();
                case TYPE_DATE:
                    return new DateAtt();
                case TYPE_DATA:
                    return new DataAtt();
                case TYPE_LIST:
                    return new ListAtt();
                case TYPE_AREA:
                    return new AreaAtt();
                case TYPE_FILE:
                    return new FileAtt();
                case TYPE_SIGN:
                    return new SignAtt();
                case TYPE_GUID:
                    return new GuidAtt();
                case TYPE_META:
                    return new MetaAtt();
                case TYPE_LOGO:
                    return new LogoAtt();
                case TYPE_HINT:
                    return new HintAtt();
                default:
                    return null;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Att GetInstance(int type, string name, string data)
        {
            Att item = GetInstance(type);
            if (item != null)
            {
                item.Name = name;
                item.Data = data;
            }
            return item;
        }
        #endregion

        #region 重载属性
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
        #endregion

        #region 附加信息
        /// <summary>
        /// 追加附加信息
        /// </summary>
        /// <param name="spec"></param>
        public void AddSpec(string spec)
        {
            this.ext.Add(spec);
        }

        /// <summary>
        /// 读取附加信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetSpec(int index)
        {
            return (index > -1 && index < ext.Count) ? ext[index] : null;
        }

        /// <summary>
        /// 读取附加信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public string GetSpec(int index, string defValue)
        {
            if (index > -1 && index < ext.Count)
            {
                string temp = ext[index];
                return temp != null ? temp : defValue;
            }
            return defValue;
        }

        /// <summary>
        /// 设置附加信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="spec"></param>
        public void SetSpec(int index, string spec)
        {
            if (index == this.ext.Count)
            {
                this.ext.Add(spec);
            }
            else
            {
                this.ext[index] = spec;
            }
        }

        /// <summary>
        /// 附加信息加密
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string EncodeSpec(char c)
        {
            if (ext == null || ext.Count < 1)
            {
                return "";
            }

            StringBuilder text = new StringBuilder();
            for (int i = 0, j = ext.Count; i < j; i += 1)
            {
                text.Append(c).Append(ext[i]);
            }
            return text.ToString();
        }

        /// <summary>
        /// 附加信息解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        public void DecodeSpec(string text, char c)
        {
            if (text == null || text.Length < 1)
            {
                return;
            }

            ext.Clear();

            int s = 0;
            int e = text.IndexOf(c, s);
            while (e >= s)
            {
                ext.Add(text.Substring(s, e - s));
                s = e + 1;
                e = text.IndexOf(c, s);
            }
        }
        #endregion

        #region 抽象方法
        /// <summary>
        /// 恢复默认值
        /// </summary>
        public abstract void SetDefault();
        /// <summary>
        /// 导出为TXT文件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public abstract bool ExportAsTxt(StringBuilder builder);
        /// <summary>
        /// 从TXT文件导入
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public abstract bool ImportByTxt(string txt);
        /// <summary>
        /// 导出为XML文件
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public abstract bool ExportAsXml(XmlWriter writer);
        /// <summary>
        /// 从XML文件导入
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public abstract bool ImportByXml(string xml);
        #endregion

        #region 公共方法
        /// <summary>
        /// 文本正向转义
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string DoEscape(string txt)
        {
            return txt != null ? txt.Replace("\\", "\\\\").Replace(",", "\\,").Replace(";", "\\;").Replace("\r\n", "\\n").Replace("\r", "\\n").Replace("\n", "\\n") : txt;
        }

        /// <summary>
        /// 文本反向转义
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string UnEscape(string txt)
        {
            return txt != null ? txt.Replace("\\n", "\n").Replace("\\;", ";").Replace("\\,", ",").Replace("\\\\", "\\") : txt;
        }
        #endregion

        #region 附加属性
        /// <summary>
        /// 附加属性常量
        /// </summary>
        public const string SPEC_VALUE_TRUE = "1";
        public const string SPEC_VALUE_FAIL = "0";
        public const string SPEC_VALUE_NONE = "";
        #endregion

        #region 属性类型
        /// <summary>
        /// 属性：信息0
        /// </summary>
        public const int TYPE_INFO = 0;
        /// <summary>
        /// 属性：文本1
        /// </summary>
        public const int TYPE_TEXT = TYPE_INFO + 1;
        /// <summary>
        /// 属性：口令2
        /// </summary>
        public const int TYPE_PASS = TYPE_TEXT + 1;
        /// <summary>
        /// 属性：链接3
        /// </summary>
        public const int TYPE_LINK = TYPE_PASS + 1;
        /// <summary>
        /// 属性：邮件4
        /// </summary>
        public const int TYPE_MAIL = TYPE_LINK + 1;
        /// <summary>
        /// 属性：日期5
        /// </summary>
        public const int TYPE_DATE = TYPE_MAIL + 1;
        /// <summary>
        /// 属性：数值6
        /// </summary>
        public const int TYPE_DATA = TYPE_DATE + 1;
        /// <summary>
        /// 属性：列表7
        /// </summary>
        public const int TYPE_LIST = TYPE_DATA + 1;
        /// <summary>
        /// 属性：附注8
        /// </summary>
        public const int TYPE_AREA = TYPE_LIST + 1;
        /// <summary>
        /// 属性：附件9
        /// </summary>
        public const int TYPE_FILE = TYPE_AREA + 1;
        /// <summary>
        /// 属性：分组10
        /// </summary>
        public const int TYPE_SIGN = TYPE_FILE + 1;
        /// <summary>
        /// 属性：模板向导
        /// </summary>
        public const int TYPE_GUID = TYPE_SIGN + 1;
        /// <summary>
        /// 属性：关键搜索
        /// </summary>
        public const int TYPE_META = TYPE_GUID + 1;
        /// <summary>
        /// 属性：口令图标
        /// </summary>
        public const int TYPE_LOGO = TYPE_META + 1;
        /// <summary>
        /// 属性：过期提示
        /// </summary>
        public const int TYPE_HINT = TYPE_LOGO + 1;
        /// <summary>
        /// 属性：组件个数
        /// </summary>
        public const int TYPE_SIZE = TYPE_HINT + 1;
        #endregion

        #region 分隔字符
        /// <summary>
        /// 数据分隔：模板数据起始默认标记
        /// 示例：&lt;电子邮件&gt;
        /// </summary>
        public const char SP_TPL_LS = '<';
        /// <summary>
        /// 数据分隔：模板数据结束默认标记
        /// 示例：&lt;电子邮件&gt;
        /// </summary>
        public const char SP_TPL_RS = '>';
        /// <summary>
        /// 同一元素键值区分标记
        /// </summary>
        public const char SP_SQL_KV = '\b';
        /// <summary>
        /// 不同元素间隔区分标记
        /// </summary>
        public const char SP_SQL_EE = '\f';
        #endregion

        #region 记录头部预留属性
        public const int PWDS_HEAD_GUID = 0;
        public const int PWDS_HEAD_META = PWDS_HEAD_GUID + 1;
        public const int PWDS_HEAD_LOGO = PWDS_HEAD_META + 1;
        public const int PWDS_HEAD_HINT = PWDS_HEAD_LOGO + 1;
        public const int HEAD_SIZE = PWDS_HEAD_HINT + 1;
        #endregion
    }
}
