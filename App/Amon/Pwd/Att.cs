using System.Text;
using System.Xml;
using Me.Amon.Pwd._Att;
using Me.Amon.Util;

namespace Me.Amon.Pwd
{
    public abstract class Att
    {
        #region 全局属性
        /// <summary>
        /// 显示排序
        /// </summary>
        public string Order { get; set; }
        /// <summary>
        /// 编辑状态
        /// </summary>
        public bool Modified { get; set; }

        /// <summary>
        /// 属性索引
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// 属性类别
        /// </summary>
        public int Type { get { return _Type; } set { _Type = value; _Spec = null; } }
        private int _Type;
        /// <summary>
        /// 属性键值
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 属性内容
        /// </summary>
        public string Data { get; set; }
        /// <summary>
        /// 专有内容
        /// </summary>
        protected string[] _Spec;
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
        /// <param name="text"></param>
        /// <param name="data"></param>
        protected Att(int type, string text, string data)
        {
            _Type = type;
            Text = text;
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
                case TYPE_CALL:
                    return new CallAtt();
                case TYPE_LIST:
                    return new ListAtt();
                case TYPE_MEMO:
                    return new MemoAtt();
                case TYPE_FILE:
                    return new FileAtt();
                case TYPE_LINE:
                    return new LineAtt();
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
        /// <param name="text"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Att GetInstance(int type, string text, string data)
        {
            Att item = GetInstance(type);
            if (item != null)
            {
                item.Text = text;
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
            return Text;
        }
        #endregion

        #region 附加信息
        /// <summary>
        /// 读取附加信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetSpec(int index)
        {
            return (index > -1 && index < _Spec.Length) ? _Spec[index] : null;
        }

        /// <summary>
        /// 读取附加信息
        /// </summary>
        /// <param name="index"></param>
        /// <param name="defValue"></param>
        /// <returns></returns>
        public string GetSpec(int index, string defValue)
        {
            if (index > -1 && index < _Spec.Length)
            {
                string temp = _Spec[index];
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
            if (index > -1 && index < _Spec.Length)
            {
                _Spec[index] = spec;
            }
        }

        /// <summary>
        /// 附加信息加密
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public string EncodeSpec(char c)
        {
            if (_Spec == null || _Spec.Length < 1)
            {
                return "";
            }

            StringBuilder text = new StringBuilder();
            foreach (string t in _Spec)
            {
                text.Append(t).Append(c);
            }
            return text.ToString();
        }

        /// <summary>
        /// 附加信息解密
        /// </summary>
        /// <param name="text"></param>
        /// <param name="c"></param>
        public void DecodeSpec(string[] arr, int off)
        {
            if (arr == null || arr.Length < off || _Spec == null)
            {
                return;
            }

            int i = arr.Length - 1 - off;
            if (i > _Spec.Length)
            {
                i = _Spec.Length;
            }
            while (i > 0)
            {
                i -= 1;
                _Spec[i] = arr[i + off];
            }
        }
        #endregion

        #region 抽象方法
        /// <summary>
        /// 恢复默认值
        /// </summary>
        public abstract void SetDefault();
        #endregion

        #region 公共方法
        #region 数据交换
        #region 数据导出
        /// <summary>
        /// 导出为TXT文件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public bool ExportAsTxt(StringBuilder buffer)
        {
            if (buffer == null)
            {
                return false;
            }
            buffer.Append(Type).Append(':').Append(Name ?? "").Append(',').Append(DoEscape(Text)).Append(',').Append(DoEscape(Data));

            if (_Spec != null)
            {
                foreach (string tmp in _Spec)
                {
                    buffer.Append(',').Append(DoEscape(tmp));
                }
            }
            buffer.Append(';');
            return true;
        }

        /// <summary>
        /// 导出为XML文件
        /// </summary>
        /// <param name="writer"></param>
        /// <returns></returns>
        public bool ExportAsXml(XmlWriter writer)
        {
            writer.WriteElementString("Type", Type.ToString());
            writer.WriteElementString("Name", Name);
            writer.WriteElementString("Text", Text);
            writer.WriteElementString("Data", Data);

            if (_Spec != null)
            {
                writer.WriteStartElement("Spec");
                //writer.WriteAttributeString("Count", _Spec.Length.ToString());
                for (int i = 0; i < _Spec.Length; i += 1)
                {
                    writer.WriteAttributeString("V" + i, _Spec[i]);
                }
                writer.WriteEndElement();
            }
            return true;
        }
        #endregion

        #region 数据导入
        /// <summary>
        /// 从TXT文件导入
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public bool ImportByTxt(string txt, string ver)
        {
            if (!CharUtil.IsValidate(txt))
            {
                return false;
            }

            string[] array = txt.Replace("\\,", "\f").Split(',');
            int i;
            switch (ver)
            {
                case "0":
                    i = ImportByTxt_0(array);
                    break;
                case "1":
                    i = ImportByTxt_1(array);
                    break;
                case "2":
                    i = ImportByTxt_2(array);
                    break;
                default:
                    return false;
            }

            if (_Spec != null)
            {
                int j = _Spec.Length + i;
                if (j > array.Length)
                {
                    j = array.Length;
                }
                while (j > i)
                {
                    j -= 1;
                    _Spec[j - i] = UnEscape(array[j].Replace("\f", "\\,"));
                }
            }
            return true;
        }

        /// <summary>
        /// 《魔方密码》数据导入
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private int ImportByTxt_0(string[] array)
        {
            int i = 0;
            if (array == null)
            {
                return i;
            }
            if (array.Length > 0)
            {
                Text = UnEscape(array[i++].Replace("\f", "\\,"));
            }
            if (array.Length > 1)
            {
                Data = UnEscape(array[i++].Replace("\f", "\\,"));
            }
            return i;
        }

        private int ImportByTxt_1(string[] array)
        {
            int i = 0;
            if (array != null && array.Length > 1)
            {
                Text = UnEscape(array[i++].Replace("\f", "\\,"));
                Data = UnEscape(array[i++].Replace("\f", "\\,"));
            }
            return i;
        }

        private int ImportByTxt_2(string[] array)
        {
            int i = 0;
            if (array != null && array.Length > 2)
            {
                Name = UnEscape(array[i++].Replace("\f", "\\,"));
                Text = UnEscape(array[i++].Replace("\f", "\\,"));
                Data = UnEscape(array[i++].Replace("\f", "\\,"));
            }
            return i;
        }

        /// <summary>
        /// 从XML文件导入
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public bool ImportByXml(XmlReader reader, string ver)
        {
            //if (reader.Name == "Type")
            //{
            //    Type = reader.ReadElementContentAsInt();
            //}

            switch (ver)
            {
                case "1":
                    ImportByXml_1(reader);
                    break;
                case "2":
                    ImportByXml_2(reader);
                    break;
                default:
                    return false;
            }

            if (reader.Name == "Spec")
            {
                int cnt = reader.AttributeCount;
                if (cnt > 0)
                {
                    _Spec = new string[cnt];
                    for (int i = 0; i < cnt; i += 1)
                    {
                        reader.MoveToAttribute("V" + i);
                        _Spec[i] = reader.ReadContentAsString();
                    }
                }
            }
            return true;
        }

        private bool ImportByXml_1(XmlReader reader)
        {
            if (reader.Name == "Name")
            {
                Text = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Data")
            {
                Data = reader.ReadElementContentAsString();
            }
            return true;
        }

        private bool ImportByXml_2(XmlReader reader)
        {
            if (reader.Name == "Name")
            {
                Name = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Text")
            {
                Text = reader.ReadElementContentAsString();
            }
            if (reader.Name == "Data")
            {
                Data = reader.ReadElementContentAsString();
            }
            return true;
        }
        #endregion
        #endregion

        #region 文本转换
        /// <summary>
        /// 文本正向转义
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string DoEscape(string txt)
        {
            return txt != null ? txt.Replace("\\", "\\\\").Replace(",", "\\,").Replace(";", "\\;").Replace("\r\n", "\\n").Replace("\r", "\\n").Replace("\n", "\\n") : "";
        }

        /// <summary>
        /// 文本反向转义
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string UnEscape(string txt)
        {
            return txt != null ? txt.Replace("\\n", "\n").Replace("\\;", ";").Replace("\\,", ",").Replace("\\\\", "\\") : "";
        }
        #endregion
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
        /// 属性：电话7
        /// </summary>
        public const int TYPE_CALL = TYPE_DATA + 1;
        /// <summary>
        /// 属性：列表8
        /// </summary>
        public const int TYPE_LIST = TYPE_CALL + 1;
        /// <summary>
        /// 属性：附注9
        /// </summary>
        public const int TYPE_MEMO = TYPE_LIST + 1;
        /// <summary>
        /// 属性：文件10
        /// </summary>
        public const int TYPE_FILE = TYPE_MEMO + 1;
        /// <summary>
        /// 属性：分组11
        /// </summary>
        public const int TYPE_LINE = TYPE_FILE + 1;
        /// <summary>
        /// 属性：模板向导12
        /// </summary>
        public const int TYPE_GUID = TYPE_LINE + 1;
        /// <summary>
        /// 属性：关键搜索13
        /// </summary>
        public const int TYPE_META = TYPE_GUID + 1;
        /// <summary>
        /// 属性：口令图标14
        /// </summary>
        public const int TYPE_LOGO = TYPE_META + 1;
        /// <summary>
        /// 属性：过期提示15
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
