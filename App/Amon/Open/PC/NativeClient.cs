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
        public NativeClient()
        {
            Path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public Image Icon
        {
            get;
            set;
        }

        public string Path
        {
            get;
            set;
        }

        public List<CsMeta> ListMeta(CsMeta meta)
        {
            List<CsMeta> metas = new List<CsMeta>();
            if (!Directory.Exists(meta.Path))
            {
                return metas;
            }

            CsMeta temp;
            foreach (string obj in Directory.GetDirectories(meta.Path))
            {
                temp = new CsMeta();
                temp.Path = obj;
                temp.Type = CPcs.META_TYPE_FOLDER;
                temp.Name = System.IO.Path.GetFileName(obj);
                temp.CreateTime = Directory.GetCreationTime(obj);
                temp.ModifyTime = Directory.GetLastWriteTime(obj);
                metas.Add(temp);
            }

            foreach (string obj in Directory.GetFiles(meta.Path))
            {
                temp = new CsMeta();
                temp.Path = obj;
                temp.Type = CPcs.META_TYPE_FILE;
                temp.Name = System.IO.Path.GetFileName(obj);
                temp.CreateTime = File.GetCreationTime(obj);
                temp.ModifyTime = File.GetLastWriteTime(obj);
                metas.Add(temp);
            }

            Path = meta.Path;
            return metas;
        }

        public List<CsMeta> ListMeta(string key)
        {
            //switch (key)
            //{
            //    case NativeServer.PATH_DOCUMENTS:
            //        return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //    case NativeServer.PATH_AUDIOS:
            //        return Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            //    case NativeServer.PATH_PICTURES:
            //        return Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            //    case NativeServer.PATH_VIDEOS:
            //        return Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            //    default:
            //        return "";
            //}
            return null;
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

        public bool Moveto(string srcMeta, string dstMeta)
        {
            string name = System.IO.Path.GetFileName(srcMeta);
            string path = System.IO.Path.Combine(dstMeta, name);
            if (System.IO.File.Exists(path))
            {
                path = GenDupName(dstMeta, name);
            }
            File.Move(srcMeta, path);
            return true;
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
                temp = System.IO.Path.Combine(path, fn + string.Format(" ({0})", i) + fe);
            } while (System.IO.File.Exists(temp));
            return temp;
        }

        public bool Copyto(string srcMeta, string dstMeta)
        {
            File.Copy(srcMeta, dstMeta);
            return true;
        }

        public void CopyRef(CsMeta meta)
        {
        }

        public void Upload(string nativeFile, string remotePath)
        {
        }

        public void Download(string remoteMeta, string nativePath)
        {
            if (!File.Exists(remoteMeta))
            {
                return;
            }
            if (!Directory.Exists(nativePath))
            {
                Directory.CreateDirectory(nativePath);
            }
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
    }
}
