using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Me.Amon.Util;

namespace Me.Amon.Ce
{
    /// <summary>
    /// \/:*?"<b>|
    /// : 数字
    /// | 字母
    /// <b> 区间
    /// * 文件名 *&lt;&gt;替换
    /// ? 后缀名 ?&lt;&gt;替换
    /// " 原有字符
    /// \ 大写 \*大写文件名 \?大写后缀名 \"大写字母 \:创建时间
    /// / 小写 /*小写文件名 /?小写后缀名 /"小写字母 /:修改时间
    /// </summary>
    public class Renamer
    {
        #region 交互时展示字符
        private const char NUMBER = ':';
        private const char CHARACTER = '|';
        private const char FILE_NAME = '*';
        private const char FILE_EXT = '?';
        private const char ORIGIN = '"';
        private const char ENUM_START = '<';
        private const char ENUM_END = '>';
        private const char CTL_LOWER = '/';
        private const char CTL_UPPER = '\\';
        #endregion

        #region 处理时替代字符
        private const char TMP_ESCAPE = '\u0000';
        /// <summary>
        /// 文件名小写
        /// </summary>
        private const char TMP_FILE_NAME_LOWER = '\u0001';
        /// <summary>
        /// 文件名大写
        /// </summary>
        private const char TMP_FILE_NAME_UPPER = '\u0002';
        /// <summary>
        /// 扩展名小写
        /// </summary>
        private const char TMP_FILE_EXT_LOWER = '\u0003';
        /// <summary>
        /// 扩展名大写
        /// </summary>
        private const char TMP_FILE_EXT_UPPER = '\u0004';
        /// <summary>
        /// 原字符小写
        /// </summary>
        private const char TMP_ORIGIN_LOWER = '\u0005';
        /// <summary>
        /// 原字符大写
        /// </summary>
        private const char TMP_ORIGIN_UPPER = '\u0006';
        /// <summary>
        /// 创建时间
        /// </summary>
        private const char TMP_CREATE_TIME = '\u0007';
        /// <summary>
        /// 更新时间
        /// </summary>
        private const char TMP_UPDATE_TIME = '\u0008';
        private const char TMP_TRIM = '\u0009';
        private const char TMP_HOLD = '\u000A';
        #endregion

        /// <summary>
        /// 公式异常信息
        /// </summary>
        public string Error { get; set; }

        /// <summary>
        /// 用户自定义字符
        /// </summary>
        private List<Udc> _UdcList;
        /// <summary>
        /// 用户自定义数值
        /// </summary>
        private List<Udn> _UdnList;
        /// <summary>
        /// 替换字符集
        /// </summary>
        private List<Rpl> _RplList;
        /// <summary>
        /// 裁剪字符集
        /// </summary>
        private List<Cut> _CutList;
        /// <summary>
        /// 时间格式
        /// </summary>
        private List<string> _FmtList;
        /// <summary>
        /// 重命名公式
        /// </summary>
        private string _Command;

        private bool _Enough;

        /// <summary>
        /// 当前处理索引
        /// </summary>
        private int Index;
        private StringBuilder _Buffer;

        #region 构造函数
        public Renamer()
        {
            _Buffer = new StringBuilder();
            _UdcList = new List<Udc>();
            _UdnList = new List<Udn>();
            _RplList = new List<Rpl>();
            _CutList = new List<Cut>();
            _FmtList = new List<string>();
        }
        #endregion

