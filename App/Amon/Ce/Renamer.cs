using System;
using System.IO;
using System.Text;

namespace Me.Amon.Ce
{
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
        private const char TMP_FILE_NAME_LOWER = '\u0001';
        private const char TMP_FILE_NAME_UPPER = '\u0002';
        private const char TMP_FILE_EXT_LOWER = '\u0003';
        private const char TMP_FILE_EXT_UPPER = '\u0004';
        private const char TMP_ORIGIN_LOWER = '\u0005';
        private const char TMP_ORIGIN_UPPER = '\u0006';
        private const char TMP_CREATE_TIME = '\u0007';
        private const char TMP_UPDATE_TIME = '\u0008';
        #endregion

        private char[][] _UdcArray;
        private int[] _KeyArray;
        private StringBuilder _Buffer;
        private string _Command;
        private bool _Enough;

        public Renamer()
        {
            _Buffer = new StringBuilder();
        }

        public bool Init(string cmd)
        {
            _Enough = false;

            // 公式解析
            int cnt = 0;
            bool isU = false;//是否大写
            bool isL = false;//是否小写
            bool isE = false;//是否枚举
            foreach (char c in cmd)
            {
                #region 大写控制处理
                if (isU)
                {
                    isU = false;
                    if (c == FILE_NAME)
                    {
                        _Buffer.Append(TMP_FILE_NAME_UPPER);
                        continue;
                    }
                    if (c == FILE_EXT)
                    {
                        _Buffer.Append(TMP_FILE_EXT_UPPER);
                        continue;
                    }
                    if (c == ORIGIN)
                    {
                        _Buffer.Append(TMP_ORIGIN_UPPER);
                        continue;
                    }
                    if (c == NUMBER)
                    {
                        _Buffer.Append(TMP_CREATE_TIME);
                        continue;
                    }
                    return false;
                }
                #endregion

                #region 小写控制处理
                if (isL)
                {
                    isL = false;
                    if (c == FILE_NAME)
                    {
                        _Buffer.Append(TMP_FILE_NAME_LOWER);
                        continue;
                    }
                    if (c == FILE_EXT)
                    {
                        _Buffer.Append(TMP_FILE_EXT_LOWER);
                        continue;
                    }
                    if (c == ORIGIN)
                    {
                        _Buffer.Append(TMP_ORIGIN_LOWER);
                        continue;
                    }
                    if (c == NUMBER)
                    {
                        _Buffer.Append(TMP_UPDATE_TIME);
                        continue;
                    }
                    return false;
                }
                #endregion

                #region 大小写判断
                if (c == CTL_LOWER)
                {
                    isL = true;
                    continue;
                }
                if (c == CTL_UPPER)
                {
                    isU = true;
                    continue;
                }
                #endregion

                #region 枚举处理
                if (isE)
                {
                    if (c == CHARACTER || c == NUMBER || c == FILE_NAME || c == FILE_EXT || c == CTL_LOWER || c == CTL_UPPER || c == ORIGIN)
                    {
                        return false;
                    }
                    if (c == ENUM_END)
                    {
                        isE = false;
                    }
                    _Buffer.Append(c);
                    continue;
                }
                #endregion

                #region 枚举判断
                if (c == ENUM_START)
                {
                    isE = true;
                    _Buffer.Append(c);
                    continue;
                }
                if (c == ENUM_END)
                {
                    return false;
                }
                #endregion

                if (c == CHARACTER || c == NUMBER)
                {
                    cnt += 1;
                }
                _Buffer.Append(c);
            }
            cmd = _Buffer.ToString();
            _Buffer.Clear();

            _UdcArray = new char[cnt][];
            _KeyArray = new int[cnt];
            cnt = 0;
            bool isC = false;// 是否为字符
            bool isN = false;// 是否为数值
            StringBuilder buf = new StringBuilder();
            foreach (char c in cmd)
            {
                #region 字符处理
                if (isC)
                {
                    if (c == ENUM_START)
                    {
                        isE = true;
                        continue;
                    }
                    if (c == ENUM_END)
                    {
                        if (buf.Length < 1)
                        {
                            return false;
                        }
                        isE = false;
                        isC = false;
                        _UdcArray[cnt] = new char[buf.Length];
                        buf.CopyTo(0, _UdcArray[cnt], 0, buf.Length);
                        buf.Clear();
                        _KeyArray[cnt++] = 0;
                        continue;
                    }
                    if (isE)
                    {
                        buf.Append(c);
                        continue;
                    }
                    _UdcArray[cnt++] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
                    _Buffer.Append(c);

                    if (c == CHARACTER)
                    {
                        isC = true;
                        continue;
                    }
                    isC = false;

                    if (c == NUMBER)
                    {
                        isN = true;
                        continue;
                    }
                    continue;
                }
                #endregion

                #region 数字处理
                if (isN)
                {
                    if (c == ENUM_START)
                    {
                        isE = true;
                        continue;
                    }
                    if (c == ENUM_END)
                    {
                        if (buf.Length < 1)
                        {
                            return false;
                        }
                        isE = false;
                        isN = false;
                        _UdcArray[cnt] = new char[buf.Length];
                        buf.CopyTo(0, _UdcArray[cnt], 0, buf.Length);
                        buf.Clear();
                        _KeyArray[cnt++] = 0;
                        continue;
                    }
                    if (isE)
                    {
                        buf.Append(c);
                        continue;
                    }
                    _UdcArray[cnt++] = "0123456789".ToCharArray();
                    _Buffer.Append(c);

                    if (c == NUMBER)
                    {
                        isN = true;
                        continue;
                    }
                    isN = false;

                    if (c == CHARACTER)
                    {
                        isC = true;
                        continue;
                    }
                    continue;
                }
                #endregion

                if (c == CHARACTER)
                {
                    _Buffer.Append(c);
                    isC = true;
                    continue;
                }
                if (c == NUMBER)
                {
                    _Buffer.Append(c);
                    isN = true;
                    continue;
                }

                _Buffer.Append(c);
            }

            _Command = _Buffer.ToString();
            _Buffer.Clear();
            _Enough = true;
            return true;
        }

