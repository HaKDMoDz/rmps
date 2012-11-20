using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

        public void Moveto(AMeta meta, string name)
        {
            string src = Path.Combine(_Root, meta.GetMetaPath(), meta.GetMetaName());
            if (!File.Exists(src))
            {
                return;
            }
            string dst = Path.Combine(meta.GetMetaPath(), name);
            if (File.Exists(dst))
            {
                dst = GenDupName(meta.GetMetaPath(), name);
            }
            File.Move(src, dst);
        }

        #region ÏÂÔØ
        public long BeginDownload(long key, string path, bool append)
        {
            if (path[0] == '/')
            {
                path = path.Substring(1);
            }
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
            try
            {
                Monitor.Enter(_Streams);
                _Streams[key] = stream;
            }
            finally
            {
                Monitor.Exit(_Streams);
            }
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
                try
                {
                    Monitor.Enter(_Streams);
                    stream.Close();
                    _Streams.Remove(key);
                }
                finally
                {
                    Monitor.Exit(_Streams);
                }
            }
        }
        #endregion

        #region ÉÏ´«
        public long BeginUpload(long key, string path)
        {
            if (!Path.IsPathRooted(path))
            {
                path = Path.Combine(_Root, path);
            }

            if (!File.Exists(path))
            {
                return -1;
            }

            var stream = File.OpenRead(path);
            try
            {
                Monitor.Enter(_Streams);
                _Streams[key] = stream;
            }
            finally
            {
                Monitor.Exit(_Streams);
            }
            return stream.Length;
        }

        public int Read(long key, byte[] buffer, int offset, int length)
        {
            return _Streams[key].Read(buffer, offset, length);
        }

        public void EndUpload(long key)
        {
            var stream = _Streams[key];
            if (stream != null)
            {
                try
                {
                    Monitor.Enter(_Streams);
                    stream.Close();
                    _Streams.Remove(key);
                }
                finally
                {
                    Monitor.Exit(_Streams);
                }
            }
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
