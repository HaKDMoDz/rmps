using System;
using System.Windows.Forms;

namespace Me.Amon
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Img.AImg());
            Text2File(@"D:\1.txt", @"D:\1.7z");
        }

        private static void File2Text(string inputFile, string outputFile)
        {
            var input = System.IO.File.OpenRead(inputFile);
            var output = new System.IO.StreamWriter(outputFile);

            int off = 0;
            byte[] buf = new byte[1024];
            var builder = new System.Text.StringBuilder();
            int len = input.Read(buf, 0, buf.Length);
            while (len > 0)
            {
                while (off < len)
                {
                    builder.Append(buf[off++].ToString("X2"));
                }
                output.WriteLine(builder.ToString());
                builder.Clear();
                off = 0;

                len = input.Read(buf, 0, buf.Length);
            }

            output.Close();
            input.Close();
        }

        private static void Text2File(string inputFile, string outputFile)
        {
            var input = System.IO.File.OpenText(inputFile);
            var output = System.IO.File.OpenWrite(outputFile);

            bool alt = false;
            byte tmp = 0;
            string line = input.ReadLine();
            while (line != null)
            {
                foreach (char c in line)
                {
                    tmp |= GetByte(c);
                    if (alt)
                    {
                        output.WriteByte(tmp);

                        tmp = 0;
                        alt = false;
                    }
                    else
                    {
                        tmp <<= 4;
                        alt = true;
                    }
                }
                line = input.ReadLine();
            }

            output.Close();
            input.Close();
        }

        private static byte GetByte(char c)
        {
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return 0;
            }
        }
    }
}