        #region 解析
        public bool Init(string cmd)
        {
            _Enough = false;
            _UdcList.Clear();
            _UdnList.Clear();
            _RplList.Clear();
            _FmtList.Clear();
            _CutList.Clear();

            _Buffer.Clear();

            Index = 0;
            char c;
            while (Index < cmd.Length)
            {
                c = cmd[Index];
                // 大写控制处理
                if (c == CTL_UPPER)
                {
                    Index += 1;
                    if (!DecodeCtl(cmd))
                    {
                        return false;
                    }
                    continue;
                }
                // 小写控制处理
                if (c == CTL_LOWER)
                {
                    Index += 1;
                    if (!DecodeCtr(cmd))
                    {
                        return false;
                    }
                    continue;
                }
                // 文件名
                if (c == FILE_NAME)
                {
                    _Buffer.Append(c);
                    Index += 1;
                    if (!DecodeRpl(cmd))
                    {
                        return false;
                    }
                    continue;
                }
                // 扩展名
                if (c == FILE_EXT)
                {
                    _Buffer.Append(c);
                    Index += 1;
                    if (!DecodeRpl(cmd))
                    {
                        return false;
                    }
                    continue;
                }
                // 字符处理
                if (c == CHARACTER)
                {
                    _Buffer.Append(c);
                    Index += 1;
                    if (!DecodeUdc(cmd))
                    {
                        return false;
                    }
                    continue;
                }
                // 数值处理
                if (c == NUMBER)
                {
                    _Buffer.Append(c);
                    Index += 1;
                    if (!DecodeUdn(cmd))
                    {
                        return false;
                    }
                    continue;
                }
                // 替换
                if (c == ENUM_START || c == ENUM_END)
                {
                    Error = "无效的枚举字符：" + c + " @" + Index;
                    return false;
                }
                _Buffer.Append(c);
                Index += 1;
            }
            _Command = _Buffer.ToString();

            _Enough = true;
            return true;
        }

        /// <summary>
        /// 反向控制信息
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeCtl(string cmd)
        {
            if (NUMBER == cmd[Index])
            {
                _Buffer.Append(TMP_CREATE_TIME);
                Index += 1;
                return DecodeFmt(cmd);
            }
            if (CHARACTER == cmd[Index])
            {
                _Buffer.Append(TMP_HOLD);
                Index += 1;
                return DecodeCut(cmd);
            }
            if (FILE_NAME == cmd[Index])
            {
                _Buffer.Append(TMP_FILE_NAME_UPPER);
                Index += 1;
                return DecodeRpl(cmd);
            }
            if (FILE_EXT == cmd[Index])
            {
                _Buffer.Append(TMP_FILE_EXT_UPPER);
                Index += 1;
                return DecodeRpl(cmd);
            }
            if (ORIGIN == cmd[Index])
            {
                _Buffer.Append(TMP_ORIGIN_UPPER);
                Index += 1;
                return true;
            }

            Error = "未知的转义字符：\\" + cmd[Index];
            return false;
        }

        /// <summary>
        /// 正向控制信息
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeCtr(string cmd)
        {
            if (NUMBER == cmd[Index])
            {
                _Buffer.Append(TMP_UPDATE_TIME);
                Index += 1;
                return DecodeFmt(cmd);
            }
            if (CHARACTER == cmd[Index])
            {
                _Buffer.Append(TMP_TRIM);
                Index += 1;
                return DecodeCut(cmd);
            }
            if (FILE_NAME == cmd[Index])
            {
                _Buffer.Append(TMP_FILE_NAME_LOWER);
                Index += 1;
                return DecodeRpl(cmd);
            }
            if (FILE_EXT == cmd[Index])
            {
                _Buffer.Append(TMP_FILE_EXT_LOWER);
                Index += 1;
                return DecodeRpl(cmd);
            }
            if (ORIGIN == cmd[Index])
            {
                _Buffer.Append(TMP_ORIGIN_LOWER);
                Index += 1;
                return true;
            }

            Error = "未知的转义字符：/" + cmd[Index];
            return false;
        }

        /// <summary>
        /// 用户自定义字符
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeUdc(string cmd)
        {
            StringBuilder buffer = new StringBuilder();
            if (!DecodeEnum(cmd, buffer, NUMBER))
            {
                return false;
            }

            Udc udc = new Udc();
            string tmp = buffer.Length < 1 ? "ABCDEFGHIJKLMNOPQRSTUVWXYZ" : buffer.ToString().Trim(NUMBER);
            if (tmp.IndexOf(NUMBER) < 0)
            {
                udc.Array = new string[tmp.Length];
                for (int i = 0; i < tmp.Length; i += 1)
                {
                    udc.Array[i] = "" + tmp[i];
                }
            }
            else
            {
                udc.Array = tmp.Split(NUMBER);
            }
            _UdcList.Add(udc);
            return true;
        }

