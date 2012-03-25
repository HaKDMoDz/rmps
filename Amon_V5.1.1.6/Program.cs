using System;
using System.IO;
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
            if (!Directory.Exists(IEnv.DIR_DATA))
            {
                Directory.CreateDirectory(IEnv.DIR_DATA);
            }
            if (!Directory.Exists(IEnv.DIR_BACK))
            {
                Directory.CreateDirectory(IEnv.DIR_BACK);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            main.InitOnce();
            Application.Run(main);
        }
    }
}
