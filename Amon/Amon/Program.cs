using System;
using System.Windows.Forms;
using System.IO;

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
            if (!Directory.Exists("dat\\"))
            {
                Directory.CreateDirectory("dat\\");
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }
    }
}
