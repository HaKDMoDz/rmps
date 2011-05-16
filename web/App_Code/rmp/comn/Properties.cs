using System.Collections.Generic;
using System.IO;
using rmp.bean;

namespace rmp.comn
{
    public class Properties
    {
        private Dictionary<string, K1V1> _properties;

        public void Set(string key, string value)
        {
            Set(key, value, "");
        }

        public void Set(string key, string value, string comment)
        {
            if (string.IsNullOrEmpty(key) || key.IndexOf('=') > -1)
            {
                return;
            }
            _properties[key] = new K1V1 { K = value, V = comment };
        }

        public string Get(string key)
        {
            return Get(key, null);
        }

        public string Get(string key, string def)
        {
            if (string.IsNullOrEmpty(key))
            {
                return def;
            }
            return _properties.ContainsKey(key) ? _properties[key].K : def;
        }

        public void Load(string filePath)
        {
            if (_properties == null)
            {
                _properties = new Dictionary<string, K1V1>();
            }
            else
            {
                _properties.Clear();
            }

            if (!File.Exists(filePath))
            {
                return;
            }

            var item = new K1V1();
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var c = line[0];
                if (c == ';' || c == '#' || c == '\'')
                {
                    item.V = line.Substring(1);
                    continue;
                }

                var i = line.IndexOf('=');
                if (i < 1)
                {
                    continue;
                }

                var key = line.Substring(0, i).Trim();
                var value = line.Substring(i + 1).Trim();

                if ((value.StartsWith("\"") && value.EndsWith("\"")) || (value.StartsWith("'") && value.EndsWith("'")))
                {
                    value = value.Substring(1, value.Length - 2);
                }
                item.K = value;

                _properties[key] = item;
                item = new K1V1();
            }
        }

        public void Save(string filePath)
        {
            var lines = new string[_properties.Count << 1];
            var i = 0;
            foreach (var key in _properties.Keys)
            {
                lines[i++] = '#' + _properties[key].V;
                lines[i++] = key + '=' + _properties[key].K;
            }
            File.WriteAllLines(filePath, lines);
        }
    }
}
