using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Da;
using Me.Amon.Da.Df;

namespace Me.Amon.Pcs.C
{
    public class NddEngine
    {
        private DFA _DFA;
        private string _Root;

        public NddEngine()
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

        private FileStream _Stream;
        public bool BeginWrite(string file)
        {
            file = Path.Combine(_Root, file);
            _Stream = File.OpenWrite(file);
            return true;
        }

        public int Write(byte[] buffer, int offset, int length)
        {
            return 0;
        }

        public bool EndWrite()
        {
            return true;
        }

        public bool BeginRead(string file)
        {
            file = Path.Combine(_Root, file);
            _Stream = File.OpenRead(file);
            return true;
        }

        public int Read(byte[] buffer, int offset, int length)
        {
            return 0;
        }

        public bool EndRead()
        {
            return true;
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
