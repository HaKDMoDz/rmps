using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Msec;

namespace Me.Amon.Asec
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main main = new Main();
            main.Init();
            Application.Run(main);
        }
    }
}
