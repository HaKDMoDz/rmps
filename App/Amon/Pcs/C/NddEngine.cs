using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Da;
using Me.Amon.Da.Df;
using Me.Amon.Pcs.M;

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

        public void CreateFolder(string path, string name)
        {
            if (path == CPcs.PATH_ALL)
            {
                path = "/";
            }

            path = Path.Combine(_Root, path.Substring(1), name);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void Delete(string path, string name)
        {
            path = Path.Combine(_Root, path, name);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void Moveto(CsMeta meta, string name)
        {
            string src = Path.Combine(_Root, meta.Path, meta.Name);
            if (!File.Exists(src))
            {
                return;
            }
            string dst = Path.Combine(meta.Path, name);
            if (File.Exists(dst))
            {
                dst = GenDupName(meta.Path, name);
            }
            File.Move(src, dst);
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

        private string GenDupName(string path, string name)
        {
            string fn = System.IO.Path.GetFileNameWithoutExtension(name);
            string fe = System.IO.Path.GetExtension(name);
            int i = 0;
            string temp;
            do
            {
                i += 1;
                name = fn + string.Format(" ({0})", i) + fe;
                temp = System.IO.Path.Combine(path, name);
            } while (System.IO.File.Exists(temp));

            return temp;
        }
    }
}
