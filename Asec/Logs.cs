using System.IO;

namespace Msec
{
    public class Logs
    {
        public static void Info(string text)
        {
            StreamWriter writer = new StreamWriter(new FileStream("log.log", FileMode.Append));
            writer.WriteLine(text);
            writer.Flush();
            writer.Close();
        }
    }
}
