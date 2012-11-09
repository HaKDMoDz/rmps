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
                case CPcs.PATH_DOCUMENTS:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                case CPcs.PATH_AUDIOS:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                case CPcs.PATH_PICTURES:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                case CPcs.PATH_VIDEOS:
                    return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                case CPcs.PATH_RECYCLE:
                    return @"C:\Recycled";
                default:
                    return key;
            }
        }

        public List<CsMeta> ListMeta(CsMeta meta)
        {
            return ListMeta(meta.Path);
        }

        public List<CsMeta> ListMeta(string path)
        {
            List<CsMeta> metas = new List<CsMeta>();

            if (!Directory.Exists(path))
            {
                return metas;
            }

            CsMeta temp;
            try
            {
                foreach (string obj in Directory.GetDirectories(path))
                {
                    temp = new NativeMeta();
                    temp.Path = obj;
                    temp.Type = CPcs.META_TYPE_FOLDER;
                    temp.Name = System.IO.Path.GetFileName(obj);
                    temp.CreateTime = Directory.GetCreationTime(obj);
                    temp.ModifyTime = Directory.GetLastWriteTime(obj);
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
                    temp.Path = obj;
                    temp.Type = CPcs.META_TYPE_FILE;
                    temp.Name = System.IO.Path.GetFileName(obj);
                    temp.CreateTime = File.GetCreationTime(obj);
                    temp.ModifyTime = File.GetLastWriteTime(obj);
                    metas.Add(temp);
                }
            }
            catch (Exception)
            {
            }

            return metas;
        }

        public string ShareMeta(CsMeta meta)
        {
            return "";
        }

        public List<CsMeta> History(CsMeta meta)
        {
            return null;
        }

        public bool CreateFolder(CsMeta meta)
        {
            return true;
        }

        public bool Delete(string meta)
        {
            File.Delete(meta);
            return true;
        }

        public bool Moveto(CsMeta meta, string dstPath)
        {
            string path = System.IO.Path.Combine(dstPath, meta.Name);
            if (System.IO.File.Exists(path))
            {
                path = GenDupName(meta, dstPath);
            }
            File.Move(meta.Path, path);
            meta.Path = path;
            return true;
        }

        private string GenDupName(CsMeta meta, string path)
        {
            string fn = System.IO.Path.GetFileNameWithoutExtension(meta.Name);
            string fe = System.IO.Path.GetExtension(meta.Name);
            int i = 0;
            string name;
            string temp;
            do
            {
                i += 1;
                name = fn + string.Format(" ({0})", i) + fe;
                temp = System.IO.Path.Combine(path, name);
            } while (System.IO.File.Exists(temp));

            meta.Name = name;
            return temp;
        }

        public bool Copyto(CsMeta meta, string dstPath)
        {
            File.Copy(meta.Path, dstPath);
            return true;
        }

        public void CopyRef(CsMeta meta)
        {
        }

        #region 上传
        public long BeginWrite(long key, string remoteMeta)
        {
            return 0;
        }

        public int Write(long key, byte[] buffer, int offset, int length)
        {
            return 0;
        }

        public void EndWrite(long key)
        {
        }
        #endregion

        #region 下载
        public long BeginRead(long key, string url, long range)
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
            _Streams[key] = stream;
            return stream.Length;
        }

        public int Read(long key, byte[] buffer, int offset, int length)
        {
            Thread.Sleep(_Random.Next(10) * 100 + 100);
            return _Streams[key].Read(buffer, offset, length);
        }

        public void EndRead(long key)
        {
            var stream = _Streams[key];
            if (stream != null)
            {
                stream.Close();
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
