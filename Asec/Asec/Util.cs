using System.Windows.Forms;
using System.Text;

namespace Msec
{
    public class Util
    {
        public static void Clear(ComboBox cBox)
        {
            if (cBox.Items.Count < 1)
            {
                return;
            }
            int idx = cBox.SelectedIndex;
            for (int i = cBox.Items.Count - 1; i > 0; i -= 1)
            {
                cBox.Items.RemoveAt(i);
            }
            if (idx != 0)
            {
                cBox.SelectedIndex = 0;
            }
        }

        public static void Clear(ComboBox cBox, Item[] items)
        {
            int idx = cBox.SelectedIndex;
            for (int i = cBox.Items.Count - 1; i > 1; i -= 1)
            {
                cBox.Items.RemoveAt(i);
            }
            cBox.Items.AddRange(items);
            if (idx != 0)
            {
                cBox.SelectedIndex = 0;
            }
        }

        public static string GenPass(string data, int length)
        {
            StringBuilder buf = new StringBuilder();
            for (int i = buf.Length, j = length; i < j; i += 1)
            {
                buf.Append(' ');
            }
            return buf.ToString();
        }
    }
}