        public bool Init(string cmd, char[][] arr)
        {
            _Enough = false;
            if (string.IsNullOrEmpty(cmd))
            {
                return false;
            }

            // 公式解析
            int cnt = 0;
            foreach (char c in cmd)
            {
                if (c == CHARACTER || c == NUMBER)
                {
                    cnt += 1;
                }
                if (c == ENUM_START || c == ENUM_END)
                {
                    return false;
                }
            }
            if (cnt != 0)
            {
                if (arr == null || cnt != arr.Length)
                {
                    return false;
                }
                foreach (char[] c in arr)
                {
                    if (c == null || c.Length < 1)
                    {
                        return false;
                    }
                }
            }

            _Command = cmd;
            _UdcArray = arr;
            _KeyArray = new int[cnt];
            _Enough = true;
            return true;
        }

        /// <summary>
        /// \/:*?"<b>|
        /// : 数字
        /// | 字母
        /// <b> 区间
        /// * 文件名
        /// ? 后缀名
        /// " 原有字符
        /// \ 大写 \*大写文件名 \?大写后缀名 \"大写字母 \:创建时间
        /// / 小写 /*小写文件名 /?小写后缀名 /"小写字母 /:修改时间
        /// </summary>
        public string Update(string path, string file)
        {
            if (!_Enough)
            {
                return "长度不足";
            }

            string name = Path.GetFileNameWithoutExtension(file);
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }

            string tmp;
            for (int i = 0; i < _Command.Length; i += 1)
            {
                char c = _Command[i];
                if (c == FILE_NAME)
                {
                    _Buffer.Append(name);
                    continue;
                }
                if (c == TMP_FILE_NAME_LOWER)
                {
                    _Buffer.Append(name.ToLower());
                    continue;
                }
                if (c == TMP_FILE_NAME_UPPER)
                {
                    _Buffer.Append(name.ToUpper());
                    continue;
                }
                if (c == FILE_EXT)
                {
                    tmp = Path.GetExtension(file);
                    if (string.IsNullOrEmpty(tmp))
                    {
                        continue;
                    }
                    tmp = tmp.Substring(1);
                    _Buffer.Append(tmp);
                    continue;
                }
                if (c == TMP_FILE_EXT_LOWER)
                {
                    tmp = Path.GetExtension(file);
                    if (string.IsNullOrEmpty(tmp))
                    {
                        continue;
                    }
                    tmp = tmp.Substring(1);
                    _Buffer.Append(tmp.ToLower());
                    continue;
                }
                if (c == TMP_FILE_EXT_UPPER)
                {
                    tmp = Path.GetExtension(file);
                    if (string.IsNullOrEmpty(tmp))
                    {
                        continue;
                    }
                    tmp = tmp.Substring(1);
                    _Buffer.Append(tmp.ToUpper());
                    continue;
                }
                if (c == ORIGIN)
                {
                    if (i >= name.Length)
                    {
                        continue;
                    }
                    _Buffer.Append(name[i]);
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
                    _Buffer.Append(Char.ToLower(name[i]));
                    continue;
                }
                if (c == NUMBER)
                {
                    _Buffer.Append(c);
                    continue;
                }
                if (c == TMP_UPDATE_TIME)
                {
                    _Buffer.Append(File.GetLastWriteTime(Path.Combine(path, file)).ToString("yyyyMMddHHmmss"));
                    continue;
                }
                if (c == TMP_CREATE_TIME)
                {
                    _Buffer.Append(File.GetCreationTime(Path.Combine(path, file)).ToString("yyyyMMddHHmmss"));
                    continue;
                }
                if (c == CHARACTER)
                {
                    _Buffer.Append(c);
                    continue;
                }
                _Buffer.Append(c);
            }

            string t = _KeyArray.Length > 0 ? dd(_Buffer) : _Buffer.ToString();
            _Buffer.Clear();
            return t;
        }

        private string dd(StringBuilder buffer)
        {
            char[] arr = new char[buffer.Length];
            buffer.CopyTo(0, arr, 0, arr.Length);
            buffer.Clear();

            int cnt = 0;
            for (int i = 0; i < arr.Length; i += 1)
            {
                if (arr[i] == CHARACTER || arr[i] == NUMBER)
                {
                    arr[i] = _UdcArray[cnt][_KeyArray[cnt]];
                    cnt += 1;
                }
            }

            // 递增处理
            cnt = _UdcArray.Length - 1;
            while (true)
            {
                _KeyArray[cnt] += 1;
                if (_KeyArray[cnt] < _UdcArray[cnt].Length)
                {
                    break;
                }

                _KeyArray[cnt] = 0;
                cnt -= 1;

                if (cnt < 0)
                {
                    _Enough = false;
                    break;
                }
            }

            return new string(arr);
        }
    }
}
