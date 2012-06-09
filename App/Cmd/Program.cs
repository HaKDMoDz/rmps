using System.IO;

namespace Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"F:\App\Amon\bin\Debug\Dat\A0000000\KEY";
            DFile(path);

            foreach (string dir in Directory.GetDirectories(path))
            {
                DFile(dir);
            }
        }

        private static void DFile(string dir)
        {
            foreach (string file in Directory.GetFiles(dir))
            {
                string src = Path.GetFileName(file);
                string dst = Path.GetFileNameWithoutExtension(file);
                MoveTo(dir, src, dst);
            }
        }

        private static void MoveTo(string path, string src, string dst)
        {
            src = path + '\\' + src;
            dst = path + '\\' + dst;
            if (File.Exists(src))
            {
                File.Move(src, dst);
            }
        }
    }
}
