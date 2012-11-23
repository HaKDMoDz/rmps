using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using Me.Amon.Pcs;
using Me.Amon.Pcs.M;

namespace Me.Amon.Open.PC
{
    public class NativeClient : PcsClient
    {
        private NativeServer _Server;
        private Dictionary<long, FileStream> _Streams;
        private Random _Random;

        #region 构造函数
        public NativeClient()
        {
            Name = "本地";
            Root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Icon = Image.FromFile(@"D:\Temp\i1\Icon.png");

            _Server = new NativeServer();
            _Streams = new Dictionary<long, FileStream>();
            _Random = new Random();
        }
        #endregion

        #region 接口实现
        public string Root { get; set; }

        public string Name { get; set; }

        public Image Icon { get; set; }

        public OAuthPcsAccount Account()
        {
            return new NativeAccount();
        }

        public string GetPath(string key)
        {
            switch (key)
            {
                case CPcs.PATH_LIB_DOCUMENTS:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                case CPcs.PATH_LIB_AUDIOS:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                case CPcs.PATH_LIB_PICTURES:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                case CPcs.PATH_LIB_VIDEOS:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                case CPcs.PATH_BIN:
                    return @"C:\Recycled";
                default:
                    return key;
            }
        }

        public List<AMeta> ListMeta(AMeta meta)
        {
            return ListMeta(meta.GetMetaPath());
        }

        public List<AMeta> ListMeta(string path)
        {
            List<AMeta> metas = new List<AMeta>();

            if (!Directory.Exists(path))
            {
                return metas;
            }

            NativeMeta temp;
            try
            {
                foreach (string obj in Directory.GetDirectories(path))
                {
                    temp = new NativeMeta();
                    temp.path = obj;
                    temp.type = CPcs.META_TYPE_FOLDER;
                    temp.name = System.IO.Path.GetFileName(obj);
                    temp.createTime = Directory.GetCreationTime(obj);
                    temp.modifyTime = Directory.GetLastWriteTime(obj);
                    metas.Add(temp);
                }
            }
            catch (Exception)
            {
            }

            try
            {
                foreach (string obj in Directory.GetFiles(path))
                {
                    temp = new NativeMeta();
                    temp.path = obj;
                    temp.type = CPcs.META_TYPE_FILE;
                    temp.name = System.IO.Path.GetFileName(obj);
                    temp.createTime = File.GetCreationTime(obj);
                    temp.modifyTime = File.GetLastWriteTime(obj);
                    metas.Add(temp);
                }
            }
            catch (Exception)
            {
            }

            return metas;
        }

        public string ShareMeta(AMeta meta)
        {
            return "";
        }

        public List<AMeta> History(AMeta meta)
        {
            return null;
        }

        public AMeta CreateFolder(string path, string name)
        {
            return null;
        }

        public bool Delete(string path, string meta)
        {
            File.Delete(Combine(path, meta));
            return true;
        }

        public AMeta Moveto(AMeta meta, string dstPath, string dstName)
        {
            string path = System.IO.Path.Combine(dstPath, dstName);
            if (System.IO.File.Exists(path))
            {
                path = GenDupName(meta, dstPath);
            }
            File.Move(meta.GetMetaPath(), path);
            meta.SetMetaPath(path);
            return meta;
        }

        private string GenDupName(AMeta meta, string path)
        {
            string fn = System.IO.Path.GetFileNameWithoutExtension(meta.GetMetaName());
            string fe = System.IO.Path.GetExtension(meta.GetMetaName());
            int i = 0;
            string name;
            string temp;
            do
            {
                i += 1;
                name = fn + string.Format(" ({0})", i) + fe;
                temp = System.IO.Path.Combine(path, name);
            } while (System.IO.File.Exists(temp));

            meta.SetMetaName(name);
            return temp;
        }

        public AMeta Copyto(AMeta meta, string dstPath, string dstName)
        {
            File.Copy(meta.GetMetaPath(), Path.Combine(dstPath, dstName));
            return meta;
        }

        public AMeta Copyto(string metaRef, string dstPath, string dstName)
        {
            return null;
        }

        public AMetaRef CopyRef(AMeta meta)
        {
            return null;
        }

        #region 上传
        public bool BeginUpload(long key, string url)
        {
            if (!Path.IsPathRooted(url))
            {
                url = Path.Combine(Root, url);
            }

            string folder = Path.GetDirectoryName(url);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            var stream = File.OpenWrite(url);
            try
            {
                Monitor.Enter(_Streams);
                _Streams[key] = stream;
            }
            finally
            {
                Monitor.Exit(_Streams);
            }
            return true;
        }

        public void Write(long key, byte[] buffer, int offset, int length)
        {
            Thread.Sleep(_Random.Next(10) * 100 + 100);
            _Streams[key].Write(buffer, offset, length);
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

        #region 下载
        public long BeginDownload(long key, string url, long range)
        {
            if (!Path.IsPathRooted(url))
            {
                url = Path.Combine(Root, url);
            }
            if (!File.Exists(url))
            {
                return -1;
            }

            var stream = File.OpenRead(url);
            if (range < 0 || range > stream.Length)
            {
                return -1;
            }

            if (range > 0)
            {
                stream.Seek(range, SeekOrigin.Current);
            }
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
            Thread.Sleep(_Random.Next(10) * 100 + 100);
            return _Streams[key].Read(buffer, offset, length);
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

        public void Thumbnail()
        {
        }

        public string Parent(string path)
        {
            return System.IO.Path.GetDirectoryName(path);
        }

        public string Combine(string path, string meta)
        {
            return System.IO.Path.Combine(path, meta);
        }

        public string Display(string path)
        {
            return "file:///" + path.Replace(Path.DirectorySeparatorChar, '/');
        }
        #endregion
    }
}