        /// <summary>
        /// 用户自定义数值
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeUdn(string cmd)
        {
            StringBuilder buffer = new StringBuilder();
            if (!DecodeEnum(cmd, buffer, TMP_ESCAPE))
            {
                return false;
            }

            Udn udn = new Udn { Start = 1, Step = 1, Fixed = 0, Char = '0' };
            if (buffer.Length < 1)
            {
                _UdnList.Add(udn);
                return true;
            }

            string[] arr = buffer.ToString().Split(',');
            string tmp = arr[0];
            if (!CharUtil.IsValidateLong(tmp))
            {
                Error = "无效的起始值：" + tmp;
                return false;
            }
            udn.Start = int.Parse(tmp);
            if (arr.Length < 2)
            {
                _UdnList.Add(udn);
                return true;
            }

            tmp = arr[1];
            if (!CharUtil.IsValidateLong(tmp))
            {
                Error = "无效的步增量：" + tmp;
                return false;
            }
            udn.Step = int.Parse(tmp);
            if (udn.Step == 0)
            {
                Error = "步增量不能为0！";
                return false;
            }
            if (arr.Length < 3)
            {
                _UdnList.Add(udn);
                return true;
            }

            tmp = arr[2];
            if (!CharUtil.IsValidateLong(tmp))
            {
                Error = "无效的填充长度：" + tmp;
                return false;
            }
            udn.Fixed = int.Parse(tmp);
            if (udn.Fixed < 0)
            {
                Error = "填充长度不能为负值！";
                return false;
            }
            if (arr.Length < 4)
            {
                _UdnList.Add(udn);
                return true;
            }

            tmp = arr[3];
            if (string.IsNullOrEmpty(tmp))
            {
                Error = "无效的填充字符！";
                return false;
            }
            if (tmp.Length != 1)
            {
                Error = "仅允许一个填充字符！";
                return false;
            }
            udn.Char = tmp[0];
            _UdnList.Add(udn);
            return true;
        }

        /// <summary>
        /// 字符替换
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeRpl(string cmd)
        {
            StringBuilder buffer = new StringBuilder();
            if (!DecodeEnum(cmd, buffer, NUMBER))
            {
                return false;
            }

            Rpl rpl = new Rpl { Src = "", Dst = "" };
            if (buffer.Length < 1)
            {
                _RplList.Add(rpl);
                return true;
            }

            string[] arr = buffer.ToString().Split(NUMBER);
            rpl.Src = arr[0];
            if (arr.Length < 2)
            {
                _RplList.Add(rpl);
                return true;
            }

            rpl.Dst = arr[1];
            if (arr.Length < 3)
            {
                _RplList.Add(rpl);
                return true;
            }

            Error = "无效的替换信息！";
            return false;
        }

        /// <summary>
        /// 时间格式
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeFmt(string cmd)
        {
            StringBuilder buffer = new StringBuilder();
            if (!DecodeEnum(cmd, buffer, TMP_ESCAPE))
            {
                return false;
            }

            if (buffer.Length < 1)
            {
                _FmtList.Add("yyyyMMddHHmmss");
            }
            else
            {
                _FmtList.Add(buffer.ToString());
            }
            return true;
        }

