using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Me.Amon.Http;
using Me.Amon.Pcs;
using Me.Amon.Pcs.M;

namespace Me.Amon.Open.PC
{
    public class NativeClient : PcsClient
    {
        private NativeServer _Server;

        #region 构造函数
        public NativeClient()
        {
            Name = "本地";
            Root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //Icon = Image.FromFile(@"D:\Temp\i1\Icon.png");

            _Server = new NativeServer();
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

        public AMeta MetaData(string path)
        {
            return null;
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

        //public bool BeginUpload(TaskInfo info)
        //{
        //    if (!Path.IsPathRooted(info.FilePath))
        //    {
        //        info.FilePath = Path.Combine(Root, info.FilePath);
        //    }

        //    string folder = Path.GetDirectoryName(info.FilePath);
        //    if (!Directory.Exists(folder))
        //    {
        //        Directory.CreateDirectory(folder);
        //    }
        //    info.MetaStream = File.OpenWrite(info.FilePath);
        //    return true;
        //}

        //public bool BeginDownload(TaskInfo info)
        //{
        //    if (!Path.IsPathRooted(info.FilePath))
        //    {
        //        info.FilePath = Path.Combine(Root, info.FilePath);
        //    }
        //    if (!File.Exists(info.FilePath))
        //    {
        //        return false;
        //    }

        //    var stream = File.OpenRead(info.FilePath);
        //    var length = info.FileStream.Length;
        //    if (length > stream.Length)
        //    {
        //        return false;
        //    }

        //    if (length > 0)
        //    {
        //        stream.Seek(length, SeekOrigin.Current);
        //    }
        //    info.MetaStream = stream;
        //    return true;
        //}

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

        public string GetFileName(string meta)
        {
            return System.IO.Path.GetFileName(meta);
        }

        public string Display(string path)
        {
            return "file:///" + path.Replace(Path.DirectorySeparatorChar, '/');
        }
        #endregion

        public TaskInfo NewDownloadTask()
        {
            return null;
        }

        public TaskInfo BeginDownload()
        {
            return null;
        }

        public TaskInfo NewUploadTask()
        {
            return null;
        }

        public TaskInfo BeginUpload()
        {
            return null;
        }
    }
}
