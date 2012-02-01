using System.IO;
using System.Text;
namespace Me.Amon
{
    public class Logs
    {
        public static StringBuilder Sb = new StringBuilder();
        public static void Info(string message)
        {
            Sb.Append(message).Append(";\n");
        }
    }
}
