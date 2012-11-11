using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Da;
using Me.Amon.Da.Df;

namespace Me.Amon.Pcs.C
{
    public class NddEngine
    {
        private string _Root;
        private DFA _DFA;
        private Dictionary<long, FileStream> _Streams;

        public NddEngine()
        {
        }

        public void Init(string root)
        {
            _Root = root;
            _DFA = new DFEngine();
            _DFA.Load(Path.Combine(root, "amon.sync"));
            _Streams = new Dictionary<long, FileStream>();
        }

        public int CompareVersion(string file, string ver)
        {
            return _DFA.Get(file, "").CompareTo(ver);
        }

        public void ChangeVergion(string file, string ver)
        {
            _DFA.Set(file, ver);
        }

        public void Moveto(string srcPath, string dstPath)
        {
        }

        #region ÏÂÔØ
        public long BeginDownload(long key, string path, bool append)
        {
            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(_Root, path);
            }

            string folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var stream = new FileStream(path, append ? FileMode.Append : FileMode.Create);
            _Streams[key] = stream;
            return stream.Length;
        }

        public int Write(long key, byte[] buffer, int offset, int length)
        {
            _Streams[key].Write(buffer, offset, length);
            return 0;
        }

        public void EndDownload(long key)
        {
            var stream = _Streams[key];
            if (stream != null)
            {
                stream.Close();
            }
        }
        #endregion

        #region ÉÏ´«
        public bool BeginRead(string file)
        {
            //file = Path.Combine(_Root, file);
            //_Stream = File.OpenRead(file);
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
        #endregion

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
