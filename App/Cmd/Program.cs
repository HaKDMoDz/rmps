using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Me.Amon.Util;

namespace Cmd
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Path.Combine(@"F:\App\Cmd\bin\Debug", "Cmd.pdb"));
            Console.ReadLine();
        }
        private static void cc()
        {
            string path = @"F:\Dat\KEY\";
            foreach (string file in Directory.GetFiles(path, "*.24"))
            {
                Stream stream = File.OpenRead(file);
                Image img = Image.FromStream(stream);
                stream.Close();

                img = BeanUtil.ScaleImage(img, 16, true);
                img.Save(path + Path.GetFileNameWithoutExtension(file) + ".16", ImageFormat.Png);
            }
        }

        public static void dd()
        {
            string text = File.ReadAllText("D:\\a.txt");
            byte[] b = Convert.FromBase64String(text);

            using (AesManaged rDel = new AesManaged())
            {
                rDel.Key = Encoding.Default.GetBytes("123                             ");
                rDel.IV = Encoding.Default.GetBytes("asd             ");

                ICryptoTransform cTransform = rDel.CreateDecryptor();

                b = cTransform.TransformFinalBlock(b, 0, b.Length);
                File.WriteAllBytes("D:\\b.7z", b);
            }
        }
    }
}
