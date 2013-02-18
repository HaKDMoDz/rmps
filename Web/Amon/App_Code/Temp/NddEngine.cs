using Me.Amon.Http;
using Me.Amon.Open.M;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Me.Amon.Pcs.C
{
    public class NddEngine
    {
        private string _Root;

        public NddEngine()
        {
        }

        public void Init(string root)
        {
            _Root = root;
        }

        public int CompareVersion(string file, string ver)
        {
            return 0;
        }

        public void ChangeVergion(string file, string ver)
        {
        }

        public void CreateFolder(string path, string name)
        {
        }

        public bool Exists(string file)
        {
            return File.Exists(GetPhysicalPath(file));
        }

        public void Delete(string path, string name)
        {
            path = Path.Combine(_Root, path, name);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public void Moveto(AMeta meta, string path, string name)
        {
            string src = Path.Combine(_Root, meta.GetMeta());
            if (!File.Exists(src))
            {
                return;
            }
            string dst = Path.Combine(path, name);
            if (File.Exists(dst))
            {
                dst = GenDupName(meta.GetMetaPath(), name);
            }
            File.Move(src, dst);
        }

        public bool BeginDownload(TaskInfo task)
        {
            if (task == null)
            {
                return false;
            }

            var file = GetPhysicalPath(task.File);
            string folder = Path.GetDirectoryName(file);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (task.IsAppend)
            {
                task.FileSize = new FileInfo(file).Length;
                if (task.FileSize >= task.MetaSize)
                {
                    return false;
                }
                task.FileStream = new FileStream(file, FileMode.Append);
            }
            else
            {
                task.FileStream = new FileStream(file, FileMode.Create);
            }
            return true;
        }

        public bool BeginUpload(TaskInfo task)
        {
            if (!Path.IsPathRooted(task.File))
            {
                task.File = Path.Combine(_Root, task.File);
            }

            if (!File.Exists(task.File))
            {
                return false;
            }

            task.FileStream = File.OpenRead(task.File);
            task.FileSize = task.FileStream.Length;
            task.FileName = Path.GetFileName(task.File);
            if (task.File.StartsWith(_Root))
            {
                task.File = task.File.Substring(_Root.Length);
            }
            else
            {
                task.File = task.FileName;
            }
            return true;
        }

        public string GetFileName(string file)
        {
            return Path.GetFileName(file);
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

        private string GetPhysicalPath(string path)
        {
            if (path[0] == '/')
            {
                path = _Root + path;
            }
            return path;
        }

        private string GetVirtualPath(string path)
        {
            return path.Replace(_Root, "");
        }
    }
}