        /// <summary>
        /// 字符裁剪
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private bool DecodeCut(string cmd)
        {
            StringBuilder buffer = new StringBuilder();
            if (!DecodeEnum(cmd, buffer, NUMBER))
            {
                return false;
            }

            if (buffer.Length < 1)
            {
                Error = "无效的起始索引及长度数值！";
                return false;
            }

            string[] arr = buffer.ToString().Split(NUMBER);
            Cut cut = new Cut();
            string tmp;
            if (arr.Length > 0)
            {
                tmp = arr[0];
                if (!CharUtil.IsValidateLong(tmp))
                {
                    Error = "无效的起始索引：" + tmp;
                    return false;
                }
                cut.Start = int.Parse(tmp);
                if (cut.Start == 0)
                {
                    Error = "起始索引不能为 0！";
                    return false;
                }
            }
            if (arr.Length > 1)
            {
                tmp = arr[1];
                if (!string.IsNullOrWhiteSpace(tmp))
                {
                    if (!CharUtil.IsValidateLong(tmp))
                    {
                        Error = "无效的长度数值：" + tmp;
                        return false;
                    }
                    cut.Count = int.Parse(tmp);
                }
            }
            _CutList.Add(cut);
            return true;
        }

        /// <summary>
        /// 枚举信息读取
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        private bool DecodeEnum(string cmd, StringBuilder buffer, char escape)
        {
            if (Index >= cmd.Length || cmd[Index] != ENUM_START)
            {
                return true;
            }
            Index += 1;

            char c;
            bool e = false;
            while (Index < cmd.Length)
            {
                c = cmd[Index];
                if (c == ENUM_END)
                {
                    Index += 1;
                    e = true;
                    break;
                }

                if (c != escape)
                {
                    if (c == CHARACTER || c == NUMBER || c == FILE_NAME || c == FILE_EXT || c == CTL_LOWER || c == CTL_UPPER || c == ORIGIN)
                    {
                        Error = "枚举中不应包含:|*?\"<>\\/等特殊字符！";
                        return false;
                    }
                }

                buffer.Append(c);
                Index += 1;
            }
            if (!e)
            {
                Error = "缺少枚举结束控制！";
                return false;
            }
            if (buffer.Length < 1)
            {
                Error = "枚举内容不能为空！";
                return false;
            }
            return true;
        }
        #endregion

        #region 生成
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public string Update(string filePath)
        {
            if (!_Enough)
            {
                Error = "长度不足！";
                return "";
            }

            string name = Path.GetFileNameWithoutExtension(filePath);
            if (string.IsNullOrEmpty(name))
            {
                Error = "无效的文件信息：" + filePath;
                return "";
            }

            _Buffer.Clear();

            string exts = Path.GetExtension(filePath);
            if (!string.IsNullOrEmpty(exts))
            {
                exts = exts.Substring(1);
            }

            int si = 0;// 引用变量索引
            int ci = 0;// 字符变量索引
            int ni = 0;// 数值变量索引
            int ri = 0;// 替换变量索引
            int ti = 0;// 时间变量索引
            int ui = 0;// 裁剪
            for (int i = 0; i < _Command.Length; i += 1)
            {
                char c = _Command[i];
                if (c == FILE_NAME)
                {
                    _Buffer.Append(Replace(name, ri++));
                    continue;
                }
                if (c == TMP_FILE_NAME_LOWER)
                {
                    _Buffer.Append(Replace(name.ToLower(), ri++));
                    continue;
                }
                if (c == TMP_FILE_NAME_UPPER)
                {
                    _Buffer.Append(Replace(name.ToUpper(), ri++));
                    continue;
                }
                if (c == FILE_EXT)
                {
                    _Buffer.Append(Replace(exts, ri++));
                    continue;
                }
                if (c == TMP_FILE_EXT_LOWER)
                {
                    _Buffer.Append(Replace(exts.ToLower(), ri++));
                    continue;
                }
                if (c == TMP_FILE_EXT_UPPER)
                {
                    _Buffer.Append(Replace(exts.ToUpper(), ri++));
                    continue;
                }
                if (c == ORIGIN)
                {
                    if (si >= name.Length)
                    {
                        continue;
                    }
                    _Buffer.Append(name[si++]);
                    continue;
                }
                if (c == TMP_ORIGIN_LOWER)
                {
                    if (i >= name.Length)
                    {
                        continue;
                    }
                    _Buffer.Append(Char.ToLower(name[i]));
                    continue;
                }
                if (c == TMP_ORIGIN_UPPER)
                {
                    if (i >= name.Length)
                    {
                        continue;
                    }
                    _Buffer.Append(Char.ToUpper(name[i]));
                    continue;
                }
                if (c == TMP_UPDATE_TIME)
                {
                    _Buffer.Append(File.GetLastWriteTime(filePath).ToString(_FmtList[ti++]));
                    continue;
                }
                if (c == TMP_CREATE_TIME)
                {
                    _Buffer.Append(File.GetCreationTime(filePath).ToString(_FmtList[ti++]));
                    continue;
                }
                if (c == TMP_TRIM)
                {
                    _Buffer.Append(Trim(name, _CutList[ui++]));
                    continue;
                }
                if (c == TMP_HOLD)
                {
                    _Buffer.Append(Hold(name, _CutList[ui++]));
                    continue;
                }
                if (c == NUMBER)
                {
                    _Buffer.Append(_UdnList[ni++].Next());
                    continue;
                }
                if (c == CHARACTER)
                {
                    _Buffer.Append(_UdcList[ci++].Next());
                    continue;
                }
                _Buffer.Append(c);
            }

            string t = _Buffer.ToString();
            Encode();

            return t;
        }

