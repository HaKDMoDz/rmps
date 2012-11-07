using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Da;
using Me.Amon.Da.Df;

namespace Me.Amon.Pcs.C
{
    public class PcEngine
    {
        private DFA _DFA;
        private string _Root;

        public PcEngine()
        {
            _DFA = new DFEngine();
        }

        public void Init(string root)
        {
            _Root = root;
            _DFA.Load(Path.Combine(root, "amon.sync"));
        }

        public int CompareVersion(string file, string ver)
        {
            return _DFA.Get(file, "").CompareTo(ver);
        }

        public void ChangeVergion(string file, string ver)
        {
            _DFA.Set(file, ver);
        }

        public FileStream OpenWrite(string path)
        {
            path = Path.Combine(_Root, path);
            return File.OpenWrite(path);
        }

        public FileStream OpenRead(string file)
        {
            file = Path.Combine(_Root, file);
            return File.OpenRead(file);
        }

        public string ComputeHash(string file)
        {
            FileStream stream = File.OpenRead(file);
            HashAlgorithm alg = HashAlgorithm.Create("MD5");
            byte[] buf = alg.ComputeHash(stream);
            stream.Close();

            StringBuilder builder = new StringBuilder();
            foreach (byte b in buf)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
}
