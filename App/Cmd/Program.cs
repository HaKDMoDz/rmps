using System;
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
            cc();
        }
        private static void cc()
        {
            BeanUtil.UnZip("F:\\Amon.dat", "F:\\123\\");
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
