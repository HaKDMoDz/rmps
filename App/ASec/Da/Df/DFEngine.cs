using System.Collections.Generic;
using System.IO;
using Me.Amon.Uc;

namespace Me.Amon.Da.Df
{
    /// <summary>
    /// 文件
    /// </summary>
    public class DFEngine : DFA
    {
        private List<string> keys = new List<string>();
        private Dictionary<string, Items> dict = new Dictionary<string, Items>();

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
                if (dict.ContainsKey(key))
                {
                    dict[key].V = value;
                }
                else
                {
                    dict[key] = new Items { V = value };
                    keys.Add(key);
                }
            }
        }

        public void Set(string key, string value, string comment)
        {
            if (key != null)
            {
                if (dict.ContainsKey(key))
                {
                    Items item = dict[key];
                    item.V = value;
                    item.D = comment;
                }
                else
                {
                    dict[key] = new Items { V = value, D = comment };
                    keys.Add(key);
                }
            }
        }

        public string Get(string key)
        {
            return Get(key, null);
        }

        public string Get(string key, string def)
        {
            if (key == null)
            {
                return def;
            }
            return dict.ContainsKey(key) ? dict[key].V : def;
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
                Items item = new Items { V = "", D = "" };
                while (true)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }
                    if (string.IsNullOrEmpty(line))
                    {
                        continue;
                    }

                    line = line.Replace("\\r", "\r").Replace("\\n", "\n").Replace("\\t", "\t");

                    if (line.StartsWith("#"))
                    {
                        item.D += line.Substring(1);
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

                        multiLine = line.EndsWith("  \\");
                        continue;
                    }

                    int idx = line.IndexOf('=');
                    if (idx > 0)
                    {
                        item.K = line.Substring(0, idx);
                        item.V = line.Substring(idx + 1);
                    }
                    dict[item.K] = item;
                    keys.Add(item.K);

                    item = new Items { V = "", D = "" };
                    isComment = false;
                }
                reader.Close();
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="filePath">要保存的Properties文件</param>
        /// <returns></returns>
        public void Save(string filePath)
        {
            using (StreamWriter writer = File.Exists(filePath) ? new StreamWriter(filePath, false) : File.CreateText(filePath))
            {
                foreach (string key in keys)
                {
                    Items item = dict[key];
                    if (!string.IsNullOrEmpty(item.D))
                    {
                        writer.WriteLine("#" + item.D);
                    }
                    if (item.V != null)
                    {
                        writer.WriteLine(key + "=" + item.V.Replace("\t", "\\t").Replace("\n", "\\n").Replace("\r", "\\r"));
                    }
                    else
                    {
                        writer.WriteLine(key + "=");
                    }
                }
                writer.Flush();
                writer.Close();
            }
        }

        public void Clear()
        {
            keys.Clear();
            dict.Clear();
        }

        public List<string> Keys
        {
            get
            {
                return keys;
            }
        }
    }
}