        private string Trim(string txt, Cut cut)
        {
            int s = cut.Start;
            int c = cut.Count;
            if (s > 0)
            {
                s -= 1;
                if (c == 0)
                {
                    c = txt.Length;
                }
                else
                {
                    c = s + c;
                }
            }
            else if (s < 0)
            {
                s += txt.Length + 1;
                if (c != 0)
                {
                    c = s - c;
                }
            }

            if (s > c)
            {
                int t = s;
                s = c;
                c = t;
            }
            if (s >= txt.Length)
            {
                return txt;
            }
            if (c >= txt.Length)
            {
                return txt.Substring(0, s);
            }
            return txt.Substring(0, s) + txt.Substring(c);
        }

        private string Hold(string txt, Cut cut)
        {
            int s = cut.Start;
            int c = cut.Count;
            if (s > 0)
            {
                s -= 1;
                if (c == 0)
                {
                    c = txt.Length;
                }
                else
                {
                    c = s + c;
                }
            }
            else if (s < 0)
            {
                s += txt.Length + 1;
                if (c != 0)
                {
                    c = s - c;
                }
            }

            if (s > c)
            {
                int t = s;
                s = c;
                c = t;
            }
            if (s >= txt.Length)
            {
                return "";
            }
            if (c >= txt.Length)
            {
                return txt.Substring(s);
            }
            return txt.Substring(s, c - s);
        }

        private string Replace(string txt, int idx)
        {
            Rpl rpl = _RplList[idx];
            if (string.IsNullOrEmpty(rpl.Src))
            {
                return txt;
            }
            return txt.Replace(rpl.Src, rpl.Dst);
        }

        private void Encode()
        {
            int cnt = _UdcList.Count - 1;
            if (cnt < 0)
            {
                return;
            }

            Udc udc;
            while (true)
            {
                udc = _UdcList[cnt];
                udc.Index += 1;
                if (udc.Index < udc.Array.Length)
                {
                    break;
                }

                udc.Index = 0;
                cnt -= 1;

                if (cnt < 0)
                {
                    _Enough = false;
                    break;
                }
            }
        }
        #endregion
    }

    class Udc
    {
        public string[] Array { get; set; }
        public int Index { get; set; }

        public string Next()
        {
            return Array[Index];
        }
    }

    class Udn
    {
        public int Start { get; set; }
        public int Step { get; set; }
        public int Fixed { get; set; }
        public char Char { get; set; }

        public string Next()
        {
            string tmp = Start.ToString();
            if (Fixed > 0)
            {
                tmp = tmp.PadLeft(Fixed, Char);
            }
            Start += Step;
            return tmp;
        }
    }

    class Rpl
    {
        public string Src { get; set; }
        public string Dst { get; set; }
    }

    class Cut
    {
        public int Start { get; set; }
        public int Count { get; set; }
    }
}
