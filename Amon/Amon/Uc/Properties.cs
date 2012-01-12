using System.Collections.Generic;
using System.IO;

namespace Me.Amon.Uc
{
    public class Properties
    {
        private List<string> keys = new List<string>();
        private Dictionary<string, Item> dict = new Dictionary<string, Item>();

        /// <summary>
        /// 重写Add方法,实现按添加顺序排列
        /// </summary>
        /// <param name="key">key</param>
        ///<param name="value">value</param>
        /// <returns></returns>
        public void Set(string key, string value)
        {
            if (key != null)
            {
                dict[key] = new Item { V = value };
                keys.Add(key);
            }
        }

        public void Set(string key, string value, string comment)
        {
            if (key != null)
            {
                dict[key] = new Item { V = value, D = comment };
                keys.Add(key);
            }
        }

        public string Get(string key)
        {
            if (key == null)
            {
                return null;
            }
            return dict.ContainsKey(key) ? dict[key].V : null;
        }

        public string Get(string key, string def)
        {
            if (key == null)
            {
                return def;
            }
            return dict.ContainsKey(key) ? dict[key].V : def;
        }

        public List<string> Keys
        {
            get
            {
                return keys;
            }
        }

        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
            {
                return;
            }
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                bool multiLine = false;
                bool isComment = false;
                Item item = new Item { V = "", D = "" };
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (line.StartsWith("#"))
                    {
                        item.D += line;
                        isComment = true;
                        continue;
                    }

                    if (multiLine)
                    {
                        if (isComment)
                        {
                            item.D += line;
                        }
                        else
                        {
                            item.V += line;
                        }

                        multiLine = line.EndsWith("\\");
                        continue;
                    }

                    int idx = line.IndexOf('=');
                    if (idx > 1)
                    {
                        item.K = line.Substring(0, idx);
                        item.V = line.Substring(idx + 1);
                    }
                    dict[item.K] = item;

                    item = new Item { V = "", D = "" };
                    isComment = false;
                    multiLine = line.EndsWith("\\");
                }
            }
        }

        /// <summary>
        /// 导入文件
        /// </summary>
        /// <param name="filePath">要导入的文件</param>
        /// <returns></returns>
        //public void Load(string filePath)
        //{
        //    int limit;
        //    int keyLen;
        //    int valueStart;
        //    char c;
        //    string line;
        //    bool hasSep;
        //    bool precedingBackslash;

        //    using (StreamReader sr = new StreamReader(filePath))
        //    {
        //        while (sr.Peek() >= 0)
        //        {
        //            line = sr.ReadLine();
        //            limit = line.Length;
        //            valueStart = limit;
        //            hasSep = false;

        //            precedingBackslash = false;
        //            keyLen = line.StartsWith("#") ? line.Length : 0;

        //            while (keyLen < limit)
        //            {
        //                c = line[keyLen];
        //                if (!precedingBackslash && (c == '=' || c == ':'))
        //                {
        //                    valueStart = keyLen + 1;
        //                    hasSep = true;
        //                    break;
        //                }
        //                if (!precedingBackslash && (c == ' ' || c == '\t' || c == '\f'))
        //                {
        //                    valueStart = keyLen + 1;
        //                    break;
        //                }
        //                if (c == '\\')
        //                {
        //                    precedingBackslash = !precedingBackslash;
        //                }
        //                else
        //                {
        //                    precedingBackslash = false;
        //                }
        //                keyLen++;
        //            }

        //            while (valueStart < limit)
        //            {
        //                c = line[valueStart];
        //                if (c != ' ' && c != '\t' && c != '\f')
        //                {
        //                    if (!hasSep && (c == '=' || c == ':'))
        //                    {
        //                        hasSep = true;
        //                    }
        //                    else
        //                    {
        //                        break;
        //                    }
        //                }
        //                valueStart++;
        //            }

        //            string key = line.Substring(0, keyLen);

        //            string values = line.Substring(valueStart, limit - valueStart);

        //            if (key == "")
        //                key += "#";
        //            while (key.StartsWith("#") & dict.ContainsKey(key))
        //            {
        //                key += "#";
        //            }

        //            Set(key, values);
        //        }
        //    }
        //}

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filePath">要保存的Properties文件</param>
        /// <returns></returns>
        public void Save(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.CreateText(filePath);
            }
            StreamWriter writer = new StreamWriter(filePath, false);
            foreach (string key in keys)
            {
                Item item = dict[key];
                writer.WriteLine("#" + item.D);
                writer.WriteLine(key + "=" + item.V);
            }
            writer.Flush();
            writer.Close();
        }
    }
}
