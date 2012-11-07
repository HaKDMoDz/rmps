using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Me.Amon.Pcs;
using Me.Amon.Pcs.M;

namespace Me.Amon.Open.PC
{
    public class NativeClient : OAuthPcs
    {
        private NativeServer _Server;

        #region 构造函数
        public NativeClient()
        {
            Name = "本地";
            Root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Icon = Image.FromFile(@"D:\Temp\i1\Icon.png");
            _Server = new NativeServer();
        }
        #endregion

        #region 接口实现
        public string Name
        {
            get;
            set;
        }

        public string Root
        {
            get;
            set;
        }

        public Image Icon
        {
            get;
            set;
        }

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

        public bool BeginWrite(string remoteMeta)
        {
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

        public bool BeginRead(string meta)
        {
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
